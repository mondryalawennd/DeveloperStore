using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services;

public class DiscountService
{
    public void ApplyDiscount(SaleItem item)
    {
        if (item.Quantity >= 10 && item.Quantity <= 20)
        {
            item.ApplyDiscount(item.UnitPrice * item.Quantity * 0.20m);
            return;
        }

        if (item.Quantity >= 4)
        {
            item.ApplyDiscount(item.UnitPrice * item.Quantity * 0.10m);
            return;
        }

        if (item.Quantity > 20)
        {
            throw new InvalidOperationException("Cannot sell more than 20 items of the same product.");
        }

        item.ApplyDiscount(0);
    }
}