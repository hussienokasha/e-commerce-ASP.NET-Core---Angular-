using System;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreDbContext(DbContextOptions options) : DbContext(options)
{
   public required DbSet<Product> Products { get; set; }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Product>();
      modelBuilder.ApplyConfiguration(new ProductConfig());
   }
}
