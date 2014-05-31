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
            return View();
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

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Signin()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}