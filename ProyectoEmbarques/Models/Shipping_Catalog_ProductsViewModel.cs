﻿using System;
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

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Nombre del área requerida.")]
        public int AreaID { get; set; }

        
        [Required(ErrorMessage = "Nombre del producto requerido.")]
        [StringLength(30, ErrorMessage = "La descripcion del componente no puede ser mayor de 30 caracteres.")]
        public string ProductName { get; set; }

        [Display(Name = "Área Interna del Producto")]
        [Required(ErrorMessage = "Área Interna requerida.")]
        public string ProductInternalArea { get; set; }

        [Display(Name = "Tipo del Producto")]
        [Required(ErrorMessage = "Tipo del producto requerido.")]
        public string ProductType { get; set; }

        public bool WOrder { get; set; }
        public bool WKRMSerie { get; set; }
        public bool TIDSerie { get; set; }

        public virtual AreasViewModel Areas { get; set; }
        public virtual ICollection<Shipping_Records> Shipping_Records { get; set; }
    }
}
