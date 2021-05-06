using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AttributeDI.Filters
{
    public class ResolvedByFactoryFilter : IAsyncAuthorizationFilter
    {
        private readonly ICurrentUser _user;

        public ResolvedByFactoryFilter(ICurrentUser user)
        {
            _user = user;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            _user.Nome = $"Nome filter para {this.GetType().Name}";

            return Task.FromResult(new Task(() => { }));
        }
    }

}
