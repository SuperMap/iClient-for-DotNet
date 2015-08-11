using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
#if !WINDOWS_PHONE
    internal class RouteConverter : JsonConverter
#else
    public class RouteConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Route route = (Route)value;
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteValue(route.Id);
            writer.WritePropertyName("length");
            writer.WriteValue(route.Length);
            writer.WritePropertyName("line");
            writer.WriteRawValue(JsonConvert.SerializeObject(route.Line));
            writer.WritePropertyName("maxM");
            writer.WriteValue(route.MaxM);
            writer.WritePropertyName("minM");
            writer.WriteValue(route.MinM);
            writer.WritePropertyName("region");
            writer.WriteRawValue(JsonConvert.SerializeObject(route.Region));
            writer.WritePropertyName("parts");
            writer.WriteRawValue(JsonConvert.SerializeObject(route.Parts));

            writer.WritePropertyName("style");
            writer.WriteRawValue(JsonConvert.SerializeObject(route.Style));
            writer.WritePropertyName("type");
            writer.WriteValue(route.Type);
            writer.WritePropertyName("points");
            writer.WriteRawValue(JsonConvert.SerializeObject(route.Points));

            writer.WriteEndObject();
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, object> routeHashValue = serializer.Deserialize<Dictionary<string, object>>(reader);
            if (routeHashValue == null) return null;
            Route route = new Route();
            route.Id = routeHashValue.ContainsKey("id") && routeHashValue["id"] != null ?
                JsonConvert.DeserializeObject<int>(routeHashValue["id"].ToString()) : 0;
            route.Parts = routeHashValue.ContainsKey("parts") && routeHashValue["parts"] != null ?
                JsonConvert.DeserializeObject<int[]>(routeHashValue["parts"].ToString()) : null;
            route.Points = routeHashValue.ContainsKey("points") && routeHashValue["points"] != null ?
               JsonConvert.DeserializeObject<PointWithMeasure[]>(routeHashValue["points"].ToString()) : null;
            route.Style = routeHashValue.ContainsKey("style") && routeHashValue["style"] != null ?
               JsonConvert.DeserializeObject<Style>(routeHashValue["style"].ToString()) : null;
            route.Type = GeometryType.UNKNOWN;
            GeometryType geoType = GeometryType.UNKNOWN;
            if (routeHashValue.ContainsKey("type") &&
                routeHashValue["type"] != null)
            {
                geoType = (GeometryType)Enum.Parse(typeof(GeometryType), routeHashValue["type"].ToString(), false);
                route.Type = geoType;
            }

            route.Length = routeHashValue.ContainsKey("length") && routeHashValue["length"] != null ?
                JsonConvert.DeserializeObject<double>(routeHashValue["length"].ToString()) : 0.0;

            route.MaxM = routeHashValue.ContainsKey("maxM") && routeHashValue["maxM"] != null ?
                JsonConvert.DeserializeObject<int>(routeHashValue["maxM"].ToString()) : 0;
            route.MinM = routeHashValue.ContainsKey("minM") && routeHashValue["minM"] != null ?
                JsonConvert.DeserializeObject<int>(routeHashValue["minM"].ToString()) : 0;

            route.Line = routeHashValue.ContainsKey("line") && routeHashValue["line"] != null ?
                JsonConvert.DeserializeObject<Geometry>(routeHashValue["line"].ToString()) : null;

            route.Region = routeHashValue.ContainsKey("region") && routeHashValue["region"] != null ?
                JsonConvert.DeserializeObject<Geometry>(routeHashValue["region"].ToString()) : null;

            return route;
        }
    }
}
