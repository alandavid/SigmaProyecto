using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Diagnostics;
using ninja.common.Abstract;
using ninja.common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ninja.common.Extension
{
    public static class WindsorExtension
    {
        public static IWindsorContainer RegisterProfile<T>(this IWindsorContainer container) where T : WindsorProfile
        {
            WindsorProfile instance = Activator.CreateInstance<T>();

            container.Register(instance);

            return container;
        }

        public static IWindsorContainer Validate(this IWindsorContainer container)
        {
            var host = (IDiagnosticsHost)container.Kernel.GetSubSystem(SubSystemConstants.DiagnosticsKey);
            var diagnostics = host.GetDiagnostic<IPotentiallyMisconfiguredComponentsDiagnostic>();
            var misconfiguredHandlers = diagnostics.Inspect();

            if (misconfiguredHandlers.Length > 0)
            {
                throw new WindsorMisconfiguredHandlersException(misconfiguredHandlers.Select(x => x.ComponentModel.Name + " " + x.CurrentState).ToArray());
            }
            return container;

        }
    }
}
