using BryShort.API.V1.DTOs.publics;
using BryShort.API.V1.DTOs.requests;
using BryShort.API.V1.Middlewares;
using BryShort.Application;
using BryShort.Application.Users.Create;
using BryShort.Application.Utils.Mediator;
using BryShort.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication().AddInfraestructure();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("api/users", async ([FromBody] CreateUserDTO dto, IMediator mediator) =>
{
    var command = new CreateUserCommand(Username: dto.UserName, Password: dto.Password, IsActive: true);

    var result = await mediator.Send(command);

    return new PublicUser(Id: result.PublicId, Username: result.Username);
});

app.Run();
