using controlEmbar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class EmbarqueEnsamblesViewModel
    {

        internal Shipping_Catalog_Products Shop;

        public EmbarqueEnsamblesViewModel()
        { }

        public int RecordID { get; set; }

        [Display(Name = "No. Parte.")]
        [Required(ErrorMessage = "No. de parte requerida.")]
        public int ProductID { get; set; }

        [Display(Name = "Shop")]
        [Required(ErrorMessage = "Nombre del area requerida.")]
        public string Areas { get; set; }

        [Display(Name = "Attn")]
        [Required(ErrorMessage = "Nombre del cliente requerido.")]
        public int ClientID { get; set; }

        [Display(Name = "Org")]
        [Required(ErrorMessage = "Nombre de la organizacion requerido.")]
        public string Compañia { get; set; }

        [Display(Name = "Job #")]
        [Required(ErrorMessage = "No. de caja con piezas requerido.")]
        public int RecordPieceBoxNo { get; set; }

        [Display(Name = "Tracking ID")]
        [Required(ErrorMessage = "Tracking de papeleria requerido.")]
        public string RecordTrackingId { get; set; }

        [Display(Name = "No. de Serie.")]
        [Required(ErrorMessage = "No. de serie requerido.")]
        public byte[] RecordSerialNo { get; set; }

        [Display(Name = "QTY")]
        [Required(ErrorMessage = "Cantidad requerida.")]
        public byte RecordQuantity { get; set; }

        [Display(Name = "Fecha de embarque")]
        [Required(ErrorMessage = "Fecha requerida.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public System.DateTime RecordDate { get; set; }

        [Display(Name = "Tracking de fedex")]
        [Required(ErrorMessage = "Tracking de fedex requerido.")]
        [StringLength(20, ErrorMessage = "La guia no puede ser mayor a 20 digitos.")]
        public string RecordTrackingFedex { get; set; }

        [Display(Name = "No. de Caja con Documento")]
        [Required(ErrorMessage = "No. de caja con documento requerido.")]
        public string RecordControlBoxNo { get; set; }

        [Display(Name = "Tipo de Embarque")]
        [Required(ErrorMessage = "Tipo de Embarque requerido.")]
        public int ShipmentTypeID { get; set; }

        [Display(Name = "No. del producto retrabajado")]
        public string RecordRework { get; set; }

        [Display(Name = "Sello de Seguridad")]
        [Required(ErrorMessage = "No. del sello de seguridad requerido.")]
        public byte[] RecordSeguritySeal { get; set; }
        
        [Display(Name = "Orden del Trabajo")]
        public string RecordWorkOrder { get; set; }

        [Display(Name = "Comentario")]
        [StringLength(200, ErrorMessage = "La descripción de la instrucción, no debe de tener mas de 200 caracteres.")]
        public string RecordComment { get; set; }

        [Display(Name = "Comentario1")]
        [StringLength(200, ErrorMessage = "La descripción de la instrucción, no debe de tener mas de 200 caracteres.")]
        public string RecordComment1 { get; set; }

        [Display(Name = "Comentario2")]
        [StringLength(200, ErrorMessage = "La descripción de la instrucción, no debe de tener mas de 200 caracteres.")]
        public string RecordComment2 { get; set; }
        
        [Display(Name = "Tipo de Servicio")]
        [Required(ErrorMessage = "Tipo de servicio requerido.")]
        public string RecordServiceType { get; set; }

        public virtual TipoEmbarqueViewModel ShipmentType { get; set; }
        public virtual ClientesViewModel Clients { get; set; }
        public virtual ProductosViewModel Shipping_Catalogo_Products { get; set; }

    }
}