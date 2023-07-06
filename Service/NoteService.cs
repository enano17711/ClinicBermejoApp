using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Orders;
using Service.Contracts;
using Shared.Notes;
using Shared.RequestFeatures;

namespace Service;

public class NoteService : INoteService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public NoteService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<NoteDto> notes, MetaData metaData)> GetNotesAsync(
        NoteParameters parameters,
        bool trackChanges)
    {
        var notesWithMetaData = await _repository.Notes.GetNotesAsync(parameters, trackChanges);
        var notesDto = _mapper.Map<IEnumerable<NoteDto>>(notesWithMetaData);

        return (notesDto, notesWithMetaData.MetaData);
    }

    public async Task<NoteDto> GetNoteByIdAsync(Guid id, bool trackChanges)
    {
        var note = await GetNoteAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<NoteDto>(note);
    }

    public async Task<NoteDto> CreateNoteAsync(NoteForCreationDto note)
    {
        var noteEntity = _mapper.Map<Note>(note);
        _repository.Notes.CreateNote(noteEntity);
        await _repository.SaveAsync();
        return _mapper.Map<NoteDto>(noteEntity);
    }

    public async Task DeleteNoteAsync(Guid id, bool trackChanges)
    {
        var note = await GetNoteAndCheckIfItExists(id, trackChanges);
        _repository.Notes.DeleteNote(note);
        await _repository.SaveAsync();
    }

    public async Task UpdateNoteAsync(Guid id, NoteForUpdateDto note, bool trackChanges)
    {
        var noteEntity = await GetNoteAndCheckIfItExists(id, trackChanges);
        _mapper.Map(note, noteEntity);
        await _repository.SaveAsync();
    }

    private async Task<Note> GetNoteAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var note = await _repository.Notes.GetNoteByIdAsync(id, trackChanges);
        if (note is null) throw new NoteNotFoundException(id);
        return note;
    }
}