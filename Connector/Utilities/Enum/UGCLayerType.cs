using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>UGC 图层类型枚举类。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UGCLayerType
    {
        /// <summary>
        /// 矢量图层。
        /// </summary>
        VECTOR,

        /// <summary>
        /// 栅格图层。
        /// </summary>
        GRID,

        /// <summary>
        /// 影像图层。
        /// </summary>
        IMAGE,

        /// <summary>
        /// 专题图层。
        /// </summary>
        THEME,

        /// <summary>
        /// WFS 图层。
        /// </summary>
        WFS,

        /// <summary>
        /// WMS 图层。
        /// </summary>
        WMS
    }
}
