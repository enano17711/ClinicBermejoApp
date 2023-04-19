using Entities.Models;

namespace Contracts;

public interface INurseRepository
{
    Task<IEnumerable<Nurse>> GetNursesAsync(bool trackChanges);
    void CreateNurse(Nurse nurse);
    Task<Nurse> GetNurseByIdAsync(Guid id, bool trackChanges);
    void DeleteNurse(Nurse nurse);
}