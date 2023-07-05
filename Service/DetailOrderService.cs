using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Orders;
using Service.Contracts;
using Shared.DetailOrders;
using Shared.RequestFeatures;

namespace Service;

public class DetailOrderService : IDetailOrderService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public DetailOrderService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<DetailOrderDto> detailOrders, MetaData metaData)> GetDetailOrdersAsync(
        DetailOrderParameters parameters,
        bool trackChanges)
    {
        var detailOrdersWithMetaData =
            await _repository.DetailOrders.GetDetailOrdersAsync(parameters, trackChanges);
        var detailOrdersDto = _mapper.Map<IEnumerable<DetailOrderDto>>(detailOrdersWithMetaData);

        return (detailOrdersDto, detailOrdersWithMetaData.MetaData);
    }

    public async Task<DetailOrderDto> GetDetailOrderByIdAsync(Guid id, bool trackChanges)
    {
        var detailOrder = await GetDetailOrderAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<DetailOrderDto>(detailOrder);
    }

    public async Task<DetailOrderDto> CreateDetailOrderAsync(DetailOrderForCreationDto detailOrder)
    {
        var detailOrderEntity = _mapper.Map<DetailOrder>(detailOrder);
        _repository.DetailOrders.CreateDetailOrder(detailOrderEntity);
        await _repository.SaveAsync();
        return _mapper.Map<DetailOrderDto>(detailOrderEntity);
    }

    public async Task DeleteDetailOrderAsync(Guid id, bool trackChanges)
    {
        var detailOrder = await GetDetailOrderAndCheckIfItExists(id, trackChanges);
        _repository.DetailOrders.DeleteDetailOrder(detailOrder);
        await _repository.SaveAsync();
    }

    public async Task UpdateDetailOrderAsync(Guid id, DetailOrderForUpdateDto detailOrder, bool trackChanges)
    {
        var detailOrderEntity = await GetDetailOrderAndCheckIfItExists(id, trackChanges);
        _mapper.Map(detailOrder, detailOrderEntity);
        await _repository.SaveAsync();
    }

    private async Task<DetailOrder> GetDetailOrderAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var detailOrder = await _repository.DetailOrders.GetDetailOrderByIdAsync(id, trackChanges);
        if (detailOrder is null) throw new DetailOrderNotFoundException(id);
        return detailOrder;
    }
}