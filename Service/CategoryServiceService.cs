using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Services;
using Service.Contracts;
using Shared.CategoryService;
using Shared.RequestFeatures;

namespace Service;

public class CategoryServiceService : ICategoryServiceService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public CategoryServiceService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<CategoryServiceDto> categoryServices, MetaData metaData)> GetCategoryServicesAsync(
        CategoryServiceParameters parameters,
        bool trackChanges)
    {
        var categoryServicesWithMetaData =
            await _repository.CategoryServices.GetCategoryServicesAsync(parameters, trackChanges);
        var categoryServicesDto = _mapper.Map<IEnumerable<CategoryServiceDto>>(categoryServicesWithMetaData);

        return (categoryServicesDto, categoryServicesWithMetaData.MetaData);
    }

    public async Task<CategoryServiceDto> GetCategoryServiceByIdAsync(Guid id, bool trackChanges)
    {
        var categoryService = await GetCategoryServiceAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<CategoryServiceDto>(categoryService);
    }

    public async Task<CategoryServiceDto> CreateCategoryServiceAsync(CategoryServiceForCreationDto categoryService)
    {
        var categoryServiceEntity = _mapper.Map<CategoryService>(categoryService);
        _repository.CategoryServices.CreateCategoryService(categoryServiceEntity);
        await _repository.SaveAsync();
        return _mapper.Map<CategoryServiceDto>(categoryServiceEntity);
    }

    public async Task DeleteCategoryServiceAsync(Guid id, bool trackChanges)
    {
        var categoryService = await GetCategoryServiceAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.CategoryServices.DeleteCategoryService(categoryService);
        await _repository.SaveAsync();
    }

    public async Task UpdateCategoryServiceAsync(Guid id, CategoryServiceForUpdateDto categoryService,
        bool trackChanges)
    {
        var categoryServiceEntity = await GetCategoryServiceAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(categoryService, categoryServiceEntity);
        await _repository.SaveAsync();
    }

    private async Task<CategoryService> GetCategoryServiceAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var categoryService = await _repository.CategoryServices.GetCategoryServiceByIdAsync(id, trackChanges);
        if (categoryService is null) throw new CategoryServiceNotFoundException(id);
        return categoryService;
    }
}