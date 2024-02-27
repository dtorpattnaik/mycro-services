using MongoDB.Driver;
using ProductService.Entities;

namespace ProductService.DbContext;

public interface IProductContext
{
    IMongoCollection<Product> Products { get; }
}