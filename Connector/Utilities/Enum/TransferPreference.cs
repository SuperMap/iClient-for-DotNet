using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 交通换乘时乘车偏好枚举。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferPreference
    {
        /// <summary>
        /// 公交汽车优先。
        /// </summary>
        BUS,
        /// <summary>
        /// 不乘地铁。
        /// </summary>
        NO_SUBWAY,
        /// <summary>
        /// 无乘车偏好。
        /// </summary>
        NONE,
        /// <summary>
        /// 地铁优先。
        /// </summary>
        SUBWAY
    }
}
