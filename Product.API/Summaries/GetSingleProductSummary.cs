using FastEndpoints;
using FluentValidation.Results;
using Product.API.Contracts.Response;
using Product.API.Endpoints.Product;

namespace Product.API.Summaries;

public class GetSingleProductSummary :  Summary<GetSingleProductEndpoint>
{
    public GetSingleProductSummary()
    {
        Summary = "Retrieves a single product by ID";
        Description = "This endpoint is used to get single product by ID";
        Response<ProductResponse>(200, "Successful response");
        Response<ValidationResult>(400, "Validation error");
        Params = new Dictionary<string, string>
        {
            { "id", "The Id of the product to retrieve." },
        };
    }
}