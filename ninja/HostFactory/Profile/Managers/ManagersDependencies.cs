using Castle.MicroKernel.Registration;
using ninja.business;
using ninja.business.Interfaces;
using ninja.common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.HostFactory.Profile.Managers
{
    public class ManagersDependencies : WindsorProfile
    {
        protected override IEnumerable<IRegistration> Registry()
        {
            return new List<IRegistration>()
            {
                    Component.For<IInvoiceManager>().LifeStyle.PerWebRequest.ImplementedBy<InvoiceManager>(),
                   




            };
        }
    }
}