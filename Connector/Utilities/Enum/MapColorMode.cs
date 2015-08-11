using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>地图颜色模式枚举。</para>
    /// <para>图颜色模式是针对地图显示而言，而且只对矢量要素起作用。各颜色模式在转换时，地图的专题风格不会改变，
    /// 而且各种颜色模式的转换是根据地图的专题风格颜色来的。SuperMap 在设置地图风格时提供了5 种颜色模式。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MapColorMode
    {
        /// <summary>
        /// 默认彩色模式，对应32位增强真彩色模式。
        /// </summary>
        DEFAULT,

        /// <summary>黑白反色模式。。</summary>
        BLACK_WHITE_REVERSE,

        /// <summary>
        /// 黑白模式。
        /// </summary>
        BLACKWHITE,

        /// <summary>
        /// 灰度模式。
        /// </summary>
        GRAY,

        /// <summary> 
        /// 黑白反色，其它颜色不变。
        /// </summary>
        ONLY_BLACK_WHITE_REVERSE,
    }
}
