using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MiataProjectTracker.ValidationAttributes;


namespace MiataProjectTracker.Models;

public class PriceComparison
{
    public int Id { get; set; }
    public string PartName { get; set; } = string.Empty;
    public decimal NewPrice { get; set; }
    public decimal ActualPaidPrice { get; set; }
    public string? Source { get; set; }  // Where you bought it from
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public string? Notes { get; set; }

    public decimal Savings => NewPrice - ActualPaidPrice;
    public decimal SavingsPercentage => (NewPrice > 0) ? ((NewPrice - ActualPaidPrice) / NewPrice) * 100 : 0;
} 