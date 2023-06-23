using Shared.RequestFeatures;
using Shared.UnitBases;

namespace Service.Contracts;

public interface IUnitBaseBaseService
{
    Task<(IEnumerable<UnitBaseDto> unitBases, MetaData metaData)> GetUnitBasesAsync(UnitBaseParameters parameters,
        bool trackChanges);

    Task<UnitBaseDto> GetUnitBaseByIdAsync(Guid id, bool trackChanges);
    Task<UnitBaseDto> CreateUnitBaseAsync(UnitBaseForCreationDto unitBase);
    Task DeleteUnitBaseAsync(Guid id, bool trackChanges);
    Task UpdateUnitBaseAsync(Guid id, UnitBaseForUpdateDto unitBase, bool trackChanges);
}