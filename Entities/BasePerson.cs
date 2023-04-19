using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class BasePerson
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "El apellido es requerido")]
    [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "El Ci es requerido")]
    public string? Ci { get; set; }

    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "El número de teléfono es requerido")]
    public string? PhoneNumber { get; set; }

    public DateTime? Date { get; set; }

    public string? Address { get; set; }
}