using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class AreasViewModel
    {
        public int AreaID { get; set; }

        [Display(Name = "Nombre del Area")]
        [Required(ErrorMessage = "Nombre del area requerida.")]
        [StringLength(30, ErrorMessage = "El nombre del area no puede ser mayor de 30 caracteres.")]
        public string AreaName { get; set; }
    }
}