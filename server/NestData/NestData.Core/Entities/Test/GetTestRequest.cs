using MediatR;
using NestData.Core.Common;
using NestData.Core.Structs;

namespace NestData.Core.Entities.Test;

public class GetTestRequest : IRequest<Response<Test>>
{
    public int Id { get; set; }
}

public class GetTestRequestHandler : IRequestHandler<GetTestRequest, Response<Test>>
{
    public Task<Response<Test>> Handle(GetTestRequest request, CancellationToken cancellationToken)
    {
        var test = new Test
        {
            Id = request.Id,
            Message = "Hello World"
        };
        return test.AsResponse().WrapTask();
    }
}