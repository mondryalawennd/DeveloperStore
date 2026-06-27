using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _repository;
    private readonly DiscountService _discount;
    private readonly ILogger<CreateSaleHandler> _logger;


    public CreateSaleHandler(ISaleRepository repository, DiscountService discount, ILogger<CreateSaleHandler> logger)
    {
        _repository = repository;
        _discount = discount;
        _logger = logger;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new Sale
        {
            CustomerId = request.CustomerId,
            CustomerName = request.CustomerName,
            BranchId = request.BranchId,
            BranchName = request.BranchName
        };

        foreach (var i in request.Items)
        {
            var item = new SaleItem
            {
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            };

            _discount.ApplyDiscount(item);

            sale.Items.Add(item);
        }

        await _repository.AddAsync(sale);

        _logger.LogInformation("EVENT: SaleCreated | SaleId: {SaleId} | Total: {Total}", sale.Id, sale.TotalAmount);

        return new CreateSaleResult
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            TotalAmount = sale.TotalAmount
        };
    }
}