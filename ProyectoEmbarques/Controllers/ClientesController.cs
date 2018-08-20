using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using ProyectoEmbarques.Models.Services;
using System.Linq;
using System.Diagnostics;

namespace ProyectoEmbarques.Controllers
{
    public class ClientesController : Controller
    {
        BAESystemsGuaymasEntities Entities = new BAESystemsGuaymasEntities();
        // GET: Clientes
        private ClientesService _Service;
        public ClientesController()
        {
            _Service = new ClientesService();
        }
        public ActionResult Index()
        {
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
        public ActionResult getCompania(int id)
        {
            var val = (from b in Entities.Clients
                       where b.ClientID == id
                       select b.ClientAddress).FirstOrDefault();
            return Content(val.ToString());
        } } }