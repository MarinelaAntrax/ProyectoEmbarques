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
            var hoy = DateTime.Today;
            var TotalAyer = (from total in BD.GraficaAirGround
                                  orderby total.FechaDia descending
                                  select new { total.TotalinShip, total.FechaDia }).First();
            var actualAir = (from consulta1 in BD.Shipping_Records
                                where consulta1.RecordDate.Day ==hoy.Day && consulta1.RecordDate.Month == hoy.Month && consulta1.RecordDate.Year == hoy.Year && consulta1.RecordServiceType.Contains("Air") && consulta1.Shipping_Catalog_Products.AreaID != 1 && consulta1.Shipping_Catalog_Products.AreaID != 33
                                select (int?)consulta1.RecordQuantity).Sum() ?? 0;
            var actualGround = (from consulta2 in BD.Shipping_Records
                                    where consulta2.RecordDate.Day == hoy.Day && consulta2.RecordDate.Month == hoy.Month && consulta2.RecordDate.Year == hoy.Year && consulta2.RecordServiceType.Contains("Ground") && consulta2.Shipping_Catalog_Products.AreaID != 1 && consulta2.Shipping_Catalog_Products.AreaID != 33
                                    select (int?)consulta2.RecordQuantity).Sum() ?? 0;
            var ayerAir = (from consulta1 in BD.Shipping_Records
                             where consulta1.RecordDate == TotalAyer.FechaDia && consulta1.RecordServiceType.Contains("Air") && consulta1.Shipping_Catalog_Products.AreaID != 1 && consulta1.Shipping_Catalog_Products.AreaID != 33
                             select (int?)consulta1.RecordQuantity).Sum() ?? 0;
            var ayerGround = (from consulta2 in BD.Shipping_Records
                                where consulta2.RecordDate == TotalAyer.FechaDia && consulta2.RecordServiceType.Contains("Ground") && consulta2.Shipping_Catalog_Products.AreaID != 1 && consulta2.Shipping_Catalog_Products.AreaID != 33
                                select (int?)consulta2.RecordQuantity).Sum() ?? 0;
            var FedexAirGraundAyer = (ayerAir + ayerGround);

            var entity = new GraficaAirGround() {
                FechaDia = DateTime.Today,
                NewScans = ((TotalAyer.TotalinShip-FedexAirGraundAyer)-Parametro)*-1,
                TotalinShip = Parametro,
                actualAir = actualAir,
                actualGround = actualGround,
                FedexAirGraundAyer = FedexAirGraundAyer
            };
            BD.GraficaAirGround.Add(entity);
            BD.SaveChanges();
        }

    }
}