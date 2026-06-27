using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; set; } = Guid.NewGuid().ToString();
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public string CustomerId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;

    public string BranchId { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;

    public bool IsCancelled { get; set; }

    public List<SaleItem> Items { get; set; } = new();

    public decimal TotalAmount => Items.Sum(x => x.TotalPrice);

    public void Cancel()
    {
        IsCancelled = true;
    }
}