using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Patient>> GetPatientsAsync(bool trackChanges) =>
        await FindAll(trackChanges).OrderBy(p => p.Name).ToListAsync();

    public async Task<Patient> GetPatientByIdsAsync(Guid id, bool trackChanges) =>
        await FindByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

    public void CreatePatient(Patient patient) => Create(patient);

    public void DeletePatient(Patient patient) => Delete(patient);
}