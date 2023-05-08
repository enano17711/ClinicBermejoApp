namespace Entities.Exceptions;

public class ServiceDoctorNotFoundException : NotFoundException
{
    public ServiceDoctorNotFoundException(Guid id) : base($"ServiceDoctor with id {id} not found")
    {
    }
}