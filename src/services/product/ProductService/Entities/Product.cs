using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ProductService.Entities;

public class Product
{
    [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public DateTime ManufacturingDate { get; set; }

    public decimal discountPercent { get; set; }

    [BsonElement("Name")]
    public required string Name { get; set; }
    public string Category { get; set; }
    
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public required decimal Price { get; set; }
    public string Summary { get; set; }
    public string Tags { get; set; }
}