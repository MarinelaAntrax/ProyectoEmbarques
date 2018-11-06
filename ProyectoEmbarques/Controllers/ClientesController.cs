using System.Web.Mvc;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System.Linq;
using System;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace ProyectoEmbarques.Controllers
{
    //[Authorize(Roles = "IT,AppAdminEMBARQUES")]
    public class ClientesController : Controller
    {
        MaterialShippingControlEntities Entities = new MaterialShippingControlEntities();

        // GET: Clientes
        private ClientesService _Service;

        public ClientesController()
        {
            _Service = new ClientesService();
        }

        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }

        public ActionResult FillCombobox()
        {
            return Json(_Service.Read(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_Service.Read().ToDataSourceResult(request));
        }

        public ActionResult GetCompania(int id)
        {
            var val = (from b in Entities.Clients
                       where b.ClientID == id
                       select b.ClientCompany).FirstOrDefault();
            return Content(val.ToString());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ClientesViewModel clientes)
        {
            try
            {
                if (clientes != null && ModelState.IsValid)
                {
                    _Service.Create(clientes);
                    ViewBag.showSuccessAlert = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY contraint"))
                {

                }
                else
                {
                    ModelState.AddModelError("", ex.Message);

                }
            }
            return Json(new[] { clientes }.ToDataSourceResult(request, ModelState));
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ClientesViewModel clientes)
        {
            try
            {
                if (_Service != null && ModelState.IsValid)
                {
                    _Service.Update(clientes);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY constraint"))
                {
                    ModelState.AddModelError("", "El Nombre de la compañia que introdujo ya existe en la base de datos.");
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return Json(new[] { clientes }.ToDataSourceResult(request, ModelState));
        }
    }
}