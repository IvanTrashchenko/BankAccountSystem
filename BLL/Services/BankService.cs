using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class BankService : IBankService
    {
        #region Repository field

        private readonly IRepository<DalAccount> repository;

        #endregion

        #region Constructor

        public BankService(IRepository<DalAccount> repository)
        {
            this.repository = repository;
        }

        #endregion

        #region IBankService implementation

        public void CloseAccount(string accountNumber)
        {
            var account = repository.GetByNumber(accountNumber);

            repository.Delete(account);
        }

        public void OpenAccount(AccountEntity account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            repository.Create(account.ToDalAccount());
        }

        public void Deposit(string accountNumber, decimal value)
        {
            AccountEntity account = repository.GetByNumber(accountNumber).ToBllAccount();
            account.Deposit(value);
            repository.Update(account.ToDalAccount());
        }

        public void Withdraw(string accountNumber, decimal value)
        {
            AccountEntity account = repository.GetByNumber(accountNumber).ToBllAccount();
            account.Withdraw(value);
            repository.Update(account.ToDalAccount());
        }

        public void Transfer(string senderAccountNumber, string recipientAccountNumber, decimal value)
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} is out of range.");
            }

            AccountEntity sender = repository.GetByNumber(senderAccountNumber).ToBllAccount();
            AccountEntity recipient = repository.GetByNumber(recipientAccountNumber).ToBllAccount();

            sender.Withdraw(value);
            recipient.Deposit(value);

            repository.Update(sender.ToDalAccount());
            repository.Update(recipient.ToDalAccount());
        }


        public List<AccountEntity> GetAllAccounts()
        {
            var collection = repository.GetAll();
            var accounts = new List<AccountEntity>();

            foreach (var i in collection)
            {
                accounts.Add(i.ToBllAccount());
            }

            return accounts;
        }

        #endregion
    }
}