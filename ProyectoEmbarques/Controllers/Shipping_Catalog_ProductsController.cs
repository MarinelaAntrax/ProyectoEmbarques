using System;
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
    public class Shipping_Catalog_ProductsController : Controller
    {
        private Shipping_Catalog_ProductsService _Service;
        public Shipping_Catalog_ProductsController()
        {
            _Service = new Shipping_Catalog_ProductsService();
        }
        private BAESystemsGuaymasEntities db = new BAESystemsGuaymasEntities();
        // GET: Shipping_Catalog_Products
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_Service.Read().ToDataSourceResult(request));
        }
        public ActionResult getAreaName(int id)
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
        // POST: Shipping_Catalog_Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,AreaID,ProductName,ProductInternalArea,ProductType")] Shipping_Catalog_Products Products)
        {
            if (ModelState.IsValid)
            {
                db.Shipping_Catalog_Products.Add(Products);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(Products);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        } } }
