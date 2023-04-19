namespace Service.Contracts;

public interface IServiceManager
{
    IDoctorService DoctorService { get; }
    IPatientService PatientService { get; }
    INurseService NurseService { get; }
}