using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data;

public static class TypeSeedData
{
    public static void SeedData(IMongoCollection<ProductType> collection)
    {
        var existCollation = collection.Find(x => true).Any();
        if (existCollation) return;
        var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "Types.json");
        if (!File.Exists(pathJson)) 
            throw new Exception($"The Seed Data of Types.json does not exist. : {pathJson}");

        var dataText = File.ReadAllText(pathJson);
        var types = JsonSerializer.Deserialize<List<ProductType>>(dataText);
        if (types != null) collection.InsertMany(types);
    }
}