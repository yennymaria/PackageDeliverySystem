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
    public class CityController : Controller
    {
        private ICityApplication _app = new CityImpApplication();
        private IDepartmentApplication _dtapp = new DepartmentImpApplication();

        // GET: City
        public ActionResult Index(string filter = "")
        {
            CityGUIMapper mapper = new CityGUIMapper();
            IEnumerable<CityModel> list = mapper.DTOToModelMapper(_app.getRecordList(filter));
            return View(list);
        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityGUIMapper mapper = new CityGUIMapper();
            CityModel CityModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (CityModel == null)
            {
                return HttpNotFound();
            }
            return View(CityModel);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            IEnumerable<DepartmentDTO> dtList = this._dtapp.getRecordList(string.Empty);
            DepartmentGUIMapper dtMapper = new DepartmentGUIMapper();
            CityModel model = new CityModel()
            {
                DepartmentList = dtMapper.DTOToModelMapper(dtList)
            };
            return View(model);
        }

        // POST: City/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Id_Department")] CityModel CityModel)
        {
            if (ModelState.IsValid)
            {
                CityGUIMapper mapper = new CityGUIMapper();
                CityDTO response = _app.createRecord(mapper.ModelToDTOMapper(CityModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(CityModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(CityModel);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityGUIMapper mapper = new CityGUIMapper();
            CityModel CityModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<DepartmentDTO> dtList = this._dtapp.getRecordList(string.Empty);
            DepartmentGUIMapper dtMapper = new DepartmentGUIMapper();
            CityModel.DepartmentList = dtMapper.DTOToModelMapper(dtList);
            if (CityModel == null)
            {
                return HttpNotFound();
            }
            return View(CityModel);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Id_Department")] CityModel CityModel)
        {
            if (ModelState.IsValid)
            {
                CityGUIMapper mapper = new CityGUIMapper();
                CityDTO response = _app.updateRecord(mapper.ModelToDTOMapper(CityModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.succesMessage;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(CityModel);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityGUIMapper mapper = new CityGUIMapper();
            CityModel CityModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (CityModel == null)
            {
                return HttpNotFound();
            }
            return View(CityModel);
        }

        // POST: City/Delete/5
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