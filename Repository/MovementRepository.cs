using Contracts;
using Entities.Models.Movements;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class MovementRepository : RepositoryBase<Movement>,
    IMovementRepository
{
    public MovementRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Movement>> GetMovementsAsync(MovementParameters parameters,
        bool trackChanges)
    {
        var movements = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(m => m.Supplier)
            .Include(m => m.DetailMovements)
            .ToListAsync();

        return PagedList<Movement>.ToPagedList(movements,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Movement?> GetMovementByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(m => m.Supplier)
            .Include(m => m.DetailMovements)
            .SingleOrDefaultAsync();

    public void CreateMovement(Movement movement) =>
        Create(movement);

    public void DeleteMovement(Movement movement) =>
        Delete(movement);
}