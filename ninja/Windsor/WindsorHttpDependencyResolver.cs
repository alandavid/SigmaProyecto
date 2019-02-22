using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ninja.Windsor
{
  
        internal sealed class WindsorHttpDependencyResolver : IDependencyResolver
        {
            private readonly IWindsorContainer container;

            public WindsorHttpDependencyResolver(
                IWindsorContainer container)
            {
                if (container == null)
                {
                    throw new ArgumentNullException("container");
                }

                this.container = container;
            }

            public object GetService(Type t)
            {
                return this.container.Kernel.HasComponent(t)
                     ? this.container.Resolve(t) : null;
            }

            public IEnumerable<object> GetServices(Type t)
            {
                return this.container.ResolveAll(t)
                    .Cast<object>().ToArray();
            }

            public IDependencyScope BeginScope()
            {
                return new WindsorDependencyScope(this.container);
            }

            public void Dispose()
            {
            }
        }
    
}