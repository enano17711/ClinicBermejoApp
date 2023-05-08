using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IDoctorService> _doctorService;
    private readonly Lazy<IPatientService> _patientService;
    private readonly Lazy<INurseService> _nurseService;
    private readonly Lazy<ISupplierService> _supplierService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _doctorService = new Lazy<IDoctorService>(() => new DoctorService(repository, mapper, logger));
        _patientService = new Lazy<IPatientService>(() => new PatientService(repository, mapper, logger));
        _nurseService = new Lazy<INurseService>(() => new NurseService(repository, mapper, logger));
        _supplierService = new Lazy<ISupplierService>(() => new SupplierService(repository, mapper, logger));
    }

    public IDoctorService DoctorService => _doctorService.Value;
    public IPatientService PatientService => _patientService.Value;
    public INurseService NurseService => _nurseService.Value;
    public ISupplierService SupplierService => _supplierService.Value;
}