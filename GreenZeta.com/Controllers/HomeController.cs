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
            var projects = from prj in db.Projects 
                           where prj.ProjectID.Equals(from prjtg in db.ProjectTags where prjtg.Tag.name == id select prjtg)
                           select prj;

            //var pageObject = (from op in db.ObjectPermissions
            //      join pg in db.Pages on op.ObjectPermissionName equals page.PageName
            //      where pg.PageID == page.PageID
            //      select new { pg, op }).SingleOrDefault();

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
