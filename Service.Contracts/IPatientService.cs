using Shared;

namespace Service.Contracts;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetPatientsAsync(bool trackChanges);
    Task<PatientDto> GetPatientByIdAsync(Guid id, bool trackChanges);
    Task<PatientDto> CreatePatientAsync(PatientForCreationDto patient);
    Task DeletePatientAsync(Guid id, bool trackChanges);
    Task UpdatePatientAsync(Guid id, PatientForUpdateDto patient, bool trackChanges);
}