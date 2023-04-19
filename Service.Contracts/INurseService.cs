using Shared;
using Shared.Nurses;

namespace Service.Contracts;

public interface INurseService
{
    Task<IEnumerable<NurseDto>> GetNursesAsync(bool trackChanges);
    Task<NurseDto> GetNurseByIdAsync(Guid id, bool trackChanges);
    Task<NurseDto> CreateNurseAsync(NurseForCreationDto nurse);
    Task DeleteNurseAsync(Guid id, bool trackChanges);
    Task UpdateNurseAsync(Guid id, NurseForUpdateDto nurse, bool trackChanges);
}