using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IPatientRepository
{
    Task<PagedList<Patient>> GetPatientsAsync(PatientParameters parameters, bool trackChanges);
    void CreatePatient(Patient patient);
    Task<Patient?> GetPatientByIdAsync(Guid id, bool trackChanges);
    void DeletePatient(Patient patient);
}