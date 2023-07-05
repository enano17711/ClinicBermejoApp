namespace Entities.Exceptions;

public class DetailOrderNotFoundException : NotFoundException
{
    public DetailOrderNotFoundException(Guid id) : base($"DetailOrder with id: {id} not found.")
    {
    }
}