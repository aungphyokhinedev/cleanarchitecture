using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Domain;
using CleanArchitecture.Core.Service;
using MediatR;

namespace CleanArchitecture.Core.Service
{
   public record CreateDepartmentCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Department
        {
            Name =  request.Name
        };

        //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.Departments.Add(entity);

        await _context.SaveChangesAsync();

        return entity.Id;
    }
}
}