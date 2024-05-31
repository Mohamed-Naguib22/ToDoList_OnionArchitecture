using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using OnionArchitecture.Application.Exceptions;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System;

namespace OnionArchitecture.WebApi.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        EntityNotFoundException => (int)HttpStatusCode.NotFound,
                        SocketException => (int)HttpStatusCode.BadGateway,
                        ValidationErrorException => (int)HttpStatusCode.BadRequest,
                    };

                    var errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error.GetBaseException().Message,
                        Errors = contextFeature.Error switch
                        {
                            ValidationErrorException validationError => validationError.Errors,
                            BadRequestException badRequestError => badRequestError.Errors,
                            _ => null
                        }
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }
    }
}