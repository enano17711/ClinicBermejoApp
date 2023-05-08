using Shared;
using Shared.Patients;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IPatientService
{
    Task<(IEnumerable<PatientDto> patients, MetaData metaData)> GetPatientsAsync(PatientParameters parameters,
        bool trackChanges);

    Task<PatientDto> GetPatientByIdAsync(Guid id, bool trackChanges);
    Task<PatientDto> CreatePatientAsync(PatientForCreationDto patient);
    Task DeletePatientAsync(Guid id, bool trackChanges);
    Task UpdatePatientAsync(Guid id, PatientForUpdateDto patient, bool trackChanges);
}