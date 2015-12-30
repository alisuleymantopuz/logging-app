using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using LoggingApplication.Infrastructure.Configuration;

namespace LoggingApplication.Infrastructure.Installers
{
    public class ConfigurationInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IConfigurationBase>().ImplementedBy<ConfigurationBase>().LifeStyle.Singleton);
            container.Register(Component.For<InfrastructureConfiguration>().LifestyleSingleton());
        }
    }
}
