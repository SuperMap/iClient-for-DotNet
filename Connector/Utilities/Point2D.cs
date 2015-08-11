using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Globalization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 二维地理坐标点。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class Point2D
#else
    [Serializable]
    public class Point2D : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数.
        /// </summary>
        public Point2D()
        { }

        /// <summary>
        /// 带参构造函数。
        /// </summary>
        /// <param name="x">地理 x 坐标。</param>
        /// <param name="y">地理 y 坐标。</param>
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="point2D">Point2D 对象。</param>
        /// <exception cref="ArgumentNullException">当 Point2D 对象为 Null 时抛出异常。</exception>
        public Point2D(Point2D point2D)
        {
            if (point2D == null) throw new ArgumentNullException();
            this.X = point2D.X;
            this.Y = point2D.Y;
        }
        ///<summary>
        ///该 Point2D 的 X 坐标。
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// 该 Point2D 的 Y 坐标。
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <summary>
        /// 比较两个<see cref="Point2D"/>对象是否是同一个点。
        /// </summary>
        /// <param name="obj">要比较的<see cref="Point2D"/>对象。</param>
        /// <returns>如果 obj 参数是 Point2D 对象，且它的 X、Y 属性与此 Point2D 的相应属性相等，则此方法返回 true；否则返回 false。</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Point2D)) return false;
            Point2D point2D = obj as Point2D;
            if (this.X == point2D.X && this.Y == point2D.Y) return true;
            else return false;
        }

        /// <summary>
        /// 返回该实例的哈希代码。
        /// </summary>
        /// <returns>哈希代码值。</returns>
        public override int GetHashCode()
        {
            string hashText = this.X + "," + this.Y;
            return hashText.GetHashCode();
        }

        /// <summary>
        /// 获取此实例的 String 表示形式。
        /// </summary>
        /// <returns>此对象的字符串表示形式。</returns>
        public override string ToString()
        {
            return this.X.ToString("R", NumberFormatInfo.InvariantInfo) + "," + this.Y.ToString("R", NumberFormatInfo.InvariantInfo);
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 序列化的构造函数。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected Point2D(SerializationInfo info, StreamingContext context)
        {
            this.X = info.GetDouble("X");
            this.Y = info.GetDouble("Y");
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
        }
        #endregion
#endif
    }

    /// <summary>
    /// <para>路由点类。</para>
    /// <para>路由点是指具有线性度量值(Measure)的二维地理坐标点。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class PointWithMeasure : Point2D
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public PointWithMeasure()
            : base()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="pointWithMeasure"></param>
        public PointWithMeasure(PointWithMeasure pointWithMeasure)
            : base(pointWithMeasure)
        {
            if (pointWithMeasure == null) throw new ArgumentException();
            this.Measure = pointWithMeasure.Measure;
        }

        /// <summary>
        /// 度量值，即路由点到起点的距离。
        /// </summary>
        [JsonProperty("measure")]
        public double Measure { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Measure", this.Measure);
            base.GetObjectData(info, context);
        }

        private PointWithMeasure(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Measure = info.GetDouble("Measure");
        }

        #endregion
#endif
    }
}
