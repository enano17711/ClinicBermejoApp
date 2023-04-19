namespace Contracts;

public interface IRepositoryManager
{
    IDoctorRepository Doctors { get; }
    INurseRepository Nurses { get; }
    IPatientRepository Patients { get; }
    Task SaveAsync();
}