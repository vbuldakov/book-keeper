using Autofac;
using Autofac.Integration.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Code
{
    public class LifetimeManager : ILifetimeManager
    {
        public ILifetimeScope BeginNewLifetime(Action<ContainerBuilder> activationAction)
        {
            return AutofacDependencyResolver.Current.ApplicationContainer.BeginLifetimeScope(activationAction);
        }
    }
}
