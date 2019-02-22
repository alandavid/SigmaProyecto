using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ninja.common.Abstract
{
    public abstract class WindsorProfile
    {
        protected abstract IEnumerable<IRegistration> Registry();

        public static implicit operator IRegistration[] (WindsorProfile prof)
        {
            return prof.Registry().ToArray();
        }
    }
}
