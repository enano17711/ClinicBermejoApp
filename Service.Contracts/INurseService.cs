using Shared;
using Shared.Nurses;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface INurseService
{
    Task<(IEnumerable<NurseDto> nurses, MetaData metaData)> GetNursesAsync(NurseParameters parameters,
        bool trackChanges);

    Task<NurseDto> GetNurseByIdAsync(Guid id, bool trackChanges);
    Task<NurseDto> CreateNurseAsync(NurseForCreationDto nurse);
    Task DeleteNurseAsync(Guid id, bool trackChanges);
    Task UpdateNurseAsync(Guid id, NurseForUpdateDto nurse, bool trackChanges);
}