namespace Entities.Exceptions;

public class PatientNotFoundException : NotFoundException
{
    public PatientNotFoundException(Guid id) : base($"Patient with id: {id} was not found")
    {
    }
}