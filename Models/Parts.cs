using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MiataProjectTracker.Models;

public class Parts
{
    public int Id { get; set; }
    public string? PartName { get; set; }
    public string? PartNumber { get; set; }
    public string? PartStatus { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PartCost { get; set; 
    }
}