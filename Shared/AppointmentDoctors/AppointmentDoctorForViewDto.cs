namespace Shared.AppointmentDoctors;

public record AppointmentDoctorForViewDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }
}