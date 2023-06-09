﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared;

namespace Service;

public class NurseService : INurseService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public NurseService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<NurseDto>> GetNursesAsync(bool trackChanges)
    {
        var nurses = await _repository.Nurses.GetNursesAsync(trackChanges);
        return _mapper.Map<IEnumerable<NurseDto>>(nurses);
    }

    public async Task<NurseDto> GetNurseByIdAsync(Guid id, bool trackChanges)
    {
        var nurse = await GetNurseAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<NurseDto>(nurse);
    }

    public async Task<NurseDto> CreateNurseAsync(NurseForCreationDto nurse)
    {
        var nurseEntity = _mapper.Map<Nurse>(nurse);
        _repository.Nurses.CreateNurse(nurseEntity);
        await _repository.SaveAsync();
        return _mapper.Map<NurseDto>(nurseEntity);
    }

    public async Task DeleteNurseAsync(Guid id, bool trackChanges)
    {
        var nurse = await GetNurseAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Nurses.DeleteNurse(nurse);
        await _repository.SaveAsync();
    }

    public async Task UpdateNurseAsync(Guid id, NurseForUpdateDto nurse, bool trackChanges)
    {
        var nurseEntity = await GetNurseAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(nurse, nurseEntity);
        await _repository.SaveAsync();
    }

    private async Task<Nurse> GetNurseAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var nurse = await _repository.Nurses.GetNurseByIdAsync(id, trackChanges);
        if (nurse is null) throw new NurseNotFoundException(id);
        return nurse;
    }
}