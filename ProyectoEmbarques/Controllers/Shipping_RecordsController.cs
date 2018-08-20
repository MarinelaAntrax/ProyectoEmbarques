using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public  class Shipping_RecordsController : Controller
        {
        private EnsamblesRealizadosService _Service;
        public Shipping_RecordsController()
        {
            _Service = new EnsamblesRealizadosService();
        }
        private BAESystemsGuaymasEntities db = new BAESystemsGuaymasEntities();
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_Service.Read().ToDataSourceResult(request));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,ClientID,ProductID,RecordQuantity,RecordDate,RecordFedexTracking,RecordControlBoxNo,RecordPieceBoxNo,ShipmentTypeID,RecordServiceType,RecordComment,RecordWorkOrder,RecordSerialNo,RecordTrackingId,RecordRework,RecordComment1,RecordComment2,RecordFAI,RecordTransfer,RecordSeguritySeal1,RecordSeguritySeal2,RecordSeguritySeal3,RecordSeguritySeal4,")] Shipping_Records Perro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Shipping_Records.Add(Perro);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                return View(Perro);
            }
            catch (DbEntityValidationException ex)
            {
                Debug.WriteLine("Error: "+ex);
            }
            return View(Perro);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        } } }

