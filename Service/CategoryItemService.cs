using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Items;
using Service.Contracts;
using Shared.CategoryItem;
using Shared.RequestFeatures;

namespace Service;

public class CategoryItemService : ICategoryItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public CategoryItemService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<CategoryItemDto> categoryItems, MetaData metaData)> GetCategoryItemsAsync(
        CategoryItemParameters parameters,
        bool trackChanges)
    {
        var categoryItemsWithMetaData = await _repository.CategoryItems.GetCategoryItemsAsync(parameters, trackChanges);
        var categoryItemsDto = _mapper.Map<IEnumerable<CategoryItemDto>>(categoryItemsWithMetaData);

        return (categoryItemsDto, categoryItemsWithMetaData.MetaData);
    }

    public async Task<CategoryItemDto> GetCategoryItemByIdAsync(Guid id, bool trackChanges)
    {
        var categoryItem = await GetCategoryItemAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<CategoryItemDto>(categoryItem);
    }

    public async Task<CategoryItemDto> CreateCategoryItemAsync(CategoryItemForCreationDto categoryItem)
    {
        var categoryItemEntity = _mapper.Map<CategoryItem>(categoryItem);
        _repository.CategoryItems.CreateCategoryItem(categoryItemEntity);
        await _repository.SaveAsync();
        return _mapper.Map<CategoryItemDto>(categoryItemEntity);
    }

    public async Task DeleteCategoryItemAsync(Guid id, bool trackChanges)
    {
        var categoryItem = await GetCategoryItemAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.CategoryItems.DeleteCategoryItem(categoryItem);
        await _repository.SaveAsync();
    }

    public async Task UpdateCategoryItemAsync(Guid id, CategoryItemForUpdateDto categoryItem, bool trackChanges)
    {
        var categoryItemEntity = await GetCategoryItemAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(categoryItem, categoryItemEntity);
        await _repository.SaveAsync();
    }

    private async Task<CategoryItem> GetCategoryItemAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var categoryItem = await _repository.CategoryItems.GetCategoryItemByIdAsync(id, trackChanges);
        if (categoryItem is null) throw new CategoryItemNotFoundException(id);
        return categoryItem;
    }
}