using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 投影坐标系类。
    /// </summary>
    /// <remarks>
    /// <para>
    /// 设置投影坐标系时，需按照PrjCoordSys中的字段结构来构建，同时也支持通过只设置EpsgCode属性值的方式传入坐标参考系，用来对请求地图。如下图所示，左图是投影前效果，右图为投影后效果。
    /// </para>
    /// <para>
    /// <img src="../../../../CHM/interfacesimges/PrjCoordSys/Unprj.png" alt="投影前效果"></img>        
    /// <img src="../../../../CHM/interfacesimges/PrjCoordSys/prjCpprdsys.png" alt="投影后效果"></img>
    /// </para>    
    /// </remarks>
    /// <example>
    /// 以下示例演示如何通过EpsgCode属性值的设置获取动态投影的地图。
    /// <code>
    /// Map map = new Map("http://localhost:8090/iserver/services/map-world");
    /// MapParameter mapParameter = new MapParameter();
    /// mapParameter.PrjCoordSys = new PrjCoordSys();
    /// mapParameter.PrjCoordSys.EpsgCode = 3857; 
    /// mapParameter.Center = new Point2D(0, 0);
    /// mapParameter.Scale = 0.0000000013138464;
    /// mapParameter.Viewer = new Utility.Rectangle(0, 0, 256, 256);
    /// mapParameter.RectifyType = RectifyType.BYCENTERANDMAPSCALE;
    /// mapParameter.CacheEnabled = false;
    /// ImageOutputOption option = new ImageOutputOption();
    /// option.ImageOutputFormat = ImageOutputFormat.PNG;
    /// option.ImageReturnType = ImageReturnType.URL;
    /// MapImage image = map.GetMapImage("World", mapParameter, option);
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class PrjCoordSys
#else
    [Serializable]
    public sealed class PrjCoordSys : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public PrjCoordSys()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="prjCoordSys">投影坐标系对象。</param>
        /// <exception cref="ArgumentNullException">投影坐标系对象为 Null 时抛出异常。</exception>
        public PrjCoordSys(PrjCoordSys prjCoordSys)
        {
            if (prjCoordSys == null) throw new ArgumentNullException();
            if (prjCoordSys.CoordSystem != null)
                this.CoordSystem = new CoordSys(prjCoordSys.CoordSystem);
            this.CoordUnit = prjCoordSys.CoordUnit;
            this.DistanceUnit = prjCoordSys.DistanceUnit;
            this.EpsgCode = prjCoordSys.EpsgCode;
            this.Name = prjCoordSys.Name;
            if (prjCoordSys.Projection != null)
                this.Projection = new Projection(prjCoordSys.Projection);
            if (prjCoordSys.ProjectionParam != null)
                this.ProjectionParam = new PrjParameter(prjCoordSys.ProjectionParam);
            this.Type = prjCoordSys.Type;
        }
        ///<summary>
        ///投影坐标系的地理坐标系统对象。
        /// </summary>
        [JsonProperty("coordSystem", NullValueHandling = NullValueHandling.Ignore)]
        public CoordSys CoordSystem { get; set; }

        /// <summary>
        /// 投影系统坐标单位。
        /// </summary>
        [JsonProperty("coordUnit")]
        public Unit CoordUnit { get; set; }

        /// <summary>
        /// 距离（长度）单位。
        /// </summary>
        [JsonProperty("distanceUnit")]
        public Unit DistanceUnit { get; set; }

        /// <summary>
        /// 投影坐标系对应的 EPSG Code。
        /// </summary>
        [JsonProperty("epsgCode")]
        public int EpsgCode { get; set; }

        /// <summary>
        ///  投影坐标系对象的名称。
        /// </summary>
        [JsonProperty("name")]
        public String Name { get; set; }

        /// <summary>
        /// 投影坐标系统的投影方式。
        /// </summary>
        [JsonProperty("projection", NullValueHandling = NullValueHandling.Ignore)]
        public Projection Projection { get; set; }

        /// <summary>
        /// 投影坐标系统对象的投影参数。
        /// </summary>
        [JsonProperty("projectionParam", NullValueHandling = NullValueHandling.Ignore)]
        public PrjParameter ProjectionParam { get; set; }

        /// <summary>
        /// 投影坐标系类型。
        /// </summary>
        [JsonProperty("type")]
        public PrjCoordSysType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private PrjCoordSys(SerializationInfo info, StreamingContext context)
        {
            this.CoordSystem = (CoordSys)info.GetValue("CoordSystem", typeof(CoordSys));
            this.CoordUnit = (Unit)info.GetValue("CoordUnit", typeof(Unit));
            this.DistanceUnit = (Unit)info.GetValue("DistanceUnit", typeof(Unit));
            this.EpsgCode = info.GetInt32("EpsgCode");
            this.Name = info.GetString("Name");
            this.Projection = (Projection)info.GetValue("Projection", typeof(Projection));
            this.ProjectionParam = (PrjParameter)info.GetValue("ProjectionParam", typeof(PrjParameter));
            this.Type = (PrjCoordSysType)info.GetValue("Type", typeof(PrjCoordSysType));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CoordSystem", this.CoordSystem);
            info.AddValue("CoordUnit", this.CoordUnit);
            info.AddValue("DistanceUnit", this.DistanceUnit);
            info.AddValue("EpsgCode", this.EpsgCode);
            info.AddValue("Name", this.Name);
            info.AddValue("Projection", this.Projection);
            info.AddValue("ProjectionParam", this.ProjectionParam);
            info.AddValue("Type", this.Type);
        }
        #endregion
#endif
    }
}
