using Contracts;
using Entities.Models;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class NurseRepository : RepositoryBase<Nurse>,
    INurseRepository
{
    public NurseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Nurse>> GetNursesAsync(NurseParameters parameters,
        bool trackChanges)
    {
        var nurses = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .ToListAsync();

        return PagedList<Nurse>.ToPagedList(nurses,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Nurse?> GetNurseByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateNurse(Nurse nurse) =>
        Create(nurse);

    public void DeleteNurse(Nurse nurse) =>
        Delete(nurse);
}