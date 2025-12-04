using Microsoft.AspNetCore.Mvc;
using TODOO_List.Dto;
using TODOO_List.Models;
using TODOO_List.Services;

namespace TODOO_List.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController(INotesService notesService) : ControllerBase
    {
        private readonly INotesService _notesService = notesService;

        [HttpGet("get-all-note")]
        public async Task<IActionResult> GetAllNote()
        {
            var note = await _notesService.GetAllNotesAsync();

            return Ok(note);
        }

        [HttpGet("get-note")]
        public async Task<IActionResult> GetNoteByTitle([FromQuery] string title)
        {
            var note = await _notesService.GetNoteByTitleAsync(title);

            return Ok(note);
        }

        [HttpPost("create-note")]
        public async Task<IActionResult> CreateNote([FromBody] NoteDto noteDto)
        {
            var newNote = new Note
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
            };

            await _notesService.CreateNoteAsync(newNote);

            return Ok(newNote);
        }

        [HttpPut("update-note")]
        public async Task<IActionResult> UpdateNote([FromBody] NoteDto noteDto)
        {
            var newNote = new Note
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
            };

            await _notesService.UpdateNoteAsync(newNote);

            return Ok(newNote);
        }

        [HttpDelete("delete-note")]
        public async Task<IActionResult> DeleteNote([FromBody] string title)
        {
            var newNote = _notesService.DeleteNoteAsync(title);

            return Ok(newNote);
        }
    }
}
