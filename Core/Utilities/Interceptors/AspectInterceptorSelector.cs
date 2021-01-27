using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);       
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)) { Priority = 1 });
            classAttributes.Add(new ExceptionLogAspect(typeof(JsonFileLogger)) { Priority = 2 });
            //classAttributes.Add(new LogAspect(typeof(JsonFileLogger)));
            //classAttributes.Add(new LogAspect(typeof(DatabaseLogger)));
            return classAttributes.OrderByDescending(x=>x.Priority).ToArray();
        }
    }
}
