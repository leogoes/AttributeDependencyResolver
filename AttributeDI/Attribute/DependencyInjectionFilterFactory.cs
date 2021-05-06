using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AttributeDI.Attribute
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DependencyInjectionFilterFactory : System.Attribute, IFilterFactory
    {
        private ObjectFactory _factory;
        public Type ImplementationType { get; set; }
        public DependencyInjectionFilterFactory(Type type)
        {
            ImplementationType = type ?? throw new ArgumentNullException(nameof(type));
        }

        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _factory ??= ActivatorUtilities.CreateFactory(ImplementationType, Type.EmptyTypes);


            var filter = (IFilterMetadata)_factory(serviceProvider, new object[]{});
            if (filter is IFilterFactory filterFactory)
            {
                filter = filterFactory.CreateInstance(serviceProvider);
            }

            return filter;
        }
    }
}
