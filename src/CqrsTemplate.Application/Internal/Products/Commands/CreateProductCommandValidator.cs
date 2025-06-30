using CqrsTemplate.Application.Internal.Products.Commands;
using FluentValidation;

namespace CqrsTemplate.Application.Internal.Products.Validators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.CreateProductData)
            .SetValidator(new CreateProductRequestDtoValidator());
    }
}
