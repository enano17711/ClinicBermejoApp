namespace Contracts;

public interface IRepositoryManager
{
    IDoctorRepository Doctors { get; }
    ISupplierRepository Suppliers { get; }
    INurseRepository Nurses { get; }
    IPatientRepository Patients { get; }
    ICategoryServiceRepository CategoryServices { get; }
    IServiceRepository Services { get; }
    IServiceDoctorRepository ServiceDoctors { get; }
    IAppointmentRepository Appointments { get; }
    IAppointmentDoctorRepository AppointmentDoctors { get; }
    IMovementRepository Movements { get; }
    IDetailMovementRepository DetailMovements { get; }
    IBrandRepository Brands { get; }
    IUnitRepository Units { get; }
    ICategoryItemRepository CategoryItems { get; }
    IItemRepository Items { get; }
    IItemUnitRepository ItemUnits { get; }
    ICategoryItemMNRepository CategoryItemMNs { get; }
    Task SaveAsync();
}