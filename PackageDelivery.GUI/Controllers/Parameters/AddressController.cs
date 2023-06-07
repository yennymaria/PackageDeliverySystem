using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Core;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class AddressController : Controller
    {
        private IAddressApplication _app;
        private ICityApplication _dtapp;
        private IPersonApplication _dt2app;

        public AddressController(IAddressApplication app, ICityApplication dtapp,
            IPersonApplication dt2app)
        {
            this._app = app;
            this._dtapp = dtapp;
            this._dt2app = dt2app;
        }

        // GET: Address
        public ActionResult Index(string filter = "")
        {
            AddressGUIMapper mapper = new AddressGUIMapper();
            IEnumerable<AddressModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel AddressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (AddressModel == null)
            {
                return HttpNotFound();
            }
            return View(AddressModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            IEnumerable<PersonDTO> dt2List = this._dt2app.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            PersonGUIMapper dt2Mapper = new PersonGUIMapper();
            AddressModel model = new AddressModel()
            {
                CityList = dtMapper.DTOToModelMapper(dtList),
                PersonList = dt2Mapper.DTOToModelMapper(dt2List)
            };
            return View(model);
        }

        // POST: Address/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Current,StreetType,Number,PropertyType,Neighborhood," +
            "Observations,Id_Person,Id_City")] AddressModel AddressModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.createRecord(mapper.ModelToDTOMapper(AddressModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(AddressModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(AddressModel);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel AddressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<CityDTO> dtList = this._dtapp.getRecordList(string.Empty);
            IEnumerable<PersonDTO> dt2List = this._dt2app.getRecordList(string.Empty);
            CityGUIMapper dtMapper = new CityGUIMapper();
            PersonGUIMapper dt2Mapper = new PersonGUIMapper();
            AddressModel.CityList = dtMapper.DTOToModelMapper(dtList);
            AddressModel.PersonList = dt2Mapper.DTOToModelMapper(dt2List);
            if (AddressModel == null)
            {
                return HttpNotFound();
            }
            return View(AddressModel);
        }

        // POST: Address/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Current,StreetType,Number,PropertyType,Neighborhood,Observations," +
            "Id_Person,Id_City")] AddressModel AddressModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.updateRecord(mapper.ModelToDTOMapper(AddressModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(AddressModel);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel AddressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (AddressModel == null)
            {
                return HttpNotFound();
            }
            return View(AddressModel);
        }

        // POST: Address/Delete/5
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