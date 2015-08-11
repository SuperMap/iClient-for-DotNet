using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>查询结果选项枚举类。</para>
    /// <para>该类定义查询时返回的结果类型。含只返回属性、只返回几何实体、返回属性和几何实体三种类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QueryOption
    {
        /// <summary>
        /// 属性。
        /// </summary>
        ATTRIBUTE,
        /// <summary>
        /// 属性和几何实体。
        /// </summary>
        ATTRIBUTEANDGEOMETRY,
        /// <summary>
        /// 几何实体。
        /// </summary>
        GEOMETRY
    }
}
