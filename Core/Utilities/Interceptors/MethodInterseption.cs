using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterseption : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnExeption(IInvocation invocation,System.Exception e) { }
        protected virtual void OnSuccsess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception e)
            {
                isSuccess = false;
                OnExeption(invocation,e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccsess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
