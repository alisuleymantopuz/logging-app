using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NLog;

namespace LoggingApplication.Infrastructure.Logging.NLog
{
    public class FileLogWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<LogConfiguration>().LifeStyle.Singleton);
            container.Register(Component.For<IObjectSerializer>().ImplementedBy<JsonSerializer>().LifeStyle.Singleton);
            container.Register(Component.For<ILoggingConfigurationModifier>().ImplementedBy<FileTargetsConfigurationModifier>());

            LogConfiguration logConfiguration = container.Resolve<LogConfiguration>();
            LogManager.GlobalThreshold = LogLevel.FromOrdinal(logConfiguration.LoggerLevel);

            ILoggingConfigurationModifier loggingConfigurationModifier = container.Resolve<ILoggingConfigurationModifier>();
            LogManager.Configuration = loggingConfigurationModifier.ModifyLoggingConfiguration(LogManager.Configuration);

            container.Register(Component.For<IEnhancedLogger>().ImplementedBy<NLogLogger>().LifeStyle.Singleton);
            container.Register(Component.For<ITraceLogger>().ImplementedBy<TraceLogger>().LifeStyle.Singleton);
            container.Register(Component.For<IMethodLogger>().ImplementedBy<MethodLogger>().LifeStyle.Singleton);
            container.Register(Component.For<IExceptionLogger>().ImplementedBy<ExceptionLogger>().LifeStyle.Singleton);

            container.Release(logConfiguration);
            container.Release(loggingConfigurationModifier);
        }
    }
}
