﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
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

            viewModel.tagCloud = from prjtg in db.Projects select prjtg;
            viewModel.Products = from prj in db.Projects
                                         join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                                         where prjtg.Tag.name == "product"
                                         select prj;
            viewModel.featuredProjects = from prj in db.Projects
                                         join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                                         where prjtg.Tag.name == "featuredproject"
                                         select prj;
            viewModel.featuredProduct = from prj in db.Projects
                                         join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                                         where prjtg.Tag.name == "featuredproduct"
                                         select prj;
            viewModel.featuredProduct.Take(1).ToList();

            return View(viewModel);
        }

        public ViewResult Dev()
        {
            var viewModel = new HomeDevData();

            viewModel.tagCloud = from prjtg in db.Projects select prjtg;
            viewModel.Products = from prj in db.Projects
                                 join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                                 where prjtg.Tag.name == "product"
                                 select prj;
            viewModel.featuredProjects = from prj in db.Projects
                                         join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                                         where prjtg.Tag.name == "featuredproject"
                                         select prj;
            viewModel.featuredProduct = from prj in db.Projects
                                        join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                                        where prjtg.Tag.name == "featuredproduct"
                                        select prj;
            viewModel.featuredProduct.Take(1).ToList();

            //int idx = 0;
            //while ( idx < viewModel.tagCloud.Count())
            //while ( idx < 3)
            //{
            //    viewModel.arrGamma.Add(viewModel.tagCloud.Skip(idx).Take(1));
            //}

            //foreach (var group in viewModel.tagCloud.SelectMany(p => p.ProjectTags).GroupBy(c => c.Tag).OrderByDescending(s => s.Count()))
            //{
            //    if (group.FirstOrDefault().Tag.type == "medium")
            //    {
            //        //viewModel.arrGamma.Add(group.FirstOrDefault().Tag);
            //    }
            //}

            return View(viewModel);
        }

        public ActionResult Listing(string id)
        {
            var viewModel = new HomeListingData();
            viewModel.tag = id;

            viewModel.tagCloud = from prjtg in db.Projects select prjtg;
            viewModel.projects = from prj in db.Projects
                           join prjtg in db.ProjectTags on prj.ProjectID equals prjtg.ProjectID
                           where prjtg.Tag.name == id
                           select prj;

            return View(viewModel);
        }

        public ActionResult Profile(string id)
        {
            var projects = db.Projects.Where(s => s.alias == id).Take(1).ToList();

            return View(projects);
        }
    }
}
