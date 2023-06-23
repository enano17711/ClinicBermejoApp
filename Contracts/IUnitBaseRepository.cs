using Entities.Models.Items;
using Shared.RequestFeatures;

namespace Contracts;

public interface IUnitBaseRepository
{
    Task<PagedList<UnitBase>> GetUnitBasesAsync(UnitBaseParameters parameters, bool trackChanges);
    void CreateUnitBase(UnitBase unitBase);
    Task<UnitBase?> GetUnitBaseByIdAsync(Guid id, bool trackChanges);
    void DeleteUnitBase(UnitBase unitBase);
}