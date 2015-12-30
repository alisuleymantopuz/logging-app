using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LoggingApplication.Container;
using LoggingApplication.Infrastructure.Logging;
using LoggingApplication.Infrastructure.Extensions;

namespace LoggingApplication.UI.Application
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper.Initialize();

            IEnhancedLogger enhancedLogger = Bootstrapper.WindsorContainer.Resolve<IEnhancedLogger>();

            enhancedLogger.Write("Enhanced logger test message", 
                LoggerLevel.Info, 
                MethodBase.GetCurrentMethod(), 
                null, new List<object>() 
                { MethodBase.GetCurrentMethod() }, 
                null, 
                Guid.NewGuid().ToString());
        }
    }
}
