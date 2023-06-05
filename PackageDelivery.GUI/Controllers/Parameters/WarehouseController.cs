using PackageDelivery.Application.Contracts.DTO.Parameters;
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
    public class WarehouseController : Controller
    {
        private IWarehouseApplication _app = new WarehouseImpApplication();
        private ICityApplication _dtapp = new CityImpApplication();

        // GET: Warehouse
        public ActionResult Index(string filter = "")
        {
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            IEnumerable<WarehouseModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (WarehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(WarehouseModel);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            WarehouseModel model = new WarehouseModel()
            {
                CityList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: Warehouse/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Direction,Code,Latitude,Longitude," +
            "Id_City")] WarehouseModel WarehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.createRecord(mapper.ModelToDTOMapper(WarehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(WarehouseModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(WarehouseModel);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            WarehouseModel.CityList = dtMapper.DTOToModelMapper(dtList);
            if (WarehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(WarehouseModel);
        }

        // POST: Warehouse/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Direction,Code,Latitude,Longitude," +
            "Id_City")] WarehouseModel WarehouseModel)
        {
            if (ModelState.IsValid)
            {
                WarehouseGUIMapper mapper = new WarehouseGUIMapper();
                WarehouseDTO response = _app.updateRecord(mapper.ModelToDTOMapper(WarehouseModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(WarehouseModel);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseGUIMapper mapper = new WarehouseGUIMapper();
            WarehouseModel WarehouseModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (WarehouseModel == null)
            {
                return HttpNotFound();
            }
            return View(WarehouseModel);
        }

        // POST: Warehouse/Delete/5
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