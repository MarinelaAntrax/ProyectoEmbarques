using Kendo.Mvc.UI;
using ProyectoEmbarques.Models;
using System.Linq;
using System.Web.Mvc;
using ProyectoEmbarques.Models.Services;
using controlEmbar.Models;

namespace ProyectoEmbarques.Controllers
{
    public class EmbarqueEnsamblesController : Controller
    {

        private ProductosService _PService;

        public EmbarqueEnsamblesController()
        {
            _PService = new ProductosService();
        }

        // GET: EmbarqueEnsamble
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClientFiltering()
        {
            return View();
        }
        public ActionResult InsertarDatos()
        {

            return View();
        }
        public JsonResult GetNoParte(string predic) {//Retorna un json con posibles opciones al combobox Numero de parte
            var variable = new BAESystemsGuaymasEntities();

            var NoParte = variable.Shipping_Catalog_Products.Select(data => new ProductosViewModel
            {
                ProductoID = data.ProductID,
                AreaID = data.AreaID,
                ProductName = data.ProductName,
                ProductInternaArea = data.ProductName,
                ProductType = data.ProductType
            });
            if (!string.IsNullOrEmpty(predic))
            {
                NoParte = NoParte.Where(p => p.ProductName.Contains(predic));
            }
            //ServiceCorrespondiente.MetodoRead,JsonRequestBehavior.allowget
            return Json(NoParte, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetArea(string predic)//Retorna un json con posibles opciones al combobox Areas
        {
            var variable = new BAESystemsGuaymasEntities();

            var Area = variable.Areas.Select(data => new AreasViewModel
            {
                AreaID = data.AreaID,
                AreaName = data.AreaName
               
            });
            if (!string.IsNullOrEmpty(predic))
            {
                Area = Area.Where(p => p.AreaName.Contains(predic));
            }
            return Json(Area, JsonRequestBehavior.AllowGet);
       }


        public JsonResult GetTipoEmbarque(string predic)
        {//Retorna un json con posibles opciones al combobox Tipo de Embarque
            var variable = new BAESystemsGuaymasEntities();

            var TipoEmbarque = variable.ShipmentType.Select(data => new TipoEmbarqueViewModel
            {
                ShipmentTypeID = data.ShipmentTypeID,
                ShipmentType1 = data.ShipmentType1
            });
            if (!string.IsNullOrEmpty(predic))
            {
                TipoEmbarque = TipoEmbarque.Where(p => p.ShipmentType1.Contains(predic));
            }
            //ServiceCorrespondiente.MetodoRead,JsonRequestBehavior.allowget
            return Json(TipoEmbarque, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanias(string predic)//Retorna un json con posibles opciones al combobox Companias
        {
            //Retorna un json con posibles opciones al combobox Tipo de Embarque
                var variable = new BAESystemsGuaymasEntities();

                var Companias = variable.Clients.Select(data => new ClientesViewModel
                {
                    ClienteID = data.ClientID,
                    ClientName = data.ClientName,
                    ClientAddress = data.ClientAddress
                });
                if (!string.IsNullOrEmpty(predic))
                {
                    Companias = Companias.Where(p => p.ClientName.Contains(predic));
                }
            return Json(Companias, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetServicios(string predic)//Retorna un json con posibles opciones al combobox Servicios
        {
            var variable = new BAESystemsGuaymasEntities();

            var Servicios = variable.Shipping_Records.Select(data => new EmbarqueEnsamblesViewModel
            {
                RecordServiceType = data.RecordServiceType

            });
            if (!string.IsNullOrEmpty(predic))
            {
                Servicios = Servicios.Where(p => p.RecordServiceType.Contains(predic));

            }
                return Json(Servicios, JsonRequestBehavior.AllowGet);
        }

        //Create record.
        //[Authorize(Roles = "IT, Quality Supplier")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, EmpleadosViewModel empleado)
        {
            try
            {
                if (empleado != null && ModelState.IsValid)
                {
                    _EmpleadosService.Create(empleado);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY contraint"))
                {
                    ModelState.AddModelError("", "El no. de empleado que introdujo ya existe en la base de datos.");

                }
                else
                {
                    ModelState.AddModelError("", ex.Message);

                }
            }

            return Json(new[] { empleado }.ToDataSourceResult(request, ModelState));
        }

        //ssDelete......................................................................................................................
        public JsonResult ClientFiltering_GetProducts(string text)
        {
            var _BDBaeGuaymas = new BAESystemsGuaymasEntities();


            var products = _BDBaeGuaymas.Shipping_Catalog_Products.Select(product => new ProductosViewModel
            {
                ProductoID = product.ProductID,
                AreaID = product.AreaID,
                ProductName = product.ProductName,
                ProductInternaArea = product.ProductInternalArea,
                ProductType = product.ProductType
            });

            if (!string.IsNullOrEmpty(text))
            {
                products = products.Where(p => p.ProductName.Contains(text));
            }

            return Json(products, JsonRequestBehavior.AllowGet);
        }
        //ssDelete......................................................................................................................
    }
}