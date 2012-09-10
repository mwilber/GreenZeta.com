using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenZeta.com.Models;

namespace GreenZeta.com.Controllers
{ 
    public class ProjectsController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        //
        // GET: /Projects/

        public ViewResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult SearchIndex(string id)
        {
            var projects = from m in db.Projects select m;

            if (!String.IsNullOrEmpty(id))
            {
                projects = projects.Where(s => s.alias.Equals(id));
            }

            return View(projects);
        }

        [HttpPost]
        public string SearchIndex(FormCollection fc, string id)
        {
            return "<h3> From [HttpPost]SearchIndex: " + id + "</h3>";
        }

        //
        // GET: /Projects/Details/5

        public ViewResult Details(int id)
        {
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(project);
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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