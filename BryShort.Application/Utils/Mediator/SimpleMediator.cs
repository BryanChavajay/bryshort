using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Utils.Mediator;

public class SimpleMediator(IServiceProvider sp) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestExecute<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var useCase = sp.GetRequiredService(handlerType);
        var method = handlerType.GetMethod("Execute")!;

        return await (Task<TResponse>)method.Invoke(useCase, new object[] { request })!;
    }
}
