using CleanArchitecture.Core.Domain;
using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace CleanArchitecture.Core.Service
{
    public record GetDepartmentWithPaginationQuery : IRequest<PaginatedList<DepartmentDto>>, ICache
{
    public string Name { get; init; }
    public int PageNumber { get; init; } // = 1;
    public int PageSize { get; init; } = 10;

    public bool BypassCache { get; set; }
    public string CacheKey => $"Department-{Name}";
    public TimeSpan? SlidingExpiration { get; set; }
}

    public class GetDepartmentWithPaginationQueryHandler : IRequestHandler<GetDepartmentWithPaginationQuery, PaginatedList<DepartmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDepartmentWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DepartmentDto>> Handle(GetDepartmentWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Departments
        .Where(x => x.Name.Contains(request.Name) )
            .OrderBy(x => x.Name)
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
    }
}