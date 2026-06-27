using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.BranchId).NotEmpty();
        RuleFor(x => x.BranchName).NotEmpty();

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Sale must have at least one item.");

        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(x => x.ProductId).NotEmpty();
            items.RuleFor(x => x.Quantity).GreaterThan(0);
            items.RuleFor(x => x.UnitPrice).GreaterThan(0);
        });
    }
}