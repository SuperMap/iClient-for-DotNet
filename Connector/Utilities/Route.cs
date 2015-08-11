using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 路由对象。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(RouteConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class Route : Geometry
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Route()
        { }

        /// <summary>
        /// 路由对象的长度，单位与数据集的单位相同。
        /// </summary>
        [JsonProperty("length")]
        public double Length { get; set; }

        /// <summary>
        /// 路由对应的线几何对象。
        /// </summary>
        [JsonProperty("line")]
        public Geometry Line { get; set; }

        /// <summary>
        /// 路由对象Measure值中的最大值。
        /// </summary>
        [JsonProperty("maxM")]
        public double MaxM { get; set; }

        /// <summary>
        /// 路由对象Measure值中的最小值。
        /// </summary>
        [JsonProperty("minM")]
        public double MinM { get; set; }

         ///<summary>
         ///指具有线性度量值的二维地理坐标点。
         ///</summary>
        //[JsonProperty("points")]
        public new PointWithMeasure[] Points { get; set; }

        /// <summary>
        /// 路由对应的面几何对象。
        /// </summary>
        [JsonProperty("region")]
        public Geometry Region { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Length", this.Length);
            info.AddValue("Line", this.Line);
            info.AddValue("MaxM", this.MaxM);
            info.AddValue("MinM", this.MinM);
            info.AddValue("Points", this.Points);
            info.AddValue("Region", this.Region);
            base.GetObjectData(info, context);
        }

        private Route(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Length = info.GetDouble("Length");
            this.Line = (Geometry)info.GetValue("Line", typeof(Geometry));
            this.MaxM = info.GetInt32("MaxM");
            this.MinM = info.GetInt32("MinM");
            this.Points = (PointWithMeasure[])info.GetValue("Points", typeof(PointWithMeasure[]));
            this.Region = (Geometry)info.GetValue("Region", typeof(Geometry));
        }
        #endregion
#endif
    }
}
