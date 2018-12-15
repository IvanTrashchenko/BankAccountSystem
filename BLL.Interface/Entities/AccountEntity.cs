using System;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Entity of bank account.
    /// </summary>
    public class AccountEntity
    {
        #region Fields

        ///Account holder's information.
        private HolderEntity holder;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntity"/> class with default values.
        /// </summary>
        public AccountEntity()
        {
            this.Holder = new HolderEntity();
            this.Balance = 0m;
            this.BonusPoints = 0;
            this.Type = AccountType.Base;
            this.AccountNumber = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntity"/> class.
        /// </summary>
        /// <param name="generator">Generator of account number.</param>
        /// <param name="holder">Account holder.</param>
        /// <param name="balance">Account's balance.</param>
        /// <param name="bonusPoints">Account's bonus points.</param>
        /// <param name="type">Type of account.</param>
        public AccountEntity(
            HolderEntity holder,
            IAccountNumberGenerator generator = null,
            AccountType type = AccountType.Base,
            decimal balance = 0m,
            int bonusPoints = 0)
        {
            this.Holder = holder;
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
            this.Type = type;
            AccountNumber = generator == null ? Guid.NewGuid().ToString() : generator.GenerateAccountNumber();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets account holder's info.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when AccountHolder value is null.</exception>
        public HolderEntity Holder
        {
            get => this.holder;

            set
            {
                this.holder = value ?? throw new ArgumentNullException($"{nameof(value)} can not be null.");
            }
        }

        /// <summary>
        /// Gets type of account.
        /// </summary>
        public AccountType Type { get; set; }

        /// <summary>
        /// Gets current balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets current amount of bonus points.
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Gets account number of account.
        /// </summary>
        public string AccountNumber { get; set; }

        #endregion

        #region Service methods

        /// <summary>
        /// Deposit operation.
        /// </summary>
        /// <param name="value">Money to deposit.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is out of range.</exception>
        public void Deposit(decimal value)
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} is out of range.");
            }

            this.Balance += value;
            this.BonusPoints += this.CalculateBonusPoints(value);
        }

        /// <summary>
        /// Withdraw operation.
        /// </summary>
        /// <param name="value">Money to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when money value is out of range.</exception>
        /// <exception cref="InvalidBalanceException">Thrown when balance is insufficient.</exception>
        public void Withdraw(decimal value)
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} is out of range.");
            }

            if (value > this.Balance)
            {
                throw new InvalidBalanceException("Insufficient funds.");
            }

            this.Balance -= value;

            int calculated = this.CalculateBonusPoints(value);

            this.BonusPoints = this.BonusPoints > calculated ? this.BonusPoints - calculated : 0;
        }
  
        /// <summary>
        /// Method for calculating bonus points depending on the specified amount of money.
        /// </summary>
        /// <param name="value">Money amount.</param>
        /// <returns><see cref="int"/> of bonus points.</returns>
        public int CalculateBonusPoints(decimal value)
        {
            decimal temp = 0.01m * (int)(Type + 1);
            return (int)(value * temp + this.Balance * temp);
        }

        #endregion

        #region Formatting member

        public override string ToString()
        {
            return $"{this.Holder}\n{nameof(this.Type)}: {this.Type}\n{nameof(this.Balance)}: {this.Balance}\n{nameof(this.BonusPoints)}: {this.BonusPoints}\n{nameof(this.AccountNumber)}: {this.AccountNumber}";
        }

        #endregion
    }
}
