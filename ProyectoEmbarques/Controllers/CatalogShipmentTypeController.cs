using ProyectoEmbarques.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Controllers
{
    public class CatalogShipmentTypeController : Controller
    {
        private CatalogShipmentTypeService _Service;
        public CatalogShipmentTypeController()
        {
             _Service = new CatalogShipmentTypeService();
        }
        // GET: TipoEmbarque
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FillCombobox()
        {
            return Json(_Service.Read(), JsonRequestBehavior.AllowGet);
        } } }