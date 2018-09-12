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

namespace ProyectoEmbarques.Controllers
{
    public partial class EnsamblesRealizadosController : Controller
    {
        BAESystemsGuaymasEntities BD = new BAESystemsGuaymasEntities();
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
            return Json(_SumarioEmbarquesService.Read(starDate, endDate).ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, Shipping_Records Datos)
        {
            try
            {
                BD.Entry(Datos).State = EntityState.Modified;
                BD.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException ex)
            {
                Debug.WriteLine("ErrorMessage: " + ex.EntityValidationErrors);
                return RedirectToAction("Index");
            }
        }
    }
}