namespace ProductService.Configuration;

public class ProductsDbConfig
{
    public required string ConnectionString { get; set; }

    public required string DatabaseName { get; set; }

    public required string CollectionName { get; set; }
}