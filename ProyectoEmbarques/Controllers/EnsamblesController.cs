using ProyectoEmbarques.Models.Services;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;

namespace ProyectoEmbarques.Controllers
{
    [Authorize(Roles = "IT,AppAdminEMBARQUES")]
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