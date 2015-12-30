using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor; 
using LoggingApplication.Infrastructure.Logging.NLog;
using LoggingApplication.Infrastructure.Installers;

namespace LoggingApplication.Container
{
    public class Bootstrapper
    {
        public static IWindsorContainer WindsorContainer { get; private set; }

        public static IWindsorContainer Initialize()
        {
            WindsorContainer = new WindsorContainer();
            WindsorContainer
                .Install(new ConfigurationInstaller())
                .Install(new DatabaseErrorLogWindsorInstaller());

            return WindsorContainer;
        }
    }
}
