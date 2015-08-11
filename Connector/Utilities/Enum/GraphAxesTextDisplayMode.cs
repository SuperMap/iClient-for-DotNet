using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>统计专题图坐标轴文本显示模式。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GraphAxesTextDisplayMode
    {   
        /// <summary>
        /// 没有显示。
        /// </summary>
        NONE,

        /// <summary>
        /// 显示全部文本。
        /// </summary>
        ALL,

        /// <summary>
        /// 显示Y轴的文本。
        /// </summary>
        YAXES
    }
}
