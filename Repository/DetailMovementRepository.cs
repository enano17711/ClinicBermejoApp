using Contracts;
using Entities.Models.Movements;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class DetailMovementRepository : RepositoryBase<DetailMovement>,
    IDetailMovementRepository
{
    public DetailMovementRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<DetailMovement>> GetDetailMovementsAsync(DetailMovementParameters parameters,
        bool trackChanges)
    {
        var detailMovements = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(dm => dm.Movement)
            .Include(dm => dm.Item)
            .ToListAsync();

        return PagedList<DetailMovement>.ToPagedList(detailMovements,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<DetailMovement?> GetDetailMovementByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(dm => dm.Movement)
            .Include(dm => dm.Item)
            .SingleOrDefaultAsync();

    public void CreateDetailMovement(DetailMovement detailMovement) =>
        Create(detailMovement);

    public void DeleteDetailMovement(DetailMovement detailMovement) =>
        Delete(detailMovement);
}