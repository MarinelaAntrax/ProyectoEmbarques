using ProyectoEmbarques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoEmbarques.Models.Services;
using Kendo.Mvc.UI;
using System.Diagnostics;
using Kendo.Mvc.Extensions;
using System.Data.Entity.Validation;

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
                model.Variable = true;
            }
            else
            {
                model.Variable = false;
            }
           
            return View(model);
        }

        public ActionResult InsertData(int TotalinShip)
        {
            if (!(TotalinShip <= 0)) { 
                try
                {
                    //service.metodo(Total);
                    _ServiceAG.Create(TotalinShip);
                }
                catch (Exception ex) {
                    Debug.WriteLine("la exception es: "+ex.Message);
                }
            }
            return RedirectToAction("IndexGrafica");
        }

        public ActionResult ReadServiceType([DataSourceRequest] DataSourceRequest request, DateTime starDate, DateTime endDate)
        {
            _ServiceAG.Update();

            return Json(_GraficaAirVSGroundService.ReadServiceType(starDate, endDate), JsonRequestBehavior.AllowGet);
        }
       
    }
}