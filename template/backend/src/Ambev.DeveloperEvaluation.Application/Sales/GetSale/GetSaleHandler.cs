using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleProfile;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _repository;

    public GetSaleHandler(ISaleRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.Id);

        if (sale == null)
            return null;

        return new GetSaleResult
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            SaleDate = sale.SaleDate,
            CustomerName = sale.CustomerName,
            BranchName = sale.BranchName,
            TotalAmount = sale.TotalAmount,
            Items = sale.Items.Select(x => new GetSaleProfileItemResult
            {
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                Discount = x.Discount,
                TotalPrice = x.TotalPrice
            }).ToList()
        };
    }
}