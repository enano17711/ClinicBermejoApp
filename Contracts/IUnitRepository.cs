using Entities.Models.Items;
using Shared.RequestFeatures;

namespace Contracts;

public interface IUnitRepository
{
    Task<PagedList<Unit>> GetUnitsAsync(UnitParameters parameters, bool trackChanges);
    void CreateUnit(Unit unit);
    Task<Unit?> GetUnitByIdAsync(Guid id, bool trackChanges);
    void DeleteUnit(Unit unit);
}