namespace Entities.Exceptions;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(Guid id) : base($"Customer with id: {id} was not found")
    {
    }
}