using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>
    /// 数据源信息。
    /// </para>
    /// <para>
    /// 该类主要描述数据源的基本信息。
    /// </para>
    /// <para>
    /// 一个工作空间可以打开多个数据源，不同的数据源通过不同的别名 <see cref="Name"/> 进行标识。
    /// </para>
    /// <para>
    /// 一个数据源对应一种数据引擎。SuperMap 产品中提供了多种数据源类型，分为文件型数据源、数据库型数据源和网络数据源。文件型数据源主要有 SDB、UDB 数据源，数据库型数据源主要有 Oracle、SQL Server 数据源等，网络数据源主要有 OGC 数据源（目前主要包括 WMS、WFS 和 WCS）。访问不同的数据源需要采用不同的引擎（EngineType）。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class DatasourceInfo
#else
    [Serializable]
    public class DatasourceInfo : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public DatasourceInfo()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="dataSourceInfo">DataSourceInfo对象实例。</param>
        /// <exception cref="ArgumentNullException">参数 dataSourceInfo 为空时抛出异常。</exception>
        public DatasourceInfo(DatasourceInfo dataSourceInfo)
        {
            if (dataSourceInfo == null)
            {
                throw new ArgumentNullException("dataSourceInfo");
            }
            this.CoordUnit = dataSourceInfo.CoordUnit;
            this.Description = dataSourceInfo.Description;
            this.DistanceUnit = dataSourceInfo.DistanceUnit;
            this.EngineType = dataSourceInfo.EngineType;
            this.Name = dataSourceInfo.Name;
            if (dataSourceInfo.PrjCoordSys != null)
            {
                this.PrjCoordSys = new PrjCoordSys(dataSourceInfo.PrjCoordSys);
            }
        }

        /// <summary>
        /// 坐标单位。 
        /// </summary>
        [JsonProperty("coordUnit")]
        public Unit CoordUnit { get; set; }

        /// <summary>
        /// 数据源描述。
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 距离单位。 
        /// </summary>
        [JsonProperty("distanceUnit")]
        public Unit DistanceUnit { get; set; }

        /// <summary>
        /// 数据源引擎类型，该字段只读。 
        /// </summary>
        [JsonProperty("engineType")]
        public EngineType EngineType { get; set; }

        /// <summary>
        /// <para>数据源的别名。</para>
        /// <para>别名用于在工作空间中唯一标识数据源，可以通过它访问数据源，该属性为只读属性。 数据源的别名在创建数据源或打开数据源时给定，打开同一个数据源可以使用不同的别名。</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 投影信息。 
        /// </summary>
        [JsonProperty("prjCoordSys")]
        public PrjCoordSys PrjCoordSys { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CoordUnit", this.CoordUnit);
            info.AddValue("Description", this.Description);
            info.AddValue("DistanceUnit", this.DistanceUnit);
            info.AddValue("EngineType", this.EngineType);
            info.AddValue("Name", this.Name);
            info.AddValue("PrjCoordSys", this.PrjCoordSys);
        }

        private DatasourceInfo(SerializationInfo info, StreamingContext context)
        {
            this.CoordUnit = (Unit)info.GetValue("CoordUnit", typeof(Unit));
            this.Description = info.GetString("Description");
            this.DistanceUnit = (Unit)info.GetValue("DistanceUnit", typeof(Unit));
            this.EngineType = (Utility.EngineType)info.GetValue("EngineType", typeof(EngineType));
            this.Name = info.GetString("Name");
            this.PrjCoordSys = (PrjCoordSys)info.GetValue("PrjCoordSys", typeof(PrjCoordSys));
        }
        #endregion
#endif
    }
}
