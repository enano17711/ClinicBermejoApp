using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Staff;

namespace Entities.Models;

public class Patient : BasePerson
{
    [Column("PatientId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "La Historia Clinica es requerida")]
    public string? ClinicHistory { get; set; }


    [ForeignKey(nameof(Doctor))] public Guid? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }


    [ForeignKey(nameof(Nurse))] public Guid? NurseId { get; set; }
    public Nurse? Nurse { get; set; }
}