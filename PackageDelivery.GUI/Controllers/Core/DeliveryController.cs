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
    public class DeliveryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Delivery
        public ActionResult Index()
        {
            return View(db.DeliveryModels.ToList());
        }

        // GET: Delivery/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // GET: Delivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delivery/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeliveryDate,Price,Id_DestinationAddress,Id_Package,Id_DeliveryStatus,Id_Sender,Id_TransportType")] DeliveryModel deliveryModel)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryModels.Add(deliveryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryModel);
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // POST: Delivery/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeliveryDate,Price,Id_DestinationAddress,Id_Package,Id_DeliveryStatus,Id_Sender,Id_TransportType")] DeliveryModel deliveryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryModel);
        }

        // GET: Delivery/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // POST: Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            db.DeliveryModels.Remove(deliveryModel);
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
