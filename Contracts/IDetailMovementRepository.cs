using Entities.Models.Movements;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDetailMovementRepository
{
    Task<PagedList<DetailMovement>> GetDetailMovementsAsync(DetailMovementParameters parameters, bool trackChanges);
    void CreateDetailMovement(DetailMovement detailMovement);
    Task<DetailMovement?> GetDetailMovementByIdAsync(Guid id, bool trackChanges);
    void DeleteDetailMovement(DetailMovement detailMovement);
}