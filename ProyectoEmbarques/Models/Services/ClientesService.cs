using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmbarques.Models.Services
{
    public class ClientesService : IDisposable
    {
        private static bool UpdateDatabase = true;
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
                ClientID = componente.ClientID,
                ClientName = componente.ClientName,
                ClientAddress = componente.ClientAddress,
                ClientCompany = componente.ClientCompany
               
            }).ToList();
            return result;
        }
        public IEnumerable<ClientesViewModel> Read()
        {
            return GetAll();
        }
        public void Create(ClientesViewModel clientes)
        {
            if (!UpdateDatabase)
            {
                var firts = Read().OrderByDescending(e => e.ClientID).FirstOrDefault();
                var id = (firts != null) ? firts.ClientID : 0;

                clientes.ClientID = id + 1;

                GetAll().Insert(0, clientes);
            }
            else
            {
                var entity = new Client();

                entity.ClientID = clientes.ClientID;
                entity.ClientName = clientes.ClientName;
                entity.ClientAddress = clientes.ClientAddress;
                entity.ClientCompany = clientes.ClientCompany;

                BAE.Clients.Add(entity);
                BAE.SaveChanges();

                clientes.ClientID = entity.ClientID;
            }
        }
        public void Update(ClientesViewModel clientes)
        {
            if (!UpdateDatabase)
            {
                var target = One(e => e.ClientID == clientes.ClientID);

                if (target != null)
                {
                    target.ClientID = clientes.ClientID;
                    target.ClientName = clientes.ClientName;
                    target.ClientAddress = clientes.ClientAddress;
                    target.ClientCompany = clientes.ClientCompany;
                }
            }
            else
            {
                var entity = new Client();

                entity.ClientID = clientes.ClientID;
                entity.ClientName = clientes.ClientName;
                entity.ClientAddress = clientes.ClientAddress;
                entity.ClientCompany = clientes.ClientCompany;

                BAE.Clients.Attach(entity);
                BAE.Entry(entity).State = EntityState.Modified;
                BAE.SaveChanges();
            }
        }
        public ClientesViewModel One(Func<ClientesViewModel, bool> predicate)
        {
            return Read().FirstOrDefault(predicate);
        }
        public void Dispose()
        {
            BAE.Dispose();
        }
    }
}
    