using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
#if !WINDOWS_PHONE
    internal class ThemeConverter : CustomCreationConverter<Theme>
#else
    public class ThemeConverter : CustomCreationConverter<Theme>
#endif
    {
        public override Theme Create(Type objectType)
        {
            if (typeof(ThemeUnique) == objectType)
            {
                return new ThemeUnique();
            }
            else if (typeof(ThemeGraph) == objectType)
            {
                return new ThemeGraph();
            }
            else if (typeof(ThemeDotDensity) == objectType)
            {
                return new ThemeDotDensity();
            }
            else if (typeof(ThemeRange) == objectType)
            {
                return new ThemeRange();
            }
            else if (typeof(ThemeGridRange) == objectType)
            {
                return new ThemeGridRange();
            }
            else if (typeof(ThemeGraduatedSymbol) == objectType)
            {
                return new ThemeGraduatedSymbol();
            }
            else if (typeof(ThemeGridUnique) == objectType)
            {
                return new ThemeGridUnique();
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
    internal class ThemeLabelConverter : JsonConverter
#else
    public class ThemeLabelConverter : JsonConverter
#endif
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ThemeLabel) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ThemeLabel themeLabel = new ThemeLabel();

            reader.Read();
            while (reader.TokenType == JsonToken.PropertyName)
            {
                string propertyName = reader.Value.ToString();
                switch (propertyName)
                {
                    case "alongLine":
                        bool alongLine = false;
                        reader.Read();
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out alongLine))
                        {
                            themeLabel.AlongLine = alongLine;
                        }
                        break;
                    case "alongLineDirection":
                        reader.Read();
                        AlongLineDirection alongLineDirection = AlongLineDirection.ALONG_LINE_NORMAL;
                        if (reader.Value != null)
                        {
                            alongLineDirection = (AlongLineDirection)Enum.Parse(typeof(AlongLineDirection), reader.Value.ToString(), false);
                            themeLabel.AlongLineDirection = alongLineDirection;
                        }
                        break;
                    case "angleFixed":
                        reader.Read();
                        bool angleFixed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out angleFixed))
                        {
                            themeLabel.AngleFixed = angleFixed;
                        }
                        break;
                    case "backStyle":
                        reader.Read();
                        themeLabel.BackStyle = serializer.Deserialize<Style>(reader);
                        break;
                    case "flowEnabled":
                        reader.Read();
                        bool flowEnabled = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out flowEnabled))
                        {
                            themeLabel.FlowEnabled = flowEnabled;
                        }
                        break;
                    case "items":
                        reader.Read();
                        themeLabel.Items = serializer.Deserialize<ThemeLabelItem[]>(reader);
                        break;
                    case "labelBackShape":
                        reader.Read();
                        LabelBackShape labelBackShape = LabelBackShape.NONE;
                        if (reader.Value != null)
                        {
                            labelBackShape = (LabelBackShape)Enum.Parse(typeof(LabelBackShape), reader.Value.ToString(), false);
                            themeLabel.LabelBackShape = labelBackShape;
                        }
                        break;
                    case "labelExpression":
                        reader.Read();
                        themeLabel.LabelExpression = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "labelOverLengthMode":
                        reader.Read();
                        LabelOverLengthMode labelOverLengthMode = LabelOverLengthMode.NONE;
                        if (reader.Value != null)
                        {
                            labelOverLengthMode = (LabelOverLengthMode)Enum.Parse(typeof(LabelOverLengthMode), reader.Value.ToString(), false);
                            themeLabel.LabelOverLengthMode = labelOverLengthMode;
                        }
                        break;
                    case "labelRepeatInterval":
                        reader.Read();
                        double labelRepeatInterval = 0.0;
                        if (reader.Value != null && double.TryParse(reader.Value.ToString(), out labelRepeatInterval))
                        {
                            themeLabel.LabelRepeatInterval = labelRepeatInterval;
                        }
                        break;
                    case "leaderLineDisplayed":
                        reader.Read();
                        bool leaderLineDisplayed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out leaderLineDisplayed))
                        {
                            themeLabel.LeaderLineDisplayed = leaderLineDisplayed;
                        }
                        break;
                    case "leaderLineStyle":
                        reader.Read();
                        themeLabel.LeaderLineStyle = serializer.Deserialize<Style>(reader);
                        break;
                    case "matrixCells":
                        reader.Read();

                        break;
                    case "maxLabelLength":
                        reader.Read();
                        int maxLabelLength = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out maxLabelLength))
                        {
                            themeLabel.MaxLabelLength = maxLabelLength;
                        }
                        break;
                    case "maxTextHeight":
                        reader.Read();
                        int maxTextHeight = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out maxTextHeight))
                        {
                            themeLabel.MaxTextHeight = maxTextHeight;
                        }
                        break;
                    case "maxTextWidth":
                        reader.Read();
                        int maxTextWidth = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out maxTextWidth))
                        {
                            themeLabel.MaxTextWidth = maxTextWidth;
                        }
                        break;
                    case "minTextHeight":
                        reader.Read();
                        int minTextHeight = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out minTextHeight))
                        {
                            themeLabel.MinTextHeight = minTextHeight;
                        }
                        break;
                    case "minTextWidth":
                        reader.Read();
                        int minTextWidth = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out minTextWidth))
                        {
                            themeLabel.MinTextWidth = minTextWidth;
                        }
                        break;
                    case "numericPrecision":
                        reader.Read();
                        int numericPrecision = 0;
                        if (reader.Value != null && int.TryParse(reader.Value.ToString(), out numericPrecision))
                        {
                            themeLabel.NumericPrecision = numericPrecision;
                        }
                        break;
                    case "offsetFixed":
                        reader.Read();
                        bool offsetFixed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out offsetFixed))
                        {
                            themeLabel.OffsetFixed = offsetFixed;
                        }
                        break;
                    case "offsetX":
                        reader.Read();
                        themeLabel.OffsetX = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "offsetY":
                        reader.Read();
                        themeLabel.OffsetY = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "overlapAvoided":
                        reader.Read();
                        bool overlapAvoided = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out overlapAvoided))
                        {
                            themeLabel.OverlapAvoided = overlapAvoided;
                        }
                        break;
                    case "rangeExpression":
                        reader.Read();
                        themeLabel.RangeExpression = reader.Value != null ? reader.Value.ToString() : string.Empty;
                        break;
                    case "repeatedLabelAvoided":
                        reader.Read();
                        bool repeatedLabelAvoided = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out repeatedLabelAvoided))
                        {
                            themeLabel.RepeatedLabelAvoided = repeatedLabelAvoided;
                        }
                        break;
                    case "repeatIntervalFixed":
                        reader.Read();
                        bool repeatIntervalFixed = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out repeatIntervalFixed))
                        {
                            themeLabel.RepeatIntervalFixed = repeatIntervalFixed;
                        }
                        break;
                    case "smallGeometryLabeled":
                        reader.Read();
                        bool smallGeometryLabeled = false;
                        if (reader.Value != null && bool.TryParse(reader.Value.ToString(), out smallGeometryLabeled))
                        {
                            themeLabel.SmallGeometryLabeled = smallGeometryLabeled;
                        }
                        break;
                    case "uniformMixedStyle":
                        reader.Read();
                        themeLabel.UniformMixedStyle = serializer.Deserialize<LabelMixedTextStyle>(reader);
                        break;
                    case "uniformStyle":
                        reader.Read();
                        themeLabel.UniformStyle = serializer.Deserialize<TextStyle>(reader);
                        break;
                    #region Theme属性
                    case "type":
                        reader.Read();
                        themeLabel.Type = ThemeType.LABEL;
                        break;
                    case "memoryData":
                        reader.Read();
                        themeLabel.MemoryData = serializer.Deserialize<Dictionary<string, string>>(reader);
                        break;
                    #endregion
                    default:
                        reader.Skip();
                        break;
                }

                reader.Read();
            }
            return themeLabel;
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
