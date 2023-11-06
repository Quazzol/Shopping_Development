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
    [Route("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
    {
        return await CommandResponse(new SignUpUserCommand(new SignUpModel(request.UserName, request.Email, request.Password)));
    }

    [HttpPost()]
    [Route("signin")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        return await QueryResponse(new SignInUserQuery(new SignInModel(request.Email, request.Password)));
    }

}
