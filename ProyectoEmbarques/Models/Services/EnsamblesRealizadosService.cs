﻿
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System;
using System.Web;
using System.Data.Entity;
using ProyectoEmbarques.Models;

namespace ProyectoEmbarques.Models.Services
{
      public class EnsamblesRealizadosService : IDisposable
      {
        private static readonly bool UpdateDatabase = true;
        MaterialShippingControlEntities BD = new MaterialShippingControlEntities();
        private MaterialShippingControlEntities Entities;

            public EnsamblesRealizadosService(MaterialShippingControlEntities Entities)
            {
                this.Entities = Entities;
            }

            public EnsamblesRealizadosService() : this(new MaterialShippingControlEntities())
            {

            }

            public IList<Shipping_RecordsViewModel> GetAll()
            {
                IList<Shipping_RecordsViewModel> result = new List<Shipping_RecordsViewModel>();

                result = Entities.Shipping_Records.Select(componente => new Shipping_RecordsViewModel
                {
                    ClientID = componente.ClientID,
                    Clients = new ClientesViewModel()
                    {
                        ClientName = componente.Clients.ClientName,
                        ClientCompany = componente.Clients.ClientCompany
                    },
                    ProductID = componente.ProductID,
                    Shipping_Catalog_Products = new Shipping_Catalog_ProductsViewModel()
                    {
                        ProductID = componente.Shipping_Catalog_Products.ProductID,
                        ProductName = componente.Shipping_Catalog_Products.ProductName,
                        AreaID = componente.Shipping_Catalog_Products.AreaID,
                    Areas = new AreasViewModel()
                    {
                        AreaName = componente.Shipping_Catalog_Products.Areas.AreaName
                    },
                        ProductType = componente.Shipping_Catalog_Products.ProductType,
                        WOrder = componente.Shipping_Catalog_Products.WOrder,
                        WKRMSerie = componente.Shipping_Catalog_Products.WKRMSerie,
                        TIDSerie = componente.Shipping_Catalog_Products.TIDSerie,
                    },
                    RecordID = componente.RecordID,
                    RecordQuantity = componente.RecordQuantity,
                    RecordDate = componente.RecordDate,
                    RecordFedexTracking = componente.RecordFedexTracking,
                    RecordControlBoxNo = componente.RecordControlBoxNo,
                    RecordPieceBoxNo = componente.RecordPieceBoxNo,
                    ShipmentTypeID = componente.ShipmentTypeID,
                    CatalogShipmentType = new CatalogShipmentTypeViewModel()
                    {
                        ShipmentTypeID = componente.Shipping_Catalog_ShipmentTypes.ShipmentTypeID,
                        ShipmentType = componente.Shipping_Catalog_ShipmentTypes.ShipmentType
                    },
                    RecordComment = componente.RecordComment,
                    RecordWorkOrder = componente.RecordWorkOrder,
                    RecordSerialNo = componente.RecordSerialNo,
                    RecordTrackingId = componente.RecordTrackingId,
                    RecordRework = componente.RecordRework,
                    RecordComment1 = componente.RecordComment1,
                    RecordComment2 = componente.RecordComment2,
                    RecordServiceType = componente.RecordServiceType,
                    RecordFAI = componente.RecordFAI,
                    RecordTransfer = componente.RecordTransfer,
                    RecordSeguritySeal1 = componente.RecordSeguritySeal1,
                    RecordSeguritySeal2 = componente.RecordSeguritySeal2,
                    RecordSeguritySeal3 = componente.RecordSeguritySeal3,
                    RecordSeguritySeal4 = componente.RecordSeguritySeal4
                }).ToList();
                return result;
            } 

        public void Create(Shipping_RecordsViewModel Record)
        {           
            if (!UpdateDatabase)
            {
                var firts = Read().OrderByDescending(e => e.RecordID).FirstOrDefault();
                var id = (firts != null) ? firts.RecordID : 0;
                Record.RecordID = id + 1;
                GetAll().Insert(0, Record);
            }
            else
            {
                var entity = new Shipping_Records
                {
                    ClientID = Record.ClientID,
                    ProductID = Record.ProductID,
                    RecordQuantity = Record.RecordQuantity,
                    RecordDate = Record.RecordDate,
                    RecordFedexTracking = Record.RecordFedexTracking,
                    RecordControlBoxNo = Record.RecordControlBoxNo,
                    RecordPieceBoxNo = Record.RecordPieceBoxNo,
                    ShipmentTypeID = Record.ShipmentTypeID,
                    RecordServiceType = Record.RecordServiceType,
                    RecordComment = Record.RecordComment,
                    RecordWorkOrder = Record.RecordWorkOrder,
                    RecordSerialNo = Record.RecordSerialNo,
                    RecordTrackingId = Record.RecordTrackingId,
                    RecordRework = Record.RecordRework,
                    RecordComment1 = Record.RecordComment1,
                    RecordComment2 = Record.RecordComment2,
                    RecordFAI = Record.RecordFAI,
                    RecordTransfer = Record.RecordTransfer,
                    RecordSeguritySeal1 = Record.RecordSeguritySeal1,
                    RecordSeguritySeal2 = Record.RecordSeguritySeal2,
                    RecordSeguritySeal3 = Record.RecordSeguritySeal3,
                    RecordSeguritySeal4 = Record.RecordSeguritySeal4
                };
                Entities.Shipping_Records.Add(entity);
                Entities.SaveChanges();
                Record.RecordID = entity.RecordID;
            }
        }

        public bool WOrderUnik(int Worder) {
            var x = One(w => w.RecordWorkOrder == Worder);
            if (x == null) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool TID(int TID)
        {
            var x = One(w => w.RecordTrackingId == TID);
            if (x == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Destroy(Shipping_RecordsViewModel Record)
        {
            if (!UpdateDatabase)
            {
                var target = Read().FirstOrDefault(e => e.RecordID == Record.RecordID);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var entity = new Shipping_Records
                {
                    RecordID = Record.RecordID
                };

                Entities.Shipping_Records.Attach(entity);
                Entities.Shipping_Records.Remove(entity);

                var record = Entities.Shipping_Records.Where(s => s.RecordID == entity.RecordID);

                foreach (var e in record)
                {
                    Entities.Shipping_Records.Remove(e);
                }
                Entities.SaveChanges();
            }
        }

        public Shipping_RecordsViewModel One(Func<Shipping_RecordsViewModel, bool> predicate)
            {
               return GetAll().FirstOrDefault(predicate);
            }

        public IEnumerable<Shipping_RecordsViewModel> Read()
                {
                    return GetAll();
                }

        public IEnumerable<Shipping_RecordsViewModel> ReadD(decimal ParametroFedex)
        {
            var total = from Shipping_Records in BD.Shipping_Records
                       join products in BD.Shipping_Catalog_Products on Shipping_Records.ProductID equals products.ProductID 
                        group Shipping_Records by new {
                            products.ProductName,
                            Shipping_Records.RecordPieceBoxNo
                        } into Shipping_RecordsGroup
                        select new Shipping_RecordsViewModel()
                        {   ProductName=Shipping_RecordsGroup.Key.ProductName,
                            RecordPieceBoxNo=Shipping_RecordsGroup.Key.RecordPieceBoxNo,
                           RecordCantidad = Shipping_RecordsGroup.Sum(x=> x.RecordQuantity)
                        };
            return total;
            //return GetAll().Where(w => w.RecordFedexTracking == ParametroFedex).ToList();
        }

        public string ReadE(decimal ParametroFedex)
        {
            return GetAll().Where(w => w.RecordFedexTracking == ParametroFedex).Select(s=>s.Clients.ClientName).FirstOrDefault();
        }


        public IEnumerable<Shipping_RecordsViewModel> Read(DateTime starDate, DateTime endDate)
        {
            return GetAll().Where(componente=>componente.RecordDate>=starDate&&componente.RecordDate <= endDate);
        }

        public void Dispose()
        {
            Entities.Dispose();
        }

            public void Update(Shipping_RecordsViewModel Record)
            {
            //Record.Shipping_Catalog_Products = null;
                if (!UpdateDatabase)
                {
                    var target = One(e => e.RecordID == Record.RecordID);

                    if (target != null)
                    {
                    target.RecordTransfer = Record.RecordTransfer;
                    }
                }
                else
                 {
                var entity = new Shipping_Records
                {
                    RecordID = Record.RecordID,
                    RecordTransfer = Record.RecordTransfer,
                    ClientID = Record.ClientID,
                    ProductID = Record.ProductID,
                    RecordQuantity = Record.RecordQuantity,
                    RecordDate = Record.RecordDate,
                    RecordFedexTracking = Record.RecordFedexTracking,
                    RecordControlBoxNo = Record.RecordControlBoxNo,
                    RecordPieceBoxNo = Record.RecordPieceBoxNo,
                    ShipmentTypeID = Record.ShipmentTypeID,
                    RecordServiceType = Record.RecordServiceType,
                    RecordComment = Record.RecordComment,
                    RecordWorkOrder = Record.RecordWorkOrder,
                    RecordSerialNo = Record.RecordSerialNo,
                    RecordTrackingId = Record.RecordTrackingId,
                    RecordRework = Record.RecordRework,
                    RecordComment1 = Record.RecordComment1,
                    RecordComment2 = Record.RecordComment2,
                    RecordFAI = Record.RecordFAI,

                    RecordSeguritySeal1 = Record.RecordSeguritySeal1,
                    RecordSeguritySeal2 = Record.RecordSeguritySeal2,
                    RecordSeguritySeal3 = Record.RecordSeguritySeal3,
                    RecordSeguritySeal4 = Record.RecordSeguritySeal4
                };
                    Entities.Shipping_Records.Add(entity);
                    
                    Entities.Entry(entity).State = EntityState.Modified;
                    Entities.SaveChanges();
                }
            }
      }
}


