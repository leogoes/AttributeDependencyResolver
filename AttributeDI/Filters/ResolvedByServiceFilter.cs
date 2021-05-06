using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttributeDI.Filters
{
    public class ResolvedByServiceFilter : IAsyncAuthorizationFilter
    {
        private readonly ICurrentUser _user;

        public ResolvedByServiceFilter(ICurrentUser user)
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
