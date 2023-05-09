namespace Entities.Exceptions;

public class ItemNotFoundException : NotFoundException
{
    public ItemNotFoundException(Guid id) : base($"Item with id: {id} not found")
    {
    }
}