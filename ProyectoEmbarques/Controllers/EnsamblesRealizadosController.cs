using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public partial class EnsamblesRealizadosController : Controller
    {
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
            return Json(_SumarioEmbarquesService.Read( starDate, endDate).ToDataSourceResult(request));
        }
       
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request,Shipping_Records Datos)
        {
            Debug.WriteLine("Datos enviados al metodo: "+ Datos);
            try { 
                if (request != null && ModelState.IsValid)
                {

                    _SumarioEmbarquesService.Update(Datos);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY constraint"))
                {
                    ModelState.AddModelError("", "El no. de empleado que introdujo ya existe en la base de datos.");
                    Debug.WriteLine("Excepcion controlada:" + ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return Json(new[] { Datos }.ToDataSourceResult(request, ModelState));
        }
    } }