using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using ninja.common.Extension;
using ninja.HostFactory.Profile;
using ninja.HostFactory.Profile.Managers;
using ninja.Windsor;
using System;
using System.Collections.Generic;

namespace ninja.Installers
{
    public class ServiceHostFactory : IWindsorInstaller
    {
        public ServiceHostFactory()
           
        {
        }
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero);

            container
                
                  .RegisterProfile<CommonDependencies>()
                  .RegisterProfile<ManagersDependencies>();
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
         
        }

      

       
    }
}
