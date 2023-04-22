using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Product.API.Contracts.Request.Product;
using Product.API.Contracts.Response;
using Product.API.Services;

namespace Product.API.Endpoints.Product;

[FastEndpoints.HttpPut("/product/{id}"), Authorize]
public class UpdateProductEndpoint : Endpoint<UpdateProductRequest, ProductResponse>
{
    private readonly ProductService _productService;

    public UpdateProductEndpoint(ProductService productService)
    {
        _productService = productService;
    }

    public override async Task HandleAsync(UpdateProductRequest req, CancellationToken ct)
    {
        ProductResponse response = await _productService.UpdateProductAsync(req);

        await SendOkAsync(response);
    }
}