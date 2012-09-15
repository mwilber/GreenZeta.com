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
    public class ScreenShotsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        //
        // GET: /ScreenShots/

        public ViewResult Index()
        {
            var screenshots = db.ScreenShots.Include(s => s.Project);
            return View(screenshots.ToList());
        }

        //
        // GET: /ScreenShots/Details/5

        public ViewResult Details(int id)
        {
            ScreenShot screenshot = db.ScreenShots.Find(id);
            return View(screenshot);
        }

        //
        // GET: /ScreenShots/Create

        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias");
            return View();
        } 

        //
        // POST: /ScreenShots/Create

        [HttpPost]
        public ActionResult Create(ScreenShot screenshot)
        {
            if (ModelState.IsValid)
            {
                db.ScreenShots.Add(screenshot);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias", screenshot.ProjectID);
            return View(screenshot);
        }
        
        //
        // GET: /ScreenShots/Edit/5
 
        public ActionResult Edit(int id)
        {
            ScreenShot screenshot = db.ScreenShots.Find(id);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias", screenshot.ProjectID);
            return View(screenshot);
        }

        //
        // POST: /ScreenShots/Edit/5

        [HttpPost]
        public ActionResult Edit(ScreenShot screenshot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screenshot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "alias", screenshot.ProjectID);
            return View(screenshot);
        }

        //
        // GET: /ScreenShots/Delete/5
 
        public ActionResult Delete(int id)
        {
            ScreenShot screenshot = db.ScreenShots.Find(id);
            return View(screenshot);
        }

        //
        // POST: /ScreenShots/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ScreenShot screenshot = db.ScreenShots.Find(id);
            db.ScreenShots.Remove(screenshot);
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