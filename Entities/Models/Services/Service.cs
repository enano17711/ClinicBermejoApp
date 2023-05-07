using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Services;

public class Service : BaseService
{
    [Column("ServiceId")] public Guid ServiceId { get; set; }

    public ICollection<ServiceDoctor>? ServiceDoctors { get; set; }
}