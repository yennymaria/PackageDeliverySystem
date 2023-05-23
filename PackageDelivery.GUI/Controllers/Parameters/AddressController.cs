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
    public class AddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Address
        public ActionResult Index()
        {
            return View(db.AddressModels.ToList());
        }

        // GET: Address/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = db.AddressModels.Find(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Current,StreetType,Number,PropertyType,Neighborhood,Observations,Id_Person,Id_City")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                db.AddressModels.Add(addressModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addressModel);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = db.AddressModels.Find(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Address/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Current,StreetType,Number,PropertyType,Neighborhood,Observations,Id_Person,Id_City")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressModel);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressModel addressModel = db.AddressModels.Find(id);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AddressModel addressModel = db.AddressModels.Find(id);
            db.AddressModels.Remove(addressModel);
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
