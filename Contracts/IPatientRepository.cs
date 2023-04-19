using Entities.Models;

namespace Contracts;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetPatientsAsync(bool trackChanges);
    void CreatePatient(Patient patient);
    Task<Patient> GetPatientByIdsAsync(Guid id, bool trackChanges);
    void DeletePatient(Patient patient);
}