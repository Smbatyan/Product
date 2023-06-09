namespace Product.API.Contracts.Response;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
}