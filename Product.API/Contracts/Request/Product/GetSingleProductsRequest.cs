using Microsoft.AspNetCore.Mvc;

namespace Product.API.Contracts.Request.Product;

public class GetSingleProductsRequest
{
    [FromRoute]
    public int Id { get; set; }
}