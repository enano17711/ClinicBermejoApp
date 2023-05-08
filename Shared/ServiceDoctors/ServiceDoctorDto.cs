namespace Shared.ServiceDoctors;

public record ServiceDoctorDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }
}