using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Core;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class PackageHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PackageHistory
        public ActionResult Index()
        {
            return View(db.PackageHistoryModels.ToList());
        }

        // GET: PackageHistory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageHistoryModel packageHistoryModel = db.PackageHistoryModels.Find(id);
            if (packageHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(packageHistoryModel);
        }

        // GET: PackageHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PackageHistory/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdmissionDate,DepurateDate,Description,Id_Package,Id_Warehouse")] PackageHistoryModel packageHistoryModel)
        {
            if (ModelState.IsValid)
            {
                db.PackageHistoryModels.Add(packageHistoryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packageHistoryModel);
        }

        // GET: PackageHistory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageHistoryModel packageHistoryModel = db.PackageHistoryModels.Find(id);
            if (packageHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(packageHistoryModel);
        }

        // POST: PackageHistory/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdmissionDate,DepurateDate,Description,Id_Package,Id_Warehouse")] PackageHistoryModel packageHistoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packageHistoryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packageHistoryModel);
        }

        // GET: PackageHistory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageHistoryModel packageHistoryModel = db.PackageHistoryModels.Find(id);
            if (packageHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(packageHistoryModel);
        }

        // POST: PackageHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PackageHistoryModel packageHistoryModel = db.PackageHistoryModels.Find(id);
            db.PackageHistoryModels.Remove(packageHistoryModel);
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
