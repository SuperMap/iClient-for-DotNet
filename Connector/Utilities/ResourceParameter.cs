using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 资源图片参数。
    /// 该类用来描述资源图片的信息，比如资源图片的高度、宽度、资源图片的风格等。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class ResourceParameter
#else
    [Serializable]
    public class ResourceParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ResourceParameter()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="resourceParameter"></param>
        public ResourceParameter(ResourceParameter resourceParameter)
        {
            if (resourceParameter == null) throw new ArgumentNullException();
            this.Width = resourceParameter.Width;
            this.Height = resourceParameter.Height;
            this.Type = resourceParameter.Type;
            //if (resourceParameter.ForeColor != null)
            //    this.ForeColor = new Color(resourceParameter.ForeColor);
            //if (resourceParameter.BackColor != null)
            //    this.BackColor = new Color(resourceParameter.BackColor);
            if (resourceParameter.Style != null)
                this.Style = new Style(resourceParameter.Style);
        }

        private int _height = 64;
        /// <summary>
        ///资源图片的高度。
        /// </summary>
        [JsonProperty("height")]
        public int Height
        {
            get { return this._height; }
            set { this._height = value; }
        }

        private Style _style = new Style();
        /// <summary>
        /// 资源图片的风格。
        /// </summary>
        [JsonProperty("style")]
        public Style Style
        {
            get { return this._style; }
            set { this._style = value; }
        }

        /// <summary>
        ///  资源风格图片的类型。
        /// </summary>
        [JsonProperty("type")]
        public ResourceType Type { get; set; }

        private int _width = 64;
        /// <summary>
        ///  资源图片的宽度。
        /// </summary>
        [JsonProperty("width")]
        public int Width
        {
            get { return this._width; }
            set { this._width = value; }
        }

        ///// <summary>
        ///// 地图符号的前景色。
        ///// </summary>
        //[JsonProperty("foreColor")]
        //public Color ForeColor { get; set; }

        ///// <summary>
        ///// 地图符号的背景色。
        ///// </summary>
        //[JsonProperty("backColor")]
        //public Color BackColor { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private ResourceParameter(SerializationInfo info, StreamingContext context)
        {
            this.Style = (Style)info.GetValue("Style", typeof(Style));
            //this.BackColor = (Color)info.GetValue("BackColor", typeof(Color));
            //this.ForeColor = (Color)info.GetValue("ForeColor", typeof(Color));
            this.Width = info.GetInt32("Width");
            this.Height = info.GetInt32("Height");
            this.Type = (ResourceType)info.GetValue("Type", typeof(ResourceType));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Style", this.Type);
            //info.AddValue("BackColor", this.BackColor);
            //info.AddValue("ForeColor", this.ForeColor);
            info.AddValue("Width", this.Width);
            info.AddValue("Height", this.Height);
            info.AddValue("Type", this.Type);
        }
        #endregion
#endif
    }
}
