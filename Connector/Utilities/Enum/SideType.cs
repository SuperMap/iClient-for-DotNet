using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 行驶位置枚举。
    /// <para>
    /// 表示行驶在路的左边、右边或者路上的枚举，用于行驶引导子项类（<see cref="PathGuideItem"/>）类中。
    /// </para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SideType
    {
        /// <summary>
        /// 路的左侧。
        /// </summary>
        LEFT,

        /// <summary>
        /// 在路上（中间）。
        /// </summary>
        MIDDLE,

        /// <summary>
        /// 无效值。
        /// </summary>
        NONE,

        /// <summary>
        ///  路的右侧。
        /// </summary>
        RIGHT
    }
}
