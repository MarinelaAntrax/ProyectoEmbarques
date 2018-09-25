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

        private MaterialShippingControlEntities db = new MaterialShippingControlEntities();

        public ActionResult Create()
        {
            ViewBag.showMs = 0;
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
            if (Perro != null && ModelState.IsValid)
            {
                _Service.Create(Perro);
                ModelState.Clear();
                ViewBag.showMs = 1;
                return View("Create");
            }
            else {
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

