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

        public ActionResult Galerifoto()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult Funedugame()
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

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            var query = from u in db.Users
                        where u.Username.Equals(user.Username) && u.Password.Equals(user.Password)
                        select u;

            foreach(var item in query)
            {
                Session["UserId"] = item.Username.ToString();
                Session["UserName"] = item.Username.ToString();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult AddToMaps()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMaps(FormCollection form)
        {
            PlanesiaDBsEntities db = new PlanesiaDBsEntities();
            if(form[''])
            return RedirectToAction("Index");
        }
    }
}