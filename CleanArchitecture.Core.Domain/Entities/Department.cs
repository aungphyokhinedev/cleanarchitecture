namespace CleanArchitecture.Core.Domain;

public class Department : AuditableEntity
{
  public string Name { get; set; } = string.Empty;

  public IList<Employee> EmployeeList { get; private set; } = new List<Employee>();
}
