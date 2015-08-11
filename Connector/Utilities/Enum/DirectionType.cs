using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>方向枚举。</para>
    /// <para>在行驶导引子项中使用。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DirectionType
    {
        /// <summary>
        /// 东。
        /// </summary>
        EAST,

        /// <summary>
        /// 结点没有方向。
        /// </summary>
        NONE,

        /// <summary>
        /// 北。
        /// </summary>
        NORTH,

        /// <summary>
        /// 南。
        /// </summary>
        SOURTH,

        /// <summary>
        /// 西。
        /// </summary>
        WEST
    }
}
