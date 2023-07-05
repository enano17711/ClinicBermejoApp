using System.ComponentModel.DataAnnotations;

namespace Entities;

/// <summary>
///     Represents a base person entity.
/// </summary>
public class BasePerson
{
    /// <summary>
    ///     Gets or sets the name of the person.
    /// </summary>
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
    public string? Name { get; set; }

    /// <summary>
    ///     Gets or sets the surname of the person.
    /// </summary>
    [Required(ErrorMessage = "El apellido es requerido")]
    [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
    public string? Surname { get; set; }

    /// <summary>
    ///     Gets or sets the identification number (CI) of the person.
    /// </summary>
    [Required(ErrorMessage = "El Ci es requerido")]
    public string? Ci { get; set; }

    /// <summary>
    ///     Gets or sets the email address of the person.
    /// </summary>
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string? Email { get; set; }

    /// <summary>
    ///     Gets or sets the phone number of the person.
    /// </summary>
    [Required(ErrorMessage = "El número de teléfono es requerido")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///     Gets or sets the date associated with the person.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    ///     Gets or sets the address of the person.
    /// </summary>
    public string? Address { get; set; }
}