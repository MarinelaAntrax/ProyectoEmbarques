using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class Shipping_Catalog_ProductsService 
    {
        private BAESystemsGuaymasEntities entities;
        public Shipping_Catalog_ProductsService(BAESystemsGuaymasEntities entities)
        {
            this.entities = entities;
        }
        public Shipping_Catalog_ProductsService() : this(new BAESystemsGuaymasEntities())
        {          }
        public IList<Shipping_Catalog_ProductsViewModel> GetAll()
        {
            IList<Shipping_Catalog_ProductsViewModel> result = new List<Shipping_Catalog_ProductsViewModel>();
            result = entities.Shipping_Catalog_Products.Select(product => new Shipping_Catalog_ProductsViewModel
            {
                ProductID = product.ProductID,
                AreaID = product.AreaID,
                AreaName =product.Areas.AreaName,
                ProductName =product.ProductName,
                ProductInternalArea = product.ProductInternalArea,
                ProductType=product.ProductType,
           }).ToList();
            return result;
        }
        public IEnumerable<Shipping_Catalog_ProductsViewModel> Read()
        {
            return GetAll();
        }
    }
}