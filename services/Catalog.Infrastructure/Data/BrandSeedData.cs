using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class BrandSeedData
{
    public static void SeedData(IMongoCollection<ProductBrand> collection)
    {
        var existCollation = collection.Find(x => true).Any();
        if(existCollation) return;
        var pathJson = Path.Combine(AppContext.BaseDirectory , "Data" , "SeedData" , "Brands.json");
        if (!File.Exists(pathJson)) 
            throw new Exception($"The Seed Data of Brands.json does not exist. : {pathJson}");
        
        var dataText= File.ReadAllText(pathJson);
        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(dataText);
        if(brands != null) collection.InsertMany(brands);
    }
}