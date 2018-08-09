using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
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
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_SumarioEmbarquesService.Read().ToDataSourceResult(request));

        }
    }
}