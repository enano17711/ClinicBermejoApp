namespace Entities.Exceptions;

public class SupplierNotFoundException : NotFoundException
{
    public SupplierNotFoundException(Guid id) : base($"Supplier with id: {id} was not found")
    {
    }
}