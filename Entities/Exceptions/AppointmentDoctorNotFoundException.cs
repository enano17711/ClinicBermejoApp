namespace Entities.Exceptions;

public class AppointmentDoctorNotFoundException : NotFoundException
{
    public AppointmentDoctorNotFoundException(Guid id) : base($"AppointmentDoctor with id: {id} not found")
    {
    }
}