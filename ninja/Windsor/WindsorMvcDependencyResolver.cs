using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Windsor
{
    internal class WindsorMvcDependencyResolver : WindsorDependencyScope, IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorMvcDependencyResolver(
            IWindsorContainer container)
            : base(container)
        {
            this.container = container;
        }
    }
}