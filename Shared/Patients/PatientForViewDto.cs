namespace Shared.Patients;

public record PatientForViewDto
{
    public Guid Id { get; init; }

    public string? ClinicHistory { get; init; }

    public string? Name { get; init; }

    public string? Surname { get; init; }

    public string? Ci { get; init; }

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public DateTime? Date { get; init; }

    public string? Address { get; init; }
}