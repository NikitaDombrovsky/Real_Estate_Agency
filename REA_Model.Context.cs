﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agency
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Real_estate_agencyEntities2 : DbContext
    {
        private static Real_estate_agencyEntities2 _context;
        public Real_estate_agencyEntities2()
            : base("name=Real_estate_agencyEntities2")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public static Real_estate_agencyEntities2 GetContext()
        {
            if (_context == null)
                _context = new Real_estate_agencyEntities2();
            return _context;
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<C_Apartment_demands_> C_Apartment_demands_ { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Demand> Demands { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<C_House_demands_> C_House_demands_ { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<C_Land_demands_> C_Land_demands_ { get; set; }
        public virtual DbSet<Land> Lands { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<Supply_View> Supply_View { get; set; }
    }
}
