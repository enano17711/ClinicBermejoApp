using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared;
using Shared.Patients;
using Shared.RequestFeatures;

namespace Service;

public class PatientService : IPatientService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public PatientService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<PatientDto> patients, MetaData metaData)> GetPatientsAsync(
        PatientParameters parameters,
        bool trackChanges)
    {
        var patientsWithMetaData = await _repository.Patients.GetPatientsAsync(parameters, trackChanges);
        var patientsDto = _mapper.Map<IEnumerable<PatientDto>>(patientsWithMetaData);

        return (patientsDto, patientsWithMetaData.MetaData);
    }

    public async Task<PatientDto> GetPatientByIdAsync(Guid id, bool trackChanges)
    {
        var patient = await GetPatientAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto> CreatePatientAsync(PatientForCreationDto patient)
    {
        var patientEntity = _mapper.Map<Patient>(patient);
        _repository.Patients.CreatePatient(patientEntity);
        await _repository.SaveAsync();
        return _mapper.Map<PatientDto>(patientEntity);
    }

    public async Task DeletePatientAsync(Guid id, bool trackChanges)
    {
        var patient = await GetPatientAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Patients.DeletePatient(patient);
        await _repository.SaveAsync();
    }

    public async Task UpdatePatientAsync(Guid id, PatientForUpdateDto patient, bool trackChanges)
    {
        var patientEntity = await GetPatientAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(patient, patientEntity);
        await _repository.SaveAsync();
    }

    private async Task<Patient> GetPatientAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var patient = await _repository.Patients.GetPatientByIdAsync(id, trackChanges);
        if (patient is null) throw new PatientNotFoundException(id);
        return patient;
    }
}