using System;
using ConsoleApp.Framework.User;
using Framework.UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CommandLineUnitTests
{
    [TestClass]
    public class UsersUnitTests
    {
        private readonly Mock<IUser> _narrator = new Mock<IUser>(MockBehavior.Strict);
        private readonly Mock<IUser> _player = new Mock<IUser>(MockBehavior.Strict);

        public UsersUnitTests()
        {
            _narrator.Setup(p => p.Name).Returns("Narrator");
            _narrator.Setup(p => p.Password).Returns("haw_haw");
            _narrator.Setup(p => p.Type).Returns(Users.Admin);

            _player.Setup(p => p.Name).Returns("Stanley Parable");
            _player.Setup(p => p.Password).Returns("Follow_the_leader");
            _player.Setup(p => p.Type).Returns(Users.Basic);
        }
        [TestMethod]
        public void TestUsersObserverNoBasic()
        {
            AssertExt.AssertThrows<Exception>(() => new UsersObserver(new IUser[] { _narrator.Object }));
        }

        [TestMethod]
        public void TestUsersObserverWithBasic()
        {
            AssertExt.AssertNoThrows<Exception>(() => new UsersObserver(new IUser[] { _player.Object }));
        }

        [TestMethod]
        public void TestUsersObserverCurrentUserBadNameException()
        {
            var observer = new UsersObserver(new IUser[] { _player.Object });

            AssertExt.AssertNoThrows<Exception>(() => observer.GetUserByName("Stanley Cup"));
        }

        [TestMethod]
        public void TestUsersObserverCurrentUserBadNameResult()
        {
            var observer = new UsersObserver(new IUser[] { _player.Object });

            var result = observer.GetUserByName("Stanley Cup");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestUsersObserverCurrentUserRightNameResult()
        {
            var observer = new UsersObserver(new IUser[] { _player.Object });

            var result = observer.GetUserByName("Stanley Parable");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUsersObserverCurrentUserRightNameResults()
        {
            var observer = new UsersObserver(new IUser[] { _player.Object });

            var result = observer.GetUserByName("Stanley Parable");
            Assert.AreEqual("Stanley Parable", result.Name);
            Assert.AreEqual("Follow_the_leader", result.Password);
            Assert.AreEqual(Users.Basic, result.Type);
        }

        [TestMethod]
        public void TestUsersObserverCurrentUser()
        {
            var observer = new UsersObserver(new IUser[] { _player.Object, _narrator.Object });
            var currentUser = observer.User;

            Assert.AreEqual("Stanley Parable", currentUser.Name);
            Assert.AreEqual("Follow_the_leader", currentUser.Password);
            Assert.AreEqual(Users.Basic, currentUser.Type);
        }

        [TestMethod]
        public void TestUsersObserverChangeCurrentUser()
        {
            var observer = new UsersObserver(new IUser[] { _player.Object, _narrator.Object });

            var changed = false;

            observer.CurrentUserChangedEvent += (s, e) => changed = true;

            var narrator = observer.GetUserByName("Narrator");
            observer.User = narrator;
            Assert.IsTrue(changed);
        }
    }
}
