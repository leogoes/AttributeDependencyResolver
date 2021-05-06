using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AttributeDI.Filters
{
    public class ResolvedByTypeFilter : IAsyncAuthorizationFilter
    {
        private readonly ICurrentUser _user;

        public ResolvedByTypeFilter(ICurrentUser user)
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
