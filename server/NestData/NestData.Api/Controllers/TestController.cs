using MediatR;
using Microsoft.AspNetCore.Mvc;
using NestData.Core.Entities.Test;
using NestData.Core.Structs;

namespace NestData.Controllers;

[Route("api/test")]
public class TestController : BaseController
{
    public TestController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet]
    public Task<ActionResult<Response<Test>>> Test(GetTestRequest request)
    {
        return Handle(request);
    }

}