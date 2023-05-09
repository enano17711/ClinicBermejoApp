using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Items;
using Service.Contracts;
using Shared.Brands;
using Shared.RequestFeatures;

namespace Service;

public class BrandService : IBrandService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public BrandService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<BrandDto> brands, MetaData metaData)> GetBrandsAsync(
        BrandParameters parameters,
        bool trackChanges)
    {
        var brandsWithMetaData = await _repository.Brands.GetBrandsAsync(parameters, trackChanges);
        var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brandsWithMetaData);

        return (brandsDto, brandsWithMetaData.MetaData);
    }

    public async Task<BrandDto> GetBrandByIdAsync(Guid id, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<BrandDto>(brand);
    }

    public async Task<BrandDto> CreateBrandAsync(BrandForCreationDto brand)
    {
        var brandEntity = _mapper.Map<Brand>(brand);
        _repository.Brands.CreateBrand(brandEntity);
        await _repository.SaveAsync();
        return _mapper.Map<BrandDto>(brandEntity);
    }

    public async Task DeleteBrandAsync(Guid id, bool trackChanges)
    {
        var brand = await GetBrandAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Brands.DeleteBrand(brand);
        await _repository.SaveAsync();
    }

    public async Task UpdateBrandAsync(Guid id, BrandForUpdateDto brand, bool trackChanges)
    {
        var brandEntity = await GetBrandAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(brand, brandEntity);
        await _repository.SaveAsync();
    }

    private async Task<Brand> GetBrandAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var brand = await _repository.Brands.GetBrandByIdAsync(id, trackChanges);
        if (brand is null) throw new BrandNotFoundException(id);
        return brand;
    }
}