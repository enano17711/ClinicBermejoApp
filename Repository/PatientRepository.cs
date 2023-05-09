using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class PatientRepository : RepositoryBase<Patient>,
    IPatientRepository
{
    public PatientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Patient>> GetPatientsAsync(PatientParameters parameters,
        bool trackChanges)
    {
        var patients = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(p => p.Doctor)
            .Include(p => p.Nurse)
            .Include(p => p.Appointments)
            .ToListAsync();

        return PagedList<Patient>.ToPagedList(patients,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Patient?> GetPatientByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(p => p.Doctor)
            .Include(p => p.Nurse)
            .Include(p => p.Appointments)
            .SingleOrDefaultAsync();

    public void CreatePatient(Patient patient) =>
        Create(patient);

    public void DeletePatient(Patient patient) =>
        Delete(patient);
}