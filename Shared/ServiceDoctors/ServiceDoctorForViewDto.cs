namespace Shared.ServiceDoctors;

public record ServiceDoctorForViewDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }
}