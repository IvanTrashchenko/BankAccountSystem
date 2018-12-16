using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using ORM.Mappers;

namespace DAL.Repositories
{
    public class DbAccountRepository : IRepository<DalAccount>
    {
        #region IRepository implementation

        public IEnumerable<DalAccount> GetAll()
        {
            using (var context = new AccountEntities())
            {
                foreach (var i in context.Accounts)
                {
                    yield return i.ToDalAccount();
                }
            }
        }

        public void Create(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                context.Accounts.Add(account.ToDbAccount());
                context.SaveChanges();
            }
        }

        public void Delete(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                var dbAcc = context.Accounts.SingleOrDefault(x => x.AccountNumber == account.AccountNumber);

                if (dbAcc == null)
                {
                    throw new InvalidOperationException($"{account} is not found.");
                }

                context.Accounts.Remove(dbAcc);
                context.SaveChanges();
            }
        }

        public void Update(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            using (var context = new AccountEntities())
            {
                var dbAcc = context.Accounts.SingleOrDefault(x => x.AccountNumber == account.AccountNumber);

                if (dbAcc == null)
                {
                    throw new InvalidOperationException($"{account} not found.");
                }

                dbAcc.Balance = account.Balance;
                dbAcc.BonusPoints = account.BonusPoints;
                dbAcc.AccountTypeId = account.Type;
                context.SaveChanges();
            }
        }

        public DalAccount GetByNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException($"{nameof(number)} cannot be null or empty.");
            }

            using (var context = new AccountEntities())
            {
                var dbAcc = context.Accounts.SingleOrDefault(x => x.AccountNumber == number);

                if (dbAcc == null)
                {
                    throw new InvalidOperationException($"{number} not found.");
                }

                return dbAcc.ToDalAccount();
            }
        }

        #endregion
    }
}
