using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Planesia.Models;
using Planesia.Service;
using Planesia.Repository;
using System.Data.Entity.Validation;
using System.Diagnostics;
    
namespace Planesia.Controllers
{
    public class HomeController : Controller
    {
        //private PlanesiaDBsEntities db = new PlanesiaDBsEntities();
        CampaignService cs = new CampaignService();
        UserService us = new UserService();
        FloraService fls = new FloraService();
        FaunaService fns = new FaunaService();
        
        public ActionResult Index()
        {
            ViewBag.Faunas = fns.GetAllFaunas();
            ViewBag.Floras = fls.GetAllFloras();
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
            //return View(db.Campaigns.ToList());
            return View(cs.GetAllCampaigns());
        }

        public ActionResult CreateCampaign()
        {
            if (Session["UserName"] != null)
                return View();
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCampaign([Bind(Include = "CampaignId, CampaignName, CampaignDescription, CampaignDate, UserId, CampaignStatus")]  Campaign campaign)
        {
            if (Session["UserName"] != null)
            {
                string c = Session["UserName"].ToString();
                if (ModelState.IsValid)
                {
                    campaign.CampaignId = cs.GetAllCampaigns().Count() + 1;
                    User user = (from u in us.GetAllUsers()
                                 where u.Username.Equals(c)
                                 select u).FirstOrDefault<User>();
                    campaign.UserId = user.UserId;
                    campaign.CampaignStatus = "not";
                    cs.AddCampaign(campaign);
                    //db.Campaigns.Add(campaign);
                    //db.SaveChanges();
                    return RedirectToAction("Campaign");
                }
                return View(campaign);
            }
            else {
                return RedirectToAction("Index");
            }
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
            var query = from u in us.GetAllUsers()
                        where u.Username.Equals(user.Username) && u.Password.Equals(user.Password)
                        select u;

            foreach(var item in query)
            {
                Session["UserId"] = item.UserId;
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
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddFauna()
        {
            if (Session["UserName"] != null)
            {
                List<Flora> floras = fls.GetAllFloras();
                List<Fauna> faunas = fns.GetAllFaunas();
                ViewBag.floras = floras;
                ViewBag.fauna = faunas;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddFlora()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddFauna(FormCollection form)
        {
            if (Session["UserName"] != null)
            {
                Fauna fauna = new Fauna();
                fauna.FaunaName = form.Get("name");
                fauna.FaunaLatinName = form.Get("latin");
                fauna.FaunaLongitude = float.Parse(form.Get("longitude"));
                fauna.FaunaLatitude = float.Parse(form.Get("latitude"));
                fauna.FaunaOtherDescription = form.Get("description");
                fauna.FaunaReference = form.Get("reference");
                fauna.FaunaPhoto = form.Get("photolink");
                fauna.FaunaDate = DateTime.Now;
                fauna.UserId = int.Parse(Session["UserId"].ToString());
                fns.AddFauna(fauna);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddFlora(FormCollection form)
        {
            if (Session["UserName"] != null)
            {
                Flora flora = new Flora();
                flora.FloraName = form.Get("name");
                flora.FloraLatinName = form.Get("latin");
                flora.FloraLongitude = float.Parse(form.Get("longitude"));
                flora.FloraLatitude = float.Parse(form.Get("latitude"));
                flora.FloraOtherDescription = form.Get("description");
                flora.FloraReference = form.Get("reference");
                flora.FloraPhoto = form.Get("photolink");
                flora.FloraDate = DateTime.Now;
                flora.UserId = int.Parse(Session["UserId"].ToString());
                fls.AddFlora(flora);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}