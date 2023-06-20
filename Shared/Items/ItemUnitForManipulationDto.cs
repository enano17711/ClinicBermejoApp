using System.ComponentModel.DataAnnotations;
using Shared.Units;

namespace Shared.Items;

public record ItemUnitForManipulationDto
{
    [Required(ErrorMessage = "El item es necesario para la relacion")]
    public Guid ItemId { get; init; }

    [Required(ErrorMessage = "La unidad es necesaria para la relacion")]
    public Guid UnitId { get; init; }
}