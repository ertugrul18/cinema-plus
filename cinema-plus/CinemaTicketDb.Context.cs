﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cinema_plus
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinemaTicketEntities : DbContext
    {
        public CinemaTicketEntities()
            : base("name=CinemaTicketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<filmler> filmlers { get; set; }
        public virtual DbSet<rezervasyon> rezervasyons { get; set; }
        public virtual DbSet<seanslar> seanslars { get; set; }
        public virtual DbSet<musteriler> musterilers { get; set; }
    }
}
