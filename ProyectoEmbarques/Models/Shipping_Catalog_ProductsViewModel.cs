using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class Shipping_Catalog_ProductsViewModel
    {
       
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }
        
       
        public int AreaID { get; set; }

        [Display(Name = "P/N")]
        [Required(ErrorMessage = "Nombre del producto requerido.")]
        [StringLength(30, ErrorMessage = "La descripcion del componente no puede ser mayor de 30 caracteres.")]
        public string ProductName { get; set; }

        [Display(Name = "Area Interna del Producto")]
        [Required(ErrorMessage = "Area Interna requerida.")]
        public string ProductInternaArea { get; set; }

        [Display(Name = "Tipo del Producto")]
        [Required(ErrorMessage = "Tipo del producto requerido.")]
        public string ProductType { get; set; }

        [Display(Name = "Shop")]
        [Required(ErrorMessage = "Nombre del Area requerida.")]
        public string AreaName { get; set; }


        public virtual Areas Areas { get; set; }
        public virtual ICollection<Shipping_Records> Shipping_Records { get; set; }
    }
}
