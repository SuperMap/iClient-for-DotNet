using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 数据查询的模式（获取要素的方式）枚举。
    /// </summary>
    /// <remarks>进行数据查询，获取要素时，需要指定查询的方式，即通过哪种方法来获取要素。</remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GetFeatureMode
    {
        /// <summary>
        /// 通过范围查询来获取要素。 
        /// </summary>
        BOUNDS,

        /// <summary>
        /// 通过范围查询加属性过滤器的模式来获取要素。 
        /// </summary>
        BOUNDS_ATTRIBUTEFILTER,

        /// <summary>
        /// 通过几何对象的缓冲区来获取要素。 
        /// </summary>
        BUFFER,

        /// <summary>
        /// 通过缓冲区加属性过滤器的模式来获取要素。 
        /// </summary>
        BUFFER_ATTRIBUTEFILTER,

        /// <summary>
        /// 通过 ID 来获取要素。 
        /// </summary>
        ID,

        /// <summary>
        /// 通过空间查询模式来获取要素。 
        /// </summary>
        SPATIAL,

        /// <summary>
        /// 通过空间查询加属性过滤器的模式来获取要素。 
        /// </summary>
        SPATIAL_ATTRIBUTEFILTER,

        /// <summary>
        /// 通过 SQL 查询来获取要素。 
        /// </summary>
        SQL
    }
}
