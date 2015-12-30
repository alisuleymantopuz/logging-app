using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public interface IMethodLogger
    {
        /// <summary>
        /// Logs method entry information. Only to be used from a method's first line or from an interceptor.
        /// </summary>
        /// <param name="referenceId">Request reference id.</param>
        /// <param name="methodInfo">The method that is entered or to be entered.</param>
        /// <param name="arguments">Paramaters that sent to the method that is entered or to be entered.</param>
        /// <param name="variableFolderName">Request variableFolderName is optional. The folder to be logged in.</param>
        void WriteMethodEntry(string referenceId, MethodBase methodBase, List<object> arguments, string variableFolderName = null);

        /// <summary>
        /// Logs method exit information. Only to be used from a method's last line or from an interceptor.
        /// </summary>
        /// <param name="referenceId">Request reference id.</param>
        /// <param name="methodInfo">The method that is exited or to be exited.</param>
        /// <param name="arguments">Paramaters that sent to the method that is exited or to be exited.</param>
        /// <param name="returnValue">Returning object that is returned or to be returned from the method that is exited or to be exited.</param>
        /// <param name="variableFolderName">Optional sub-folder name, the log file will be put. Each Write method call can specify a different sub-folder for 
        /// its log and as variableFolderName parameter differs at each call, logs would be put in different files in different folders.
        /// </param>
        void WriteMethodExit(string referenceId, MethodBase methodBase, List<object> arguments, object returnValue, string variableFolderName = null);

    }
}
