//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoEmbarques.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatalogShipmentType
    {
        public CatalogShipmentType()
        {
            this.Shipping_Records = new HashSet<Shipping_Records>();
        }
    
        public int ShipmentTypeID { get; set; }
        public string ShipmentType { get; set; }
    
        public virtual ICollection<Shipping_Records> Shipping_Records { get; set; }
    }
}