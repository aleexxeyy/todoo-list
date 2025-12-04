using Microsoft.EntityFrameworkCore;
using TODOO_List.Models;

namespace TODOO_List.DataAccess
{
    public class NoteDbContext(DbContextOptions<NoteDbContext> options) : DbContext(options)
    {
        public DbSet<Note> Notes { get; set; }
    }
}
