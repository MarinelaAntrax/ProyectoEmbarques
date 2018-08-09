using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public class TipoEmbarqueController : Controller
    {
        private TipoEmbarqueService _Service;
        public TipoEmbarqueController()
        {
             _Service = new TipoEmbarqueService();
        }
        // GET: TipoEmbarque
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