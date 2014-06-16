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
        public ActionResult Login(FormCollection form)
        {
            string username = form.Get("username");
            string password = form.Get("password");
            var query = from u in db.Users
                        where u.Username.Equals(username) && u.Password.Equals(password)
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

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult AddFauna()
        {
            return View();
        }

        public ActionResult AddFlora()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFauna(FormCollection form)
        {
            Fauna fauna = new Fauna();
            fauna.FaunaName = form.Get("name");
            fauna.FaunaLatinName = form.Get("latin");
            //fauna.FaunaLongitude = float.Parse(form.Get("longitude"));
            //fauna.FaunaLatitude = float.Parse(form.Get("latitude"));
            fauna.FaunaOtherDescription = form.Get("description");
            fauna.FaunaDiscoverer = form.Get("discoverer");
            fauna.FaunaPhoto = form.Get("photolink");
            try
            {
                db.Faunas.Add(fauna);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")</script>");
                Response.Redirect("Error");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddFlora(FormCollection form)
        {
            Flora flora = new Flora();
            flora.FloraName= form.Get("name");
            flora.FloraLatinName = form.Get("latin");
            //flora.FloraLongitude = float.Parse(form.Get("longitude"));
            //flora.FloraLatitude = float.Parse(form.Get("latitude"));
            flora.FloraOtherDescription = form.Get("description");
            flora.FloraDiscoverer = form.Get("discoverer");
            flora.FloraPhoto = form.Get("photolink");
            try
            {
                db.Floras.Add(flora);
                db.SaveChanges();
            }
            catch
            {
                Response.Redirect("ErrorPage");
            }
            return View();
        }
    }
}