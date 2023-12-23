using Application.Abstractions;

namespace WebApi.Middlewares;

public class ContextSetterMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
{
    public async Task Invoke(HttpContext context, ICurrentHttpContextAccessor currentHttpContextAccessor)
    {
        currentHttpContextAccessor.SetContext(context);
        await next(context);
    }

}