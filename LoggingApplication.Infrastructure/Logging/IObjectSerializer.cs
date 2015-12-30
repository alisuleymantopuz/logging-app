using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingApplication.Infrastructure.Logging
{
    public interface IObjectSerializer
    {
        /// <summary>
        /// Serializes the given object.
        /// </summary>
        /// <typeparam name="TObject">Object to be serialized.</typeparam>
        /// <param name="objectToSerialize">Serialized object as string.</param>
        /// <returns></returns>
        string Serialize<TObject>(TObject objectToSerialize);

        /// <summary>
        /// Serializes the given object.
        /// </summary>
        /// <typeparam name="TObject">Object to be serialized.</typeparam>
        /// <param name="objectToSerialize">Serialized object as string.</param>
        /// <returns></returns>
        TObject Deserialize<TObject>(string data);
    }
}
