using Core.Utilities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";
            string MessageId = httpContext.Response.StatusCode.ToString();
            GetValidationException(httpContext, e,ref message,ref MessageId);
            GetConnectionException(httpContext, e,ref message, ref MessageId);
            GetLicenseException(httpContext, e,ref message, ref MessageId);
            GetAuthenticationException(httpContext, e, ref message, ref MessageId);
            GetNotificationException(httpContext, e, ref message, ref MessageId);
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message,
                MessageId = MessageId,
            }.ToString());
        }
        
        private void GetValidationException(HttpContext httpContext, Exception e,ref string message,ref string messageId)
        {
            if (e.GetType() == typeof(ValidationException))
            {
                var exception = (ValidationException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                message = exception.Message;
                messageId = exception.Errors.FirstOrDefault().ErrorCode;
            }
        }
        private void GetConnectionException(HttpContext httpContext, Exception e,ref string message, ref string messageId)
        {
            if (e.GetType() == typeof(ConnectionException))
            {
                var exception = (ConnectionException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                message = exception.Message;
                messageId = exception.MessageId;
            }
        }
        private void GetLicenseException(HttpContext httpContext, Exception e,ref string message, ref string messageId)
        {          
            if (e.GetType() == typeof(LicenseException))
            {
                var exception = (LicenseException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                message = e.Message;
                messageId = exception.MessageId;
            }
        }
        private void GetAuthenticationException(HttpContext httpContext, Exception e, ref string message, ref string messageId)
        {
            if (e.GetType() == typeof(AuthException))
            {
                var exception = (AuthException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                message = e.Message;
                messageId = exception.MessageId;
            }
        }
        private void GetNotificationException(HttpContext httpContext, Exception e, ref string message, ref string messageId)
        {
            if (e.GetType() == typeof(NotificationException))
            {
                var exception = (NotificationException)e;
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                message = e.Message;
                messageId = exception.MessageId;
            }
        }
    }
}
