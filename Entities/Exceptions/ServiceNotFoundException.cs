namespace Entities.Exceptions;

public class ServiceNotFoundException : NotFoundException
{
    public ServiceNotFoundException(Guid id) : base($"Service with id: {id} was not found")
    {
    }
}