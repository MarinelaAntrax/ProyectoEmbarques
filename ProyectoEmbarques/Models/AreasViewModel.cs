using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEmbarques.Models
{
    public class AreasViewModel
    {
        public int AreaID { get; set; }  

        [Display(Name = "Area")]
        [Required(ErrorMessage = "Nombre del area requerida.")]
        [StringLength(30, ErrorMessage = "El nombre del area no puede ser mayor de 30 caracteres.")]
        public string AreaName { get; set; }

        public virtual  Shipping_Catalog_Products Area { get; set; }
    } } 