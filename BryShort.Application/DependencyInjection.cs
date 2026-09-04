using BryShort.Application.Links.Create;
using BryShort.Application.Links.GetLinkByShorturl;
using BryShort.Application.Users.Create;
using BryShort.Application.Utils.Mediator;
using BryShort.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();

        services.AddScoped<IRequestExecute<CreateUserCommand, User>, UseCaseCreateUser>();
        services.AddScoped<IRequestExecute<CreateLinkCommand, Link>, UseCaseCreateLink>();
        services.AddScoped<IRequestExecute<GetLinkByShorturlCommand, Link>, UseCaseGetLinkByShorturl>();

        return services;
    }
}
