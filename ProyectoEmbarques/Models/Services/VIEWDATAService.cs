using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class VIEWDATAService
    {
        private BAESystemsGuaymasEntities entities;
        public VIEWDATAService(BAESystemsGuaymasEntities entities)
        {
            this.entities = entities;
        }
        public VIEWDATAService() : this(new BAESystemsGuaymasEntities())
        { }
        public IList<VIEWDATAViewModel> GetAll()
        {
            IList<VIEWDATAViewModel> result = new List<VIEWDATAViewModel>();
            result = entities.VIEWDATA.Select(product => new VIEWDATAViewModel
            {
                DATA = product.DATA,
            }).ToList();
            return result;
        }
        public IEnumerable<VIEWDATAViewModel> Read()
        {
            return GetAll();
        } } }