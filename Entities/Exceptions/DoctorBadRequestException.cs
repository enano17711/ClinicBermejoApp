namespace Entities.Exceptions;

public class DoctorBadRequestException : BadRequestException
{
    public DoctorBadRequestException() : base("Doctor Bad Request")
    {
    }
}