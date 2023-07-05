namespace Shared.RequestFeatures;

public class CustomerParameters : RequestParameters
{
    public string? Nit { get; set; }
    public string? SearchColumn { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; } = "Name";
    public string? SortOrder { get; set; } = "ASC";
}