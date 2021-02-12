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
            modelBuilder.Entity<Rental>().Property(p => p.Id).HasColumnName("RentID");
            modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("UserID");
            modelBuilder.Entity<Customer>().Property(p => p.CustomerId).HasColumnName("CustomerID");
            modelBuilder.Entity<Car>().Property(p => p.Id).HasColumnName("CarID");
            modelBuilder.Entity<Color>().Property(p => p.Id).HasColumnName("ColorID");
            modelBuilder.Entity<Brand>().Property(p => p.Id).HasColumnName("BrandID");
        } 

    }
}
