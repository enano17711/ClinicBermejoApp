using System.Linq.Dynamic.Core;

namespace Repository.Extensions;

public static class GenericRepositoryExtension
{
    public static IQueryable<T> SearchGeneric<T>(this IQueryable<T> source,
        string? searchColumn,
        string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm) ||
            string.IsNullOrWhiteSpace(searchColumn) ||
            string.IsNullOrEmpty(searchTerm) ||
            string.IsNullOrEmpty(searchColumn))
            return source;

        if (searchColumn.ToLower() != "id")
            return source.Where($"s => s.{searchColumn}.ToLower().Contains(@0)", searchTerm.Trim());

        return source.Where($"s => s.{searchColumn}.ToString().ToLower().Contains(@0)",
            searchTerm.Trim()
                .ToLower());
    }

    public static IQueryable<T> SortGeneric<T>(this IQueryable<T> source,
        string? column,
        string? order)
    {
        return source.OrderBy($"{column} {order}");
    }
}