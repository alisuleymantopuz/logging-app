using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public class MethodLogger : IMethodLogger
    {
        public IEnhancedLogger EnhancedLogger { get; private set; }

        public MethodLogger(IEnhancedLogger enhancedLogger)
        {
            this.EnhancedLogger = enhancedLogger;
        }

        public void WriteMethodEntry(string referenceId, MethodBase methodBase, List<object> arguments, string variableFolderName = null)
        {
            this.EnhancedLogger.Write("Entering Method: " + methodBase.Name + " (" + methodBase.DeclaringType.FullName + ")",
                LoggerLevel.Trace, methodBase, null, arguments, null, referenceId: referenceId, variableFolderName: variableFolderName);
        }

        public void WriteMethodExit(string referenceId, MethodBase methodBase, List<object> arguments, object returnValue, string variableFolderName = null)
        {
            this.EnhancedLogger.Write("Exiting Method: " + methodBase.Name + " (" + methodBase.DeclaringType.FullName + ")",
                LoggerLevel.Trace, methodBase, null, arguments, returnValue, referenceId: referenceId, variableFolderName: variableFolderName);
        }
    }
}
