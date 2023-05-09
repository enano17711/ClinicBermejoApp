using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Appointments;
using Service.Contracts;
using Shared.Appointments;
using Shared.RequestFeatures;

namespace Service;

public class AppointmentService : IAppointmentService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public AppointmentService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<AppointmentDto> appointments, MetaData metaData)> GetAppointmentsAsync(
        AppointmentParameters parameters,
        bool trackChanges)
    {
        var appointmentsWithMetaData = await _repository.Appointments.GetAppointmentsAsync(parameters, trackChanges);
        var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointmentsWithMetaData);

        return (appointmentsDto, appointmentsWithMetaData.MetaData);
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id, bool trackChanges)
    {
        var appointment = await GetAppointmentAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentForCreationDto appointment)
    {
        var appointmentEntity = _mapper.Map<Appointment>(appointment);
        _repository.Appointments.CreateAppointment(appointmentEntity);
        await _repository.SaveAsync();
        return _mapper.Map<AppointmentDto>(appointmentEntity);
    }

    public async Task DeleteAppointmentAsync(Guid id, bool trackChanges)
    {
        var appointment = await GetAppointmentAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Appointments.DeleteAppointment(appointment);
        await _repository.SaveAsync();
    }

    public async Task UpdateAppointmentAsync(Guid id, AppointmentForUpdateDto appointment, bool trackChanges)
    {
        var appointmentEntity = await GetAppointmentAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(appointment, appointmentEntity);
        await _repository.SaveAsync();
    }

    private async Task<Appointment> GetAppointmentAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var appointment = await _repository.Appointments.GetAppointmentByIdAsync(id, trackChanges);
        if (appointment is null) throw new AppointmentNotFoundException(id);
        return appointment;
    }
}