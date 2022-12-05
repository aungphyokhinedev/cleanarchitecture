using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Core.Domain;

namespace CleanArchitecture.Core.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ApiControllerBase
{


   [HttpPost]
    public async Task<ActionResult<int>> Create(CreateDepartmentCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<DepartmentDto>>> Get([FromQuery] GetDepartmentWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

   
}
