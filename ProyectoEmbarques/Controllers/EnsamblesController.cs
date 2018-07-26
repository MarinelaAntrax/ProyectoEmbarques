using ProyectoEmbarques.Models.Services;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;


namespace ProyectoEmbarques.Controllers
{
    public class EnsamblesController : Controller
    {
       
            // GET: Ensambles

            private EnsamblesService _EnsamblesService;

            public EnsamblesController()
            {
                _EnsamblesService = new EnsamblesService();
            }

            public ActionResult Index()
            {
                return View();
            }

            //Load data to a grid
            public ActionResult Read([DataSourceRequest] DataSourceRequest request)
            {
                return Json(_EnsamblesService.Read().ToDataSourceResult(request));

            }
        }
}