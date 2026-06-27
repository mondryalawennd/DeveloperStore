using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleProfile;

public class GetSaleCommand : IRequest<GetSaleResult>
{
    public Guid Id { get; set; }
}