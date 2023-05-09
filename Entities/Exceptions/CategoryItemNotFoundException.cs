namespace Entities.Exceptions;

public class CategoryItemNotFoundException : NotFoundException
{
    public CategoryItemNotFoundException(Guid id) : base($"Category item with id: {id} not found.")
    {
    }
}