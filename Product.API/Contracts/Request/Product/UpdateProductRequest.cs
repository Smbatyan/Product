using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Contracts.Request.Product;

public class UpdateProductRequest
{
    [FromRoute]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}