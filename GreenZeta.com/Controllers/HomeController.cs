using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenZeta.com.DAL;
using GreenZeta.com.Models;
using GreenZeta.com.ViewModels;

namespace GreenZeta.com.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        public ViewResult Index()
        {
            var viewModel = new HomeIndexData();

            viewModel.tagCloud = from tg in db.Tags select tg;
            viewModel.featuredProjects = from prj in db.Projects select prj;

            return View(viewModel);
        }

        public ActionResult Listing(string id)
        {
            var projects = from prj in db.Projects
                           join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                           where prjtg.Tag.name == id
                           select prj;

            return View(projects);
        }

        public ActionResult Profile(string id)
        {
            //var projects = db.Projects.Single(s => s.alias == id);

               // projects = projects.Single(s => s.alias == id);

            var projects = db.Projects.Where(s => s.alias == id).Take(1).ToList();

            return View(projects);
        }
    }
}
