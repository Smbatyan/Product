using FastEndpoints;
using Product.API.Contracts.Response;
using Product.API.Endpoints.Product;

namespace Product.API.Summaries;

public class GetProductsSummary : Summary<GetProductsEndpoint>
{
    public GetProductsSummary()
    {
        Summary = "Retrieves all products";
        Description = "This endpoint is used to get all products";
        Response<IEnumerable<ProductResponse>>(200, "Successful response");
        Params = new Dictionary<string, string>
        {
            { "page", "The page number to return (default is 1)." },
            { "pageSize", "The number of products to return per page (default is 10)." }
        };
    }
}