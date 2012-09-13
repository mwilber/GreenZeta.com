using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenZeta.com.DAL;
using GreenZeta.com.Models;

namespace GreenZeta.com.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";

            return View();
        }

        public ActionResult Listing(string id)
        {
            var projects = from m in db.Projects select m;

            if (!String.IsNullOrEmpty(id))
            {
                projects = projects.Where(s => s.alias.Equals(id));
            }

            return View(projects);
        }

        public ActionResult Profile(string id)
        {
            var projects = from m in db.Projects select m;

            if (!String.IsNullOrEmpty(id))
            {
                projects = projects.Where(s => s.alias == id);
            }

            return View(projects);
        }
    }
}
