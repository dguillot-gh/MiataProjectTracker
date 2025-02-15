using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MiataProjectTracker.ValidationAttributes;


namespace MiataProjectTracker.Models;

public class BuildLog
{
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Summary { get; set; }
    [Required]
    [TagValidation]
    public string? Tag { get; set; }
    public DateOnly? Date { get; set; }
}
