using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using LoggingApplication.Infrastructure.Logging;
using LoggingApplication.Infrastructure.Logging.NLog;
using NLog;

namespace LoggingApplication.Infrastructure.Installers
{
    public class LoggingInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<LogConfiguration>().LifeStyle.Singleton);
            container.Register(Component.For<IObjectSerializer>().ImplementedBy<JsonSerializer>().LifeStyle.Singleton);
            container.Register(Component.For<ILoggingConfigurationModifier>().ImplementedBy<FileAndDatabaseTargetsConfigurationModifier>());

            LogConfiguration logConfiguration = container.Resolve<LogConfiguration>();
            LogManager.GlobalThreshold = LogLevel.FromOrdinal(logConfiguration.LoggerLevel);
            container.Release(logConfiguration);

            ILoggingConfigurationModifier loggingConfigurationModifier = container.Resolve<ILoggingConfigurationModifier>();
            LogManager.Configuration = loggingConfigurationModifier.ModifyLoggingConfiguration(LogManager.Configuration);
            container.Release(loggingConfigurationModifier);

            container.Register(Component.For<IEnhancedLogger>().ImplementedBy<NLogLogger>().LifeStyle.Singleton);
            container.Register(Component.For<ITraceLogger>().ImplementedBy<TraceLogger>().LifeStyle.Singleton);
            container.Register(Component.For<IMethodLogger>().ImplementedBy<MethodLogger>().LifeStyle.Singleton);
            container.Register(Component.For<IExceptionLogger>().ImplementedBy<ExceptionLogger>().LifeStyle.Singleton);
        }
    }
}
