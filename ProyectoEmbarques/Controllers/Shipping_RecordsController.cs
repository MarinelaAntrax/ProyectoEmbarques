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
        public ActionResult Create([Bind(Include = "RecordID,ClientID,ProductID,RecordQuantity,RecordDate,RecordFedexTracking,RecordControlBoxNo,RecordPieceBoxNo,ShipmentTypeID,RecordServiceType,RecordComment,RecordWorkOrder,RecordSerialNo,RecordTrackingId,RecordRework,RecordComment1,RecordComment2,RecordFAI,RecordSeguritySeal1,RecordSeguritySeal2,RecordSeguritySeal3,RecordSeguritySeal4,")] Shipping_Records Perro)
        {
            //Debug.WriteLine(Perro.RecordID + "--" +
            //    Perro.ClientID + "--" +
            //    Perro.ProductID + "--" +
            //    Perro.RecordQuantity + "--" +
            //    Perro.RecordDate + "--" +
            //    Perro.RecordFedexTracking + "--" +
            //    Perro.RecordControlBoxNo + "--" +
            //    Perro.RecordPieceBoxNo + "--" +
            //    Perro.ShipmentTypeID + "--" +
            //    Perro.RecordServiceType + "--" +
            //    Perro.RecordComment + "--" +
            //    Perro.RecordWorkOrder + "--" +
            //    Perro.RecordSerialNo + "--" +
            //    Perro.RecordTrackingId + "--" +
            //    Perro.RecordRework + "--" +
            //    Perro.RecordComment1 + "--" +
            //    Perro.RecordComment2 + "--" +
            //    Perro.RecordFAI + "--" +
            //    Perro.RecordSeguritySeal1 + "--" +
            //    Perro.RecordSeguritySeal2 + "--" +
            //    Perro.RecordSeguritySeal3 + "--" +
            //    Perro.RecordSeguritySeal4 + "--");
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
            //ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", Perro.ClientID);
            //ViewBag.ShipmentTypeID = new SelectList(db.CatalogShipmentType, "ShipmentTypeID", "ShipmentType", Perro.ShipmentTypeID);
            //ViewBag.ProductID = new SelectList(db.Shipping_Catalog_Products, "ProductID", "ProductName", Perro.ProductID);
            return View(Perro);
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

