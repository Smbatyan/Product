using FastEndpoints;
using FluentValidation;
using Product.API.Contracts.Request.Product;

namespace Product.API.Validations;

public class GetSingleProductValidator : Validator<GetSingleProductsRequest>
{
    public GetSingleProductValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}