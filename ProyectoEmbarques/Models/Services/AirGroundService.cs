using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class AirGroundService
    {
        MaterialShippingControlEntities BD = new MaterialShippingControlEntities();

        public IList<AirGroundViewModel> GetAll()
        {
            IList<AirGroundViewModel> result = new List<AirGroundViewModel>();

            result = BD.GraficaAirGround.Select(Grafica => new AirGroundViewModel
            {
                id = Grafica.id,
                FechaDia = Grafica.FechaDia,
                FedExAir = Grafica.actualAir,
                FedExGround = Grafica.actualGround,
                Porcentaje = Grafica.Porcentaje
            }).ToList();
            return result;
        }
        //Ingresa un valor para el dia de hoy
        public void Create(int Parametro)
        {
            var hoy = DateTime.Today;
            var TotalAyer = (from total in BD.GraficaAirGround
                             orderby total.FechaDia descending
                             select new { total.TotalinShip, total.FechaDia }).First();
            var ayerAir = (from consulta1 in BD.Shipping_Records
                           where consulta1.RecordDate == TotalAyer.FechaDia && consulta1.RecordServiceType.Contains("Air") && consulta1.Shipping_Catalog_Products.AreaID != 1 && consulta1.Shipping_Catalog_Products.AreaID != 33
                           select (int?)consulta1.RecordQuantity).Sum() ?? 0;
            var ayerGround = (from consulta2 in BD.Shipping_Records
                              where consulta2.RecordDate == TotalAyer.FechaDia && consulta2.RecordServiceType.Contains("Ground") && consulta2.Shipping_Catalog_Products.AreaID != 1 && consulta2.Shipping_Catalog_Products.AreaID != 33
                              select (int?)consulta2.RecordQuantity).Sum() ?? 0;
            var FedexAirGraundAyer = (ayerAir + ayerGround);

            var entity = new GraficaAirGround()
            {
                FechaDia = DateTime.Today,
                NewScans = ((TotalAyer.TotalinShip - FedexAirGraundAyer) - Parametro) * -1,
                TotalinShip = Parametro,
                FedexAirGraundAyer = FedexAirGraundAyer
            };
            BD.GraficaAirGround.Add(entity);
            BD.SaveChanges();
        }
        public void Update()
        {
            var hoy = DateTime.Today;
            var registroHoy = BD.GraficaAirGround.Where(w => w.FechaDia.Day == hoy.Day && w.FechaDia.Year == hoy.Year && w.FechaDia.Month == hoy.Month)
            .Select(sel => new AirGroundViewModel()
            {
                id = sel.id,
                FechaDia = sel.FechaDia,
                FedExAir = sel.actualAir,
                FedExGround = sel.actualGround,
                FedexAirGraundAyer = sel.FedexAirGraundAyer,
                NewScans = sel.NewScans,
                Porcentaje = sel.Porcentaje,
                TotalinShip = sel.TotalinShip
            }).FirstOrDefault();

            var actualAir = (from consulta1 in BD.Shipping_Records
                             where consulta1.RecordDate.Day == hoy.Day && consulta1.RecordDate.Month == hoy.Month && consulta1.RecordDate.Year == hoy.Year && consulta1.RecordServiceType.Contains("Air") && consulta1.Shipping_Catalog_Products.AreaID != 1 && consulta1.Shipping_Catalog_Products.AreaID != 33
                             select (int?)consulta1.RecordQuantity).Sum() ?? 0;
            var actualGround = (from consulta2 in BD.Shipping_Records
                                where consulta2.RecordDate.Day == hoy.Day && consulta2.RecordDate.Month == hoy.Month && consulta2.RecordDate.Year == hoy.Year && consulta2.RecordServiceType.Contains("Ground") && consulta2.Shipping_Catalog_Products.AreaID != 1 && consulta2.Shipping_Catalog_Products.AreaID != 33
                                select (int?)consulta2.RecordQuantity).Sum() ?? 0;
            if (registroHoy != null)
            {
                if (actualGround != 0 || actualAir != 0)
                {
                    var entity = new GraficaAirGround
                    {
                        id = registroHoy.id,
                        FedexAirGraundAyer = registroHoy.FedexAirGraundAyer,
                        TotalinShip = registroHoy.TotalinShip,
                        NewScans = registroHoy.NewScans,
                        FechaDia = registroHoy.FechaDia,
                        actualAir = actualAir,
                        actualGround = actualGround,
                        Porcentaje = (int)Math.Round(((decimal)actualGround / (decimal)(actualAir + actualGround) * 100))
                    };
                        BD.GraficaAirGround.Attach(entity);
                        BD.Entry(entity).State = EntityState.Modified;
                        BD.SaveChanges();
                }
                    else
                    {
                        Debug.WriteLine("No hay registros para hoy");
                    }
            }
        }
    }
}