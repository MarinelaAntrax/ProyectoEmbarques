using controlEmbar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Models.Services
{
    public class TipoEmbarqueService : Controller
    {
        // GET: TipoEmbarque
        private BAESystemsGuaymasEntities entities;
        public TipoEmbarqueService(BAESystemsGuaymasEntities entities)
        {
            this.entities = entities;
        }
        public TipoEmbarqueService() : this(new BAESystemsGuaymasEntities())
        {      }
        public IList<TipoEmbarqueViewModel> GetAll()
        {
            IList<TipoEmbarqueViewModel> result = new List<TipoEmbarqueViewModel>();
            result = entities.CatalogShipmentType.Select(product => new TipoEmbarqueViewModel
            {
                ShipmentTypeID = product.ShipmentTypeID,
                ShipmentType = product.ShipmentType,
            }).ToList();
            return result;
        }
        public IEnumerable<TipoEmbarqueViewModel> Read()
        {
            return GetAll();
        }
    }
}