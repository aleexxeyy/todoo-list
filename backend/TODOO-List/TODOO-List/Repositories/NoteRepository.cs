using Microsoft.EntityFrameworkCore;
using TODOO_List.DataAccess;
using TODOO_List.Models;

namespace TODOO_List.Repositories
{
    public class NoteRepository(NoteDbContext dbcontext) : INoteRepository
    {
        private readonly NoteDbContext _dbContext = dbcontext;

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _dbContext
                .Notes
                .ToListAsync();
        }

        public async Task<Note?> GetNoteByTitleAsync(string title)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Title == title);
            return note;
        }

        public async Task CreateNoteAsync(Note note)
        {
           var exsistingNote = await GetNoteByTitleAsync(note.Title);

            if (exsistingNote is not null)
                throw new InvalidOperationException("Note already exists.");

            var newNote = new Note 
            { 
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                CreatedAt = note.CreatedAt
            };

            await _dbContext.Notes.AddAsync(newNote);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(string title)
        {
            var note = await GetNoteByTitleAsync(title);

            if (note is null)
                throw new InvalidOperationException("Note does not exist.");

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNoteAsync(Note note)
        {
            var existingNote = await GetNoteByTitleAsync(note.Title);

            if (existingNote is null)
                throw new InvalidOperationException("Note does not exist.");

            existingNote.Description = note.Description;

            await _dbContext.SaveChangesAsync();
        }
    }
}
