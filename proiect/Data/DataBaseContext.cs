using System;
using Microsoft.EntityFrameworkCore;
using proiect.Models;

namespace proiect.Data
{
	public class DataBaseContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Shoe> Shoes { get; set; }
		public DbSet<Purchase> Purchases { get; set; }
		public DbSet<CardMember> CardMembers { get; set; }


		public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Many-to-Many
			modelBuilder.Entity<Purchase>()
			   .HasKey(p => new { p.OrderId, p.ShoeId });

			modelBuilder.Entity<Purchase>()
				.HasOne<Shoe>(s => s.Shoe)
				.WithMany(p => p.Purchases)
				.HasForeignKey(s => s.ShoeId);

			modelBuilder.Entity<Purchase>()
				.HasOne<Order>(o => o.Order)
				.WithMany(p => p.Purchases)
				.HasForeignKey(o => o.OrderId);

			//One-to-Many
			modelBuilder.Entity<User>()
				.HasMany(o => o.Orders)
				.WithOne(u => u.Client);

			//One-to-One
			modelBuilder.Entity<User>()
				.HasOne(u => u.CardMember)
				.WithOne(c => c.Client)
				.HasForeignKey<User>(u => u.CardMemberId);


			base.OnModelCreating(modelBuilder);
		}
	}
}

