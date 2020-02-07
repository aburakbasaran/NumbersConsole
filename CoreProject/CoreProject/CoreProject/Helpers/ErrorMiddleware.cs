using CoreProject.Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Helpers
{
    public class ErrorClass
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// This is the Custom Middleware
    /// 
    public class ErrorMiddleware
    {
        RequestDelegate requestDelegate;
        public ErrorMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(httpContext, ex);
            }
        }

        public static Task HandleErrorAsync(HttpContext httpContext, Exception exception)
        {
            var exTypeName = exception.GetType().Name;
            ExceptionTypesEnum type = ExceptionTypesEnum.Other;
            try
            {
                type = (ExceptionTypesEnum)Enum.Parse(typeof(ExceptionTypesEnum), exTypeName);
            }
            catch (Exception)
            {

                type = ExceptionTypesEnum.Other;
            }

            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync("Exception:");
        }
    }
    public static class CustomErrorExtensionsMiddleware
    {
        public static void CustomExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
        }
    }


    public enum ExceptionTypesEnum
    {
        BusinessLayerException = 0,
        DataLayerException = 1,
        ValidationException = 2,
        ServiceControlledException = 3,
        Other = 4
    }
}
