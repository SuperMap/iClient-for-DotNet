using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
#if WINDOWS_PHONE
    public class DateTimeConverter:JsonConverter
#else
    internal class DateTimeConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, object> timeHashValue = serializer.Deserialize<Dictionary<string, object>>(reader);
            if (timeHashValue == null)
            {
                return DateTime.MinValue;
            }
            if (timeHashValue.ContainsKey("time") && timeHashValue.ContainsKey("year") && timeHashValue.ContainsKey("month") && timeHashValue.ContainsKey("date")
                 && timeHashValue.ContainsKey("hours") && timeHashValue.ContainsKey("minutes") && timeHashValue.ContainsKey("seconds"))
            {
                long time = Convert.ToInt64(timeHashValue["time"]);
                int year = Convert.ToInt32(timeHashValue["year"]);
                int month = Convert.ToInt32(timeHashValue["month"]);
                int day = Convert.ToInt32(timeHashValue["date"]);
                int hours = Convert.ToInt32(timeHashValue["hours"]);
                int minutes = Convert.ToInt32(timeHashValue["minutes"]);
                int seconds = Convert.ToInt32(timeHashValue["seconds"]);
                TimeSpan span = new TimeSpan(time);
                DateTime times;
                try
                {
                    times = new DateTime(year, month, day, hours, minutes, seconds);
                }
                catch
                {
                    times = DateTime.MinValue;
                }
                return times.Add(span);
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
