using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoEmbarques.Models.Services
{
    public class Shipping_Catalog_ProductsService : IDisposable
    {
        private static bool UpdateDatabase = true;
        private MaterialShippingControlEntities entities;

        public Shipping_Catalog_ProductsService(MaterialShippingControlEntities entities)
        {
            this.entities = entities;
        }

        public Shipping_Catalog_ProductsService() : this(new MaterialShippingControlEntities())
        {

        }

        public IList<Shipping_Catalog_ProductsViewModel> GetAll()
        {
            IList<Shipping_Catalog_ProductsViewModel> result = new List<Shipping_Catalog_ProductsViewModel>();

            result = entities.Shipping_Catalog_Products.Select(product => new Shipping_Catalog_ProductsViewModel
            {
                ProductID = product.ProductID,
                AreaID = product.AreaID,
                Areas = new AreasViewModel()
                {
                    AreaName = product.Areas.AreaName
              },
                ProductName =product.ProductName,
                ProductInternalArea = product.ProductInternalArea,
                ProductType=product.ProductType
           }).ToList();
            return result;
        }

        public IEnumerable<Shipping_Catalog_ProductsViewModel> Read()
        {
            return GetAll();
        }

        public void Create(Shipping_Catalog_ProductsViewModel product)
        {
            if (!UpdateDatabase)
            {
                var first = Read().OrderByDescending(s => s.ProductID).FirstOrDefault();
                var id = (first != null) ? first.ProductID : 0;

                product.ProductID = id + 1;

                GetAll().Insert(0, product);
            }
                else
                {
                    var entity = new Shipping_Catalog_Products();

                    //entity.ProductID = product.ProductID;
                    entity.AreaID = product.AreaID;
                    entity.ProductName = product.ProductName;
                    entity.ProductInternalArea = product.ProductInternalArea;
                    entity.ProductType = product.ProductType;

                    entities.Shipping_Catalog_Products.Add(entity);
                    entities.SaveChanges();

                    //product.ProductID = entity.ProductID;
                }
        }

             public Shipping_Catalog_ProductsViewModel One(Func<Shipping_Catalog_ProductsViewModel, bool> predicate)
             {
                return Read().FirstOrDefault(predicate);       
             }

            public void Dispose()
            {
                entities.Dispose();
            }
        
    }
}