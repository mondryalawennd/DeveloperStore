using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }

    public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

    public void ApplyDiscount(decimal discount)
    {
        Discount = discount;
    }
}