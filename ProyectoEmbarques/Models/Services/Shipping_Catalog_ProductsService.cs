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
                AreaName = product.Areas.AreaName,
                ProductName =product.ProductName,
                WOrder = product.WOrder,
                WKRMSerie = product.WKRMSerie,
                TIDSerie = product.TIDSerie,
                ProductType =product.ProductType
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

                    entity.ProductID = product.ProductID;
                    entity.ProductName = product.ProductName;
                    entity.AreaID = product.AreaID;
                    entity.WOrder = product.WOrder;
                    entity.WKRMSerie = product.WKRMSerie;
                    entity.TIDSerie = product.TIDSerie;
                    entity.ProductType = product.ProductType;

                    entities.Shipping_Catalog_Products.Add(entity);
                    entities.SaveChanges();

                //product.ProductID = entity.ProductID;
            }
        }

        public void Update(Shipping_Catalog_ProductsViewModel product)
        {
            if (!UpdateDatabase)
            {
                var target = One(e => e.ProductID == product.ProductID);

                if (target != null)
                {
                    target.ProductID = product.ProductID;
                    target.ProductName = product.ProductName;
                    target.AreaID = product.AreaID;
                    target.WOrder = product.WOrder;
                    target.TIDSerie = product.TIDSerie;
                    target.WKRMSerie = product.WKRMSerie;
                    target.ProductType = product.ProductType;
                }
            }
            else
            {
                var entity = new Shipping_Catalog_Products();

                entity.ProductID = product.ProductID;
                entity.ProductName = product.ProductName;
                entity.AreaID = product.AreaID;
                entity.WOrder = product.WOrder;
                entity.TIDSerie = product.TIDSerie;
                entity.WKRMSerie = product.WKRMSerie;
                entity.ProductType = product.ProductType; 

                entities.Shipping_Catalog_Products.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
                entities.SaveChanges();
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