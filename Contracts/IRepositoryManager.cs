namespace Contracts;

public interface IRepositoryManager
{
    IDoctorRepository Doctors { get; }
    ISupplierRepository Suppliers { get; }
    INurseRepository Nurses { get; }
    IPatientRepository Patients { get; }
    Task SaveAsync();
}