using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models
{
    public class AirGroundViewModel
    {
        public int NewScans { get; set; }

        public int FedExAir { get; set; }

        public int FedExGround { get; set; }

        public int TotalinShip { get; set; }

        public bool variable { get; set; }

        public DateTime FechaDia { get; set; }

        public int FedexAirGraundAyer { get; set; }

        public int porcentaje { get; set; }
    }
}