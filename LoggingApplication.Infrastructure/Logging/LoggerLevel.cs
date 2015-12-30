using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public enum LoggerLevel
    {
        Off = 6,
        Fatal = 5,
        Error = 4,
        Warn = 3,
        Info = 2,
        Debug = 1,
        Trace = 0
    }
}
