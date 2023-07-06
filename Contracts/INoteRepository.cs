using Entities.Models.Orders;
using Shared.RequestFeatures;

namespace Contracts;

public interface INoteRepository
{
    Task<List<Note>> GetAllNotesAsync();
    Task<PagedList<Note>> GetNotesAsync(NoteParameters parameters, bool trackChanges);
    void CreateNote(Note note);
    Task<Note?> GetNoteByIdAsync(Guid id, bool trackChanges);
    void DeleteNote(Note note);
}