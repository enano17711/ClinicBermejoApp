namespace Shared.RequestFeatures;

public class DetailSaleParameters : RequestParameters
{
    /// <summary>
    ///     Gets or sets the column to search in.
    /// </summary>
    public string? SearchColumn { get; set; }

    /// <summary>
    ///     Gets or sets the search term to filter the detail orders.
    /// </summary>
    public string? SearchTerm { get; set; }

    /// <summary>
    ///     Gets or sets the column to sort the detail orders by. Default value is "Id".
    /// </summary>
    public string? SortColumn { get; set; } = "Id";

    /// <summary>
    ///     Gets or sets the sort order of the detail orders. Default value is "ASC".
    /// </summary>
    public string? SortOrder { get; set; } = "ASC";
}