using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data.SeedData;

public class StoreContextSeed
{
    public static async Task SeedData(StoreDbContext context)
    {
        if (!context.Products.Any())
        {
            var products = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
            var productsData = JsonSerializer.Deserialize<List<Product>>(products);
            await context.Products.AddRangeAsync(productsData!);
            await context.SaveChangesAsync();
    
        }
    }
}
