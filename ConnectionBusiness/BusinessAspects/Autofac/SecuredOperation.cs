using Castle.DynamicProxy;
using ConnectionBusiness.Constants;
using Core.Extensions;
using Core.Utilities.Exceptions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ConnectionBusiness.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterseption
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor= ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            if(!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                throw new AuthException(Messages.AuthenticationDenied, Messages.AuthenticationDeniedId);

            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roleClaims)
            {
                if(_roles.Contains(role))
                {
                    return;
                }
            }
            throw new AuthException(Messages.AuthorizeationDenied, Messages.AuthorizeationDeniedId);
        }
    }
}
