using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SACDL.Entities
{
    public partial class AppStoreDbContext : DbContext
    {
        public AppStoreDbContext()
        {
        }

        public AppStoreDbContext(DbContextOptions<AppStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseSqlServer("Server=tcp:klaus-server.database.windows.net,1433;Initial Catalog=AppStoreDb;Persist Security Info=False;User ID=klauslawsondjecky@gmail.com@klaus-server;Password=K12241997e.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.CustomerPhone, "UQ__Customer__6ABBA970AA4DF21F")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerEmail, "UQ__Customer__881B3A6388A9000A")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("_customerAddress");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("_customerEmail");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("_customerName");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("_customerPhone");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasKey(e => e.LineItemsId)
                    .HasName("LineItemsPK");

                entity.Property(e => e.LineItemsId).HasColumnName("lineItemsId");

                entity.Property(e => e.LineItemsProductQuantity)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("_lineItemsProductQuantity");

                entity.Property(e => e.OrdersId).HasColumnName("_ordersId");

                entity.Property(e => e.ProductId).HasColumnName("_productId");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("LiOrdersFK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("LIProductFK");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrdersId)
                    .HasName("OrderPK");

                entity.Property(e => e.OrdersId).HasColumnName("ordersId");

                entity.Property(e => e.CustomerId).HasColumnName("_customerId");

                entity.Property(e => e.OrdersLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("_ordersLocation");

                entity.Property(e => e.OrdersTotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("_ordersTotalPrice");

                entity.Property(e => e.StoreFrontId).HasColumnName("_storeFrontId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("CustOrderFK");

                entity.HasOne(d => d.StoreFront)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreFrontId)
                    .HasConstraintName("StoreOrderFK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("_productName");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("_productPrice");

                entity.Property(e => e.ProductQuantity).HasColumnName("_productQuantity");

                entity.Property(e => e.Productcategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("_productcategory");

                entity.Property(e => e.Productdescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("_productdescription");

                entity.Property(e => e.StoreFrontId).HasColumnName("_storeFrontId");

                entity.HasOne(d => d.StoreFront)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreFrontId)
                    .HasConstraintName("ProductStoreFrontFK");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.ToTable("StoreFront");

                entity.HasIndex(e => e.StoreFrontAddress, "UQ__StoreFro__A777CE85F02D367D")
                    .IsUnique();

                entity.Property(e => e.StoreFrontId).HasColumnName("storeFrontId");

                entity.Property(e => e.StoreFrontAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("_storeFrontAddress");

                entity.Property(e => e.StoreFrontName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("_storeFrontName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
