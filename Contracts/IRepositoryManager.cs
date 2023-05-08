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
    Task SaveAsync();
}