using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Appointments;

public class Appointment
{
    [Column("AppointmentId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es requerida")]
    public DateTime DateInit { get; set; }

    [Required(ErrorMessage = "La fecha de fin es requerida")]
    public DateTime DateEnd { get; set; }

    [Required(ErrorMessage = "El Precio es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser positivo")]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey(nameof(Doctor))] public Guid? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    [ForeignKey(nameof(Patient))] public Guid? PatientId { get; set; }
    public Patient? Patient { get; set; }

    [ForeignKey(nameof(Nurse))] public Guid? NurseId { get; set; }
    public Nurse? Nurse { get; set; }
}