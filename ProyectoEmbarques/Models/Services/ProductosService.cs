using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class ProductosService
    {
        private BAESystemsGuaymasEntities entities;
        public ProductosService(BAESystemsGuaymasEntities entities)
        {
            this.entities = entities;
        }

        public ProductosService() : this(new BAESystemsGuaymasEntities())
        {

        }
        public IList<ProductosViewModel> GetAll()
        {
            IList<ProductosViewModel> result = new List<ProductosViewModel>();

            result = entities.Shipping_Catalog_Products.Select(product => new ProductosViewModel
            {
                ProductoID = product.ProductID,
                AreaID = product.AreaID,
                ProductName =product.ProductName,
                ProductInternaArea = product.ProductName,
                ProductType=product.ProductType
               
            }).ToList();
            return result;
        }

        public IEnumerable<ProductosViewModel> Read()
        {
            return GetAll();
        }

    }
}