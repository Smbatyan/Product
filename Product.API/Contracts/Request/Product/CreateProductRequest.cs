namespace Product.API.Contracts.Request.Product;

public class CreateProductRequest
{
    public string Name { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}