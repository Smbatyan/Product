using FastEndpoints;
using FluentValidation;
using Product.API.Contracts.Request.Product;

namespace Product.API.Validations;

public class CreateProductValidator : Validator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Description).MaximumLength(500);
    }
}