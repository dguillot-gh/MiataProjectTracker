using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiataProjectTracker.Models
{
    public class TaskComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; } = "";

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("TaskId")]
        public virtual BuildTasks? Task { get; set; }
    }
}