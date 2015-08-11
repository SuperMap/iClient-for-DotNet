using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>空间坐标系类型枚举。</para>
    /// <para>空间坐标系类型，用以区分平面坐标系、经纬坐标系、投影坐标系。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpatialRefType
    {   
        /// <summary>
        /// 经纬坐标系。
        /// </summary>
        SPATIALREF_EARTH_LONGITUDE_LATITUDE,

        /// <summary>
        /// 投影坐标系。
        /// </summary>
        SPATIALREF_EARTH_PROJECTION,

        /// <summary>
        /// 平面坐标系。
        /// </summary>
        SPATIALREF_NONEARTH
    }
}
