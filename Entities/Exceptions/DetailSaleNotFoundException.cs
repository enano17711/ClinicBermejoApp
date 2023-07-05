namespace Entities.Exceptions;

public class DetailSaleNotFoundException : NotFoundException
{
    public DetailSaleNotFoundException(Guid id) : base($"DetailSale with id: {id} not found.")
    {
    }
}