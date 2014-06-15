using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Repository;
using Planesia.Models;

namespace Planesia.UnitTest
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void UserRepositoryDb_GetAllData()
        {
            UserRepositoryDb urd = new UserRepositoryDb();
            int expectedCount = 3;

            int count = urd.Users.Count;

            Assert.AreSame(expectedCount, count, "Harusnya 3.");
        }

        [TestMethod]
        public void UserRepositoryMock_GetAllData()
        {
            UserRepositoryMock urm = new UserRepositoryMock();
            int expectedCount = 5;

            int count = urm.Users.Count;

            Assert.AreEqual(expectedCount, count, "Harusnya 5.");
        }

        [TestMethod]
        public void UserRepositoryDb_GetUserById()
        {
            UserRepositoryDb urd = new UserRepositoryDb();
            var a = urd.GetUserById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void UserRepositoryMock_GetUserById()
        {
            UserRepositoryMock urm = new UserRepositoryMock();
            var a = urm.GetUserById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void UserRepositoryDb_AddUser()
        {
            UserRepositoryDb urd = new UserRepositoryDb();
            User user = new User() { Username = "Njajal Gan", UserId = 1000 };
            urd.AddUser(user);
            var a = urd.GetUserById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void UserRepositoryMock_AddUser()
        {
            UserRepositoryMock urm = new UserRepositoryMock();
            User user = new User() { Username = "Njajal Gan", UserId = 1000 };
            urm.AddUser(user);
            var a = urm.GetUserById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void UserRepositoryDb_UpdateUser()
        {
            UserRepositoryDb urd = new UserRepositoryDb();
            User user = new User() { Username = "Njajal Gan", UserId = 1 };
            urd.UpdateUser(user);
            var a = urd.GetUserById(1);

            Assert.AreEqual(user, a);
        }

        [TestMethod]
        public void UserRepositoryMock_UpdateUser()
        {
            UserRepositoryMock urm = new UserRepositoryMock();
            User user = new User() { Username = "Njajal Gan", UserId = 1 };
            urm.UpdateUser(user);
            var a = urm.GetUserById(1);

            Assert.AreEqual(user, a);
        }

        [TestMethod]
        public void UserRepositoryDb_DeleteUser()
        {
            UserRepositoryDb urd = new UserRepositoryDb();
            urd.DeleteUser(1);
            var a = urd.GetUserById(1);

            Assert.IsNull(a);
        }

        [TestMethod]
        public void UserRepositoryMock_DeleteUser()
        {
            UserRepositoryMock urm = new UserRepositoryMock();
            urm.DeleteUser(1);
            var a = urm.GetUserById(1);

            Assert.IsNull(a);
        }
    }
}