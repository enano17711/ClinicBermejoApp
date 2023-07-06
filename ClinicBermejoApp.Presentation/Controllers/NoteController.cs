using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Notes;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly IServiceManager _service;

    public NoteController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetNotes")]
    public async Task<IActionResult> GetNotes([FromQuery] NoteParameters parameters)
    {
        var pagedResult = await _service.NoteService.GetNotesAsync(parameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.notes);
    }

    [HttpGet("{id:guid}", Name = "GetNoteById")]
    public async Task<IActionResult> GetNoteById(Guid id)
    {
        var note = await _service.NoteService.GetNoteByIdAsync(id, false);
        return Ok(note);
    }

    [HttpPost(Name = "CreateNote")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateNote([FromBody] NoteForCreationDto note)
    {
        var createNote = await _service.NoteService.CreateNoteAsync(note);
        return CreatedAtRoute("GetNoteById", new { id = createNote.Id }, createNote);
    }

    [HttpDelete("{id:guid}", Name = "DeleteNote")]
    public async Task<IActionResult> DeleteNote(Guid id)
    {
        await _service.NoteService.DeleteNoteAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateNote")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateNote(Guid id, [FromBody] NoteForUpdateDto note)
    {
        await _service.NoteService.UpdateNoteAsync(id, note, true);
        return NoContent();
    }
}