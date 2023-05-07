using System.Linq.Dynamic.Core;
using System.Reflection;
using Entities.Models;
using Entities.Models.Staff;

namespace Repository.Extensions;

public static class RepositoryDoctorExtensions
{
    public static IQueryable<Doctor> Filter(this IQueryable<Doctor> doctors, Shared.Specialty? filterTerm)
    {
        if (filterTerm != null)
        {
            return doctors.Where(d => d.Specialty.Equals(filterTerm));
        }
        else
            return doctors;
    }

    public static IQueryable<Doctor> Search(this IQueryable<Doctor> doctors,
        string? searchColumn, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumn)
                                                  || string.IsNullOrEmpty(searchTerm) ||
                                                  string.IsNullOrEmpty(searchColumn))
            return doctors;

        var columns = new Doctor().GetType().GetProperties();
        foreach (var column in columns)
        {
            if (column.Name == searchColumn)
            {
                return doctors.Where(d => d.GetType().GetProperty(column.Name).GetValue(d) == searchTerm);
            }
        }

        return doctors;

        // var ret = doctors.Where(d => d.Name.Contains(searchTerm));
        //
        // return ret;
    }

    public static IQueryable<Doctor> Sort(this IQueryable<Doctor> doctors,
        string column, string order)
    {
        return doctors.OrderBy($"{column} {order}");
    }
}