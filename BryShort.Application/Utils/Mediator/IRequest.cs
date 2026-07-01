using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Utils.Mediator;

public interface IRequest<TResponde>
{

}

public interface IRequestExecute<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Execute(TRequest request);
}

