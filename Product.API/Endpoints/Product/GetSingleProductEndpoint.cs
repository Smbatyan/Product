using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Product.API.Contracts.Request.Product;
using Product.API.Contracts.Response;
using Product.API.Services;

namespace Product.API.Endpoints.Product;

[HttpGet("product/{id}"), AllowAnonymous]
public class GetSingleProductEndpoint : Endpoint<GetSingleProductsRequest, ProductResponse>
{
    private readonly ProductService _productService;
    
    public GetSingleProductEndpoint(ProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(GetSingleProductsRequest req, CancellationToken ct)
    {
        ProductResponse product = await _productService.GetProductAsync(req.Id);
        
        await SendOkAsync(product);
    }
}