using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Product.API.Contracts.Request.Product;
using Product.API.Contracts.Response;
using Product.API.Services;

namespace Product.API.Endpoints.Product;

[FastEndpoints.HttpPost("/product"), Authorize]
public class CreateProductEndpoint : Endpoint<CreateProductRequest, ProductResponse>
{
    private readonly ProductService _productService;
    
    public CreateProductEndpoint(ProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
    {
        ProductResponse product = await _productService.CreateProductAsync(req);
        
        await SendOkAsync(product);
    }
}