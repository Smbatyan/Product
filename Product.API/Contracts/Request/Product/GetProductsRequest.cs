using Microsoft.AspNetCore.Mvc;

namespace Product.API.Contracts.Request.Product;

public class GetProductsRequest
{
    [FromQuery] public int Page { get; set; } = 1;
    [FromQuery] public int PageSize { get; set; } = 10;
}