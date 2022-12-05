using CleanArchitecture.Core.Domain;

namespace CleanArchitecture.Core.Service
{
    public class DepartmentDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public string? Name { get; set; }
    }
}