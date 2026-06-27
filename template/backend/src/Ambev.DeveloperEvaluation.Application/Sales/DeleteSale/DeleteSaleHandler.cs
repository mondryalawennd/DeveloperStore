using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, bool>
{
    private readonly ISaleRepository _repository;
    private readonly ILogger<DeleteSaleHandler> _logger;

    public DeleteSaleHandler(ISaleRepository repository, ILogger<DeleteSaleHandler> logger)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _repository.GetByIdAsync(request.Id);

        if (sale == null)
            return false;

        await _repository.DeleteAsync(sale);
        _logger.LogInformation(  "EVENT: SaleCancelled | SaleId: {SaleId}",sale.Id);

        return true;
    }
}