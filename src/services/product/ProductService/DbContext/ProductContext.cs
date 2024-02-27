
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductService.Configuration;
using ProductService.Entities;

namespace ProductService.DbContext;

public class ProductContext : IProductContext
{
    public ProductContext(IOptions<ProductsDbConfig> productDbConfig, IMongoClient mongoClient)
    {
        var productDb = mongoClient.GetDatabase(productDbConfig.Value.DatabaseName);
        Products = productDb.GetCollection<Product>(productDbConfig.Value.CollectionName);
    }

    public IMongoCollection<Product> Products { get; }
}