using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MiataProjectTracker.Models;

public class Parts
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? PartName { get; set; }
    public string? PartNumber { get; set; }

    [Required]
    [RegularExpression("Accquired|Needed", ErrorMessage = "Part Status must be Accquired, or Needed")]
    public string? PartStatus { get; set; }

    [Range(0, 1000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PartCost { get; set; }
}
