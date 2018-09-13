using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class ComponentesViewModel
    {
        public int ComponentID { get; set; }

        [Display(Name = "Nombre del Componente")]
        [Required(ErrorMessage = "Nombre del componente requerida.")]
        [StringLength(250, ErrorMessage = "La descripcion del componente no puede ser mayor de 250 caracteres.")]
        public string ComponentPN { get; set; }

        public string ComponentDescription { get; set; }

        public string ComponentName { get; set; }
    }
}