using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 风格类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Style
#else
    [Serializable]
    public sealed class Style : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Style()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="style">风格对象。</param>
        /// <exception cref="ArgumentNullException">当风格对象为 Null 时抛出异常。</exception>
        public Style(Style style)
        {
            if (style == null) throw new ArgumentNullException();
            if (style.FillBackColor != null)
                this.FillBackColor = new Color(style.FillBackColor);
            this.FillBackOpaque = style.FillBackOpaque;
            if (style.FillForeColor != null)
                this.FillForeColor = new Color(style.FillBackColor);
            this.FillGradientAngle = style.FillGradientAngle;
            this.FillGradientMode = style.FillGradientMode;
            this.FillGradientOffsetRatioX = style.FillGradientOffsetRatioX;
            this.FillGradientOffsetRatioY = style.FillGradientOffsetRatioY;
            this.FillOpaqueRate = style.FillOpaqueRate;
            this.FillSymbolID = style.FillSymbolID;
            if (style.LineColor != null)
                this.LineColor = new Color(style.LineColor);
            this.LineSymbolID = style.LineSymbolID;
            this.LineWidth = style.LineWidth;
            this.MarkerAngle = style.MarkerAngle;
            this.MarkerSize = style.MarkerSize;
            this.MarkerSymbolID = style.MarkerSymbolID;
        }

        /// <summary>
        /// 填充符号的背景色。
        /// </summary>
        /// <remarks>
        /// 当填充模式为渐变填充时，该颜色为填充终止色。
        /// </remarks>
        [JsonProperty("fillBackColor")]
        public Color FillBackColor { get; set; }

        /// <summary>
        /// 当前填充背景是否不透明。
        /// </summary>
        /// <remarks>
        /// 如果当前填充背景是不透明的，则为 true，否则为 false。默认值为 False，代表透明。
        /// </remarks>
        [JsonProperty("fillBackOpaque")]
        public bool FillBackOpaque { get; set; }

        /// <summary>
        /// 填充符号的前景色。
        /// </summary>
        /// <remarks>
        /// 当填充模式为渐变填充时，该颜色为渐变填充起始色。
        /// </remarks>
        [JsonProperty("fillForeColor")]
        public Color FillForeColor { get; set; }

        /// <summary>
        /// 渐变填充的旋转角度。
        /// </summary>
        [JsonProperty("fillGradientAngle")]
        public double FillGradientAngle { get; set; }

        /// <summary>
        /// 渐变填充风格的渐变类型。
        /// </summary>
        [JsonProperty("fillGradientMode")]
        public FillGradientMode FillGradientMode { get; set; }

        /// <summary>
        /// 变填充中心点相对于填充区域范围中心点的水平偏移百分比。
        /// </summary>
        /// <remarks>
        /// 设填充区域范围中心点的坐标为（x0, y0），填充中心点的坐标为（x, y），填充区域范围的宽度为 a，水平偏移百分比为 dx，则
        /// x=x0 + a*dx/100
        /// 该百分比可以为负，当其为负时，填充中心点相对于填充区域范围中心点向 x 轴负方向偏移。
        /// 该属性仅对辐射渐变、圆锥渐变和四角渐变填充有效，不适用于线性渐变填充。
        /// </remarks>
        [JsonProperty("fillGradientOffsetRatioX")]
        public double FillGradientOffsetRatioX { get; set; }

        /// <summary>
        /// 填充中心点相对于填充区域范围中心点的垂直偏移百分比。
        /// </summary>
        [JsonProperty("fillGradientOffsetRatioY")]
        public double FillGradientOffsetRatioY { get; set; }

        private int _fillOpaqueRate = 100;
        /// <summary>
        /// 填充不透明度，合法值为 0——100 的数值。
        /// </summary>
        /// 其中 0 表示完全透明；100 表示完全不透明。赋值小于 0 时按照 0 处理，大于 100 时按照 100 处理。 默认值为 100，表示完全不透明。
        [JsonProperty("fillOpaqueRate")]
        public int FillOpaqueRate
        {
            get { return this._fillOpaqueRate; }
            set
            {
                if (value < 0) this._fillOpaqueRate = value;
                else if (value >= 0 && value <= 100) this._fillOpaqueRate = value;
                else this._fillOpaqueRate = 100;
            }
        }

        /// <summary>
        ///  填充符号的编码，即在填充库中填充风格的 ID。
        /// </summary>
        /// <remarks>
        /// 此编码用于唯一标识各普通填充风格的填充符号。
        /// </remarks>
        [JsonProperty("fillSymbolID")]
        public int FillSymbolID { get; set; }

        /// <summary>
        /// 边线的颜色。
        /// </summary>
        [JsonProperty("lineColor")]
        public Color LineColor { get; set; }

        private int _lineSymbolID = 0;
        /// <summary>
        ///  线状符号的编码，即线型库中线型的 ID。
        /// </summary>
        /// <remarks>
        /// 此编码用于唯一标识各普通填充风格的填充符号，默认值为0。
        /// </remarks>
        [JsonProperty("lineSymbolID")]
        public int LineSymbolID
        {
            get { return this._lineSymbolID; }
            set { this._lineSymbolID = value; }
        }

        private double _lineWidth = 1.0;
        /// <summary>
        /// 边线宽度。
        /// </summary>
        /// <remarks>
        /// 位为毫米，精度到0.1。默认值为1.0。
        /// </remarks>
        [JsonProperty("lineWidth")]
        public double LineWidth
        {
            get { return this._lineWidth; }
            set { this._lineWidth = Math.Round(value, 1); }
        }

        private double _markerAngle = 0.0;
        /// <summary>
        /// 点状符号的旋转角度。
        /// </summary>
        /// <remarks>
        /// 以度为单位，精确到 0.1 度，逆时针方向为正方向。此角度可以作为普通填充风格中填充符号的旋转角度。默认值为0。
        /// </remarks>
        [JsonProperty("markerAngle")]
        public double MarkerAngle
        {
            get { return this._markerAngle; }
            set { this._markerAngle = Math.Round(value, 1); }
        }


        /// <summary>
        /// 点状符号的大小。
        /// </summary>
        /// <remarks>
        /// 单位为：mm。点状符号的大小跟点的显示大小是两个概念，这里设置的是点状符号的大小。
        /// </remarks>
        [JsonProperty("markerSize")]
        public double MarkerSize { get; set; }

        /// <summary>
        /// 点状符号的编码，即符号库中点风格的 ID。
        /// </summary>
        /// <remarks>
        /// 此编码用于唯一标识各点状符号。
        /// </remarks>
        [JsonProperty("markerSymbolID")]
        public int MarkerSymbolID { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private Style(SerializationInfo info, StreamingContext context)
        {
            this.FillBackColor = (Color)info.GetValue("FillBackColor", typeof(Color));
            this.FillBackOpaque = info.GetBoolean("FillBackOpaque");
            this.FillForeColor = (Color)info.GetValue("FillBackColor", typeof(Color));
            this.FillGradientAngle = info.GetDouble("FillGradientAngle");
            this.FillGradientMode = (FillGradientMode)info.GetValue("FillGradientMode", typeof(FillGradientMode));
            this.FillGradientOffsetRatioX = info.GetDouble("FillGradientOffsetRatioX");
            this.FillGradientOffsetRatioY = info.GetDouble("FillGradientOffsetRatioY");
            this.FillOpaqueRate = info.GetInt32("FillOpaqueRate");
            this.FillSymbolID = info.GetInt32("FillSymbolID");
            this.LineColor = (Color)info.GetValue("LineColor", typeof(Color));
            this.LineSymbolID = info.GetInt32("LineSymbolID");
            this.LineWidth = info.GetDouble("LineWidth");
            this.MarkerAngle = info.GetDouble("MarkerAngle");
            this.MarkerSize = info.GetDouble("MarkerSize");
            this.MarkerSymbolID = info.GetInt32("MarkerSymbolID");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FillBackColor", this.FillBackColor);
            info.AddValue("FillBackOpaque", this.FillBackOpaque);
            info.AddValue("FillForeColor", this.FillForeColor);
            info.AddValue("FillGradientAngle", this.FillGradientAngle);
            info.AddValue("FillGradientMode", this.FillGradientMode);
            info.AddValue("FillGradientOffsetRatioX", this.FillGradientOffsetRatioX);
            info.AddValue("FillGradientOffsetRatioY", this.FillGradientOffsetRatioY);
            info.AddValue("FillOpaqueRate", this.FillOpaqueRate);
            info.AddValue("FillSymbolID", this.FillSymbolID);
            info.AddValue("LineColor", this.LineColor);
            info.AddValue("LineSymbolID", this.LineSymbolID);
            info.AddValue("LineWidth", this.LineWidth);
            info.AddValue("MarkerAngle", this.MarkerAngle);
            info.AddValue("MarkerSize", this.MarkerSize);
            info.AddValue("MarkerSymbolID", this.MarkerSymbolID);
        }
        #endregion
#endif
    }
}
