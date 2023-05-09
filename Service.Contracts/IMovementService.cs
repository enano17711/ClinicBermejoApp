using Shared.Movements;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IMovementService
{
    Task<(IEnumerable<MovementDto> movements, MetaData metaData)> GetMovementsAsync(MovementParameters parameters,
        bool trackChanges);

    Task<MovementDto> GetMovementByIdAsync(Guid id, bool trackChanges);
    Task<MovementDto> CreateMovementAsync(MovementForCreationDto movement);
    Task DeleteMovementAsync(Guid id, bool trackChanges);
    Task UpdateMovementAsync(Guid id, MovementForUpdateDto movement, bool trackChanges);
}