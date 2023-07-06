namespace Service.Contracts;

public interface IServiceManager
{
    IDoctorService DoctorService { get; }
    IPatientService PatientService { get; }
    INurseService NurseService { get; }
    ISupplierService SupplierService { get; }
    ICategoryServiceService CategoryServiceService { get; }
    IServiceService ServiceService { get; }
    IServiceDoctorService ServiceDoctorService { get; }
    IAppointmentService AppointmentService { get; }
    IAppointmentDoctorService AppointmentDoctorService { get; }
    IOrderService OrderService { get; }
    IDetailOrderService DetailOrderService { get; }
    IBrandService BrandService { get; }
    IUnitService UnitService { get; }
    ICategoryItemService CategoryItemService { get; }
    IItemService ItemService { get; }
    IUnitBaseBaseService UnitBaseService { get; }
    INoteService NoteService { get; }
    ICustomerService CustomerService { get; }
}