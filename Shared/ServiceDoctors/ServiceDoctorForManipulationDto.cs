using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.ServiceDoctors;

public abstract record ServiceDoctorForManipulationDto
{
    [Required(ErrorMessage = "La comision es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La comision no puede ser negativa")]
    [Precision(18, 2)]
    public decimal CommissionPrice { get; set; }

    public Guid? ServiceId { get; set; }

    public Guid? DoctorId { get; set; }
}