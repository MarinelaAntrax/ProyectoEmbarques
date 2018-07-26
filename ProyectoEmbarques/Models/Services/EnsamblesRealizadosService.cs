using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoEmbarques.Models.Services
{
        public class EnsamblesRealizadosService : Controller
        {
            private BAESystemsGuaymasEntities Entities;

            public EnsamblesRealizadosService(BAESystemsGuaymasEntities Entities)
            {
                this.Entities = Entities;
            }

            public EnsamblesRealizadosService() : this(new BAESystemsGuaymasEntities())
            {

            }
            public IList<EmbarqueEnsamblesViewModel> GetAll()
        {
            IList<EmbarqueEnsamblesViewModel> result = new List<EmbarqueEnsamblesViewModel>();

            result = Entities.Shipping_Records.Select(componente => new EmbarqueEnsamblesViewModel
            {
                ProductID = componente.ProductID,
                Shop = componente.Shipping_Catalog_Products,
                RecordDate = componente.RecordDate,
                RecordTrackingFedex = componente.RecordFedexTracking,
                RecordWorkOrder = componente.RecordWorkOrder,
                RecordSerialNo = componente.RecordSerialNo,
                RecordControlBoxNo = componente.RecordControlBoxNo,
                RecordTrackingId = componente.RecordTrackingId,
                RecordQuantity = componente.RecordQuantity,
                RecordPieceBoxNo = componente.RecordPieceBoxNo,
                ClientID = componente.ClientID,
                //ClientAddress = componente.Clients,
                ShipmentTypeID = componente.ShipmentTypeID,
                RecordRework = componente.RecordRework,
                RecordSeguritySeal = componente.RecordSeguritySeal,
                RecordComment = componente.RecordComment,
                RecordComment1 = componente.RecordComment1,
                RecordComment2 = componente.RecordComment2,
                RecordServiceType = componente.RecordServiceType,
            }).ToList();
            return result;
        }


        public IEnumerable<EmbarqueEnsamblesViewModel> Read()
            {
                return GetAll();
            }
        }
    }


