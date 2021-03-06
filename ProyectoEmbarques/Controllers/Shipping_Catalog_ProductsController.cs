﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Diagnostics;
namespace ProyectoEmbarques.Controllers
{
    //[Authorize(Roles = "IT,AppAdminEMBARQUES")]
    public class Shipping_Catalog_ProductsController : Controller
    {
        MaterialShippingControlEntities db = new MaterialShippingControlEntities();
        AreasService _Areas = new AreasService();
        VIEWDATAService _ViewData = new VIEWDATAService();
        private Shipping_Catalog_ProductsService _Service;
        public Shipping_Catalog_ProductsController()
        {
            _Service = new Shipping_Catalog_ProductsService();
        }

        // GET: Shipping_Catalog_Products
        public ActionResult Index() {
            return View();
        }

        public ActionResult GetMaxControlBox()
        {
            decimal Max = 0;
            try
            {
                Max = (db.Shipping_Records.Max(max => max.RecordControlBoxNo));
            }


            catch (Exception ex)
            {
                Debug.WriteLine("Exepcion controlada por el usuario: " + ex);
            }
            return Content(Max.ToString());
        }

        public ActionResult GetLastClient()
        {
            var Max = (db.Shipping_Records.Select(sel => new { sel.ClientID, sel.RecordID }).OrderByDescending(max => max.RecordID));

            return Content(Max.ToString());
        }

        public ActionResult GetMaxFedexTracking()
        {
            decimal Max = 0;
            try
            {
                Max = (db.Shipping_Records.Max(max => max.RecordFedexTracking));
            }
                catch (Exception ex)
            {
                Debug.WriteLine("Exepcion controlada por el usuario: " + ex);
            }
            return Content(Max.ToString());
        }

        public ActionResult GetMaxPieceBoxNo()
        {
            decimal Max = 0;
            try
            {
                Max = (db.Shipping_Records.Max(max => max.RecordPieceBoxNo));
            }
                catch (Exception ex)
            {
                Debug.WriteLine("Exepcion controlada por el usuario: " + ex);
            }
            return Content(Max.ToString());
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_Service.Read().ToDataSourceResult(request));
        }

        public ActionResult GetAreaName(int id)
        {
            var idArea = (from b in db.Shipping_Catalog_Products
                       where b.ProductID == id
                       select b.AreaID).FirstOrDefault();
            var result = (from x in db.Areas
                          where x.AreaID == idArea
                          select x.AreaName).FirstOrDefault();
            return Content(result.ToString());
        }

        // GET: Shipping_Catalog_Products/Create
        public ActionResult FillCombobox()
        {
            return Json(_Service.Read(), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Shipping_Catalog_ProductsViewModel Products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Service.Update(Products);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY constraint"))
                {
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return Json(new[] { Products }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult FillComboboxAreas()
        {
            return Json(_Areas.Read(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FillComboboxViewData()
        {
            return Json(_ViewData.Read(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _Service.Dispose();
            base.Dispose(disposing);
        }

    }
}

