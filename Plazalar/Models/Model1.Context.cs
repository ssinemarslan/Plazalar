﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plazalar.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PlazalarAppEntities1 : DbContext
    {
        public PlazalarAppEntities1()
            : base("name=PlazalarAppEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BloklarBilgi> BloklarBilgis { get; set; }
        public virtual DbSet<GorevlerBilgi> GorevlerBilgis { get; set; }
        public virtual DbSet<HizmetlerBilgi> HizmetlerBilgis { get; set; }
        public virtual DbSet<PersonellerBilgi> PersonellerBilgis { get; set; }
        public virtual DbSet<PlazalarBilgi> PlazalarBilgis { get; set; }
    }
}
