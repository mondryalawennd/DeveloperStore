namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleProfile;

public class GetSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public List<GetSaleProfileItemResult> Items { get; set; } = new();
}

public class GetSaleProfileItemResult
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
}