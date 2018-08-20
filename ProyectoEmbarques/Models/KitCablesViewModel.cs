using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class KitCablesViewModel
    {
        public int WireKitID { get; set; }

        [Display(Name = "Nombre del Kit de cables")]
        [Required(ErrorMessage = "Nombre del kit de cables requerido.")]
        public string WireKitPN { get; set; }
            } }