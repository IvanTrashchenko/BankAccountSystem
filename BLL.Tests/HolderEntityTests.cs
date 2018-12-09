using System;
using BLL.Interface.Entities;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class HolderEntityTests
    {
        private readonly HolderEntity holder =
            new HolderEntity("Name", "Surname", "test@test.com");

        [Test]
        public void HolderEntity_FirstName_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => holder.FirstName = null);
        }

        [Test]
        public void HolderEntity_LastName_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => holder.LastName = null);
        }

        [Test]
        public void HolderEntity_Email_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => holder.Email = null);
        }

        [Test]
        public void HolderEntity_FirstName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => holder.FirstName = "a");
        }

        [Test]
        public void HolderEntity_LastName_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => holder.LastName = "a");
        }

        [TestCase("a")]
        [TestCase("a.com")]
        [TestCase("a@com")]
        public void HolderEntity_Email_ThrowArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() => holder.Email = email);
        }
    }
}
