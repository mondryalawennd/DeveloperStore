using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult?>
{
    private readonly ISaleRepository _repository;
    private readonly ILogger<UpdateSaleHandler> _logger;

    public UpdateSaleHandler(ISaleRepository repository, ILogger<UpdateSaleHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<UpdateSaleResult?> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.Id);

        if (sale == null)
            return null;

        sale.CustomerId = request.CustomerId;
        sale.CustomerName = request.CustomerName;
        sale.BranchId = request.BranchId;
        sale.BranchName = request.BranchName;

        await _repository.UpdateAsync(sale);

        _logger.LogInformation("EVENT: SaleUpdated | SaleId: {SaleId}", sale.Id);

        return new UpdateSaleResult
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            TotalAmount = sale.TotalAmount
        };
    }
}