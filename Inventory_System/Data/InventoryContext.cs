using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Inventory_System.Data
{
    public class InventoryContext :DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BatchNumber> BatchNumbers { get; set; }
        public DbSet<ManuFactor> ManuFactors { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<SNnumber> SNnumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<BatchNumber>().ToTable("BatchNumber");
            modelBuilder.Entity<ManuFactor>().ToTable("ManuFactory");
            modelBuilder.Entity<WareHouse>().ToTable("WareHouse");
            modelBuilder.Entity<SNnumber>().ToTable("SNnumber");
        }

    }
}
