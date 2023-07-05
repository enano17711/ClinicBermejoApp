namespace Shared.RequestFeatures;

public class DetailOrderParameters : RequestParameters
{
    public string? SearchColumn { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; } = "Id";
    public string? SortOrder { get; set; } = "ASC";
}