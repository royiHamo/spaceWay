﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpaceWay.Context;
using SpaceWay.Models;

namespace SpaceWay.Controllers
{
    public class AircraftsController : Controller
    {
        private SpaceWayDbContext db = new SpaceWayDbContext();

        // GET: Aircrafts
        public ActionResult Index(int? levelToFilter)
        {

            var airs = from a in db.Aircrafts.ToList()
                       where a.Level == levelToFilter
                       select a;
            if (!airs.Any())
            {
                return View(db.Aircrafts.ToList());
            }
            return View(airs);

            //List<Aircraft> airs = new List<Aircraft>();
            //airs = db.Aircrafts.ToList().Where(a => a.Level == levelToFilter).ToList();

            //if (!airs.Any())
            //{
            //    return View(db.Aircrafts.ToList());
            //}

            //return View(airs);
        }

        // POST: Aircrafts
        [HttpPost]
        public ActionResult Search(string lvl)
        {
            if (string.IsNullOrEmpty(lvl))
            {
                return RedirectToAction("Index");
            }

            if (lvl.All(char.IsNumber))
            {
                int level = Convert.ToInt16(lvl);
                return RedirectToAction("Index", new { @levelToFilter = level });
            }
            
            return RedirectToAction("Index");

        }


        // GET: Aircrafts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircrafts.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // GET: Aircrafts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aircrafts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AircraftID,Level,Seats")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Aircrafts.Add(aircraft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aircraft);
        }

        // GET: Aircrafts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircrafts.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // POST: Aircrafts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AircraftID,Level,Seats")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircraft);
        }

        // GET: Aircrafts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = db.Aircrafts.Find(id);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(aircraft);
        }

        // POST: Aircrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aircraft aircraft = db.Aircrafts.Find(id);
            db.Aircrafts.Remove(aircraft);
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


