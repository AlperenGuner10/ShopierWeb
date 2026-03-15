using Microsoft.EntityFrameworkCore;
using Shopier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Persistance.Context
{
	public class AppDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-TVGOALM\\SQLEXPRESS;Database=ShopierDb;TrustServerCertificate=true;Integrated Security=True;");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Product> Products { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);

		//	modelBuilder.Entity<Category>()
		//		.HasMany(c => c.Products)
		//		.WithOne(p => p.Category)
		//		.HasForeignKey(p => p.CategoryId);

		//	modelBuilder.Entity<Product>()
		//		.HasOne(p => p.Category)
		//		.WithMany(c => c.Products)
		//		.HasForeignKey(p => p.CategoryId);

		//	modelBuilder.Entity<Customer>()
		//		.HasMany(c => c.Orders)
		//		.WithOne(o => o.Customer)
		//		.HasForeignKey(o => o.CustomerId);

		//	modelBuilder.Entity<Order>()
		//		.HasOne(o=>o.Customer)
		//		.WithMany(c => c.Orders)
		//		.HasForeignKey(o => o.CustomerId);

		//	modelBuilder.Entity<Order>()
		//		.HasMany(o=> o.OrderItems)
		//		.WithOne(oi=>oi.Order)
		//		.HasForeignKey(oi=>oi.OrderId);

		//	modelBuilder.Entity<OrderItem>()
		//		.HasOne(oi => oi.Order)
		//		.WithMany(o=> o.OrderItems)
		//		.HasForeignKey(oi => oi.OrderId);
		//}
	}
}
