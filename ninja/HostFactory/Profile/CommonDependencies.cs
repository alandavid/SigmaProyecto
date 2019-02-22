using Castle.MicroKernel.Registration;
using ninja.common.Abstract;
using ninja.dataAcces.Interfaces;
using ninja.dataAcces.Mock;
using ninja.Mapping;
using ninja.Mapping.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ninja.HostFactory.Profile
{
    public class CommonDependencies : WindsorProfile
    {
        protected override IEnumerable<IRegistration> Registry()
        {
            return new List<IRegistration>()
            {
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),
                Component.For<ITransformMapper>().ImplementedBy<BusinessTransformMapper>().LifestyleSingleton(),
                
             };
        }
    }
}