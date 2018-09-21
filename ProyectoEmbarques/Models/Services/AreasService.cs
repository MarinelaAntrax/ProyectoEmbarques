using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class AreasService
    {
        private MaterialShippingControlEntities entities;

        public AreasService(MaterialShippingControlEntities entities)
        {
            this.entities = entities;
        }

        public AreasService() : this(new MaterialShippingControlEntities())
        {

        }

        public IList<AreasViewModel> GetAll()
        {
            IList<AreasViewModel> result = new List<AreasViewModel>();

            result = entities.Areas.Select(product => new AreasViewModel
            {
                AreaID = product.AreaID,
                AreaName = product.AreaName
            }).ToList();
            return result;
        }

        public IEnumerable<AreasViewModel> Read()
        {
            return GetAll();
        }
    }
}