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
    
    public partial class Areas
    {
        public Areas()
        {
            this.Shipping_Catalog_Products = new HashSet<Shipping_Catalog_Products>();
        }
    
        public int AreaID { get; set; }
        public string AreaName { get; set; }
    
        public virtual ICollection<Shipping_Catalog_Products> Shipping_Catalog_Products { get; set; }
    }
}