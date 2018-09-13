using ProyectoEmbarques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Models.Services
{
    public class CatalogShipmentTypeService : Controller
    {
        // GET: TipoEmbarque
        private BAESystemsGuaymasEntities entities;
        public CatalogShipmentTypeService(BAESystemsGuaymasEntities entities)
        {
            this.entities = entities;
        }
        public CatalogShipmentTypeService() : this(new BAESystemsGuaymasEntities())
        {

        }
        public IList<CatalogShipmentTypeViewModel> GetAll()
        {
            IList<CatalogShipmentTypeViewModel> result = new List<CatalogShipmentTypeViewModel>();
            result = entities.CatalogShipmentType.Select(product => new CatalogShipmentTypeViewModel
            {
                ShipmentTypeID = product.ShipmentTypeID,
                ShipmentType = product.ShipmentType,
            }).ToList();
            return result;
        }
        public IEnumerable<CatalogShipmentTypeViewModel> Read()
        {
            return GetAll();
        }
    }
}