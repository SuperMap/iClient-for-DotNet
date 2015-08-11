using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>地图背景格网类型枚举类。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GridType
    {   
        /// <summary>
        /// 十字叉丝。
        /// </summary>
        CROSS,

        /// <summary>
        /// 网格线。
        /// </summary>
        GRID,

        /// <summary>
        /// 点。
        /// </summary>
        POINT
    }
}
