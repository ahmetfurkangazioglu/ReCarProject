using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
      public class ReCarProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Database=ReCarProject;Trusted_Connection=true");
        }
        public DbSet<Car> cars { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Rental> rentals { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CarImage> carImages { get; set; }
    }
}
