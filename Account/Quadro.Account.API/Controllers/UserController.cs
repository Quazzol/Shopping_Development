using MediatR;
using Microsoft.AspNetCore.Mvc;
using Quadro.Account.API.Application.Commands;
using Quadro.Account.API.Application.Queries;

namespace Quadro.Account.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : CustomControllerBase
{

    public UserController(
        ICommandBus commandBus,
         IQueryBus queryBus) : base(commandBus, queryBus)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpUserCommand command)
    {
        return await CommandResponse(command);
    }


    [HttpGet()]
    public async Task<IActionResult> FindUser(string email)
    {
        return await QueryResponse(new FindUserQuery { Email = email });
    }

}
