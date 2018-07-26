using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class EnsamblesService
    {
        private BAESystemsGuaymasEntities Systems;

        public EnsamblesService(BAESystemsGuaymasEntities Systems)
        {
            this.Systems = Systems;
        }

        public EnsamblesService() : this(new BAESystemsGuaymasEntities())
        {

        }
        public IList<EnsamblesViewModel> GetAll()
        {
            IList<EnsamblesViewModel> result = new List<EnsamblesViewModel>();

            result = Systems.Assemblies.Select(componente => new EnsamblesViewModel
            {
                AssemblyID = componente.AssemblyID,
                //AreaID = componente.,
                AssemblyPartNumber = componente.AssemblyPartNumber,
            }).ToList();
            return result;
        }
        public IEnumerable<EnsamblesViewModel> Read()
        {
            return GetAll();
        }
    }
}