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
    public class CampaignRepositoryTest
    {
        [TestMethod]
        public void CampaignRepositoryDb_GetAllData()
        {
            CampaignRepositoryDb urd = new CampaignRepositoryDb();
            int expectedCount = 3;

            int count = urd.Campaigns.Count;

            Assert.AreSame(expectedCount, count, "Harusnya 3.");
        }

        [TestMethod]
        public void CampaignRepositoryMock_GetAllData()
        {
            CampaignRepositoryMock urm = new CampaignRepositoryMock();
            int expectedCount = 5;

            int count = urm.Campaigns.Count;

            Assert.AreEqual(expectedCount, count, "Harusnya 5.");
        }

        [TestMethod]
        public void CampaignRepositoryDb_GetCampaignById()
        {
            CampaignRepositoryDb urd = new CampaignRepositoryDb();
            var a = urd.GetCampaignById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void CampaignRepositoryMock_GetCampaignById()
        {
            CampaignRepositoryMock urm = new CampaignRepositoryMock();
            var a = urm.GetCampaignById(1);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void CampaignRepositoryDb_AddCampaign()
        {
            CampaignRepositoryDb urd = new CampaignRepositoryDb();
            Campaign campaign = new Campaign() { CampaignName = "Njajal Gan", CampaignId = 1000 };
            urd.AddCampaign(campaign);
            var a = urd.GetCampaignById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void CampaignRepositoryMock_AddCampaign()
        {
            CampaignRepositoryMock urm = new CampaignRepositoryMock();
            Campaign campaign = new Campaign() { CampaignName = "Njajal Gan", CampaignId = 1000 };
            urm.AddCampaign(campaign);
            var a = urm.GetCampaignById(1000);

            Assert.IsNotNull(a);
        }

        [TestMethod]
        public void CampaignRepositoryDb_UpdateCampaign()
        {
            CampaignRepositoryDb urd = new CampaignRepositoryDb();
            Campaign campaign = new Campaign() { CampaignName = "Njajal Gan", CampaignId = 1 };
            urd.UpdateCampaign(campaign);
            var a = urd.GetCampaignById(1);

            Assert.AreEqual(campaign, a);
        }

        [TestMethod]
        public void CampaignRepositoryMock_UpdateCampaign()
        {
            CampaignRepositoryMock urm = new CampaignRepositoryMock();
            Campaign campaign = new Campaign() { CampaignName = "Njajal Gan", CampaignId = 1 };
            urm.UpdateCampaign(campaign);
            var a = urm.GetCampaignById(1);

            Assert.AreEqual(campaign, a);
        }

        [TestMethod]
        public void CampaignRepositoryDb_DeleteCampaign()
        {
            CampaignRepositoryDb urd = new CampaignRepositoryDb();
            urd.DeleteCampaign(1);
            var a = urd.GetCampaignById(1);

            Assert.IsNull(a);
        }

        [TestMethod]
        public void CampaignRepositoryMock_DeleteCampaign()
        {
            CampaignRepositoryMock urm = new CampaignRepositoryMock();
            urm.DeleteCampaign(1);
            var a = urm.GetCampaignById(1);

            Assert.IsNull(a);
        }
    }
}