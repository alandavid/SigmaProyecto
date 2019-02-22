﻿using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;

namespace ninja.Windsor
{
    internal class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer container;
        private readonly IDisposable scope;

        public WindsorDependencyScope(
            IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
            this.scope = container.BeginScope();
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

        public void Dispose()
        {
            this.scope.Dispose();
        }
    }
}