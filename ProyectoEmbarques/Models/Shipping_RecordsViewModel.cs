using controlEmbar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class Shipping_RecordsViewModel
    {
       
        [ScaffoldColumn(false)]
        public int RecordID { get; set; }
        
        [Display(Name = "No. Parte")]
        [Required(ErrorMessage = "No. de parte requerida.")]
        public int ProductID { get; set; }

        [Display(Name = "Area")]
        public string AreaID { get; set; }

        [Display(Name = "Attn")]
        [Required(ErrorMessage = "Nombre del cliente requerido.")]
        public int ClientID { get; set; }

        [Display(Name = "Org")]
        public string ClientAddress { get; set; }

        [Display(Name = "No. de Caja Piezas")]
        [Required(ErrorMessage = "No. de caja con piezas requerido.")]
        public int RecordPieceBoxNo { get; set; }

        [Display(Name = "Tracking ID")]
        [Required(ErrorMessage = "Tracking de Papeleria requerida.")]
        public string RecordTrackingId { get; set; }

        [Display(Name = "Serial#")]
        public string RecordSerialNo { get; set; }

        [Display(Name = "QTY")]
        [Required(ErrorMessage = "Cantidad requerida.")]
        public int RecordQuantity { get; set; }

        [Display(Name = "Date(D/M/Y)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd MMM yyyy}")]
        public System.DateTime RecordDate { get; set; }

        [Display(Name = "Fedex Tracking ")]
        [Required(ErrorMessage = "Tracking de fedex requerido.")]
        public string RecordFedexTracking { get; set; }

        [Display(Name = "No. Caja CD")]
        [Required(ErrorMessage = "No. de caja con Doc. requerido.")]
        public string RecordControlBoxNo { get; set; }

        [Display(Name = "Tipo de Embarque")]
        [Required(ErrorMessage = "Tipo de Embarque requerido.")]
        public int ShipmentTypeID { get; set; }

        [Display(Name = "Retrabajado")]
        public string RecordRework { get; set; }

        [Display(Name = "Sello de Seguridad1")]
        public string RecordSeguritySeal1 { get; set; }

        [Display(Name = "Sello de Seguridad2")]
        public string RecordSeguritySeal2 { get; set; }

        [Display(Name = "Sello de Seguridad3")]
        public string RecordSeguritySeal3 { get; set; }

        [Display(Name = "Sello de Seguridad4")]
        public string RecordSeguritySeal4 { get; set; }

        [Display(Name = "Job #")]
        public string RecordWorkOrder { get; set; }

        [Display(Name = "Comentario")]
        public string RecordComment { get; set; }

        [Display(Name = "Comentario1")]
        public string RecordComment1 { get; set; }

        [Display(Name = "Comentario2")]
        public string RecordComment2 { get; set; }

        [Display(Name ="FAI(PrimeraPieza)")]
        public string RecordFAI { get; set; }

        [Display(Name = "Tipo de Servicio")]
        [Required(ErrorMessage = "Tipo de servicio requerido.")]
        public string RecordServiceType { get; set; }
        
        public string RecordDescripcion { get; set; }
        public string RecordPeso { get; set; }
        public string RecordObservaciones { get; set; }

        public virtual TipoEmbarqueViewModel CatalogShipmentType { get; set; }
        public virtual ClientesViewModel Clients { get; set; }
        public virtual Shipping_Catalog_ProductsViewModel Shipping_Catalog_Products { get; set; }
    }
}