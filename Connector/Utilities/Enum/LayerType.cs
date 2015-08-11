using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>图层类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LayerType
    {   
        /// <summary>
        /// 自定义图层。
        /// </summary>
        CUSTOM,

        /// <summary>
        /// SuperMap UGC 类型图层。如矢量图层、栅格(Grid)图层、影像图层。
        /// </summary>
        UGC,

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
