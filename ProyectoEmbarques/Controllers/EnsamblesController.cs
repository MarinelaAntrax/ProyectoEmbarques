using ProyectoEmbarques.Models.Services;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using System;

namespace ProyectoEmbarques.Controllers
{
    //[Authorize(Roles = "IT,AppAdminEMBARQUES")]
    public class EnsamblesController : Controller
    {
        MaterialShippingControlEntities db = new MaterialShippingControlEntities();

        // GET: Ensambles
        private EnsamblesService _EnsamblesService;
        private Shipping_Catalog_ProductsService _shipping;

        public EnsamblesController()
        {
            _shipping = new Shipping_Catalog_ProductsService();
            _EnsamblesService = new EnsamblesService();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductID,AreaID,ProductName,ProductInternalArea,ProductType")] Shipping_Catalog_Products Products)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Shipping_Catalog_Products.Add(Products);
        //        db.SaveChanges();
        //        return RedirectToAction("Create");
        //    }
        //    return View(Products);
        //}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "AreaID,ProductName,WOrder,WKRMSerie,TIDSerie,ProductType")] Shipping_Catalog_ProductsViewModel Products)
        {
            if (Products.ProductName != null && Products.ProductType != null)
            {
                _shipping.Create(Products);
                ModelState.Clear();
                ViewBag.showMs = 1;
                return View("Index");
            }
            else
            {
                ViewBag.showMs = 2;
                return View("Index", Products);
            }
        }

        public ActionResult FillCombobox()
        {
            return Json(_EnsamblesService.Read(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_EnsamblesService.Read().ToDataSourceResult(request));
        }
    }
}