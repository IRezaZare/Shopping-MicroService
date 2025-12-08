using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data;

public static class ProductSeedData
{
    public static void SeedData(IMongoCollection<Product> collection)
    {
        var existCollation = collection.Find(x => true).Any();
        if (existCollation) return;
        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "Products.json");
        if (!File.Exists(pathJson)) 
            throw new Exception($"The Seed Data of Products.json does not exist. : {pathJson}");
        
        var dataText = File.ReadAllText(pathJson);
        var products = JsonSerializer.Deserialize<List<Product>>(dataText);
        if (products != null) collection.InsertMany(products);
    }
}