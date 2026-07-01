using BryShort.Core.Interfaces;
using BryShort.Infrastructure.Persistance.EFCore;
using BryShort.Infrastructure.Persistance.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("name=DefaultConnection"));

        services.AddScoped<IUserRepository, EFUserRepository>();
        services.AddScoped<ILinkRepository, EFLinkRepository>();

        return services;
    }
}