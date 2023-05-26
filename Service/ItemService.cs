﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Items;
using Service.Contracts;
using Shared.Items;
using Shared.RequestFeatures;

namespace Service;

public class ItemService : IItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ItemService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<ItemDto> items, MetaData metaData)> GetItemsAsync(
        ItemParameters parameters,
        bool trackChanges)
    {
        var itemsWithMetaData = await _repository.Items.GetItemsAsync(parameters, trackChanges);
        var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(itemsWithMetaData);

        return (itemsDto, itemsWithMetaData.MetaData);
    }

    public async Task<ItemDto> GetItemByIdAsync(Guid id, bool trackChanges)
    {
        var item = await GetItemAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<ItemDto>(item);
    }

    public async Task<ItemDto> CreateItemAsync(ItemForCreationDto item)
    {
        var itemEntity = _mapper.Map<Item>(item);
        _repository.Items.CreateItem(itemEntity);
        await _repository.SaveAsync();
        return _mapper.Map<ItemDto>(itemEntity);
    }

    public async Task DeleteItemAsync(Guid id, bool trackChanges)
    {
        var item = await GetItemAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Items.DeleteItem(item);
        await _repository.SaveAsync();
    }

    public async Task UpdateItemAsync(Guid id, ItemForUpdateDto item, bool trackChanges)
    {
        var itemEntity = await GetItemAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(item, itemEntity);
        await _repository.SaveAsync();
    }

    private async Task<Item> GetItemAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var item = await _repository.Items.GetItemByIdAsync(id, trackChanges);
        if (item is null) throw new ItemNotFoundException(id);
        return item;
    }
}