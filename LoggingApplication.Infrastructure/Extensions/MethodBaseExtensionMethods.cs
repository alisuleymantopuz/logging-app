using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Extensions
{
    public static class MethodBaseExtensionMethods
    {
        public static string CurrentMethodQualifiedName(this MethodBase methodBase)
        {
            return string.Format("[{0}]", methodBase.Name);
        }
    }
}
