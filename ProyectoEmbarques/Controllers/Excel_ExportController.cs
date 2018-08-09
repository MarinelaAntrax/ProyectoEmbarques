using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using System;
using ProyectoEmbarques.Models.Services;

namespace ProyectoEmbarques.Controllers
{
    public partial class Excel_ExportController : Controller
    {
        private EnsamblesRealizadosService _EmbarquesService;

        public Excel_ExportController()
        {
            _EmbarquesService = new EnsamblesRealizadosService();
        }
        // GET: Excel_Export
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Excel_Export_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_EmbarquesService.Read().ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string xlsx, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, "application/xlsx", "EmbarquesCantidadRealizadaDiariamente.XLSX");
        }
    }
}
