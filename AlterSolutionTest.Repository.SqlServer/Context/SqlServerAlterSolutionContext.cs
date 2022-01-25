using AlterSolutionTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterSolutionTest.Repository.SqlServer.Context
{
    public class SqlServerAlterSolutionContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=AlterSolutionDB;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasOne(e => e.Category)
               .WithMany(c => c.Products);

            modelBuilder.Entity<Product>()
               .HasOne(e => e.Category)
               .WithMany(c => c.Products);
        }
    }
}
