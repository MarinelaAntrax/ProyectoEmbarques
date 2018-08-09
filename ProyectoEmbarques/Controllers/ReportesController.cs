using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.Model;

namespace ProyectoEmbarques.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult Index(){
            return View();
        }
        public ActionResult Download_ManifiestoXLSX(){
            return View();
        }
        public ActionResult EmbarquesDiarios_PDF(){
            return View();
        }
        public ActionResult EmbarquesDiarios_Excel(){
            return View();
        }
        public ActionResult EmbarquesHotShot(){
            return View();
        }
        public ActionResult Download_EmbarquesHotShotXLSX(){
            return View();
        }
        public ActionResult ReportesFechaNSerieXLSX(){
            return View();
        }
        public ActionResult ManifiestoNAgrupadosXLSX(){
            return View();
        }
        public ActionResult DireccionesClientes(){
            return View();
        }
    }
}