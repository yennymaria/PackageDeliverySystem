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
    public class OfficeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Office
        public ActionResult Index()
        {
            return View(db.OfficeModels.ToList());
        }

        // GET: Office/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeModel officeModel = db.OfficeModels.Find(id);
            if (officeModel == null)
            {
                return HttpNotFound();
            }
            return View(officeModel);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Direction,Code,CellPhone,Latitude,Longitude,Id_City")] OfficeModel officeModel)
        {
            if (ModelState.IsValid)
            {
                db.OfficeModels.Add(officeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officeModel);
        }

        // GET: Office/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeModel officeModel = db.OfficeModels.Find(id);
            if (officeModel == null)
            {
                return HttpNotFound();
            }
            return View(officeModel);
        }

        // POST: Office/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Direction,Code,CellPhone,Latitude,Longitude,Id_City")] OfficeModel officeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officeModel);
        }

        // GET: Office/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeModel officeModel = db.OfficeModels.Find(id);
            if (officeModel == null)
            {
                return HttpNotFound();
            }
            return View(officeModel);
        }

        // POST: Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            OfficeModel officeModel = db.OfficeModels.Find(id);
            db.OfficeModels.Remove(officeModel);
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
