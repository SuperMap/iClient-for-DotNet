using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 颜色类。该类用三原色 GRB 表达。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Color
#else
    [Serializable]
    public sealed class Color : ISerializable
#endif
    {
        /// <summary>
        /// 初始化 Color 类的新实例，该实例为空并且具有默认初始容量。
        /// </summary>
        public Color()
        {

        }
#if !WINDOWS_PHONE
        /// <summary>
        /// 初始化 Color 类的新实例，该实例从<see cref="System.Drawing.Color"/>对象中赋值颜色初始值。
        /// </summary>
        /// <param name="color">System.Drawing.Color对象。</param>
        public Color(System.Drawing.Color color)
        {
            if (color == null) return;
            this.Red = color.R;
            this.Green = color.G;
            this.Blue = color.B;
        }
#else
        /// <summary>
        /// 初始化 Color 类的新实例，该实例从<see cref="System.Drawing.Color"/>对象中赋值颜色初始值。
        /// </summary>
        /// <param name="color">System.Drawing.Color对象。</param>
        public Color(Microsoft.Xna.Framework.Color color)
        {
            if (color == null) return;
            this.Red = color.R;
            this.Green = color.G;
            this.Blue = color.B;
        }
#endif
        /// <summary>
        /// 初始化 Color 类的新实例。
        /// </summary>
        /// <param name="color"></param>
        public Color(Color color)
        {
            if (color == null) return;
            this.Red = color.Red;
            this.Green = color.Green;
            this.Blue = color.Blue;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="red">红色分量。</param>
        /// <param name="green"> 绿色分量。</param>
        /// <param name="blue">蓝色分量。</param>
        public Color(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        private int _red = 0;
        ///<summary>
        ///获取或设置 R 值，取值范围0-255。默认值为0。
        ///</summary>
        [JsonProperty("red")]
        public int Red
        {
            get { return this._red; }
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException("Red", "0-255");
                this._red = value;
            }
        }

        private int _green = 0;
        ///<summary>
        ///获取或设置 G 值，取值范围0-255。默认值为0。
        ///</summary>
        [JsonProperty("green")]
        public int Green
        { get { return this._green; }
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException("Green", "0-255");
                this._green = value;
            }
        }

        private int _blue = 0;
        ///<summary>
        ///获取或设置 B 值，取值范围0-255。默认值为0。
        ///</summary>
        [JsonProperty("blue")]
        public int Blue
        {
            get { return this._blue; }
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException("Blue", "0-255");
                this._blue = value;
            }
        }

        /// <summary>
        /// Color 类型转换为包含了颜色 RGB 分量信息的整数。
        /// </summary>
        /// <returns></returns>
        public int ToInt()
        {
            return Red + Green * 256 + Blue * 256 * 256;
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private Color(SerializationInfo info, StreamingContext context)
        {
            Red = info.GetInt16("Red");
            Green = info.GetInt16("Green");
            Blue = info.GetInt16("Blue");
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Red", Red);
            info.AddValue("Green", Green);
            info.AddValue("Blue", Blue);
        }
        #endregion
#endif
    }
}
