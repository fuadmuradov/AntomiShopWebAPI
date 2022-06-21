using Antomi.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntomiApi.ServiceExtensions
{
    public static class ExceptionHandlerExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    int statusCode = 500;
                    string message = "Internal Server Error!";
                    if (contextFeature != null)
                    {
                        message = contextFeature.Error.Message;
                        if (contextFeature.Error is ItemNotFoundException)
                        {
                            statusCode = 404;
                        }
                        else if (contextFeature.Error is RecordDublicateException)
                        {
                            statusCode = 409;
                        }
                    }
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    string responseStr = JsonConvert.SerializeObject(new
                    {
                        code = statusCode,
                        Message = message
                    });
                    await context.Response.WriteAsync(responseStr).ConfigureAwait(false);
                });
            });

            //            app.UseExceptionHandler(
            //    options =>
            //    {
            //        options.Run(async context =>
            //        {
            //            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //            context.Response.ContentType = "text/html";


            //            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
            //            var errorMessage = "Internal Seerver Error";
            //            if (null != exceptionObject)
            //            {
            //               // var exError = exceptionObject.Error.GetBaseException();
            //                 errorMessage = $"{exceptionObject.Error.Message}";
            //            }

            //            await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);

            //        });
            //    }
            //);
        }
    }
}
