//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoEmbarques.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipping_Records
    {
        public int RecordID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int RecordQuantity { get; set; }
        public System.DateTime RecordDate { get; set; }
        public decimal RecordFedexTracking { get; set; }
        public decimal RecordControlBoxNo { get; set; }
        public decimal RecordPieceBoxNo { get; set; }
        public int ShipmentTypeID { get; set; }
        public string RecordServiceType { get; set; }
        public string RecordComment { get; set; }
        public Nullable<decimal> RecordWorkOrder { get; set; }
        public Nullable<decimal> RecordSerialNo { get; set; }
        public Nullable<decimal> RecordTrackingId { get; set; }
        public string RecordRework { get; set; }
        public string RecordComment1 { get; set; }
        public string RecordComment2 { get; set; }
        public string RecordFAI { get; set; }
        public string RecordSeguritySeal1 { get; set; }
        public string RecordSeguritySeal2 { get; set; }
        public string RecordSeguritySeal3 { get; set; }
        public string RecordSeguritySeal4 { get; set; }
        public string RecordTransfer { get; set; }
    
        public virtual CatalogShipmentType CatalogShipmentType { get; set; }
        public virtual Client Client { get; set; }
        public virtual Shipping_Catalog_Products Shipping_Catalog_Products { get; set; }
    }
}
