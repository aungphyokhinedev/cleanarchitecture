namespace CleanArchitecture.Core.Domain;

public class Employee : AuditableEntity
{
  public string Name { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty;
  
}
