namespace Quadro.Core.Infrastructure.WebApi;

public class CustomControllerBase : ControllerBase
{

    protected readonly ICommandBus _commandBus;
    protected readonly IQueryBus _queryBus;

    protected CustomControllerBase(ICommandBus commandBus, IQueryBus queryBus)
    {
        _commandBus = commandBus;
        _queryBus = queryBus;
    }

    protected async Task<IActionResult> CommandResponse<TResult>(ICommand<TResult> command)
    {
        TResult result;
        try
        {
            result = await _commandBus.Send<ICommand<TResult>, TResult>(command);
        }
        catch (Exception e)
        {
            return BadRequestActionResult(e.Message);
        }

        return Ok(new ApiResponse<TResult>
        {
            Data = result,
            Success = true
        });
    }

    protected async Task<IActionResult> QueryResponse<TResult>(IQuery<TResult> query)
    {
        TResult result;

        try
        {
            result = await _queryBus.Send(query);
        }
        catch (Exception e)
        {
            return BadRequestActionResult(e.Message);
        }

        return Ok(new ApiResponse<TResult>
        {
            Data = result,
            Success = true
        });
    }


    protected IActionResult BadRequestActionResult(string resultErrors)
    {
        return BadRequest(new ApiResponse<IActionResult>
        {
            Success = false,
            Message = resultErrors
        });
    }

}