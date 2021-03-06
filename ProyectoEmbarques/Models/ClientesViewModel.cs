﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoEmbarques.Models
{
    public class ClientesViewModel
    {
        [ScaffoldColumn(false)]
        public int ClientID { get; set; }

        [Display(Name = "Nombre del Cliente")]
        [Required(ErrorMessage = "Nombre del cliente requerido.")]
        public string ClientName { get; set; }

        [Display(Name = "Nombre de la Compañía ")]
        [Required(ErrorMessage = "Nombre de la compañía requerida.")]
        public string ClientCompany { get; set; }
    }
}