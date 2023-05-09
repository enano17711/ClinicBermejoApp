namespace Entities.Exceptions;

public class MovementNotFoundException : NotFoundException
{
    public MovementNotFoundException(Guid id) : base($"Movement with id: {id} not found")
    {
    }
}