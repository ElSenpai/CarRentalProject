using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class RentalContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Rental;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().Property(r => r.Id).HasColumnName("RentID");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("UserID");
            modelBuilder.Entity<Customer>().Property(cu => cu.UserID).HasColumnName("UserID");
            modelBuilder.Entity<Car>().Property(c => c.Id).HasColumnName("CarID");
            modelBuilder.Entity<Color>().Property(co => co.Id).HasColumnName("ColorID");
            modelBuilder.Entity<Brand>().Property(b => b.Id).HasColumnName("BrandID");
            modelBuilder.Entity<Customer>().HasKey(Cu => Cu.UserID);
        }

    }
}
