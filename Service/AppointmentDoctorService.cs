using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Appointments;
using Service.Contracts;
using Shared.AppointmentDoctors;
using Shared.RequestFeatures;

namespace Service;

public class AppointmentDoctorService : IAppointmentDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public AppointmentDoctorService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<AppointmentDoctorDto> appointmentDoctors, MetaData metaData)>
        GetAppointmentDoctorsAsync(
            AppointmentDoctorParameters parameters,
            bool trackChanges)
    {
        var appointmentDoctorsWithMetaData =
            await _repository.AppointmentDoctors.GetAppointmentDoctorsAsync(parameters, trackChanges);
        var appointmentDoctorsDto = _mapper.Map<IEnumerable<AppointmentDoctorDto>>(appointmentDoctorsWithMetaData);

        return (appointmentDoctorsDto, appointmentDoctorsWithMetaData.MetaData);
    }

    public async Task<AppointmentDoctorDto> GetAppointmentDoctorByIdAsync(Guid id, bool trackChanges)
    {
        var appointmentDoctor = await GetAppointmentDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<AppointmentDoctorDto>(appointmentDoctor);
    }

    public async Task<AppointmentDoctorDto> CreateAppointmentDoctorAsync(
        AppointmentDoctorForCreationDto appointmentDoctor)
    {
        var appointmentDoctorEntity = _mapper.Map<AppointmentDoctor>(appointmentDoctor);
        _repository.AppointmentDoctors.CreateAppointmentDoctor(appointmentDoctorEntity);
        await _repository.SaveAsync();
        return _mapper.Map<AppointmentDoctorDto>(appointmentDoctorEntity);
    }

    public async Task DeleteAppointmentDoctorAsync(Guid id, bool trackChanges)
    {
        var appointmentDoctor = await GetAppointmentDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.AppointmentDoctors.DeleteAppointmentDoctor(appointmentDoctor);
        await _repository.SaveAsync();
    }

    public async Task UpdateAppointmentDoctorAsync(Guid id, AppointmentDoctorForUpdateDto appointmentDoctor,
        bool trackChanges)
    {
        var appointmentDoctorEntity = await GetAppointmentDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(appointmentDoctor, appointmentDoctorEntity);
        await _repository.SaveAsync();
    }

    private async Task<AppointmentDoctor> GetAppointmentDoctorAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var appointmentDoctor = await _repository.AppointmentDoctors.GetAppointmentDoctorByIdAsync(id, trackChanges);
        if (appointmentDoctor is null) throw new AppointmentDoctorNotFoundException(id);
        return appointmentDoctor;
    }
}