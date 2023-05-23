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
    public class DeliveryStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeliveryStatus
        public ActionResult Index()
        {
            return View(db.DeliveryStatusModels.ToList());
        }

        // GET: DeliveryStatus/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatusModel deliveryStatusModel = db.DeliveryStatusModels.Find(id);
            if (deliveryStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStatusModel);
        }

        // GET: DeliveryStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryStatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DeliveryStatusModel deliveryStatusModel)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryStatusModels.Add(deliveryStatusModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryStatusModel);
        }

        // GET: DeliveryStatus/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatusModel deliveryStatusModel = db.DeliveryStatusModels.Find(id);
            if (deliveryStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStatusModel);
        }

        // POST: DeliveryStatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DeliveryStatusModel deliveryStatusModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryStatusModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryStatusModel);
        }

        // GET: DeliveryStatus/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryStatusModel deliveryStatusModel = db.DeliveryStatusModels.Find(id);
            if (deliveryStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryStatusModel);
        }

        // POST: DeliveryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DeliveryStatusModel deliveryStatusModel = db.DeliveryStatusModels.Find(id);
            db.DeliveryStatusModels.Remove(deliveryStatusModel);
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
