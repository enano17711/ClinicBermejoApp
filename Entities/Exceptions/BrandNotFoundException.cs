namespace Entities.Exceptions;

public class BrandNotFoundException : NotFoundException
{
    public BrandNotFoundException(Guid id) : base($"Brand with id {id} not found")
    {
    }
}