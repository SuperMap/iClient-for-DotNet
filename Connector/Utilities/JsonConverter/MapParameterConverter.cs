using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
#if !WINDOWS_PHONE
    internal class MapParameterConverter : JsonConverter
#else
    public class MapParameterConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MapParameter) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            MapParameter mapParameter = new MapParameter();
            reader.Read();
            while (reader.TokenType == JsonToken.PropertyName)
            {
                string propertyName = reader.Value.ToString();
                switch (propertyName)
                {
                    case "name":
                        reader.Read();
                        mapParameter.Name = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "center":
                        reader.Read();
                        mapParameter.Center = serializer.Deserialize<Point2D>(reader);
                        break;
                    case "scale":
                        reader.Read();
                        double scale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out scale))
                        {
                            mapParameter.Scale = scale;
                        }
                        break;
                    case "maxScale":
                        reader.Read();
                        double maxScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out maxScale))
                        {
                            mapParameter.MaxScale = maxScale;
                        }
                        break;
                    case "minScale":
                        reader.Read();
                        double minScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minScale))
                        {
                            mapParameter.MinScale = minScale;
                        }
                        break;
                    case "angle":
                        reader.Read();
                        double angle = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out angle))
                        {
                            mapParameter.Angle = angle;
                        }
                        break;
                    case "antialias":
                        reader.Read();
                        bool antialias = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out antialias))
                        {
                            mapParameter.Antialias = antialias;
                        }
                        break;
                    case "backgroundStyle":
                        reader.Read();
                        mapParameter.BackgroundStyle = serializer.Deserialize<Style>(reader);
                        break;
                    case "bounds":
                        reader.Read();
                        mapParameter.Bounds = serializer.Deserialize<Rectangle2D>(reader);
                        break;
                    case "clipRegion":
                        reader.Read();
                        mapParameter.ClipRegion = serializer.Deserialize<Geometry>(reader);
                        break;
                    case "colorMode":
                        reader.Read();
                        MapColorMode colorMode = MapColorMode.DEFAULT;
                        if (reader.Value != null)
                        {
                            colorMode = (MapColorMode)Enum.Parse(typeof(MapColorMode), reader.Value.ToString(), false);
                            mapParameter.ColorMode = colorMode;
                        }
                        break;
                    case "clipRegionEnabled":
                        reader.Read();
                        bool clipRegionEnabled = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out clipRegionEnabled))
                        {
                            mapParameter.ClipRegionEnabled = clipRegionEnabled;
                        }
                        break;
                    case "maxVisibleVertex":
                        reader.Read();
                        int maxVisibleVertex = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out maxVisibleVertex))
                        {
                            mapParameter.MaxVisibleVertex = maxVisibleVertex;
                        }
                        break;
                    case "coordUnit":
                        reader.Read();
                        Unit coordUnit = Unit.METER;
                        if (reader.Value != null)
                        {
                            coordUnit = (Unit)Enum.Parse(typeof(Unit), reader.Value.ToString(), false);
                            mapParameter.CoordUnit = coordUnit;
                        }
                        break;
                    case "rectifyType":
                        reader.Read();
                        RectifyType rectifyType = RectifyType.BYCENTERANDMAPSCALE;
                        if (reader.Value != null)
                        {
                            rectifyType = (RectifyType)Enum.Parse(typeof(RectifyType), reader.Value.ToString(), false);
                            mapParameter.RectifyType = rectifyType;
                        }
                        break;
                    case "customEntireBounds":
                        reader.Read();
                        mapParameter.CustomEntireBounds = serializer.Deserialize<Rectangle2D>(reader);
                        break;
                    case "customEntireBoundsEnabled":
                        reader.Read();
                        bool customEntireBoundsEnabled = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out customEntireBoundsEnabled))
                        {
                            mapParameter.CustomEntireBoundsEnabled = customEntireBoundsEnabled;
                        }
                        break;
                    case "customParams":
                        reader.Read();
                        mapParameter.CustomParams = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "description":
                        reader.Read();
                        mapParameter.Description = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "distanceUnit":
                        reader.Read();
                        Unit distanceUnit = Unit.METER;
                        if (reader.Value != null)
                        {
                            distanceUnit = (Unit)Enum.Parse(typeof(Unit), reader.Value.ToString(), false);
                            mapParameter.CoordUnit = distanceUnit;
                        }
                        break;
                    case "dynamicProjection":
                        reader.Read();
                        bool dynamicProjection = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out dynamicProjection))
                        {
                            mapParameter.DynamicProjection = dynamicProjection;
                        }
                        break;
                    case "markerAngleFixed":
                        reader.Read();
                        bool markerAngleFixed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out markerAngleFixed))
                        {
                            mapParameter.MarkerAngleFixed = markerAngleFixed;
                        }
                        break;
                    case "maxVisibleTextSize":
                        reader.Read();
                        double maxVisibleTextSize = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out maxVisibleTextSize))
                        {
                            mapParameter.MaxVisibleTextSize = maxVisibleTextSize;
                        }
                        break;
                    case "minVisibleTextSize":
                        reader.Read();
                        double minVisibleTextSize = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minVisibleTextSize))
                        {
                            mapParameter.MinVisibleTextSize = minVisibleTextSize;
                        }
                        break;
                    case "overlapDisplayed":
                        reader.Read();
                        bool overlapDisplayed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out overlapDisplayed))
                        {
                            mapParameter.OverlapDisplayed = overlapDisplayed;
                        }
                        break;
                    case "paintBackground":
                        reader.Read();
                        bool paintBackground = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out paintBackground))
                        {
                            mapParameter.PaintBackground = paintBackground;
                        }
                        break;
                    case "textAngleFixed":
                        reader.Read();
                        bool textAngleFixed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out textAngleFixed))
                        {
                            mapParameter.TextAngleFixed = textAngleFixed;
                        }
                        break;
                    case "textOrientationFixed":
                        reader.Read();
                        bool textOrientationFixed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out textOrientationFixed))
                        {
                            mapParameter.TextOrientationFixed = textOrientationFixed;
                        }
                        break;
                    case "prjCoordSys":
                        reader.Read();
                        mapParameter.PrjCoordSys = serializer.Deserialize<PrjCoordSys>(reader);
                        break;
                    case "viewBounds":
                        reader.Read();
                        mapParameter.ViewBounds = serializer.Deserialize<Rectangle2D>(reader);
                        break;
                    case "viewer":
                        reader.Read();
                        mapParameter.Viewer = serializer.Deserialize<Rectangle>(reader);
                        break;
                    case "cacheEnabled":
                        reader.Read();
                        bool cacheEnabled = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out cacheEnabled))
                        {
                            mapParameter.CacheEnabled = cacheEnabled;
                        }
                        break;
                    case "userToken":
                        reader.Read();
                        mapParameter.UserToken = serializer.Deserialize<UserInfo>(reader);
                        break;
                    case "layers":
                        reader.Read();
                        List<Dictionary<string, object>> layers = serializer.Deserialize<List<Dictionary<string, object>>>(reader);
                        mapParameter.Layers = new List<Layer>();
                        if (layers != null && layers.Count > 0)
                        {
                            for (int i = 0; i < layers.Count; i++)
                            {
                                LayerType layerType = (LayerType)Enum.Parse(typeof(LayerType), layers[i]["type"].ToString(), false);
                                switch (layerType)
                                {
                                    case LayerType.UGC:
                                        UGCMapLayer ugcMapLayer = JsonConvert.DeserializeObject<UGCMapLayer>(JsonConvert.SerializeObject(layers[i]));
                                        //mapParameter.Layers.Add(ugcMapLayer);
                                        if (ugcMapLayer != null)
                                        {
                                            for (int j = 0; j < ugcMapLayer.SubLayers.Count; j++)
                                            {
                                                mapParameter.Layers.Add(ugcMapLayer.SubLayers[j]);
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
                reader.Read();
            }
            return mapParameter;
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
