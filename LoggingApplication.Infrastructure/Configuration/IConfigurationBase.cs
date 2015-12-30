using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Configuration
{
    public interface IConfigurationBase
    {
        T GetValue<T>(string key, KeyRequirement keyRequirement);
        string GetValue(string key, KeyRequirement keyRequirement);
        string GetStringValue(string key);
    }
}
