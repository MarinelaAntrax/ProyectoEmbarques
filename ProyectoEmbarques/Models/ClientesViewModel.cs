using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class ClientesViewModel
    {
        [ScaffoldColumn(false)]
        public int ClientID { get; set; }

        [Display(Name = "Nombre del Cliente")]
        [Required(ErrorMessage = "Nombre requerido.")]
        [StringLength(50, ErrorMessage = "El nombre del cliente no puede ser mayor de 50 caracteres.")]
        public string ClientName { get; set; }

        [Display(Name = "Nombre de la Compañia ")]
        [Required(ErrorMessage = "Nombre de la compañia requerida.")]
        public string ClientAddress { get; set; }
           } }