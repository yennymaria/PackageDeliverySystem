using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Parameters;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class WarehouseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Warehouse
        public ActionResult Index()
        {
            return View(db.WarehouseModels.ToList());
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseModel warehouseModel = db.WarehouseModels.Find(id);
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Direction,Code,Latitude,Longitude,Id_City")] WarehouseModel warehouseModel)
        {
            if (ModelState.IsValid)
            {
                db.WarehouseModels.Add(warehouseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouseModel);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseModel warehouseModel = db.WarehouseModels.Find(id);
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // POST: Warehouse/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Direction,Code,Latitude,Longitude,Id_City")] WarehouseModel warehouseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouseModel);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseModel warehouseModel = db.WarehouseModels.Find(id);
            if (warehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(warehouseModel);
        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WarehouseModel warehouseModel = db.WarehouseModels.Find(id);
            db.WarehouseModels.Remove(warehouseModel);
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
