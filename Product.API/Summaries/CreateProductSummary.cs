using FastEndpoints;
using FluentValidation.Results;
using Product.API.Contracts.Response;
using Product.API.Endpoints.Product;

namespace Product.API.Summaries;

public class CreateProductSummary : Summary<CreateProductEndpoint>
{
    public CreateProductSummary()
    {
        Summary = "Creates a new product";
        Description = "This endpoint is used to create a new product";
        Response<ProductResponse>(200, "Successful response");
        Response<ValidationResult>(400, "Validation error");
        Response<ValidationResult>(409, "Resource already exists");
        Params = new Dictionary<string, string>
        {
            { "name", "The name of the product." },
            { "description", "The description of the product." },
            { "price", "The price of the product." },
            {
                "quantity", "The quantity of the product." +
                            "If the quantity is 0, the product is out of stock."
            }
        };
    }
}