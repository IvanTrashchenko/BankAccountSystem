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
        #region Fields

        private readonly IRepository<DalAccount> repository;

        private readonly IAccountLogger logger;

        #endregion

        #region Constructor

        public BankService(IRepository<DalAccount> repository, IAccountLogger logger)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion

        #region IBankService implementation

        public void CloseAccount(string accountNumber)
        {
            try
            {
                var account = repository.GetByNumber(accountNumber);

                repository.Delete(account);

                logger.Info($"Account {accountNumber} was successfully deleted.");
            }
            catch (Exception e)
            {
                logger.Error($"CloseAccount operation failed: {e.Message}");
            }
        }

        public void OpenAccount(AccountEntity account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} cannot be null.");
            }

            if (!this.repository.Contains(account.ToDalAccount()))
            {
                repository.Create(account.ToDalAccount());
                logger.Info($"Account {account.AccountNumber} was successfully added.");
            }
            else
            {
                logger.Info($"OpenAccount operation failed: email {account.Holder.Email} already exists.");
            }
        }

        public void Deposit(string accountNumber, decimal value)
        {
            AccountEntity account = repository.GetByNumber(accountNumber).ToBllAccount();
            try
            {
                account.Deposit(value);
                repository.Update(account.ToDalAccount());
                logger.Info($"Account {accountNumber}: +{value}");
            }
            catch (Exception e)
            {
                logger.Error($"Deposit operation failed: {e.Message}");
            }
        }

        public void Withdraw(string accountNumber, decimal value)
        {
            AccountEntity account = repository.GetByNumber(accountNumber).ToBllAccount();
            try
            {
                account.Withdraw(value);
                repository.Update(account.ToDalAccount());
                logger.Info($"Account {accountNumber}: -{value}");
            }
            catch (Exception e)
            {
                logger.Error($"Withdraw operation failed: {e.Message}");
            }          
        }

        public void Transfer(string senderAccountNumber, string recipientAccountNumber, decimal value)
        {
            try
            {
                AccountEntity sender = repository.GetByNumber(senderAccountNumber).ToBllAccount();
                AccountEntity recipient = repository.GetByNumber(recipientAccountNumber).ToBllAccount();

                sender.Withdraw(value);
                recipient.Deposit(value);

                repository.Update(sender.ToDalAccount());
                repository.Update(recipient.ToDalAccount());

                logger.Info($"Account {senderAccountNumber}: -{value}");
                logger.Info($"Account {recipientAccountNumber}: +{value}");
            }
            catch (Exception e)
            {
                logger.Error($"Transfer operation failed: {e.Message}");
            }
            
        }


        public IEnumerable<AccountEntity> GetAllAccounts()
        {
            foreach (var i in repository.GetAll())
            {
                yield return i.ToBllAccount();
            }
        }

        #endregion
    }
}