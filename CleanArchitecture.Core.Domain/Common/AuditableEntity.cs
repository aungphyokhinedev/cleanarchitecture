namespace CleanArchitecture.Core.Domain;

public class AuditableEntity : EntityBase
{
  public DateTimeOffset CreatedAt{get;set;}
  public DateTimeOffset ModifiedAt{get;set;}

  public int CreatedBy {get;set;}

  public int ModifiedBy {get;set;}
}
