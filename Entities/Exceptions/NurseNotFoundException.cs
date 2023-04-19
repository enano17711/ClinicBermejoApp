namespace Entities.Exceptions;

public class NurseNotFoundException : NotFoundException
{
    public NurseNotFoundException(Guid id) : base($"Nurse with id: {id} was not found")
    {
    }
}