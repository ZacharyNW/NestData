using MediatR;
using MediatR.Pipeline;
using NestData.Core.Common;
using NestData.Core.Structs;

namespace NestData.Core.Configurations;

public class ExceptionHandler<TRequest, TException> : IRequestExceptionHandler<TRequest, Response, TException>
    where TRequest : IRequest<Response>
    where TException : Exception
{
    public ExceptionHandler()
    {
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<Response> state,
        CancellationToken cancellationToken)
    {
        var response = new Response();
        response.AddError(new Error(ErrorMessages.CoreFatal, ""));
        state.SetHandled(response);   
        return Task.CompletedTask;
    }
}
    
