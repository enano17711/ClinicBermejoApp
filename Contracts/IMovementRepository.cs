using Entities.Models.Movements;
using Shared.RequestFeatures;

namespace Contracts;

public interface IMovementRepository
{
    Task<PagedList<Movement>> GetMovementsAsync(MovementParameters parameters, bool trackChanges);
    void CreateMovement(Movement movement);
    Task<Movement?> GetMovementByIdAsync(Guid id, bool trackChanges);
    void DeleteMovement(Movement movement);
}