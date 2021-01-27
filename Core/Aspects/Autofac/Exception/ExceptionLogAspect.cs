using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect:MethodInterseption
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;

        public ExceptionLogAspect(Type LoggerService)
        {
           if(LoggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new System.Exception(CoreMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(LoggerService);
            _httpContextAccessor = ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnExeption(IInvocation invocation,System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            logDetailWithException.InnerMessage = e.InnerException?.ToString();
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value=invocation.Arguments[i],
                    Type=invocation.Arguments[i].GetType().Name,
                });
            }

            var logDetailWithException = new LogDetailWithException
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value,
                Target = invocation.InvocationTarget?.ToString(),
                MethodName = invocation.Method.Name,
                LogParameters=logParameters,
            };

            return logDetailWithException;
        }
    }
}
