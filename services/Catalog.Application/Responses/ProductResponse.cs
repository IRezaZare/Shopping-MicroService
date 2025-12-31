using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.Application.Responses;

public class ProductResponse : IRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    //Relation
    public BrandResponse Brands { get; set; }
    public TypeResponse Types { get; set; }
}