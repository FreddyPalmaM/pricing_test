﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ejercicio_ASP.NET_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pricing_testEntities : DbContext
    {
        public pricing_testEntities()
            : base("name=pricing_testEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<ciudad> ciudad { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<comuna> comuna { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<telefono_contacto> telefono_contacto { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<venta_detalle> venta_detalle { get; set; }
    }
}