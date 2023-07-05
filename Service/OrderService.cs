using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Orders;
using Service.Contracts;
using Shared.Orders;
using Shared.RequestFeatures;

namespace Service;

public class OrderService : IOrderService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public OrderService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task DeleteOrderAsync(Guid id, bool trackChanges)
    {
        var order = await GetOrderAndCheckIfItExists(id, trackChanges);
        _repository.Orders.DeleteOrder(order);
        await _repository.SaveAsync();
    }

    public async Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetOrdersAsync(
        OrderParameters parameters,
        bool trackChanges)
    {
        var ordersWithMetaData = await _repository.Orders.GetOrdersAsync(parameters, trackChanges);
        var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(ordersWithMetaData);

        return (ordersDto, ordersWithMetaData.MetaData);
    }

    public async Task<OrderDto> GetOrderByIdAsync(Guid id, bool trackChanges)
    {
        var order = await GetOrderAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateOrderAsync(OrderForCreationDto order)
    {
        var orderEntity = _mapper.Map<Order>(order);
        _repository.Orders.CreateOrder(orderEntity);
        await _repository.SaveAsync();
        return _mapper.Map<OrderDto>(orderEntity);
    }

    public async Task UpdateOrderAsync(Guid id, OrderForUpdateDto order, bool trackChanges)
    {
        var orderEntity = await GetOrderAndCheckIfItExists(id, trackChanges);
        _mapper.Map(order, orderEntity);
        await _repository.SaveAsync();
    }

    private async Task<Order> GetOrderAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var order = await _repository.Orders.GetOrderByIdAsync(id, trackChanges);
        if (order is null) throw new OrderNotFoundException(id);
        return order;
    }
}