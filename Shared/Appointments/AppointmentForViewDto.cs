namespace Shared.Appointments;

public record AppointmentForViewDto
{
    public Guid Id { get; set; }

    public DateTime DateInit { get; set; }

    public DateTime DateEnd { get; set; }

    public decimal Price { get; set; }
}