using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IDoctorRepository> _doctorRepository;
    private readonly Lazy<INurseRepository> _nurseRepository;
    private readonly Lazy<IPatientRepository> _patientRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _doctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(_repositoryContext));
        _nurseRepository = new Lazy<INurseRepository>(() => new NurseRepository(_repositoryContext));
        _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(_repositoryContext));
    }

    public IDoctorRepository Doctors => _doctorRepository.Value;
    public INurseRepository Nurses => _nurseRepository.Value;
    public IPatientRepository Patients => _patientRepository.Value;
    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
}