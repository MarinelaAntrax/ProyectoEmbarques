using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    //[Authorize(Roles = "IT,AppAdminEMBARQUES")]
    public  class Shipping_RecordsController : Controller{

        private EnsamblesRealizadosService _ServiceSR;

        public Shipping_RecordsController()
        {
            _ServiceSR = new EnsamblesRealizadosService();
        }

        private MaterialShippingControlEntities db = new MaterialShippingControlEntities();

        public ActionResult Create()
        {
            Shipping_RecordsViewModel Perro = _ServiceSR.TakeLast();
            return View(Perro);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_ServiceSR.Read().ToDataSourceResult(request));
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,ClientID,ProductID,RecordQuantity,RecordDate,RecordFedexTracking,RecordControlBoxNo,RecordPieceBoxNo,ShipmentTypeID,RecordServiceType,RecordComment,RecordWorkOrder,RecordSerialNo,RecordTrackingId,RecordRework,RecordComment1,RecordComment2,RecordFAI,RecordTransfer,RecordSeguritySeal1,")] Shipping_RecordsViewModel Perro)
        {
            bool va1 = false;
            bool va2 = false;
            
            if (Perro != null && ModelState.IsValid)
            {
                if (Perro.RecordWorkOrder != null && !_ServiceSR.WOrderUnik((int)Perro.RecordWorkOrder))
                {/*Si es diferente de nulo y no esta repetido en la BD*/
                    ViewBag.showMs = 3;//WorkOrder
                    return View("Create", Perro);
                }
                else {
                    va1 = true;
                }

                if (Perro.RecordTrackingId != null && !_ServiceSR.TID((int)Perro.RecordTrackingId))
                {
                    /*Si es diferente de nulo y no esta repetido en la BD*/
                    ViewBag.showMs = 4;
                    return View("Create", Perro);
                }
                else {
                    va2 = true;
                }

                if (va1 && va2)
                {
                    ViewBag.showMs = 1;
                    _ServiceSR.Create(Perro);
                    ModelState.Clear();
                    Perro = _ServiceSR.TakeLast();
                    return View("Create",Perro);
                }
                else {
                    return View("Create", Perro);
                }
            }
            else
            {
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

