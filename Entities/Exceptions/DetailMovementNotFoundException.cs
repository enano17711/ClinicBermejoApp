namespace Entities.Exceptions;

public class DetailMovementNotFoundException : NotFoundException
{
    public DetailMovementNotFoundException(Guid id) : base($"DetailMovement with id: {id} not found.")
    {
    }
}