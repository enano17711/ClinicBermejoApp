namespace Entities.Exceptions;

public class UnitBaseNotFoundException : NotFoundException
{
    public UnitBaseNotFoundException(Guid id) : base($"UnitBase with id: {id} not found")
    {
    }
}