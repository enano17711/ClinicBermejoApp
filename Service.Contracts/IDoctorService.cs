using Shared;
using Shared.Doctors;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IDoctorService
{
    Task<(IEnumerable<DoctorDto> doctors, MetaData metaData)> GetDoctorsAsync(DoctorParameters parameters,
        bool trackChanges);

    Task<DoctorDto> GetDoctorByIdAsync(Guid id, bool trackChanges);
    Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto doctor);
    Task DeleteDoctorAsync(Guid id, bool trackChanges);
    Task UpdateDoctorAsync(Guid id, DoctorForUpdateDto doctor, bool trackChanges);
}