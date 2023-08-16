using MediatR;
using Microsoft.AspNetCore.Mvc;
using NestData.Core.Common;
using NestData.Core.Structs;

namespace NestData.Controllers;

public class BaseController : Controller
{
    public IMediator Mediator { get; set; }

    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected async Task<ActionResult<Response>> Handle(IRequest<Response> request, int successStatusCode = StatusCodes.Status200OK)
    {
        var response = await Mediator.Send(request);
        return HandleResponse<Response>(response, successStatusCode);
    }
    
    protected async Task<ActionResult<Response<TResult>>> Handle<TResult>(IRequest<Response<TResult>> request, int successStatusCode = StatusCodes.Status200OK)
    {
        var response = await Mediator.Send(request);
        return HandleResponse<Response<TResult>>(response, successStatusCode);
    }


    protected ActionResult<T> HandleResponse<T>(Response response, int successStatusCode)
    {
        if (!response.HasErrors)
        {
            return StatusCode(successStatusCode, response);
        }

        return StatusCode(response.Errors.Any(x => x.Property == ErrorMessages.CoreFatal) 
            ? StatusCodes.Status500InternalServerError 
            : StatusCodes.Status400BadRequest, response);
    }
}