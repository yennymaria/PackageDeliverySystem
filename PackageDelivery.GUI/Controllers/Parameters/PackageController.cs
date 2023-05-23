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
    public class PackageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Package
        public ActionResult Index()
        {
            return View(db.PackageModels.ToList());
        }

        // GET: Package/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageModel packageModel = db.PackageModels.Find(id);
            if (packageModel == null)
            {
                return HttpNotFound();
            }
            return View(packageModel);
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Package/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Depth,Width,Height,Id_Office")] PackageModel packageModel)
        {
            if (ModelState.IsValid)
            {
                db.PackageModels.Add(packageModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packageModel);
        }

        // GET: Package/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageModel packageModel = db.PackageModels.Find(id);
            if (packageModel == null)
            {
                return HttpNotFound();
            }
            return View(packageModel);
        }

        // POST: Package/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Depth,Width,Height,Id_Office")] PackageModel packageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packageModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packageModel);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageModel packageModel = db.PackageModels.Find(id);
            if (packageModel == null)
            {
                return HttpNotFound();
            }
            return View(packageModel);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PackageModel packageModel = db.PackageModels.Find(id);
            db.PackageModels.Remove(packageModel);
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
