using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Appointments;

public class AppointmentDoctor
{
    [Column("AppointmentDoctorId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "La comision es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La comision no puede ser negativa")]
    [Precision(18, 2)]
    public decimal CommissionPrice { get; set; }

    [ForeignKey(nameof(Appointment))] public Guid? AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }

    [ForeignKey(nameof(Doctor))] public Guid? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
}