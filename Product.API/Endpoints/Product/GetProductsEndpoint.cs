using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Product.API.Contracts.Request.Product;
using Product.API.Contracts.Response;
using Product.API.Services;

namespace Product.API.Endpoints.Product;

[HttpGet("product"), AllowAnonymous]
public class GetProductsEndpoint : Endpoint<GetProductsRequest, IEnumerable<ProductResponse>>
{
    private readonly ProductService _productService;
    
    public GetProductsEndpoint(ProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(GetProductsRequest req, CancellationToken ct)
    {
        IEnumerable<ProductResponse> products =
            await _productService.GetProductsAsync(req.Page, req.PageSize);
        
        await SendOkAsync(products);
    }
}