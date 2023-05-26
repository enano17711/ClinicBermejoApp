using Shared.Services;

namespace Shared.ServiceDoctors;

public record ServiceDoctorForDoctorViewDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }

    public ServiceForViewDto? Service { get; set; }
}