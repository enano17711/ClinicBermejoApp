using System.ComponentModel.DataAnnotations;

namespace Shared.Items;

public record CategoryItemMNForManipulationDto
{
    [Required(ErrorMessage = "El item es necesario para la relacion")]
    public Guid ItemId { get; init; }

    [Required(ErrorMessage = "La unidad es necesaria para la relacion")]
    public Guid CategoryItemId { get; init; }
};