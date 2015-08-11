
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>校验方式枚举类。</para>
    /// <para>调整中心点、比例尺、viewBounds 与 viewer 相一致。
    /// 默认情况下，即该参数为 null 的时候，各个参数的优先级：viewer > 比例尺 > 中心点 > viewBounds。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RectifyType
    {
        /// <summary>
        /// 以中心点和比例尺为准。 
        /// </summary>
        BYCENTERANDMAPSCALE,
        /// <summary>
        /// 以视图范围为准。 
        /// </summary>
        BYVIEWBOUNDS
    }
}
