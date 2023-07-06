using Contracts;
using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class NoteRepository : RepositoryBase<Note>,
    INoteRepository
{
    public NoteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<List<Note>> GetAllNotesAsync()
    {
        var notes = await FindAll(false).ToListAsync();
        return notes;
    }

    public async Task<PagedList<Note>> GetNotesAsync(NoteParameters parameters,
        bool trackChanges)
    {
        var notes = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(n => n.Orders)
            .Include(n => n.Sales)
            .ToListAsync();

        return PagedList<Note>.ToPagedList(notes,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Note?> GetNoteByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(n => n.Orders)
            .Include(n => n.Sales)
            .SingleOrDefaultAsync();
    }

    public void CreateNote(Note note)
    {
        Create(note);
    }

    public void DeleteNote(Note note)
    {
        Delete(note);
    }
}