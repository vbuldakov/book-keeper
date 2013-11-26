using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILifetimeManager
    {
        ILifetimeScope BeginNewLifetime(Action<ContainerBuilder> activationAction);
    }
}
