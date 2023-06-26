using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Items;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.UnitBases;

namespace Service;

public class UnitBaseService : IUnitBaseBaseService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public UnitBaseService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<UnitBaseDto> unitBases, MetaData metaData)> GetUnitBasesAsync(
        UnitBaseParameters parameters,
        bool trackChanges)
    {
        var unitBasesWithMetaData = await _repository.UnitBases.GetUnitBasesAsync(parameters, trackChanges);
        var unitBasesDto = _mapper.Map<IEnumerable<UnitBaseDto>>(unitBasesWithMetaData);

        return (unitBasesDto, unitBasesWithMetaData.MetaData);
    }

    public async Task<UnitBaseDto> GetUnitBaseByIdAsync(Guid id, bool trackChanges)
    {
        var unitBase = await GetUnitBaseAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<UnitBaseDto>(unitBase);
    }

    public async Task<UnitBaseDto> CreateUnitBaseAsync(UnitBaseForCreationDto unitBase)
    {
        var unitBaseEntity = _mapper.Map<UnitBase>(unitBase);
        _repository.UnitBases.CreateUnitBase(unitBaseEntity);
        await _repository.SaveAsync();
        return _mapper.Map<UnitBaseDto>(unitBaseEntity);
    }

    public async Task DeleteUnitBaseAsync(Guid id, bool trackChanges)
    {
        var unitBase = await GetUnitBaseAndCheckIfItExists(id, trackChanges);
        _repository.UnitBases.DeleteUnitBase(unitBase);
        await _repository.SaveAsync();
    }

    public async Task UpdateUnitBaseAsync(Guid id, UnitBaseForUpdateDto unitBase, bool trackChanges)
    {
        var unitBaseEntity = await GetUnitBaseAndCheckIfItExists(id, trackChanges);
        _mapper.Map(unitBase, unitBaseEntity);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<UnitBaseDto>> GetAllUnitBases()
    {
        var unitBases = await _repository.UnitBases.GetAllUnitBases();
        return _mapper.Map<IEnumerable<UnitBaseDto>>(unitBases);
    }

    private async Task<UnitBase> GetUnitBaseAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var unitBase = await _repository.UnitBases.GetUnitBaseByIdAsync(id, trackChanges);
        if (unitBase is null) throw new UnitBaseNotFoundException(id);
        return unitBase;
    }
}