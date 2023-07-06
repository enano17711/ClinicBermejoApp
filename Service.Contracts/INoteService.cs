using Shared.Notes;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface INoteService
{
    Task<(IEnumerable<NoteDto> notes, MetaData metaData)> GetNotesAsync(NoteParameters parameters,
        bool trackChanges);

    Task<NoteDto> GetNoteByIdAsync(Guid id, bool trackChanges);
    Task<NoteDto> CreateNoteAsync(NoteForCreationDto note);
    Task DeleteNoteAsync(Guid id, bool trackChanges);
    Task UpdateNoteAsync(Guid id, NoteForUpdateDto note, bool trackChanges);
}