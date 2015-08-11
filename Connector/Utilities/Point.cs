using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 像素点坐标对象。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Point
#else
    [Serializable]
    public sealed class Point : ISerializable
#endif
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Point()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="point">Point对象实例。</param>
        public Point(Point point)
        {
            if (point == null) return;
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        /// 构造函数，通过XY坐标点初始化Point对象。
        /// </summary>
        /// <param name="x">x 坐标</param>
        /// <param name="y">y 坐标</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        ///<summary>
        /// x 坐标。
        /// </summary>
        [JsonProperty("x")]
        public int X { get; set; }

        /// <summary>
        ///  y 坐标。
        /// </summary>
        [JsonProperty("y")]
        public int Y { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private Point(SerializationInfo info, StreamingContext context)
        {
            this.X = info.GetInt32("X");
            this.Y = info.GetInt32("Y");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", this.X);
            info.AddValue("Y", this.Y);
        }
        #endregion
#endif
    }

}
