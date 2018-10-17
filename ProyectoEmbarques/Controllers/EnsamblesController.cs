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

        public EnsamblesController()
        {
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Shipping_Catalog_Products Products)
        {
            try
            {
                if (_EnsamblesService != null && ModelState.IsValid)
                {
                    _EnsamblesService.Update(Products);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY constraint"))
                {
                    ModelState.AddModelError("", "El Nombre de la compañia que introdujo ya existe en la base de datos.");
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return Json(new[] { Products }.ToDataSourceResult(request, ModelState));
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