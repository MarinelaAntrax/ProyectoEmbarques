using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoEmbarques.Controllers
{
    [Authorize(Roles = "IT,AppAdminEMBARQUES")]
    public partial class EnsamblesRealizadosController : Controller
    {
        MaterialShippingControlEntities BD = new MaterialShippingControlEntities();

        private EnsamblesRealizadosService _SumarioEmbarquesService;

        public EnsamblesRealizadosController()
        {
            _SumarioEmbarquesService = new EnsamblesRealizadosService();
        }

        public ActionResult Index()
        {

            return View();
        }

        //Load data to a grid
        public ActionResult Read([DataSourceRequest] DataSourceRequest request, DateTime starDate, DateTime endDate)
        {
            return Json(_SumarioEmbarquesService.Read(starDate, endDate).OrderByDescending(ord=>ord.RecordID).ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Shipping_RecordsViewModel Datos)
        {
            try
            {
                _SumarioEmbarquesService.Update(Datos);
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                Debug.WriteLine("ErrorMessage: " + ex.EntityValidationErrors);
                return RedirectToAction("Index");
            }
        }
             [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, Shipping_RecordsViewModel Datos)
        {
            RouteValueDictionary routeValues;

            _SumarioEmbarquesService.Destroy(Datos);

            routeValues = this.GridRouteValues();

            return Json(new[] { Datos }.ToDataSourceResult(request, ModelState));
        }

    }   
    
}