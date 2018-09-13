﻿using ProyectoEmbarques.Models;
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
        [Required(ErrorMessage = "No.Parte requerida.")]
        public int ProductID { get; set; }

        [Display(Name = "Attn")]
        [Required(ErrorMessage = "Nombre del Cliente requerida.")]
        public int ClientID { get; set; }

        [Display(Name = "No. de Caja Piezas")]
        public decimal RecordPieceBoxNo { get; set; }

        [Display(Name = "Tracking ID")]
        public Nullable<decimal> RecordTrackingId { get; set; }

        [Display(Name = "Serial#")]
        public Nullable<decimal> RecordSerialNo { get; set; }

        [Display(Name = "QTY")]
        [Required(ErrorMessage = "Cantidad requerida.")]
        public int RecordQuantity { get; set; }

        [Display(Name = "Date(D/M/Y)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd MMM yyyy}")]
        public System.DateTime RecordDate { get; set; }

        [Display(Name = "Fedex Tracking ")]
        public decimal RecordFedexTracking { get; set; }

        [Display(Name = "No. Caja CD")]
        public decimal RecordControlBoxNo { get; set; }

        [Display(Name = "Tipo de Embarque")]
        public int ShipmentTypeID { get; set; }

        [Display(Name = "Retrabajado")]
        public string RecordRework { get; set; }

        [UIHint("Transferible")]
        public string RecordTransfer { get; set; }
       
        [Display(Name = "Sello de Seguridad1")]
        [Required(ErrorMessage = "Sello de Seguridad requerido.")]
        public string RecordSeguritySeal1 { get; set; }

        [Display(Name = "Sello de Seguridad2")]
        [Required(ErrorMessage = "Sello de Seguridad requerido.")]
        public string RecordSeguritySeal2 { get; set; }

        [Display(Name = "Sello de Seguridad3")]
        [Required(ErrorMessage = "Sello de Seguridad requerido.")]
        public string RecordSeguritySeal3 { get; set; }

        [Display(Name = "Sello de Seguridad4")]
        [Required(ErrorMessage = "Sello de Seguridad requerido.")]
        public string RecordSeguritySeal4 { get; set; }

        [Display(Name = "Job #")]
        public Nullable<decimal> RecordWorkOrder { get; set; }

        [Display(Name = "Comentario")]
        [StringLength(250, ErrorMessage = "La descripción de la instrucción, no debe de tener mas de 250 caracteres.")]
        public string RecordComment { get; set; }

        [Display(Name = "Comentario1")]
        [StringLength(250, ErrorMessage = "La descripción de la instrucción, no debe de tener mas de 250 caracteres.")]
        public string RecordComment1 { get; set; }

        [Display(Name = "Comentario2")]
        [StringLength(250, ErrorMessage = "La descripción de la instrucción, no debe de tener mas de 250 caracteres.")]
        public string RecordComment2 { get; set; }

        [Display(Name ="FAI(PrimeraPieza)")]
        public string RecordFAI { get; set; }

        [Display(Name = "Tipo de Servicio")]
        [Required(ErrorMessage = "Tipo de Servicio requerido.")]
        public string RecordServiceType { get; set; }

        public virtual CatalogShipmentTypeViewModel CatalogShipmentType { get; set; }
        public virtual ClientesViewModel Clients { get; set; }
        public virtual Shipping_Catalog_ProductsViewModel Shipping_Catalog_Products { get; set; }
    }
}