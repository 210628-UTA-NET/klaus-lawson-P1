using Microsoft.EntityFrameworkCore;
using SAModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADL
{
    public  class SADBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Store> Stores{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<LineItem> lineItems { get; set; }
        public SADBContext() : base()
        { }

        public SADBContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)    
        {            
            //Address
            p_modelBuilder.Entity<Address>()
                .Property(addr => addr.Id)
                .ValueGeneratedOnAdd();
            
            //Customer
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.Id)
                .ValueGeneratedOnAdd();

            //Store
            p_modelBuilder.Entity<Store>()
                .Property(str => str.Id)
                .ValueGeneratedOnAdd();

            //Order
            p_modelBuilder.Entity<Order>()
                .Property(ord => ord.Id)
                .ValueGeneratedOnAdd();

            //LineItem
            p_modelBuilder.Entity<LineItem>()
                .HasKey(bc => new { bc.OrderId, bc.ProductId });
            p_modelBuilder.Entity<LineItem>()
                .HasOne(bc => bc.Order)
                .WithMany(b => b.LineItems)
                .HasForeignKey(bc => bc.OrderId);
            p_modelBuilder.Entity<LineItem>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.LineItems)
                .HasForeignKey(bc => bc.ProductId);

            //Product
            p_modelBuilder.Entity<Product>()
                .Property(prd => prd.Id)
                .ValueGeneratedOnAdd();

            //Category
            p_modelBuilder.Entity<Category>()
                .Property(cat => cat.Id)
                .ValueGeneratedOnAdd();           
        }
    }
}
