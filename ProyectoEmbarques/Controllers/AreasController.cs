using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public class AreasController : Controller
    {
        private AreasService _Service;

        public AreasController()
        {
            _Service = new AreasService();
        }

        // GET: Areas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FillCombobox()
        {
            return Json(_Service.Read(), JsonRequestBehavior.AllowGet);
        }
    }
}