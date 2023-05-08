namespace Shared.RequestFeatures;

public class NurseParameters : RequestParameters
{
    public Specialty? Specialty { get; set; }
    public string? SearchColumn { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; } = "Name";
    public string? SortOrder { get; set; } = "ASC";
}