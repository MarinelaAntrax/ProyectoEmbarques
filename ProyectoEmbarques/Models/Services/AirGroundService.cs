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
                Porcentaje = Grafica.Porcentaje,
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
        public void UpdateAyer()
        {
            var hoy = DateTime.Today;
            var ayer = BD.Shipping_Records.Where(w=>w.RecordDate<hoy).Distinct()
                .OrderByDescending(des=>des.RecordDate.Month)
                .ThenByDescending(des=>des.RecordDate.Day)
                .Select(d=>d.RecordDate)
                .FirstOrDefault();
            var registroAyer = BD.GraficaAirGround.Where(w => w.FechaDia.Day == ayer.Day && w.FechaDia.Year == ayer.Year && w.FechaDia.Month == ayer.Month)
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



            var UltimoAir = (from consulta1 in BD.Shipping_Records
                             where consulta1.RecordDate.Day == ayer.Day && consulta1.RecordDate.Month == ayer.Month && consulta1.RecordDate.Year == ayer.Year && consulta1.RecordServiceType.Contains("Air") && consulta1.Shipping_Catalog_Products.AreaID != 1 && consulta1.Shipping_Catalog_Products.AreaID != 33
                             select (int?)consulta1.RecordQuantity).Sum() ?? 0;
            var UltimoGround = (from consulta2 in BD.Shipping_Records
                                where consulta2.RecordDate.Day == ayer.Day && consulta2.RecordDate.Month == ayer.Month && consulta2.RecordDate.Year == ayer.Year && consulta2.RecordServiceType.Contains("Ground") && consulta2.Shipping_Catalog_Products.AreaID != 1 && consulta2.Shipping_Catalog_Products.AreaID != 33
                                select (int?)consulta2.RecordQuantity).Sum() ?? 0;

            if (registroAyer != null)
            {
                if (UltimoGround != 0 || UltimoAir != 0)
                {
                    var entity = new GraficaAirGround
                    {
                        id = registroAyer.id,
                        FedexAirGraundAyer = registroAyer.FedexAirGraundAyer,
                        TotalinShip = registroAyer.TotalinShip,
                        NewScans = registroAyer.NewScans,
                        FechaDia = registroAyer.FechaDia,
                        actualAir = UltimoAir,
                        actualGround = UltimoGround,
                        Porcentaje = (int)Math.Round(((decimal)UltimoGround / (decimal)(UltimoAir + UltimoGround) * 100))
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