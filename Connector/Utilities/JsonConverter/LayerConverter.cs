using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    //public class LayerConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return typeof(Layer) == objectType;
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool CanWrite
    //    {
    //        get
    //        {
    //            return false;
    //        }
    //    }
    //}

    //public class UGCMapLayerConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class UGCLayerConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class UGCVectorLayerConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return typeof(UGCVectorLayer) == objectType;
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        UGCVectorLayer ugcVectorLayer = new UGCVectorLayer();

    //        reader.Read();
    //        while (reader.TokenType == JsonToken.PropertyName)
    //        {
    //            string propertyName = reader.Value.ToString();
    //            switch (propertyName)
    //            {
    //                #region Layer属性读取
    //                case "bounds":
    //                    reader.Read();
    //                    ugcVectorLayer.Bounds = serializer.Deserialize<Rectangle2D>(reader);
    //                    break;
    //                case "caption":
    //                    reader.Read();
    //                    ugcVectorLayer.Caption = reader.Value != null ? reader.Value.ToString() : string.Empty;
    //                    break;
    //                case "description":
    //                    reader.Read();
    //                    ugcVectorLayer.Description = reader.Value != null ? reader.Value.ToString() : string.Empty;
    //                    break;
    //                case "name":
    //                    reader.Read();
    //                    ugcVectorLayer.Name = reader.Value != null ? reader.Value.ToString() : string.Empty;
    //                    break;
    //                case "queryable":
    //                    reader.Read();
    //                    bool queryable = false;
    //                    if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out queryable))
    //                    {
    //                        ugcVectorLayer.Queryable = queryable;
    //                    }
    //                    break;
    //                case "type":
    //                    reader.Read();
    //                    ugcVectorLayer.Type = iServerConnectorUtilities.LayerType.UGC;
    //                    break;
    //                case "visible":
    //                    bool visible = false;
    //                    reader.Read();
    //                    if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out visible))
    //                    {
    //                        ugcVectorLayer.Visible = visible;
    //                    }
    //                    break;
    //                case "subLayers":
    //                    reader.Read();
    //                    ugcVectorLayer.SubLayers = serializer.Deserialize<LayerCollection>(reader);
    //                    break;
    //                #endregion

    //                #region UGCMapLayer属性读取
    //                case "completeLineSymbolDisplayed":
    //                    reader.Read();
    //                    bool completeLineSymbolDisplayed = false;
    //                    if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out completeLineSymbolDisplayed))
    //                    {
    //                        ugcVectorLayer.CompleteLineSymbolDisplayed = completeLineSymbolDisplayed;
    //                    }
    //                    break;
    //                case "maxScale":
    //                    reader.Read();
    //                    double maxScale = 0.0;
    //                    if (reader.Value != null && double.TryParse(reader.Value.ToString(), out maxScale))
    //                    {
    //                        ugcVectorLayer.MaxScale = maxScale;
    //                    }
    //                    break;
    //                case "minScale":
    //                    reader.Read();
    //                    double minScale = 0.0;
    //                    if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minScale))
    //                    {
    //                        ugcVectorLayer.MaxScale = minScale;
    //                    }
    //                    break;
    //                case "minVisibleGeometrySize":
    //                    reader.Read();
    //                    double minVisibleGeometrySize = 0.0;
    //                    if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minVisibleGeometrySize))
    //                    {
    //                        ugcVectorLayer.MinVisibleGeometrySize = minVisibleGeometrySize;
    //                    }
    //                    break;
    //                case "opaqueRate":
    //                    reader.Read();
    //                    int opaqueRate = 0;
    //                    if (reader.Value != null && int.TryParse(reader.Value.ToString(), out opaqueRate))
    //                    {
    //                        ugcVectorLayer.OpaqueRate = opaqueRate;
    //                    }
    //                    break;
    //                case "symbolScalable":
    //                    reader.Read();
    //                    bool symbolScalable = false;
    //                    if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out symbolScalable))
    //                    {
    //                        ugcVectorLayer.SymbolScalable = symbolScalable;
    //                    }
    //                    break;
    //                case "symbolScale":
    //                    reader.Read();
    //                    double symbolScale = 0.0;
    //                    if (reader.Value != null && double.TryParse(reader.Value.ToString(), out symbolScale))
    //                    {
    //                        ugcVectorLayer.SymbolScale = symbolScale;
    //                    }
    //                    break;
    //                #endregion

    //                #region UGCLayer属性读取
    //                case "datasetInfo":
    //                    reader.Read();
    //                    ugcVectorLayer.DatasetInfo = serializer.Deserialize<DatasetInfo>(reader);
    //                    break;
    //                case "displayFilter":
    //                    reader.Read();
    //                    ugcVectorLayer.DisplayFilter = reader.Value != null ? reader.Value.ToString() : string.Empty;
    //                    break;
    //                case "joinItems":
    //                    reader.Read();
    //                    ugcVectorLayer.JoinItems = serializer.Deserialize<JoinItem[]>(reader);
    //                    break;
    //                case "representationField":
    //                    reader.Read();
    //                    ugcVectorLayer.RepresentationField = reader.Value != null ? reader.Value.ToString() : string.Empty;
    //                    break;
    //                case "ugcLayerType":
    //                    reader.Read();
    //                    ugcVectorLayer.UgcLayerType = iServerConnectorUtilities.UGCLayerType.VECTOR;
    //                    break;
    //                #endregion

    //                #region UGCVectorLayer属性
    //                case "style":
    //                    reader.Read();
    //                    ugcVectorLayer.Style = serializer.Deserialize<Style>(reader);
    //                    break;
    //                #endregion
    //                default:
    //                    reader.Skip();
    //                    break;
    //            }
    //            reader.Read();
    //        }
    //        return ugcVectorLayer;
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

#if !WINDOWS_PHONE
    internal class LayerConverter : CustomCreationConverter<Layer>
#else
    public class LayerConverter : CustomCreationConverter<Layer>
#endif
    {
        public override Layer Create(Type objectType)
        {
            if (typeof(Layer) == objectType)
            {
                return new Layer();
            }
            //else if (typeof(UGCMapLayer) == objectType)
            //{
            //    return new UGCMapLayer();
            //}
            if (typeof(UGCLayer) == objectType)
            {
                return new UGCLayer();
            }
            else if (typeof(UGCVectorLayer) == objectType)
            {
                return new UGCVectorLayer();
            }
            //else if (typeof(UGCThemeLayer) == objectType)
            //{
            //    return new UGCThemeLayer();
            //}
            else if (typeof(UGCImageLayer) == objectType)
            {
                return new UGCImageLayer();
            }
            else if (typeof(UGCGridLayer) == objectType)
            {
                return new UGCGridLayer();
            }
            else if (typeof(WMSLayer) == objectType)
            {
                return new WMSLayer();
            }
            else if (typeof(WFSLayer) == objectType)
            {
                return new WFSLayer();
            }
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
#if !WINDOWS_PHONE
    internal class UGCThemeLayerConverter : JsonConverter
#else
    public class UGCThemeLayerConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(UGCThemeLayer) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            UGCThemeLayer ugcThemeLayer = new UGCThemeLayer();
            reader.Read();
            while (reader.TokenType == JsonToken.PropertyName)
            {
                string propertyName = reader.Value.ToString();
                switch (propertyName)
                {
                    #region Layer属性读取
                    case "bounds":
                        reader.Read();
                        ugcThemeLayer.Bounds = serializer.Deserialize<Rectangle2D>(reader);
                        break;
                    case "caption":
                        reader.Read();
                        ugcThemeLayer.Caption = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "description":
                        reader.Read();
                        ugcThemeLayer.Description = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "name":
                        reader.Read();
                        ugcThemeLayer.Name = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "queryable":
                        reader.Read();
                        bool queryable = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out queryable))
                        {
                            ugcThemeLayer.Queryable = queryable;
                        }
                        break;
                    case "type":
                        reader.Read();
                        ugcThemeLayer.Type = LayerType.UGC;
                        break;
                    case "visible":
                        bool visible = false;
                        reader.Read();
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out visible))
                        {
                            ugcThemeLayer.Visible = visible;
                        }
                        break;
                    case "subLayers":
                        reader.Read();
                        ugcThemeLayer.SubLayers = serializer.Deserialize<LayerCollection>(reader);
                        break;
                    #endregion

                    #region UGCMapLayer属性读取
                    case "completeLineSymbolDisplayed":
                        reader.Read();
                        bool completeLineSymbolDisplayed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out completeLineSymbolDisplayed))
                        {
                            ugcThemeLayer.CompleteLineSymbolDisplayed = completeLineSymbolDisplayed;
                        }
                        break;
                    case "maxScale":
                        reader.Read();
                        double maxScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out maxScale))
                        {
                            ugcThemeLayer.MaxScale = maxScale;
                        }
                        break;
                    case "minScale":
                        reader.Read();
                        double minScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minScale))
                        {
                            ugcThemeLayer.MinScale = minScale;
                        }
                        break;
                    case "minVisibleGeometrySize":
                        reader.Read();
                        double minVisibleGeometrySize = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minVisibleGeometrySize))
                        {
                            ugcThemeLayer.MinVisibleGeometrySize = minVisibleGeometrySize;
                        }
                        break;
                    case "opaqueRate":
                        reader.Read();
                        int opaqueRate = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out opaqueRate))
                        {
                            ugcThemeLayer.OpaqueRate = opaqueRate;
                        }
                        break;
                    case "symbolScalable":
                        reader.Read();
                        bool symbolScalable = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out symbolScalable))
                        {
                            ugcThemeLayer.SymbolScalable = symbolScalable;
                        }
                        break;
                    case "symbolScale":
                        reader.Read();
                        double symbolScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out symbolScale))
                        {
                            ugcThemeLayer.SymbolScale = symbolScale;
                        }
                        break;
                    #endregion

                    #region UGCLayer属性读取
                    case "datasetInfo":
                        reader.Read();
                        ugcThemeLayer.DatasetInfo = serializer.Deserialize<DatasetInfo>(reader);
                        break;
                    case "displayFilter":
                        reader.Read();
                        ugcThemeLayer.DisplayFilter = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "joinItems":
                        reader.Read();
                        ugcThemeLayer.JoinItems = serializer.Deserialize<JoinItem[]>(reader);
                        break;
                    case "representationField":
                        reader.Read();
                        ugcThemeLayer.RepresentationField = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "ugcLayerType":
                        reader.Read();
                        if (reader.Value != null)
                        {
                            UGCLayerType layerType = (UGCLayerType)Enum.Parse(typeof(UGCLayerType), reader.Value.ToString(), false);
                            ugcThemeLayer.UgcLayerType = layerType;
                        }
                        break;
                    #endregion

                    case "themeElementPosition":
                        reader.Read();
                        ugcThemeLayer.ThemeElementPosition = serializer.Deserialize<Dictionary<int, Point2D>>(reader);
                        break;
                    case "theme":
                        reader.Read();
                        Dictionary<string, object> themeItems = serializer.Deserialize<Dictionary<string, object>>(reader);
                        if (themeItems != null && themeItems.Count > 0)
                        {
                            if (themeItems["type"] != null)
                            {
                                ThemeType themeType = (ThemeType)Enum.Parse(typeof(ThemeType), themeItems["type"].ToString(), false);
                                switch (themeType)
                                {
                                    case ThemeType.UNIQUE:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeUnique>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.RANGE:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeRange>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.LABEL:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeLabel>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.GRIDUNIQUE:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeGridUnique>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.GRIDRANGE:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeGridRange>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.GRAPH:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeGraph>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.GRADUATEDSYMBOL:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeGraduatedSymbol>(JsonConvert.SerializeObject(themeItems));
                                        break;
                                    case ThemeType.DOTDENSITY:
                                        ugcThemeLayer.Theme = JsonConvert.DeserializeObject<ThemeDotDensity>(JsonConvert.SerializeObject(themeItems));
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
            return ugcThemeLayer;
            //throw new NotImplementedException();
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

#if !WINDOWS_PHONE
    internal class UGCMapLayerConverter : JsonConverter
#else
    public class UGCMapLayerConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(UGCMapLayer) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            UGCMapLayer ugcMapLayer = new UGCMapLayer();
            reader.Read();
            while (reader.TokenType == JsonToken.PropertyName)
            {
                string propertyName = reader.Value.ToString();
                switch (propertyName)
                {
                    #region Layer属性读取
                    case "bounds":
                        reader.Read();
                        ugcMapLayer.Bounds = serializer.Deserialize<Rectangle2D>(reader);
                        break;
                    case "caption":
                        reader.Read();
                        ugcMapLayer.Caption = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "description":
                        reader.Read();
                        ugcMapLayer.Description = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "name":
                        reader.Read();
                        ugcMapLayer.Name = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "queryable":
                        reader.Read();
                        bool queryable = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out queryable))
                        {
                            ugcMapLayer.Queryable = queryable;
                        }
                        break;
                    case "type":
                        reader.Read();
                        ugcMapLayer.Type = LayerType.UGC;
                        break;
                    case "visible":
                        bool visible = false;
                        reader.Read();
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out visible))
                        {
                            ugcMapLayer.Visible = visible;
                        }
                        break;
                    case "subLayers":
                        reader.Read();
                        ugcMapLayer.SubLayers = new LayerCollection();
                        Dictionary<string, object> ugcMapLayersMap = serializer.Deserialize<Dictionary<string, object>>(reader);
                        if (ugcMapLayersMap == null || !ugcMapLayersMap.ContainsKey("layers")) break;
                        List<Dictionary<string, object>> ugcMapLayersSubLayers = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ugcMapLayersMap["layers"].ToString());
                        for (int j = 0; j < ugcMapLayersSubLayers.Count; j++)
                        {
                            Dictionary<string, object> layerItems = ugcMapLayersSubLayers[j];
                            if (layerItems != null && layerItems.Count > 0)
                            {
                                if (layerItems["ugcLayerType"] != null)
                                {
                                    UGCLayerType ugcLayerType = (UGCLayerType)Enum.Parse(typeof(UGCLayerType), layerItems["ugcLayerType"].ToString(), false);
                                    switch (ugcLayerType)
                                    {
                                        case UGCLayerType.GRID:
                                            ugcMapLayer.SubLayers.Add(JsonConvert.DeserializeObject<UGCGridLayer>(JsonConvert.SerializeObject(layerItems)));
                                            break;
                                        case UGCLayerType.IMAGE:
                                            ugcMapLayer.SubLayers.Add(JsonConvert.DeserializeObject<UGCImageLayer>(JsonConvert.SerializeObject(layerItems)));
                                            break;
                                        case UGCLayerType.THEME:
                                            ugcMapLayer.SubLayers.Add(JsonConvert.DeserializeObject<UGCThemeLayer>(JsonConvert.SerializeObject(layerItems)));
                                            break;
                                        case UGCLayerType.VECTOR:
                                            ugcMapLayer.SubLayers.Add(JsonConvert.DeserializeObject<UGCVectorLayer>(JsonConvert.SerializeObject(layerItems)));
                                            break;
                                        case UGCLayerType.WFS:
                                            ugcMapLayer.SubLayers.Add(JsonConvert.DeserializeObject<WFSLayer>(JsonConvert.SerializeObject(layerItems)));
                                            break;
                                        case UGCLayerType.WMS:
                                            ugcMapLayer.SubLayers.Add(JsonConvert.DeserializeObject<WMSLayer>(JsonConvert.SerializeObject(layerItems)));
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    #endregion

                    case "completeLineSymbolDisplayed":
                        reader.Read();
                        bool completeLineSymbolDisplayed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out completeLineSymbolDisplayed))
                        {
                            ugcMapLayer.CompleteLineSymbolDisplayed = completeLineSymbolDisplayed;
                        }
                        break;
                    case "maxScale":
                        reader.Read();
                        double maxScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out maxScale))
                        {
                            ugcMapLayer.MaxScale = maxScale;
                        }
                        break;
                    case "minScale":
                        reader.Read();
                        double minScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minScale))
                        {
                            ugcMapLayer.MaxScale = minScale;
                        }
                        break;
                    case "minVisibleGeometrySize":
                        reader.Read();
                        double minVisibleGeometrySize = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out minVisibleGeometrySize))
                        {
                            ugcMapLayer.MinVisibleGeometrySize = minVisibleGeometrySize;
                        }
                        break;
                    case "opaqueRate":
                        reader.Read();
                        int opaqueRate = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out opaqueRate))
                        {
                            ugcMapLayer.OpaqueRate = opaqueRate;
                        }
                        break;
                    case "symbolScalable":
                        reader.Read();
                        bool symbolScalable = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out symbolScalable))
                        {
                            ugcMapLayer.SymbolScalable = symbolScalable;
                        }
                        break;
                    case "symbolScale":
                        reader.Read();
                        double symbolScale = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out symbolScale))
                        {
                            ugcMapLayer.SymbolScale = symbolScale;
                        }
                        break;

                    default:
                        reader.Skip();
                        break;
                }

                reader.Read();
            }
            return ugcMapLayer;
            //throw new NotImplementedException();
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
