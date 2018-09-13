using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.Model;
using ProyectoEmbarques.Models.Services;
using System.Diagnostics;
using ProyectoEmbarques.Models;
namespace ProyectoEmbarques.Controllers
{
    
    public class ReportesController : Controller
    {
        BAESystemsGuaymasEntities Entities = new BAESystemsGuaymasEntities();
        public ActionResult Index(){
            return View();
        }
        public ActionResult FillCombobox()
        {
            var FD = new BAESystemsGuaymasEntities().Shipping_Records.Select(client => new
            { RecordFedexTracking = client.RecordFedexTracking.ToString() });
            return Json(FD, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PackingList(string ParametroFedex)
        {
            Debug.WriteLine(ParametroFedex);
            PdfFormatProvider formatProvider = new PdfFormatProvider();
            formatProvider.ExportSettings.ImageQuality = ImageQuality.High;

            byte[] renderedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                RadFixedDocument document = CreateDocument.CreatePDFDocument(decimal.Parse(ParametroFedex));
                formatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, "application/pdf", "PackingList (" + DateTime.Now.ToString() + ").pdf");
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
        public ActionResult ReporteFechaNAgrupadosXLSX(){
            return View();
        }
        public ActionResult DireccionesClientes(){
            return View();
        }
    }
}