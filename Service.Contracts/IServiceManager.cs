namespace Service.Contracts;

public interface IServiceManager
{
    IDoctorService DoctorService { get; }
    IPatientService PatientService { get; }
    INurseService NurseService { get; }
    ISupplierService SupplierService { get; }
    ICategoryServiceService CategoryServiceService { get; }
    IServiceService ServiceService { get; }
}