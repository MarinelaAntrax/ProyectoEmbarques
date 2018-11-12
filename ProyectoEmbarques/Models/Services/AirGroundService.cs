using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class AirGroundService
    {
        MaterialShippingControlEntities BD = new MaterialShippingControlEntities();
        //Ingresa un valor para el dia de hoy
        public void Create( int Parametro) {
            var entity = new GraficaAirGround() {
                FechaDia = DateTime.Today,
                NewScans = 123,
                TotalinShip =Parametro
            };
            BD.GraficaAirGround.Add(entity);
            BD.SaveChanges();
        }

    }
}