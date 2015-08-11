using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 公交换乘策略枚举。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferTactic
    {
        /// <summary>
        /// 时间短。
        /// </summary>
        LESS_TIME,

        /// <summary>
        /// 少换乘。
        /// </summary>
        LESS_TRANSFER,

        /// <summary>
        /// 少步行。
        /// </summary>
        LESS_WALK,

        /// <summary>
        /// 距离最短。
        /// </summary>
        MIN_DISTANCE
    }
}
