using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenZeta.com.Models;
using GreenZeta.com.DAL;

namespace GreenZeta.com.Controllers
{ 
    public class ProjectTagsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        //
        // GET: /ProjectTags/

        public ViewResult Index()
        {
            var projecttags = db.ProjectTags.Include(p => p.Project).Include(p => p.Tag);
            return View(projecttags.ToList());
        }

        //
        // GET: /ProjectTags/Details/5

        public ViewResult Details(int id)
        {
            ProjectTag projecttag = db.ProjectTags.Find(id);
            return View(projecttag);
        }

        //
        // GET: /ProjectTags/Create

        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias");
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "name");
            return View();
        } 

        //
        // POST: /ProjectTags/Create

        [HttpPost]
        public ActionResult Create(ProjectTag projecttag)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTags.Add(projecttag);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias", projecttag.ProjectID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "name", projecttag.TagID);
            return View(projecttag);
        }
        
        //
        // GET: /ProjectTags/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProjectTag projecttag = db.ProjectTags.Find(id);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias", projecttag.ProjectID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "name", projecttag.TagID);
            return View(projecttag);
        }

        //
        // POST: /ProjectTags/Edit/5

        [HttpPost]
        public ActionResult Edit(ProjectTag projecttag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecttag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias", projecttag.ProjectID);
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "name", projecttag.TagID);
            return View(projecttag);
        }

        //
        // GET: /ProjectTags/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProjectTag projecttag = db.ProjectTags.Find(id);
            return View(projecttag);
        }

        //
        // POST: /ProjectTags/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ProjectTag projecttag = db.ProjectTags.Find(id);
            db.ProjectTags.Remove(projecttag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}