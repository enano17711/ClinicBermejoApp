namespace Entities.Exceptions;

public class CategoryServiceNotFoundException: NotFoundException
{
    public CategoryServiceNotFoundException(Guid id) : base($"CategoryService with id: {id} was not found")
    {
    }
}