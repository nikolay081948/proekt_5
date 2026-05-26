using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StoreContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=STUDENT26;Database=OnlineStoreDB1;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.PasswordHash)
                    .IsRequired();

                entity.Property(u => u.Role)
                    .IsRequired();
            });


            builder.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });


            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Description)
                    .HasMaxLength(1000);

                entity.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");

                // Product -> Seller
                entity.HasOne(p => p.Seller)
                    .WithMany(u => u.Products)
                    .HasForeignKey(p => p.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Product -> Store
                entity.HasOne(p => p.Store)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.StoreId)
                    .OnDelete(DeleteBehavior.Cascade);
            });



            builder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.TotalPrice)
                    .HasColumnType("decimal(18,2)");

                entity.Property(o => o.OrderedAt)
                    .IsRequired();

                // Order -> Buyer
                entity.HasOne(o => o.Buyer)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Order -> Product
                entity.HasOne(o => o.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
