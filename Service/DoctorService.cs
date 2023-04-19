using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared;
using Shared.Doctors;
using Shared.RequestFeatures;

namespace Service;

public class DoctorService : IDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public DoctorService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<DoctorDto> doctors, MetaData metaData)> GetDoctorsAsync(DoctorParameters parameters,
        bool trackChanges)
    {
        var doctorsWithMetaData = await _repository.Doctors.GetDoctorsAsync(parameters, trackChanges);
        var doctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(doctorsWithMetaData);

        return (doctorsDto, doctorsWithMetaData.MetaData);
    }

    public async Task<DoctorDto> GetDoctorByIdAsync(Guid id, bool trackChanges)
    {
        var doctor = await GetDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task<DoctorDto> CreateDoctorAsync(DoctorForCreationDto doctor)
    {
        var doctorEntity = _mapper.Map<Doctor>(doctor);
        _repository.Doctors.CreateDoctor(doctorEntity);
        await _repository.SaveAsync();
        return _mapper.Map<DoctorDto>(doctorEntity);
    }

    public async Task DeleteDoctorAsync(Guid id, bool trackChanges)
    {
        var doctor = await GetDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Doctors.DeleteDoctor(doctor);
        await _repository.SaveAsync();
    }

    public async Task UpdateDoctorAsync(Guid id, DoctorForUpdateDto doctor, bool trackChanges)
    {
        var doctorEntity = await GetDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(doctor, doctorEntity);
        await _repository.SaveAsync();
    }

    private async Task<Doctor> GetDoctorAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var doctor = await _repository.Doctors.GetDoctorByIdAsync(id, trackChanges);
        if (doctor is null) throw new DoctorNotFoundException(id);
        return doctor;
    }
}