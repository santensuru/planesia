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
    public class FaunaRepositoryTest
    {
        [TestMethod]
        public void FaunaRepositoryDb_GetAllData()
        {
            FaunaRepositoryDb urd = new FaunaRepositoryDb();
            int expectedCount = 3;

            int count = urd.Faunas.Count;

            Assert.AreSame(expectedCount, count, "Harusnya 3.");
        }

        [TestMethod]
        public void FaunaRepositoryMock_GetAllData()
        {
            FaunaRepositoryMock urm = new FaunaRepositoryMock();
            int expectedCount = 5;

            int count = urm.Faunas.Count;

            Assert.AreEqual(expectedCount, count, "Harusnya 5.");
        }

        [TestMethod]
        public void FaunaRepositoryDb_GetFaunaById()
        {
            FaunaRepositoryDb urd = new FaunaRepositoryDb();
            var a = urd.GetFaunaById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FaunaRepositoryMock_GetFaunaById()
        {
            FaunaRepositoryMock urm = new FaunaRepositoryMock();
            var a = urm.GetFaunaById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FaunaRepositoryDb_AddFauna()
        {
            FaunaRepositoryDb urd = new FaunaRepositoryDb();
            Fauna fauna = new Fauna() { FaunaName = "Njajal Gan", FaunaId = 1000 };
            urd.AddFauna(fauna);
            var a = urd.GetFaunaById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FaunaRepositoryMock_AddFauna()
        {
            FaunaRepositoryMock urm = new FaunaRepositoryMock();
            Fauna fauna = new Fauna() { FaunaName = "Njajal Gan", FaunaId = 1000 };
            urm.AddFauna(fauna);
            var a = urm.GetFaunaById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FaunaRepositoryDb_UpdateFauna()
        {
            FaunaRepositoryDb urd = new FaunaRepositoryDb();
            Fauna fauna = new Fauna() { FaunaName = "Njajal Gan", FaunaId = 1 };
            urd.UpdateFauna(fauna);
            var a = urd.GetFaunaById(1);

            Assert.AreEqual(fauna, a);
        }

        [TestMethod]
        public void FaunaRepositoryMock_UpdateFauna()
        {
            FaunaRepositoryMock urm = new FaunaRepositoryMock();
            Fauna fauna = new Fauna() { FaunaName = "Njajal Gan", FaunaId = 1 };
            urm.UpdateFauna(fauna);
            var a = urm.GetFaunaById(1);

            Assert.AreEqual(fauna, a);
        }

        [TestMethod]
        public void FaunaRepositoryDb_DeleteFauna()
        {
            FaunaRepositoryDb urd = new FaunaRepositoryDb();
            urd.DeleteFauna(1);
            var a = urd.GetFaunaById(1);

            Assert.IsNull(a);
        }

        [TestMethod]
        public void FaunaRepositoryMock_DeleteFauna()
        {
            FaunaRepositoryMock urm = new FaunaRepositoryMock();
            urm.DeleteFauna(1);
            var a = urm.GetFaunaById(1);

            Assert.IsNull(a);
        }
    }
}