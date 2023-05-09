using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Items;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.Units;

namespace Service;

public class UnitService : IUnitService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public UnitService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<UnitDto> units, MetaData metaData)> GetUnitsAsync(
        UnitParameters parameters,
        bool trackChanges)
    {
        var unitsWithMetaData = await _repository.Units.GetUnitsAsync(parameters, trackChanges);
        var unitsDto = _mapper.Map<IEnumerable<UnitDto>>(unitsWithMetaData);

        return (unitsDto, unitsWithMetaData.MetaData);
    }

    public async Task<UnitDto> GetUnitByIdAsync(Guid id, bool trackChanges)
    {
        var unit = await GetUnitAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<UnitDto>(unit);
    }

    public async Task<UnitDto> CreateUnitAsync(UnitForCreationDto unit)
    {
        var unitEntity = _mapper.Map<Unit>(unit);
        _repository.Units.CreateUnit(unitEntity);
        await _repository.SaveAsync();
        return _mapper.Map<UnitDto>(unitEntity);
    }

    public async Task DeleteUnitAsync(Guid id, bool trackChanges)
    {
        var unit = await GetUnitAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Units.DeleteUnit(unit);
        await _repository.SaveAsync();
    }

    public async Task UpdateUnitAsync(Guid id, UnitForUpdateDto unit, bool trackChanges)
    {
        var unitEntity = await GetUnitAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(unit, unitEntity);
        await _repository.SaveAsync();
    }

    private async Task<Unit> GetUnitAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var unit = await _repository.Units.GetUnitByIdAsync(id, trackChanges);
        if (unit is null) throw new UnitNotFoundException(id);
        return unit;
    }
}