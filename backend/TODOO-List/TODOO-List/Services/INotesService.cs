using TODOO_List.Models;

namespace TODOO_List.Services
{
    public interface INotesService
    {
        // GET Methods
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task<Note?> GetNoteByTitleAsync(string title);

        // POST Methods
        Task CreateNoteAsync(Note note);

        // PUT Methods
        Task UpdateNoteAsync(Note note);

        // DELETE Methods
        Task DeleteNoteAsync(string title);
    }
}
