using System.ComponentModel.DataAnnotations;

namespace TODOO_List.Dto
{
    public class NoteDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
