using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Appointments;
using Shared;

namespace Entities.Models.Staff;

public class Nurse : BasePerson
{
    [Column("NurseId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "La matricula es requerida")]
    public string? RegisterNumber { get; set; }

    public Specialty Specialty { get; set; }

    public ICollection<Patient>? Patients { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }
}