﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoEmbarques.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BAESystemsGuaymasEntities : DbContext
    {
        public BAESystemsGuaymasEntities()
            : base("name=BAESystemsGuaymasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Assemblies> Assemblies { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Components> Components { get; set; }
        public DbSet<WireKit> WireKit { get; set; }
        public DbSet<CatalogShipmentType> CatalogShipmentType { get; set; }
        public DbSet<VIEWDATA> VIEWDATA { get; set; }
        public DbSet<Shipping_Catalog_Products> Shipping_Catalog_Products { get; set; }
        public DbSet<Shipping_Records> Shipping_Records { get; set; }
    }
}
