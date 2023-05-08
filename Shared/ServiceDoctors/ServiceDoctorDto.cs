using Shared.Doctors;
using Shared.Services;

namespace Shared.ServiceDoctors;

public record ServiceDoctorDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }

    public ServiceForViewDto? Service { get; set; }

    public DoctorDto? Doctor { get; set; }
}