using Mentor138.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Mentor138.Extentions
{
    public static class ExceptionHandlingExtentionQlobal
    {
        public static void ConfigureExtentionHandling(this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(appError => 
            {
                appError.Run(async context =>
                {
                    Console.WriteLine("Global Exception is running");
                    context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType="application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) 
                    {
                        //todo log yazaciq!
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
                    { 
                      StatusCode=context.Response.StatusCode,
                      Message=$"Internal Server Error : {contextFeature.Error}"
                    }));
                    }

                });
            });
        }
    }
}
