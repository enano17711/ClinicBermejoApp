using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Services;

public class CategoryService : BaseService
{
    [Column("CategoryServiceId")] public Guid Id { get; set; }
}