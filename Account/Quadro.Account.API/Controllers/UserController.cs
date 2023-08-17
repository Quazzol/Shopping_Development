using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Quadro.Account.API;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    public UserController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }


    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }


    [HttpGet()]
    public async Task<IActionResult> FindUser(string email)
    {
        return Ok(await Mediator.Send(new FindUserQuery() { Email = email }));
    }

}
