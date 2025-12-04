using System.ComponentModel.DataAnnotations;

namespace TODOO_List.Models
{
    public class Note
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
