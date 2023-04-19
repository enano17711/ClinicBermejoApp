using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDoctorRepository
{
    Task<PagedList<Doctor>> GetDoctorsAsync(DoctorParameters parameters, bool trackChanges);
    void CreateDoctor(Doctor doctor);
    Task<Doctor> GetDoctorByIdAsync(Guid id, bool trackChanges);
    void DeleteDoctor(Doctor doctor);
}