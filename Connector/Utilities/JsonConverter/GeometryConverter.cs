using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
#if !WINDOWS_PHONE
    internal class GeometryConverter : JsonConverter
#else
    public class GeometryConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            if (typeof(Geometry) != objectType ||
                //typeof(GeometryCAD) != objectType ||
                typeof(GeometryText) != objectType)
                return true;
            else return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, object> geometryHashValue = serializer.Deserialize<Dictionary<string, object>>(reader);
            if (geometryHashValue == null) return null;
            Geometry geometry = null;
            if (geometryHashValue != null &&
                geometryHashValue.ContainsKey("type") &&
                geometryHashValue["type"] != null &&
                geometryHashValue["type"].ToString() == "TEXT")
            {
                geometry = new GeometryText();
                (geometry as GeometryText).Texts = geometryHashValue.ContainsKey("texts") && geometryHashValue["texts"] != null ?
                JsonConvert.DeserializeObject<string[]>(geometryHashValue["texts"].ToString()) : null;
                (geometry as GeometryText).TextStyle = geometryHashValue.ContainsKey("textStyle") && geometryHashValue["textStyle"] != null ?
                JsonConvert.DeserializeObject<TextStyle>(geometryHashValue["textStyle"].ToString()) : null;
            }
            else
            {
                geometry = new Geometry();
            }
            geometry.Id = geometryHashValue.ContainsKey("id") && geometryHashValue["id"] != null ?
                JsonConvert.DeserializeObject<int>(geometryHashValue["id"].ToString()) : 0;
            geometry.Parts = geometryHashValue.ContainsKey("parts") && geometryHashValue["parts"] != null ?
                JsonConvert.DeserializeObject<int[]>(geometryHashValue["parts"].ToString()) : null;
            geometry.Points = geometryHashValue.ContainsKey("points") && geometryHashValue["points"] != null ?
               JsonConvert.DeserializeObject<Point2D[]>(geometryHashValue["points"].ToString()) : null;
            geometry.Style = geometryHashValue.ContainsKey("style") && geometryHashValue["style"] != null ?
               JsonConvert.DeserializeObject<Style>(geometryHashValue["style"].ToString()) : null;
            geometry.Type = GeometryType.UNKNOWN;
            GeometryType geoType = GeometryType.UNKNOWN;
            if (geometryHashValue.ContainsKey("type") &&
                geometryHashValue["type"] != null)
            {
                geoType = (GeometryType)Enum.Parse(typeof(GeometryType), geometryHashValue["type"].ToString(), false);
                geometry.Type = geoType;
            }
            return geometry;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    }
}
