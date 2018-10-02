using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public  class Shipping_RecordsController : Controller{
        private EnsamblesRealizadosService _Service;
        private EnsamblesRealizadosService _ServiceSR;

        public Shipping_RecordsController()
        {
            _ServiceSR = new EnsamblesRealizadosService();
            _Service = new EnsamblesRealizadosService();
        }

        private MaterialShippingControlEntities db = new MaterialShippingControlEntities();

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
        public ActionResult Create([Bind(Include = "RecordID,ClientID,ProductID,RecordQuantity,RecordDate,RecordFedexTracking,RecordControlBoxNo,RecordPieceBoxNo,ShipmentTypeID,RecordServiceType,RecordComment,RecordWorkOrder,RecordSerialNo,RecordTrackingId,RecordRework,RecordComment1,RecordComment2,RecordFAI,RecordTransfer,RecordSeguritySeal1,RecordSeguritySeal2,RecordSeguritySeal3,RecordSeguritySeal4,")] Shipping_RecordsViewModel Perro)
        {
            if (Perro != null && ModelState.IsValid){
                if (Perro.RecordTrackingId != null || Perro.RecordTrackingId !=0)
                {
                    var P = _ServiceSR.One(w => w.RecordTrackingId == Perro.RecordTrackingId);
                    if (P != null)
                    {
                        ViewBag.showMs = 3;
                        return View("Create", Perro);
                    }
                }
                if (Perro.RecordWorkOrder != null || Perro.RecordWorkOrder != 0)
                {
                    var W = _ServiceSR.One(w => w.RecordWorkOrder == Perro.RecordWorkOrder);
                    if (W != null)
                    {
                        ViewBag.showMs = 4;
                        return View("Create", Perro);
                    }
                }

                _Service.Create(Perro);
                ModelState.Clear();
                ViewBag.showMs = 1;
                return View("Create");
            }else{
                ViewBag.showMs = 2;
                return View("Create", Perro);
            }

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

