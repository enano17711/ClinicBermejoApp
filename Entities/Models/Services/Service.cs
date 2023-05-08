using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Services;

public class Service : BaseService
{
    [Column("ServiceId")] public Guid Id { get; set; }

    [ForeignKey(nameof(CategoryService))] public Guid? CategoryServiceId { get; set; }
    public CategoryService? CategoryService { get; set; }

    public ICollection<ServiceDoctor>? ServiceDoctors { get; set; }
}