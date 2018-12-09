using System;
using BLL.Interface.Entities;
using BLL.Services;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountEntityTests
    {
        private readonly AccountEntity account =
            new AccountEntity(new HolderEntity(), new AccountNumberGenerator(), AccountStatus.Base, 500, 15);

        [Test]
        public void AccountEntity_Holder_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => account.Holder = null);
        }

        [TestCase(500, ExpectedResult = 10)]
        [TestCase(1000, ExpectedResult = 15)]
        public int AccountEntity_CalculateBonusPoints_Test(decimal value) => account.CalculateBonusPoints(value);


        [Test]
        public void AccountEntity_Deposit_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-5));
        }

        [Test]
        public void AccountEntity_Withdraw_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-5));
        }

        [Test]
        public void AccountEntity_Withdraw_ThrowInvalidBalanceException()
        {
            Assert.Throws<InvalidBalanceException>(() => account.Withdraw(600));
        }
    }
}
