using Contracts;
using Entities.Models;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class NurseRepository : RepositoryBase<Nurse>, INurseRepository
{
    public NurseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Nurse>> GetNursesAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(n => n.Name).ToListAsync();

    public async Task<Nurse> GetNurseByIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(n => n.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

    public void CreateNurse(Nurse nurse) => Create(nurse);

    public void DeleteNurse(Nurse nurse) => Delete(nurse);
}