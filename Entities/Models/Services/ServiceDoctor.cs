using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Services;

public class ServiceDoctor
{
    [Column("ServiceDoctorId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "La comision es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La comision no puede ser negativa")]
    [Precision(18, 2)]
    public decimal CommissionPrice { get; set; }

    [ForeignKey(nameof(Service))] public Guid? ServiceId { get; set; }
    public Service? Service { get; set; }

    [ForeignKey(nameof(Doctor))] public Guid? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
}