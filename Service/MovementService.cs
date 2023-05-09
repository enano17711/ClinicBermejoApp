using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Movements;
using Service.Contracts;
using Shared.Movements;
using Shared.RequestFeatures;

namespace Service;

public class MovementService : IMovementService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public MovementService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<MovementDto> movements, MetaData metaData)> GetMovementsAsync(
        MovementParameters parameters,
        bool trackChanges)
    {
        var movementsWithMetaData = await _repository.Movements.GetMovementsAsync(parameters, trackChanges);
        var movementsDto = _mapper.Map<IEnumerable<MovementDto>>(movementsWithMetaData);

        return (movementsDto, movementsWithMetaData.MetaData);
    }

    public async Task<MovementDto> GetMovementByIdAsync(Guid id, bool trackChanges)
    {
        var movement = await GetMovementAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<MovementDto>(movement);
    }

    public async Task<MovementDto> CreateMovementAsync(MovementForCreationDto movement)
    {
        var movementEntity = _mapper.Map<Movement>(movement);
        _repository.Movements.CreateMovement(movementEntity);
        await _repository.SaveAsync();
        return _mapper.Map<MovementDto>(movementEntity);
    }

    public async Task DeleteMovementAsync(Guid id, bool trackChanges)
    {
        var movement = await GetMovementAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Movements.DeleteMovement(movement);
        await _repository.SaveAsync();
    }

    public async Task UpdateMovementAsync(Guid id, MovementForUpdateDto movement, bool trackChanges)
    {
        var movementEntity = await GetMovementAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(movement, movementEntity);
        await _repository.SaveAsync();
    }

    private async Task<Movement> GetMovementAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var movement = await _repository.Movements.GetMovementByIdAsync(id, trackChanges);
        if (movement is null) throw new MovementNotFoundException(id);
        return movement;
    }
}