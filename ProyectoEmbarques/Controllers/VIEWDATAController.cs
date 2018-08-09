using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public class VIEWDATAController : Controller
    {
        // GET: VIEWDATA
        private VIEWDATAService _Service;
        public VIEWDATAController()
        {
            _Service = new VIEWDATAService();
        }
   
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