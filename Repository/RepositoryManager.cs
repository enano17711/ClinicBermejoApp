using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IAppointmentDoctorRepository> _appointmentDoctorRepository;
    private readonly Lazy<IAppointmentRepository> _appointmentRepository;
    private readonly Lazy<IBrandRepository> _brandRepository;
    private readonly Lazy<ICategoryItemMNRepository> _categoryItemMNRepository;
    private readonly Lazy<ICategoryItemRepository> _categoryItemRepository;
    private readonly Lazy<ICategoryServiceRepository> _categoryServiceRepository;
    private readonly Lazy<IDetailOrderRepository> _detailOrderRepository;
    private readonly Lazy<IDoctorRepository> _doctorRepository;
    private readonly Lazy<IItemRepository> _itemRepository;
    private readonly Lazy<IItemUnitRepository> _itemUnitRepository;
    private readonly Lazy<INurseRepository> _nurseRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IPatientRepository> _patientRepository;
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IServiceDoctorRepository> _serviceDoctorRepository;
    private readonly Lazy<IServiceRepository> _serviceRepository;
    private readonly Lazy<ISupplierRepository> _supplierRepository;
    private readonly Lazy<IUnitBaseRepository> _unitBaseRepository;
    private readonly Lazy<IUnitRepository> _unitRepository;


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
        _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(_repositoryContext));
        _appointmentDoctorRepository =
            new Lazy<IAppointmentDoctorRepository>(() => new AppointmentDoctorRepository(_repositoryContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_repositoryContext));
        _detailOrderRepository =
            new Lazy<IDetailOrderRepository>(() => new DetailOrderRepository(_repositoryContext));
        _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(_repositoryContext));
        _unitRepository = new Lazy<IUnitRepository>(() => new UnitRepository(_repositoryContext));
        _categoryItemRepository =
            new Lazy<ICategoryItemRepository>(() => new CategoryItemRepository(_repositoryContext));
        _itemRepository = new Lazy<IItemRepository>(() => new ItemRepository(_repositoryContext));
        _itemUnitRepository = new Lazy<IItemUnitRepository>(() => new ItemUnitRepository(_repositoryContext));
        _categoryItemMNRepository = new Lazy<ICategoryItemMNRepository>(() =>
            new CategoryItemMNRepository(_repositoryContext));
        _unitBaseRepository = new Lazy<IUnitBaseRepository>(() => new UnitBaseRepository(_repositoryContext));
    }

    public IDoctorRepository Doctors => _doctorRepository.Value;
    public INurseRepository Nurses => _nurseRepository.Value;
    public IPatientRepository Patients => _patientRepository.Value;
    public ISupplierRepository Suppliers => _supplierRepository.Value;
    public ICategoryServiceRepository CategoryServices => _categoryServiceRepository.Value;
    public IServiceRepository Services => _serviceRepository.Value;
    public IServiceDoctorRepository ServiceDoctors => _serviceDoctorRepository.Value;
    public IAppointmentRepository Appointments => _appointmentRepository.Value;
    public IAppointmentDoctorRepository AppointmentDoctors => _appointmentDoctorRepository.Value;
    public IOrderRepository Orders => _orderRepository.Value;
    public IDetailOrderRepository DetailOrders => _detailOrderRepository.Value;
    public IBrandRepository Brands => _brandRepository.Value;
    public IUnitRepository Units => _unitRepository.Value;
    public ICategoryItemRepository CategoryItems => _categoryItemRepository.Value;
    public IItemRepository Items => _itemRepository.Value;
    public IItemUnitRepository ItemUnits => _itemUnitRepository.Value;
    public ICategoryItemMNRepository CategoryItemMNs => _categoryItemMNRepository.Value;
    public IUnitBaseRepository UnitBases => _unitBaseRepository.Value;

    public Task SaveAsync()
    {
        return _repositoryContext.SaveChangesAsync();
    }
}