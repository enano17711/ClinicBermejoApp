namespace Entities.Exceptions;

public class DoctorNotFoundException : NotFoundException
{
    public DoctorNotFoundException(Guid id) : base($"Doctor with id: {id} was not found")
    {
    }
}