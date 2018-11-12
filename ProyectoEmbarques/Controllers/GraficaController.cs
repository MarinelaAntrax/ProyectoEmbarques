using ProyectoEmbarques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoEmbarques.Models.Services;
using Kendo.Mvc.UI;
using System.Diagnostics;

namespace ProyectoEmbarques.Controllers
{
    //[Authorize(Roles = "IT,AppAdminEMBARQUES")]
    public class GraficaController : Controller
    {
        MaterialShippingControlEntities BD = new MaterialShippingControlEntities();
        AirGroundService _ServiceAG = new AirGroundService();
        EnsamblesRealizadosService _GraficaAirVSGroundService = new EnsamblesRealizadosService();


        // GET: Grafica
        public ActionResult IndexGrafica()
        {
            AirGroundViewModel model= new AirGroundViewModel();

            var consulta = BD.GraficaAirGround.Where(w => w.FechaDia.Day == DateTime.Today.Day && w.FechaDia.Month == DateTime.Today.Month && w.FechaDia.Year == DateTime.Today.Year)
                .FirstOrDefault();
            if (consulta == null)
            {
                model.variable = true;
            }
            else
            {
                model.variable = false;
            }
           
            return View(model);
        }

        public ActionResult InsertData(int Total)
        {
            try
            {
                //service.metodo(Total);
                _ServiceAG.Create(Total);
            }
            catch (Exception ex) {
                Debug.WriteLine("la exception es: "+ex.Message);
            }

            return RedirectToAction("IndexGrafica");
        }

        public ActionResult ReadServiceType([DataSourceRequest] DataSourceRequest request, DateTime starDate, DateTime endDate)
        {
            return Json(_GraficaAirVSGroundService.ReadServiceType(starDate, endDate), JsonRequestBehavior.AllowGet);
        }
    }
}