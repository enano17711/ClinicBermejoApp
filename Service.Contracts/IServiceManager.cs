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
    IMovementService MovementService { get; }
    IDetailMovementService DetailMovementService { get; }
    IBrandService BrandService { get; }
    IUnitService UnitService { get; }
    ICategoryItemService CategoryItemService { get; }
    IItemService ItemService { get; }
    IUnitBaseBaseService UnitBaseService { get; }
}