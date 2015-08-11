using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 地理坐标系类型对象。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class CoordSys
#else
    [Serializable]
    public sealed class CoordSys : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public CoordSys()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="coordSys">地图坐标系对象。</param>
        /// <exception cref="ArgumentException">当地图坐标系对象为 Null 时抛出异常。</exception>
        public CoordSys(CoordSys coordSys)
        {
            if (coordSys == null) throw new ArgumentException();
            if (coordSys.Datum != null)
                this.Datum = new Datum(coordSys.Datum);
            this.Name = Datum.Name;
            if (coordSys.PrimeMeridian != null)
                this.PrimeMeridian = new PrimeMeridian(coordSys.PrimeMeridian);
            this.SpatialRefType = coordSys.SpatialRefType;
            this.Type = coordSys.Type;
            this.Unit = coordSys.Unit;
        }
        ///<summary>
        ///投影坐标系所基于的地理坐标系对象。
        ///</summary>
        [JsonProperty("datum", NullValueHandling = NullValueHandling.Ignore)]
        public Datum Datum { get; set; }

        /// <summary>
        /// 投影坐标系统的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        ///<summary>
        ///中央子午线对象。
        ///</summary>
        [JsonProperty("primeMeridian", NullValueHandling = NullValueHandling.Ignore)]
        public PrimeMeridian PrimeMeridian { get; set; }

        ///<summary>
        ///空间参照类型，用以区分平面坐标系、经纬坐标系、投影坐标系。
        ///</summary>
        [JsonProperty("spatialRefType")]
        public SpatialRefType SpatialRefType { get; set; }

        ///<summary>
        ///坐标系的具体类型。
        ///</summary>
        [JsonProperty("type")]
        public CoordSysType Type { get; set; }

        ///<summary>
        ///坐标单位。
        ///</summary>
        [JsonProperty("unit")]
        public Unit Unit { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private CoordSys(SerializationInfo info, StreamingContext context)
        {
            this.Datum = (Datum)info.GetValue("Datum", typeof(Datum));
            this.Name = info.GetString("Name");
            this.PrimeMeridian = (PrimeMeridian)info.GetValue("PrimeMeridian", typeof(PrimeMeridian));
            this.SpatialRefType = (Utility.SpatialRefType)info.GetValue("SpatialRefType", typeof(SpatialRefType));
            this.Type = (CoordSysType)info.GetValue("Type", typeof(CoordSysType));
            this.Unit = (Utility.Unit)info.GetValue("Unit", typeof(Unit));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Datum", this.Datum);
            info.AddValue("Name", this.Name);
            info.AddValue("PrimeMeridian", this.PrimeMeridian);
            info.AddValue("SpatialRefType", this.SpatialRefType);
            info.AddValue("Type", this.Type);
            info.AddValue("Unit", this.Unit);
        }
        #endregion
#endif
    }
}
