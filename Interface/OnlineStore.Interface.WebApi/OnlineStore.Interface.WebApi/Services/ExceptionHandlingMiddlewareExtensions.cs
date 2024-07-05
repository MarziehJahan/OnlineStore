using Framework.Exception;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace OnlineStore.Interface.WebApi.Services
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static void ConfigureExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    if (IsTypeOfBusinessException(context))
                    {
                        await HandleResponse(context);
                        return;
                    }

                });
            });
        }

        private static async Task HandleResponse(HttpContext context)
        {
            await SetResponse(context);
        }

        private static async Task SetResponse(HttpContext context)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorDetails()
            {
                Message = exceptionHandlerFeature.Error.Message,
            }.ToString());
        }

        private static bool IsTypeOfBusinessException(HttpContext context)
        {
            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerPathFeature?.Error is BusinessException)
                return true;
            return false;
        }
    }
}
