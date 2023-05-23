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
    public class VehicleController : Controller
    {
        private IVehicleApplication _app = new VehicleImpApplication();
        private ITransportTypeApplication _dtApp = new TransportTypeImpApplication();

        // GET: Vehicle
        public ActionResult Index(string filter = "")
        {
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            IEnumerable<VehicleModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel VehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (VehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(VehicleModel);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            IEnumerable<TransportTypeDTO> dtList = this._dtApp.getRecordList(string.Empty);
            TransportTypeGUIMapper dtMapper = new TransportTypeGUIMapper();
            VehicleModel model = new VehicleModel()
            {
                TransportTypeList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: Vehicle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Plate,IdTransportType")] VehicleModel VehicleModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.createRecord(mapper.ModelToDTOMapper(VehicleModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(VehicleModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(VehicleModel);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel VehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<TransportTypeDTO> dtList = this._dtApp.getRecordList(string.Empty);
            TransportTypeGUIMapper dtMapper = new TransportTypeGUIMapper();
            VehicleModel.TransportTypeList = dtMapper.DTOToModelMapper(dtList);
            if (VehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(VehicleModel);
        }

        // POST: Vehicle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Plate,IdTransportType")] VehicleModel VehicleModel)
        {
            if (ModelState.IsValid)
            {
                VehicleGUIMapper mapper = new VehicleGUIMapper();
                VehicleDTO response = _app.updateRecord(mapper.ModelToDTOMapper(VehicleModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(VehicleModel);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleGUIMapper mapper = new VehicleGUIMapper();
            VehicleModel VehicleModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (VehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(VehicleModel);
        }

        // POST: Vehicle/Delete/5
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