using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class CatalogShipmentTypeViewModel
    {
        public int ShipmentTypeID { get; set; }

        [Display(Name = "Tipo de embarque")]
        [Required(ErrorMessage = "Tipo de embarque requerido.")]
        public string ShipmentType { get; set; }
    }
}