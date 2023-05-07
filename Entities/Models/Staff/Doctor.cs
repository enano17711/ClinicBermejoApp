using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Services;
using Shared;

namespace Entities.Models.Staff;

public class Doctor : BasePerson
{
    [Column("DoctorId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "La matricula es requerida")]
    public string? RegisterNumber { get; set; }

    public Specialty Specialty { get; set; }

    public ICollection<Patient>? Patients { get; set; }

    public ICollection<ServiceDoctor>? ServiceDoctors { get; set; }
}