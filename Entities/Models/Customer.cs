using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Sales;

namespace Entities.Models;

public class Customer : BasePerson
{
    [Column("CustomerId")] public Guid Id { get; set; }

    [MaxLength(50, ErrorMessage = "El nit no puede tener más de 50 caracteres")]
    public string? Nit { get; set; }

    public ICollection<Sale>? Sales { get; set; }
}