using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterseption
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var argument = GetFieldsOfClass(invocation.Arguments);
            var key = $"{methodName}({argument})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
        public string GetFieldsOfClass(params object[] entity)
        {
            List<string> result = new List<string>();
            foreach (var item in entity)
            {

                result.Add(string.Join(",", item.GetType()
                            .GetFields(BindingFlags.Public | BindingFlags.NonPublic
                            | BindingFlags.Instance)
                            .Where(x => x?.GetValue(item) != null)
                            .Select(x => x?.GetValue(item)).ToList()));
            }

            return string.Join(",", result);
        }
    }
}