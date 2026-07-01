using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application.Utils.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
}
