using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace DAL.Fake.Repositories
{
    public class AccountRepository : IRepository<DalAccount>
    {
        #region Constructors

        public AccountRepository()
        {
            Accounts = new List<DalAccount>();
        }

        public AccountRepository(IEnumerable<DalAccount> accounts)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException($"{nameof(accounts)} cannot be null.");
            }

            Accounts = new List<DalAccount>(accounts);
        }

        #endregion

        #region Property

        public List<DalAccount> Accounts { get; set; }

        #endregion

        #region IRepository implementation

        public IEnumerable<DalAccount> GetAll()
        {
            return Accounts;
        }

        public void Create(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            this.Accounts.Add(account);
        }

        public void Delete(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            this.Accounts.Remove(account);
        }

        public void Update(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            var resAcc = Accounts.SingleOrDefault(x => x.AccountNumber == account.AccountNumber);

            if (resAcc == null)
            {
                throw new InvalidOperationException($"{account} not found.");
            }

            resAcc.Balance = account.Balance;
            resAcc.BonusPoints = account.BonusPoints;
            resAcc.Type = account.Type;
        }

        public DalAccount GetByNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException($"{nameof(number)} cannot be null or empty.");
            }

            var result = Accounts.SingleOrDefault(x => x.AccountNumber == number);

            if (result == null)
            {
                throw new InvalidOperationException($"{number} not found.");
            }

            return result;
        }

        #endregion
    }
}
