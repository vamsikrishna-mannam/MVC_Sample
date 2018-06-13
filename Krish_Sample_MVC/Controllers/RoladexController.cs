using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Krish_Sample_MVC.Models;

namespace Krish_Sample_MVC.Controllers
{
    public class RoladexController : Controller
    {
        private Krish_MVC_Entities db = new Krish_MVC_Entities();

        // GET: Roladex
        public ActionResult Index()
        {
            return View(db.Roladexes.ToList());
        }

        // GET: Roladex/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roladex roladex = db.Roladexes.Find(id);
            if (roladex == null)
            {
                return HttpNotFound();
            }
            return View(roladex);
        }

        // GET: Roladex/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roladex/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoladexId,Company,Name,PhoneNo,Email,Address,City,State,ZipCode,Country,Notes")] Roladex roladex)
        {
            if (ModelState.IsValid)
            {
                db.Roladexes.Add(roladex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roladex);
        }

        // GET: Roladex/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roladex roladex = db.Roladexes.Find(id);
            if (roladex == null)
            {
                return HttpNotFound();
            }
            return View(roladex);
        }

        // POST: Roladex/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoladexId,Company,Name,PhoneNo,Email,Address,City,State,ZipCode,Country,Notes")] Roladex roladex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roladex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roladex);
        }

        // GET: Roladex/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roladex roladex = db.Roladexes.Find(id);
            if (roladex == null)
            {
                return HttpNotFound();
            }
            return View(roladex);
        }

        // POST: Roladex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roladex roladex = db.Roladexes.Find(id);
            db.Roladexes.Remove(roladex);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
