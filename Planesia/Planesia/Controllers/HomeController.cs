using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Planesia.Models;

namespace Planesia.Controllers
{
    public class HomeController : Controller
    {
        private PlanesiaDBsEntities db = new PlanesiaDBsEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult Campaign()
        {
            return View(db.Campaigns.ToList());
        }

        public ActionResult CreateCampaign()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCampaign([Bind(Include = "CampaignId, CampaignName, CampaignDescription, CampaignDate, UserId, CampaignStatus")]  Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                campaign.CampaignId = db.Campaigns.Count() + 1;
                campaign.UserId = 1;
                campaign.CampaignStatus = "not";
                db.Campaigns.Add(campaign);
                db.SaveChanges();
                return RedirectToAction("Campaign");
            }

            return View(campaign);
        }


        public ActionResult Funedugame()
        {
            return View();
        }

        public ActionResult Unique()
        {
            return View();
        }

        public ActionResult News(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(Planesia.Models.RssReader.GetRssFeed().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}