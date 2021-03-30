using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GraphQlDocker
{

    /// <summary>
    /// Extranet currently only has functionality to pick dates, so we assume it's utc time (date plus + 00:00:00)
    /// will require refactoring if or when we had the ability to edit Date Times,
    /// this means updating the ui to handle utc to local time conversion and API to assume
    /// date times are UTC
    /// </summary>
    public class CustomJsonDateConvertor : DateTimeConverterBase
    {
        /// <summary>
        /// As we are storing date objects as UTC, we need to convert the UTC date time to local for client
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var s = reader.Value.ToString();
            if (DateTime.TryParse(s, out DateTime result))
            {
                return result.ToLocalTime();
            }

            return DateTime.MinValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (DateTime)value;
            DateTime utcDateTime = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            writer.WriteValue(date);
        }
    }
}
