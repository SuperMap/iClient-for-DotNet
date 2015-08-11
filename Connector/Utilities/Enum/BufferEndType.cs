using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 缓冲区端点类型枚举。
    /// 用以区分线对象缓冲区分析时的端点是圆头缓冲还是平头缓冲。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BufferEndType
    {
        /// <summary>
        /// 圆头缓冲。
        /// 圆头缓冲区是在生成缓冲区时，在线段的端点处做半圆弧处理。
        /// <para><img src="../../../../CHM/interfacesimges/spatialsnalyst/buffer/round.png"></img></para>
        /// </summary>
        ROUND,
        /// <summary>
        /// 平头缓冲。
        /// 平头缓冲区是在生成缓冲区时，在线段的端点处做圆弧的垂线。
        /// <para><img src="../../../../CHM/interfacesimges/spatialsnalyst/buffer/flat.png"></img></para>
        /// </summary>
        FLAT
    }
}
