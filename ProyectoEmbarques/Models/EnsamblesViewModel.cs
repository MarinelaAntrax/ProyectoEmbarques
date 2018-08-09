using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class EnsamblesViewModel
    {
        public int AssemblyID { get; set; }

        [Display(Name = "Area")]
        public int AreaName { get; set; }

        [Display(Name = "Nombre de partes de la pieza")]
        public string ProductName { get; set; }

    }
}
