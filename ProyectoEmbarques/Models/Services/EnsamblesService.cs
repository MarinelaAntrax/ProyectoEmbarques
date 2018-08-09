using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Models.Services
{
    public class EnsamblesService : Controller
    {
        private BAESystemsGuaymasEntities Systems;
        public EnsamblesService(BAESystemsGuaymasEntities Systems)
        {
            this.Systems = Systems;
        }
        public EnsamblesService() : this(new BAESystemsGuaymasEntities())
        { }
        public IList<EnsamblesViewModel> GetAll()
        {
            IList<EnsamblesViewModel> result = new List<EnsamblesViewModel>();
            result = Systems.Assemblies.Select(componente => new EnsamblesViewModel
            {
                AssemblyID = componente.AssemblyID,
                
            }).ToList();
            return result;
        }

        public IEnumerable<EnsamblesViewModel> Read()
        {
            return GetAll();
        }
    }
}

    
