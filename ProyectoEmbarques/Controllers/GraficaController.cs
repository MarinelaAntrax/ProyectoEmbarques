﻿using ProyectoEmbarques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoEmbarques.Models.Services;
using Kendo.Mvc.UI;

namespace ProyectoEmbarques.Controllers
{
    public class GraficaController : Controller
    {
        MaterialShippingControlEntities BD = new MaterialShippingControlEntities();

        EnsamblesRealizadosService _GraficaAirVSGroundService = new EnsamblesRealizadosService();


        // GET: Grafica
        public ActionResult IndexGrafica()
        {
            return View();
        }

        public ActionResult ReadServiceType([DataSourceRequest] DataSourceRequest request, DateTime fechaInicio, DateTime fechaFinal)
        {
            return Json(_GraficaAirVSGroundService.ReadServiceType(fechaInicio, fechaFinal), JsonRequestBehavior.AllowGet);
        }
    }
}