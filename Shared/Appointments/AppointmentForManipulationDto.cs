using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Appointments;

public abstract record AppointmentForManipulationDto
{
    [Required(ErrorMessage = "La fecha de inicio es requerida")]
    public DateTime DateInit { get; set; }

    [Required(ErrorMessage = "La fecha de fin es requerida")]
    public DateTime DateEnd { get; set; }

    [Required(ErrorMessage = "El Precio es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo")]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    public Guid? DoctorId { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? NurseId { get; set; }
}