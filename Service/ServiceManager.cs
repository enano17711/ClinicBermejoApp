using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAppointmentDoctorService> _appointmentDoctorService;
    private readonly Lazy<IAppointmentService> _appointmentService;
    private readonly Lazy<IBrandService> _brandService;
    private readonly Lazy<ICategoryItemService> _categoryItemService;
    private readonly Lazy<ICategoryServiceService> _categoryServiceService;
    private readonly Lazy<IDetailOrderService> _detailOrderService;
    private readonly Lazy<IDoctorService> _doctorService;
    private readonly Lazy<IItemService> _itemService;
    private readonly Lazy<INurseService> _nurseService;
    private readonly Lazy<IOrderService> _orderService;
    private readonly Lazy<IPatientService> _patientService;
    private readonly Lazy<IServiceDoctorService> _serviceDoctorService;
    private readonly Lazy<IServiceService> _serviceService;
    private readonly Lazy<ISupplierService> _supplierService;
    private readonly Lazy<IUnitBaseBaseService> _unitBaseService;
    private readonly Lazy<IUnitService> _unitService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _doctorService = new Lazy<IDoctorService>(() => new DoctorService(repository, mapper, logger));
        _patientService = new Lazy<IPatientService>(() => new PatientService(repository, mapper, logger));
        _nurseService = new Lazy<INurseService>(() => new NurseService(repository, mapper, logger));
        _supplierService = new Lazy<ISupplierService>(() => new SupplierService(repository, mapper, logger));
        _categoryServiceService =
            new Lazy<ICategoryServiceService>(() => new CategoryServiceService(repository, mapper, logger));
        _serviceService = new Lazy<IServiceService>(() => new ServiceService(repository, mapper, logger));
        _serviceDoctorService =
            new Lazy<IServiceDoctorService>(() => new ServiceDoctorService(repository, mapper, logger));
        _appointmentService = new Lazy<IAppointmentService>(() => new AppointmentService(repository, mapper, logger));
        _appointmentDoctorService =
            new Lazy<IAppointmentDoctorService>(() => new AppointmentDoctorService(repository, mapper, logger));
        _orderService = new Lazy<IOrderService>(() => new OrderService(repository, mapper, logger));
        _detailOrderService =
            new Lazy<IDetailOrderService>(() => new DetailOrderService(repository, mapper, logger));
        _brandService = new Lazy<IBrandService>(() => new BrandService(repository, mapper, logger));
        _unitService = new Lazy<IUnitService>(() => new UnitService(repository, mapper, logger));
        _categoryItemService =
            new Lazy<ICategoryItemService>(() => new CategoryItemService(repository, mapper, logger));
        _itemService = new Lazy<IItemService>(() => new ItemService(repository, mapper, logger));
        _unitBaseService = new Lazy<IUnitBaseBaseService>(() => new UnitBaseService(repository, mapper, logger));
    }

    public IDoctorService DoctorService => _doctorService.Value;
    public IPatientService PatientService => _patientService.Value;
    public INurseService NurseService => _nurseService.Value;
    public ISupplierService SupplierService => _supplierService.Value;
    public ICategoryServiceService CategoryServiceService => _categoryServiceService.Value;
    public IServiceService ServiceService => _serviceService.Value;
    public IServiceDoctorService ServiceDoctorService => _serviceDoctorService.Value;
    public IAppointmentService AppointmentService => _appointmentService.Value;
    public IAppointmentDoctorService AppointmentDoctorService => _appointmentDoctorService.Value;
    public IOrderService OrderService => _orderService.Value;
    public IDetailOrderService DetailOrderService => _detailOrderService.Value;
    public IBrandService BrandService => _brandService.Value;
    public IUnitService UnitService => _unitService.Value;
    public ICategoryItemService CategoryItemService => _categoryItemService.Value;
    public IItemService ItemService => _itemService.Value;
    public IUnitBaseBaseService UnitBaseService => _unitBaseService.Value;
}