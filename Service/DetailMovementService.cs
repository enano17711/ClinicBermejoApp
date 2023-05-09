using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Movements;
using Service.Contracts;
using Shared.DetailMovements;
using Shared.RequestFeatures;

namespace Service;

public class DetailMovementService : IDetailMovementService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public DetailMovementService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<DetailMovementDto> detailMovements, MetaData metaData)> GetDetailMovementsAsync(
        DetailMovementParameters parameters,
        bool trackChanges)
    {
        var detailMovementsWithMetaData =
            await _repository.DetailMovements.GetDetailMovementsAsync(parameters, trackChanges);
        var detailMovementsDto = _mapper.Map<IEnumerable<DetailMovementDto>>(detailMovementsWithMetaData);

        return (detailMovementsDto, detailMovementsWithMetaData.MetaData);
    }

    public async Task<DetailMovementDto> GetDetailMovementByIdAsync(Guid id, bool trackChanges)
    {
        var detailMovement = await GetDetailMovementAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<DetailMovementDto>(detailMovement);
    }

    public async Task<DetailMovementDto> CreateDetailMovementAsync(DetailMovementForCreationDto detailMovement)
    {
        var detailMovementEntity = _mapper.Map<DetailMovement>(detailMovement);
        _repository.DetailMovements.CreateDetailMovement(detailMovementEntity);
        await _repository.SaveAsync();
        return _mapper.Map<DetailMovementDto>(detailMovementEntity);
    }

    public async Task DeleteDetailMovementAsync(Guid id, bool trackChanges)
    {
        var detailMovement = await GetDetailMovementAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.DetailMovements.DeleteDetailMovement(detailMovement);
        await _repository.SaveAsync();
    }

    public async Task UpdateDetailMovementAsync(Guid id, DetailMovementForUpdateDto detailMovement, bool trackChanges)
    {
        var detailMovementEntity = await GetDetailMovementAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(detailMovement, detailMovementEntity);
        await _repository.SaveAsync();
    }

    private async Task<DetailMovement> GetDetailMovementAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var detailMovement = await _repository.DetailMovements.GetDetailMovementByIdAsync(id, trackChanges);
        if (detailMovement is null) throw new DetailMovementNotFoundException(id);
        return detailMovement;
    }
}