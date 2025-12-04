using TODOO_List.Models;
using TODOO_List.Repositories;

namespace TODOO_List.Services
{
    public class NotesService(INoteRepository noteRepository) : INotesService
    {
        private readonly INoteRepository _noteRepository = noteRepository;

        public Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return _noteRepository.GetAllNotesAsync();
        }

        public Task<Note?> GetNoteByTitleAsync(string title)
        {
            return _noteRepository.GetNoteByTitleAsync(title);
        }

        public Task CreateNoteAsync(Note note)
        {
            return _noteRepository.CreateNoteAsync(note);
        }

        public Task UpdateNoteAsync(Note note)
        {
           return _noteRepository.UpdateNoteAsync(note);    
        }

        public Task DeleteNoteAsync(string title)
        {
            return _noteRepository.DeleteNoteAsync(title);
        }

    }
}
