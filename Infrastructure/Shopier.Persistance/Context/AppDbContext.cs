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
		public DbSet<Cart> Cart { get; set; }
		public DbSet<CartItem> CartItems { get; set; }


	}
}
