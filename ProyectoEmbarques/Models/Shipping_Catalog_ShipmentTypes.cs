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
    
    public partial class Shipping_Catalog_ShipmentTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipping_Catalog_ShipmentTypes()
        {
            this.Shipping_Records = new HashSet<Shipping_Records>();
        }
    
        public int ShipmentTypeID { get; set; }
        public string ShipmentType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipping_Records> Shipping_Records { get; set; }
    }
}
