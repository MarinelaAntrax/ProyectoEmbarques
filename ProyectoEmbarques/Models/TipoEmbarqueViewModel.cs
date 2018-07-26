using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace controlEmbar.Models
{

    public class TipoEmbarqueViewModel
    {
        public int ShipmentTypeID { get; set; }

        [Display(Name = "Tipo de embarque")]
        [Required(ErrorMessage = "Tipo de embarque requerido.")]
        public string ShipmentType1 { get; set; }
    }
}