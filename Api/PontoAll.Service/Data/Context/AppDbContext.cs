﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PontoAll.Models.Companys;
using PontoAll.Models.Points;
using PontoAll.Models.User;
using PontoAll.Service.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new ApplicationUserMapping());
            modelBuilder.ApplyConfiguration(new CollaboratorUserMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new PointMapping());
            modelBuilder.ApplyConfiguration(new AddressPointMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Address { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<AddressPoint> AddressPoint { get; set; }
    }
}
