using Entities.Models;
using Entities.Models.Staff;
using Shared.RequestFeatures;

namespace Contracts;

public interface INurseRepository
{
    Task<PagedList<Nurse>> GetNursesAsync(NurseParameters parameters, bool trackChanges);
    void CreateNurse(Nurse nurse);
    Task<Nurse?> GetNurseByIdAsync(Guid id, bool trackChanges);
    void DeleteNurse(Nurse nurse);
}