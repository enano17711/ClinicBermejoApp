using Shared.RequestFeatures;
using Shared.Units;

namespace Service.Contracts;

public interface IUnitService
{
    Task<(IEnumerable<UnitDto> units, MetaData metaData)> GetUnitsAsync(UnitParameters parameters,
        bool trackChanges);

    Task<UnitDto> GetUnitByIdAsync(Guid id, bool trackChanges);
    Task<UnitDto> CreateUnitAsync(UnitForCreationDto unit);
    Task DeleteUnitAsync(Guid id, bool trackChanges);
    Task UpdateUnitAsync(Guid id, UnitForUpdateDto unit, bool trackChanges);
}