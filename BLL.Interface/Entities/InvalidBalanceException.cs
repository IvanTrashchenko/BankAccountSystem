using System;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Exception of incorrect "withdraw" operation in <see cref="AccountEntity"/> class when working with balance.
    /// </summary>
    public class InvalidBalanceException : Exception
    {
        public InvalidBalanceException()
        {
        }

        public InvalidBalanceException(string message) : base(message)
        {
        }

        public InvalidBalanceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
