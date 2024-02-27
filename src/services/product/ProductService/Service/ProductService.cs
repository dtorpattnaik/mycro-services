using Microsoft.AspNetCore.Mvc;
using ProductService.Entities;
using ProductService.Repository;
using System.Net;

namespace ProductService.Service;

public class ProductService
{
    private readonly IProductRepository _repository;
    private readonly ILogger<ProductService> _logger;
    public ProductService(IProductRepository repository, ILogger<ProductService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var products = await _repository.GetProducts();
        return products;
    }

    public async Task<Product> GetProductById(string id)
    {
        var product = await _repository.GetProduct(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id}, not found.");
        }

        return product;
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string category)
    {
        var products = await _repository.GetProductsByCategory(category);
        return products;
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        var items = await _repository.GetProductByName(name);
        if (items == null)
        {
            _logger.LogError($"Products with name: {name} not found.");
        }
        return items;
    }

    public async Task<Product> CreateProduct([FromBody] Product product)
    {
        await _repository.CreateProduct(product);

        return product;
    }

    public async Task UpdateProduct([FromBody] Product product)
    {
        await _repository.UpdateProduct(product);
    }

    public async Task DeleteProductById(string id)
    {
        await _repository.DeleteProduct(id);
    }
}