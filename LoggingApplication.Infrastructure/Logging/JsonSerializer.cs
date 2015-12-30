using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoggingApplication.Infrastructure.Logging
{
    public class JsonSerializer : IObjectSerializer
    {
        private JsonSerializerSettings settings;

        public JsonSerializer()
        {
            this.settings = new JsonSerializerSettings();
        }

        public string Serialize<TObject>(TObject objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented);
        }

        public TObject Deserialize<TObject>(string data)
        {
            return JsonConvert.DeserializeObject<TObject>(data);
        }
    }
}
