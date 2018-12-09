﻿using System;
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
            Accounts = new List<DalAccount>(Accounts);
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

            if (this.Contains(account))
            {
                throw new InvalidOperationException($"Email {account.Holder.Email} already exists.");
            }

            this.Accounts.Add(account);
        }

        public void Delete(DalAccount account)
        {
            this.Accounts.Remove(account);
        }

        public void Update(DalAccount account)
        {
            for (int i = 0; i < Accounts.Count; i++)
                if (Accounts[i].AccountNumber == account.AccountNumber)
                {
                    Accounts[i] = account;
                    break;
                }
        }

        public DalAccount GetById(int id)
        {
            var result = Accounts.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new InvalidOperationException($"Invalid {id}.");
            }

            return result;
        }

        public DalAccount GetByNumber(string number)
        {
            var result = Accounts.FirstOrDefault(x => x.AccountNumber == number);

            if (result == null)
            {
                throw new InvalidOperationException($"{number} not found.");
            }

            return result;
        }

        public bool Contains(DalAccount account)
        {
            foreach (var acc in Accounts)
            {
                if (acc.Holder.Email == account.Holder.Email)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
