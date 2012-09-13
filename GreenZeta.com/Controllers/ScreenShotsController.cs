using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenZeta.com.DAL;
using GreenZeta.com.Models;

namespace GreenZeta.com.Controllers
{ 
    public class ScreenShotsController : Controller
    {
        private PortfolioContext db = new PortfolioContext();

        //
        // GET: /ScreenShots/

        public ViewResult Index()
        {
            return View(db.ScreenShots.ToList());
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

            return View(screenshot);
        }
        
        //
        // GET: /ScreenShots/Edit/5
 
        public ActionResult Edit(int id)
        {
            ScreenShot screenshot = db.ScreenShots.Find(id);
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