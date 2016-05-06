using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis.Sdk.Contract
{
    public class CultureInfoJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CultureInfo);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var culture = reader.Value.ToString();
                return new CultureInfo(culture);
            }

            return null;            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var culture = (CultureInfo)value;
            var token = JToken.FromObject(culture.Name);
            token.WriteTo(writer);
        }
    }
}
