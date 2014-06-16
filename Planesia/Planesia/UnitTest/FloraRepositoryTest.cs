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
    public class FloraRepositoryTest
    {
        [TestMethod]
        public void FloraRepositoryDb_GetAllData()
        {
            FloraRepositoryDb urd = new FloraRepositoryDb();
            int expectedCount = 3;

            int count = urd.Floras.Count;

            Assert.AreSame(expectedCount, count, "Harusnya 3.");
        }

        [TestMethod]
        public void FloraRepositoryMock_GetAllData()
        {
            FloraRepositoryMock urm = new FloraRepositoryMock();
            int expectedCount = 5;

            int count = urm.Floras.Count;

            Assert.AreEqual(expectedCount, count, "Harusnya 5.");
        }

        [TestMethod]
        public void FloraRepositoryDb_GetFloraById()
        {
            FloraRepositoryDb urd = new FloraRepositoryDb();
            var a = urd.GetFloraById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FloraRepositoryMock_GetFloraById()
        {
            FloraRepositoryMock urm = new FloraRepositoryMock();
            var a = urm.GetFloraById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FloraRepositoryDb_AddFlora()
        {
            FloraRepositoryDb urd = new FloraRepositoryDb();
            Flora flora = new Flora() { FloraName = "Njajal Gan", FloraId = 1000 };
            urd.AddFlora(flora);
            var a = urd.GetFloraById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FloraRepositoryMock_AddFlora()
        {
            FloraRepositoryMock urm = new FloraRepositoryMock();
            Flora flora = new Flora() { FloraName = "Njajal Gan", FloraId = 1000 };
            urm.AddFlora(flora);
            var a = urm.GetFloraById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void FloraRepositoryDb_UpdateFlora()
        {
            FloraRepositoryDb urd = new FloraRepositoryDb();
            Flora flora = new Flora() { FloraName = "Njajal Gan", FloraId = 1 };
            urd.UpdateFlora(flora);
            var a = urd.GetFloraById(1);

            Assert.AreEqual(flora, a);
        }

        [TestMethod]
        public void FloraRepositoryMock_UpdateFlora()
        {
            FloraRepositoryMock urm = new FloraRepositoryMock();
            Flora flora = new Flora() { FloraName = "Njajal Gan", FloraId = 1 };
            urm.UpdateFlora(flora);
            var a = urm.GetFloraById(1);

            Assert.AreEqual(flora, a);
        }

        [TestMethod]
        public void FloraRepositoryDb_DeleteFlora()
        {
            FloraRepositoryDb urd = new FloraRepositoryDb();
            urd.DeleteFlora(1);
            var a = urd.GetFloraById(1);

            Assert.IsNull(a);
        }

        [TestMethod]
        public void FloraRepositoryMock_DeleteFlora()
        {
            FloraRepositoryMock urm = new FloraRepositoryMock();
            urm.DeleteFlora(1);
            var a = urm.GetFloraById(1);

            Assert.IsNull(a);
        }
    }
}