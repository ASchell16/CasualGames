using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSWeek3._1.Models;

namespace CSWeek3._1.Controllers
{
    public class PlayerItemsController : Controller
    {
        private CSWeek3_1Context db = new CSWeek3_1Context();

        // GET: PlayerItems
        public ActionResult Index()
        {
            var playerItems = db.PlayerItems.Include(p => p.Item).Include(p => p.Player);
            return View(playerItems.ToList());
        }

        // GET: PlayerItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerItems playerItems = db.PlayerItems.Find(id);
            if (playerItems == null)
            {
                return HttpNotFound();
            }
            return View(playerItems);
        }

        // GET: PlayerItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ID", "iconUrl");
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "Username");
            return View();
        }

        // POST: PlayerItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlayerID,ItemID,Quantity")] PlayerItems playerItems)
        {
            if (ModelState.IsValid)
            {
                db.PlayerItems.Add(playerItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ID", "iconUrl", playerItems.ItemID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "Username", playerItems.PlayerID);
            return View(playerItems);
        }

        // GET: PlayerItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerItems playerItems = db.PlayerItems.Find(id);
            if (playerItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "iconUrl", playerItems.ItemID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "Username", playerItems.PlayerID);
            return View(playerItems);
        }

        // POST: PlayerItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlayerID,ItemID,Quantity")] PlayerItems playerItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "iconUrl", playerItems.ItemID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "Username", playerItems.PlayerID);
            return View(playerItems);
        }

        // GET: PlayerItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerItems playerItems = db.PlayerItems.Find(id);
            if (playerItems == null)
            {
                return HttpNotFound();
            }
            return View(playerItems);
        }

        // POST: PlayerItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerItems playerItems = db.PlayerItems.Find(id);
            db.PlayerItems.Remove(playerItems);
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
