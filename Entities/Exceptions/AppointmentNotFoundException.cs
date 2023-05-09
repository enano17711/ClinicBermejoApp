namespace Entities.Exceptions;

public class AppointmentNotFoundException : NotFoundException
{
    public AppointmentNotFoundException(Guid id) : base($"Appointment with id {id} not found")
    {
    }
}