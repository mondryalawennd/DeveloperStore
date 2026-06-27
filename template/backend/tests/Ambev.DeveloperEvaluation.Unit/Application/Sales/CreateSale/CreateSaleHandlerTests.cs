using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _repository;
    private readonly DiscountService _discountService;
    private readonly ILogger<CreateSaleHandler> _logger;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _repository = Substitute.For<ISaleRepository>();
        _discountService = new DiscountService();
        _logger = Substitute.For<ILogger<CreateSaleHandler>>();

        _handler = new CreateSaleHandler(
            _repository,
            _discountService,
            _logger
        );
    }

    [Fact]
    public async Task Handle_ShouldCreateSaleSuccessfully()
    {
        // Arrange
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        _repository.AddAsync(Arg.Any<Sale>())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        await _repository.Received(1)
            .AddAsync(Arg.Any<Sale>());
    }
}