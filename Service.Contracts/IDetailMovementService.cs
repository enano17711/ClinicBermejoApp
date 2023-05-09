using Shared.DetailMovements;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IDetailMovementService
{
    Task<(IEnumerable<DetailMovementDto> detailMovements, MetaData metaData)> GetDetailMovementsAsync(
        DetailMovementParameters parameters,
        bool trackChanges);

    Task<DetailMovementDto> GetDetailMovementByIdAsync(Guid id, bool trackChanges);
    Task<DetailMovementDto> CreateDetailMovementAsync(DetailMovementForCreationDto detailMovement);
    Task DeleteDetailMovementAsync(Guid id, bool trackChanges);
    Task UpdateDetailMovementAsync(Guid id, DetailMovementForUpdateDto detailMovement, bool trackChanges);
}