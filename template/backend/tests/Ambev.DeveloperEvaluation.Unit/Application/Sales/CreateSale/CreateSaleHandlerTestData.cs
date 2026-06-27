using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public static class CreateSaleHandlerTestData
{
    private static readonly Faker<CreateSaleCommand> faker =
        new Faker<CreateSaleCommand>()
            .CustomInstantiator(f => new CreateSaleCommand
            {
                CustomerId = Guid.NewGuid().ToString(),
                CustomerName = f.Person.FullName,
                BranchId = Guid.NewGuid().ToString(),
                BranchName = f.Company.CompanyName(),
                Items = new List<CreateSaleItemCommand>
                {
                    new CreateSaleItemCommand
                    {
                        ProductId = Guid.NewGuid().ToString(),
                        ProductName = f.Commerce.ProductName(),
                        Quantity = 5,
                        UnitPrice = 10
                    }
                }
            });

    public static CreateSaleCommand GenerateValidCommand()
        => faker.Generate();
}