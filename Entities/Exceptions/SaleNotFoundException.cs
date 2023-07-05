namespace Entities.Exceptions;

public class SaleNotFoundException : NotFoundException
{
    public SaleNotFoundException(Guid id) : base($"Sale with id: {id} not found")
    {
    }
}