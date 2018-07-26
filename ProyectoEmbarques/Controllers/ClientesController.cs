using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models.Services;

namespace ProyectoEmbarques.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes

        private ClientesService _ClientesService;

        public ClientesController()
        {
            _ClientesService = new ClientesService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //Load data to a grid
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_ClientesService.Read().ToDataSourceResult(request));

        }
    }
}