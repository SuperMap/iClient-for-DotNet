using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 文本风格类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TextStyle
#else
    [Serializable]
    public class TextStyle : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public TextStyle()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="textStyle">TextStyle对象实例。</param>
        public TextStyle(TextStyle textStyle)
        {
            if (textStyle == null) throw new ArgumentNullException();
            this.Align = textStyle.Align;
            if (textStyle.BackColor != null)
                this.BackColor = new Color(textStyle.BackColor);
            this.BackOpaque = textStyle.BackOpaque;
            this.Bold = textStyle.Bold;
            this.FontHeight = textStyle.FontHeight;
            this.FontName = textStyle.FontName;
            this.FontScale = textStyle.FontScale;
            this.FontWeight = textStyle.FontWeight;
            this.FontWidth = textStyle.FontWidth;
            if (textStyle.ForeColor != null)
                this.ForeColor = new Color(textStyle.ForeColor);
            this.Italic = textStyle.Italic;
            this.ItalicAngle = textStyle.ItalicAngle;
            this.OpaqueRate = textStyle.OpaqueRate;
            this.Outline = textStyle.Outline;
            this.Rotation = textStyle.Rotation;
            this.Shadow = textStyle.Shadow;
            this.SizeFixed = textStyle.SizeFixed;
            this.Strikeout = textStyle.Strikeout;
            this.Underline = textStyle.Underline;
        }

        /// <summary>
        /// 文本的对齐方式。
        /// </summary>
        [JsonProperty("align")]
        public TextAlignment Align { get; set; }

        /// <summary>
        /// 文本的背景色。
        /// </summary>
        [JsonProperty("backColor")]
        public Color BackColor { get; set; }

        /// <summary>
        ///  文本背景是否不透明，true 表示文本背景不透明。
        /// </summary>
        [JsonProperty("backOpaque")]
        public bool BackOpaque { get; set; }

        /// <summary>
        /// 文本是否为粗体字，true 表示为粗体。
        /// </summary>
        [JsonProperty("bold")]
        public bool Bold { get; set; }

        /// <summary>
        /// 文本字体的高度，默认值为6，单位与<see cref="SizeFixed"/>有关。当<see cref="SizeFixed"/>为False时，即非固定文本大小时使用地图坐标单位，如地理坐标系下的地图中单位为度；当<see cref="SizeFixed"/>为True时，单位为毫米（mm）。
        /// </summary>
        [JsonProperty("fontHeight")]
        public double FontHeight { get; set; }

        /// <summary>
        ///  文本字体的名称。
        /// </summary>
        [JsonProperty("fontName")]
        public string FontName { get; set; }

        /// <summary>
        ///    文本字体的缩放比例。
        /// </summary>
        [JsonProperty("fontScale")]
        public double FontScale { get; set; }

        /// <summary>
        ///  文本字体的磅数，表示粗体的具体数值。
        /// </summary>
        [JsonProperty("fontWeight")]
        public int FontWeight { get; set; }

        /// <summary>
        /// 文本字体的宽度。
        /// </summary>
        [JsonProperty("fontWidth")]
        public double FontWidth { get; set; }

        /// <summary>
        ///  文本的前景色。
        /// </summary>
        [JsonProperty("foreColor")]
        public Color ForeColor { get; set; }

        /// <summary>
        /// 文本是否采用斜体，true 表示采用斜体。
        /// </summary>
        [JsonProperty("italic")]
        public bool Italic { get; set; }

        /// <summary>
        /// 字体倾斜角度，正负度之间，以度为单位，精确到0.1度。
        /// </summary>
        [JsonProperty("italicAngle")]
        public double ItalicAngle { get; set; }

        /// <summary>
        /// 注记文字的不透明度，只对三维字体有效。 
        /// </summary>
        [JsonProperty("opaqueRate")]
        public int OpaqueRate { get; set; }

        /// <summary>
        ///  是否以轮廓的方式来显示文本的背景。
        /// </summary>
        [JsonProperty("outline")]
        public bool Outline { get; set; }

        /// <summary>
        /// 文本旋转的角度。
        /// </summary>
        [JsonProperty("rotation")]
        public double Rotation { get; set; }

        /// <summary>
        ///  文本是否有阴影。
        /// </summary>
        [JsonProperty("shadow")]
        public bool Shadow { get; set; }

        /// <summary>
        ///   文本大小是否固定。
        /// </summary>
        [JsonProperty("sizeFixed")]
        public bool SizeFixed { get; set; }

        /// <summary>
        ///  文本字体是否加删除线。
        /// </summary>
        [JsonProperty("strikeout")]
        public bool Strikeout { get; set; }

        /// <summary>
        /// 文本字体是否加下划线。
        /// </summary>
        [JsonProperty("underline")]
        public bool Underline { get; set; }
        
#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private TextStyle(SerializationInfo info, StreamingContext context)
        {
            this.Align = (TextAlignment)info.GetValue("Align", typeof(TextAlignment));
            this.BackColor = (Color)info.GetValue("BackColor", typeof(Color));
            this.BackOpaque = info.GetBoolean("BackOpaque");
            this.Bold = info.GetBoolean("Bold");
            this.FontHeight = info.GetDouble("FontHeight");
            this.FontName = info.GetString("FontName");
            this.FontScale = info.GetDouble("FontScale");
            this.FontWeight = info.GetInt32("FontWeight");
            this.FontWidth = info.GetDouble("FontWidth");
            this.ForeColor = (Color)info.GetValue("ForeColor", typeof(Color));
            this.Italic = info.GetBoolean("Italic");
            this.ItalicAngle = info.GetDouble("ItalicAngle");
            this.OpaqueRate = info.GetInt32("OpaqueRate");
            this.Outline = info.GetBoolean("Outline");
            this.Rotation = info.GetDouble("Rotation");
            this.Shadow = info.GetBoolean("Shadow");
            this.SizeFixed = info.GetBoolean("SizeFixed");
            this.Strikeout = info.GetBoolean("Strikeout");
            this.Underline = info.GetBoolean("Underline");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Align", this.Align);
            info.AddValue("BackColor", this.BackColor);
            info.AddValue("BackOpaque", this.BackOpaque);
            info.AddValue("Bold", this.Bold);
            info.AddValue("FontHeight", this.FontHeight);
            info.AddValue("FontName", this.FontName);
            info.AddValue("FontScale", this.FontScale);
            info.AddValue("FontWeight", this.FontWeight);
            info.AddValue("FontWidth", this.FontWidth);
            info.AddValue("ForeColor", this.ForeColor);
            info.AddValue("Italic", this.Italic);
            info.AddValue("ItalicAngle", this.ItalicAngle);
            info.AddValue("OpaqueRate", this.OpaqueRate);
            info.AddValue("Outline", this.Outline);
            info.AddValue("Rotation", this.Rotation);
            info.AddValue("Shadow", this.Shadow);
            info.AddValue("SizeFixed", this.SizeFixed);
            info.AddValue("Strikeout", this.Strikeout);
            info.AddValue("Underline", this.Underline);
        }
        #endregion
#endif
    }
}
