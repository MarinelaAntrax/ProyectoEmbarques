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

        // GET: Shipping_Catalog_Products/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Shipping_Catalog_Products shipping_Catalog_Products = await db.Shipping_Catalog_Products.FindAsync(id);
        //    if (shipping_Catalog_Products == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(shipping_Catalog_Products);
        //}
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
        /*
        // GET: Shipping_Catalog_Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping_Catalog_ProductsViewModel shipping_Catalog_Products = await db.Shipping_Catalog_Products.FindAsync(id);
            if (shipping_Catalog_Products == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", shipping_Catalog_Products.AreaID);
            return View(shipping_Catalog_Products);
        }
        // POST: Shipping_Catalog_Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,AreaID,ProductName,ProductInternalArea,ProductType")] Shipping_Catalog_ProductsViewModel shipping_Catalog_Products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipping_Catalog_Products).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", shipping_Catalog_Products.AreaID);
            return View(shipping_Catalog_Products);
        }
        // GET: Shipping_Catalog_Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping_Catalog_Products shipping_Catalog_Products = await db.Shipping_Catalog_Products.FindAsync(id);
            if (shipping_Catalog_Products == null)
            {
                return HttpNotFound();
            }
            return View(shipping_Catalog_Products);
        }
        // POST: Shipping_Catalog_Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Shipping_Catalog_Products shipping_Catalog_Products = await db.Shipping_Catalog_Products.FindAsync(id);
            db.Shipping_Catalog_Products.Remove(shipping_Catalog_Products);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        */
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
