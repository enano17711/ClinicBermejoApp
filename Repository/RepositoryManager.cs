using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IDoctorRepository> _doctorRepository;
    private readonly Lazy<INurseRepository> _nurseRepository;
    private readonly Lazy<IPatientRepository> _patientRepository;
    private readonly Lazy<ISupplierRepository> _supplierRepository;
    private readonly Lazy<ICategoryServiceRepository> _categoryServiceRepository;
    private readonly Lazy<IServiceRepository> _serviceRepository;
    private readonly Lazy<IServiceDoctorRepository> _serviceDoctorRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _doctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(_repositoryContext));
        _nurseRepository = new Lazy<INurseRepository>(() => new NurseRepository(_repositoryContext));
        _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(_repositoryContext));
        _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(_repositoryContext));
        _categoryServiceRepository =
            new Lazy<ICategoryServiceRepository>(() => new CategoryServiceRepository(_repositoryContext));
        _serviceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(_repositoryContext));
        _serviceDoctorRepository =
            new Lazy<IServiceDoctorRepository>(() => new ServiceDoctorRepository(_repositoryContext));
    }

    public IDoctorRepository Doctors => _doctorRepository.Value;
    public INurseRepository Nurses => _nurseRepository.Value;
    public IPatientRepository Patients => _patientRepository.Value;
    public ISupplierRepository Suppliers => _supplierRepository.Value;
    public ICategoryServiceRepository CategoryServices => _categoryServiceRepository.Value;
    public IServiceRepository Services => _serviceRepository.Value;
    public IServiceDoctorRepository ServiceDoctors => _serviceDoctorRepository.Value;
    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
}