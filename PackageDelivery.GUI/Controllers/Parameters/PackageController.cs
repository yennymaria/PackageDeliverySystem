﻿using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System;
using PackageDelivery.GUI.Mappers.Parameters;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class PackageController : Controller
    {
        private IPackageApplication _app = new PackageImpApplication();
        private IOfficeApplication _dtapp = new OfficeImpApplication();

        // GET: Package
        public ActionResult Index(string filter = "")
        {
            PackageGUIMapper mapper = new PackageGUIMapper();
            IEnumerable<PackageModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: Package/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel PackageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (PackageModel == null)
            {
                return HttpNotFound();
            }
            return View(PackageModel);
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            IEnumerable<OfficeDTO> dtList = this._dtapp.getRecordList(string.Empty);
            OfficeGUIMapper dtMapper = new OfficeGUIMapper();
            PackageModel model = new PackageModel()
            {
                OfficeList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: Package/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Depth,Width,Height," +
            "Id_Office")] PackageModel PackageModel)
        {
            if (ModelState.IsValid)
            {
                PackageGUIMapper mapper = new PackageGUIMapper();
                PackageDTO response = _app.createRecord(mapper.ModelToDTOMapper(PackageModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(PackageModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(PackageModel);
        }

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel PackageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<OfficeDTO> dtList = this._dtapp.getRecordList(string.Empty);
            OfficeGUIMapper dtMapper = new OfficeGUIMapper();
            PackageModel.OfficeList = dtMapper.DTOToModelMapper(dtList);
            if (PackageModel == null)
            {
                return HttpNotFound();
            }
            return View(PackageModel);
        }

        // POST: Package/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Depth,Width,Height," +
            "Id_Office")] PackageModel PackageModel)
        {
            if (ModelState.IsValid)
            {
                PackageGUIMapper mapper = new PackageGUIMapper();
                PackageDTO response = _app.updateRecord(mapper.ModelToDTOMapper(PackageModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(PackageModel);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel PackageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (PackageModel == null)
            {
                return HttpNotFound();
            }
            return View(PackageModel);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool response = _app.deleteRecordById(id);
            if (response)
            {
                ViewBag.ClassName = ActionMessages.successClass;
                ViewBag.Message = ActionMessages.succesMessage;
                return RedirectToAction("Index");
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View();
        }
    }
}