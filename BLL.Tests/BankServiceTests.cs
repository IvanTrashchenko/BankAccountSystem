using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class BankServiceTests
    {
        [Test]
        public void Test_CloseAccount_Calls_Repository_And_Logger()
        {
            // Arrange
            var repository = new MockRepository(MockBehavior.Default);

            var repositoryMock = repository.Create<IRepository<DalAccount>>();
            repositoryMock.Setup(x => x.Delete(It.IsAny<DalAccount>()));

            var loggerMock = repository.Create<IAccountLogger>();
            loggerMock.Setup(lm => lm.Info(It.IsAny<string>()));

            var bankService = new BankService(repositoryMock.Object, loggerMock.Object);

            // Act
            bankService.CloseAccount("aa");

            // Assert
            repository.Verify();
        }

        [Test]
        public void Test_OpenAccount_Calls_Repository_And_Logger()
        {            
            var repository = new MockRepository(MockBehavior.Default);

            var repositoryMock = repository.Create<IRepository<DalAccount>>();
            repositoryMock.Setup(x => x.Create(It.IsAny<DalAccount>()));

            var loggerMock = repository.Create<IAccountLogger>();
            loggerMock.Setup(lm => lm.Info(It.IsAny<string>()));

            var bankService = new BankService(repositoryMock.Object, loggerMock.Object);
            
            bankService.OpenAccount(new AccountEntity());
        
            repository.Verify();
        }

        [Test]
        public void Test_Deposit_Calls_Repository_And_Logger()
        {            
            var repository = new MockRepository(MockBehavior.Default);

            var repositoryMock = repository.Create<IRepository<DalAccount>>();
            repositoryMock.Setup(x => x.Update(It.IsAny<DalAccount>()));

            var loggerMock = repository.Create<IAccountLogger>();
            loggerMock.Setup(lm => lm.Info(It.IsAny<string>()));

            var bankService = new BankService(repositoryMock.Object, loggerMock.Object);
            
            bankService.Deposit("aa", 500);
            
            repository.Verify();
        }

        [Test]
        public void Test_Withdraw_Calls_Repository_And_Logger()
        {           
            var repository = new MockRepository(MockBehavior.Default);

            var repositoryMock = repository.Create<IRepository<DalAccount>>();
            repositoryMock.Setup(x => x.Update(It.IsAny<DalAccount>()));

            var loggerMock = repository.Create<IAccountLogger>();
            loggerMock.Setup(lm => lm.Info(It.IsAny<string>()));

            var bankService = new BankService(repositoryMock.Object, loggerMock.Object);
           
            bankService.Withdraw("aa", 500);
           
            repository.Verify();
        }

        [Test]
        public void Test_Transfer_Calls_Repository_And_Logger()
        {
            var repository = new MockRepository(MockBehavior.Default);

            var repositoryMock = repository.Create<IRepository<DalAccount>>();
            repositoryMock.Setup(x => x.Update(It.IsAny<DalAccount>()));

            var loggerMock = repository.Create<IAccountLogger>();
            loggerMock.Setup(lm => lm.Info(It.IsAny<string>()));

            var bankService = new BankService(repositoryMock.Object, loggerMock.Object);
            
            bankService.Transfer("aa", "bb", 500);
           
            repository.Verify();
        }
    }
}
