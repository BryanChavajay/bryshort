using BryShort.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace BryShort.API.V1.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BaseException be) {
            await BaseExceptionHandler(context, be);
        }
        catch (Exception e)
        {
            await ExceptionHandler(context, e);
        }
    }

    private Task BaseExceptionHandler(HttpContext context, BaseException exception) { 
        context.Response.ContentType = "application/json";
        var resultado = JsonSerializer.Serialize(new
        {
            detail = exception.Message 
        });
        Console.WriteLine(exception);

        context.Response.StatusCode = exception.StatusCode;
        return context.Response.WriteAsync(resultado);
    }

    private Task ExceptionHandler(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize("INTERNAL SERVER ERROR");
        Console.WriteLine(exception);

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(result);
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}