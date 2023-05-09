namespace Entities.Exceptions;

public class UnitNotFoundException : NotFoundException
{
    public UnitNotFoundException(Guid id) : base($"Unit with id: {id} not found")
    {
    }
}