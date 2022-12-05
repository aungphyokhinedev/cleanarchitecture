using CleanArchitecture.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Core.Service;

public interface IApplicationDbContext
{
    DbSet<Department> Departments { get; }

    DbSet<Employee> Employees { get; }

    Task<int> SaveChangesAsync();
}

