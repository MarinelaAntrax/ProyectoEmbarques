using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Models.Services
{
    public class ClientesService : Controller
    {
        private BAESystemsGuaymasEntities BAE;

        public ClientesService(BAESystemsGuaymasEntities BAE)
        {
            this.BAE = BAE;
        }

        public ClientesService() : this(new BAESystemsGuaymasEntities())
        {

        }
        public IList<ClientesViewModel> GetAll()
        {
            IList<ClientesViewModel> result = new List<ClientesViewModel>();

            result = BAE.Clients.Select(componente => new ClientesViewModel
            {
                ClienteID = componente.ClientID,
                ClientName = componente.ClientName,
            }).ToList();
            return result;
        }
        public IEnumerable<ClientesViewModel> Read()
        {
            return GetAll();
        }
    }
}
    