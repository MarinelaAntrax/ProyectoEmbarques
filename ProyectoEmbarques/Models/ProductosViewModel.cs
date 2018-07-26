using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class ProductosViewModel
    {
        public int ProductoID { get; set; }


        [Display(Name = "Nombre del Area")]
        public int AreaID { get; set; }

        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "Nombre del producto requerida.")]
        [StringLength(30, ErrorMessage = "La descripcion del componente no puede ser mayor de 30 caracteres.")]
        public string ProductName { get; set; }

        [Display(Name = "Area Interna del Producto")]
        public string ProductInternaArea { get; set; }

        [Display(Name = "Tipo del Producto")]
        public string ProductType { get; set; }

        public virtual AreasViewModel Area { get; set; }

    }
}
