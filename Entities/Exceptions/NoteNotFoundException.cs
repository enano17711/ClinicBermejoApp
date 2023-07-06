namespace Entities.Exceptions;

public class NoteNotFoundException : NotFoundException
{
    public NoteNotFoundException(Guid id) : base($"Note with id: {id} not found")
    {
    }
}