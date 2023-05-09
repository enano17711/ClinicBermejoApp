using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.AppointmentDoctors;

public abstract record AppointmentDoctorForManipulationDto
{
    [Required(ErrorMessage = "La comision es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La comision no puede ser negativa")]
    [Precision(18, 2)]
    public decimal CommissionPrice { get; set; }

    public Guid? AppointmentId { get; set; }

    public Guid? DoctorId { get; set; }
}