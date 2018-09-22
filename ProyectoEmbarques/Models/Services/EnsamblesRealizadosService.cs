using ProyectoEmbarques.Models;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System;
using System.Web;
using System.Data.Entity;

namespace ProyectoEmbarques.Models.Services
{
      public class EnsamblesRealizadosService : IDisposable
      {
        private static bool UpdateDatabase = true;

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
                        ClientAddress = componente.Clients.ClientAddress,
                        ClientCompany = componente.Clients.ClientCompany
                    },
                    ProductID = componente.ProductID,
                    Shipping_Catalog_Products = new Shipping_Catalog_ProductsViewModel()
                    {
                        ProductID = componente.Shipping_Catalog_Products.ProductID,
                        ProductName = componente.Shipping_Catalog_Products.ProductName,
                        AreaID = componente.Shipping_Catalog_Products.AreaID,
                        ProductType = componente.Shipping_Catalog_Products.ProductType,
                        ProductInternalArea = componente.Shipping_Catalog_Products.ProductInternalArea
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
                var entity = new Shipping_Records();
                
                entity.ClientID = Record.ClientID;
                entity.ProductID = Record.ProductID;
                entity.RecordQuantity = Record.RecordQuantity;
                entity.RecordDate = Record.RecordDate;
                entity.RecordFedexTracking = Record.RecordFedexTracking;
                entity.RecordControlBoxNo = Record.RecordControlBoxNo;
                entity.RecordPieceBoxNo = Record.RecordPieceBoxNo;
                entity.ShipmentTypeID = Record.ShipmentTypeID;
                entity.RecordServiceType = Record.RecordServiceType;
                entity.RecordComment = Record.RecordComment;
                entity.RecordWorkOrder = Record.RecordWorkOrder;
                entity.RecordSerialNo = Record.RecordSerialNo;
                entity.RecordTrackingId = Record.RecordTrackingId;
                entity.RecordRework = Record.RecordRework;
                entity.RecordComment1 = Record.RecordComment1;
                entity.RecordComment2 = Record.RecordComment2;
                entity.RecordFAI = Record.RecordFAI;
                entity.RecordTransfer = Record.RecordTransfer;
                entity.RecordSeguritySeal1 = Record.RecordSeguritySeal1;
                entity.RecordSeguritySeal2 = Record.RecordSeguritySeal2;
                entity.RecordSeguritySeal3 = Record.RecordSeguritySeal3;
                entity.RecordSeguritySeal4 = Record.RecordSeguritySeal4;
                Entities.Shipping_Records.Add(entity);
                Entities.SaveChanges();
                Record.RecordID = entity.RecordID;
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
                var entity = new Shipping_Records();

                entity.RecordID = Record.RecordID;

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
                    var entity = new Shipping_Records();
                entity.RecordID = Record.RecordID;
                    entity.RecordTransfer = Record.RecordTransfer;
                    entity.ClientID = Record.ClientID;
                    entity.ProductID = Record.ProductID;
                    entity.RecordQuantity = Record.RecordQuantity;
                    entity.RecordDate = Record.RecordDate;
                    entity.RecordFedexTracking = Record.RecordFedexTracking;
                    entity.RecordControlBoxNo = Record.RecordControlBoxNo;
                    entity.RecordPieceBoxNo = Record.RecordPieceBoxNo;
                    entity.ShipmentTypeID = Record.ShipmentTypeID;
                    entity.RecordServiceType = Record.RecordServiceType;
                    entity.RecordComment = Record.RecordComment;
                    entity.RecordWorkOrder = Record.RecordWorkOrder;
                    entity.RecordSerialNo = Record.RecordSerialNo;
                    entity.RecordTrackingId = Record.RecordTrackingId;
                    entity.RecordRework = Record.RecordRework;
                    entity.RecordComment1 = Record.RecordComment1;
                    entity.RecordComment2 = Record.RecordComment2;
                    entity.RecordFAI = Record.RecordFAI;
                    
                    entity.RecordSeguritySeal1 = Record.RecordSeguritySeal1;
                    entity.RecordSeguritySeal2 = Record.RecordSeguritySeal2;
                    entity.RecordSeguritySeal3 = Record.RecordSeguritySeal3;
                    entity.RecordSeguritySeal4 = Record.RecordSeguritySeal4;
                    Entities.Shipping_Records.Add(entity);
                    
                    Entities.Entry(entity).State = EntityState.Modified;
                    Entities.SaveChanges();
                }
            }
      }
}


