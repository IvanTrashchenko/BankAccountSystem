using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    /// <summary>
    /// Interface of bank service.
    /// </summary>
    public interface IBankService
    { 
        /// <summary>
        /// Deleting of specific account operation.
        /// </summary>
        /// <param name="accountNumber">Account's number.</param>
        void CloseAccount(string accountNumber);

        /// <summary>
        /// Opening new account operation.
        /// </summary>
        /// <param name="account">Account of type <see cref="AccountEntity"/>.</param>
        void OpenAccount(AccountEntity account);

        /// <summary>
        /// Deposit operation.
        /// </summary>
        /// <param name="accountNumber">Account's number.</param>
        /// <param name="value">Money amount.</param>
        void Deposit(string accountNumber, decimal value);

        /// <summary>
        /// Withdraw operation.
        /// </summary>
        /// <param name="accountNumber">Account's number.</param>
        /// <param name="value">Money amount.</param>
        void Withdraw(string accountNumber, decimal value);

        /// <summary>
        /// Transfer operation.
        /// </summary>
        /// <param name="senderAccountNumber">Sender's account number.</param>
        /// <param name="recipientAccountNumber">Recipient's account number.</param>
        /// <param name="value">Money amount.</param>
        void Transfer(string senderAccountNumber, string recipientAccountNumber, decimal value);

        /// <summary>
        /// Gets all accounts from repository.
        /// </summary>
        /// <returns><see cref="IEnumerable{AccountEntity}"/>.</returns>
        IEnumerable<AccountEntity> GetAllAccounts();

    }
}
