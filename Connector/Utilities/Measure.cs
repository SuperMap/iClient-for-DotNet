using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 面积量算结果。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class MeasureAreaResult
    {
        ///<summary>
        ///面积量算结果。
        /// </summary>
        [JsonProperty("area")]
        public double Area { get; set; }

        /// <summary>
        /// 量算单位。
        /// </summary>
        [JsonProperty("unit")]
        public Unit Unit { get; set; }
    }

    /// <summary>
    /// 距离量算结果。
    /// </summary>
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class MeasureDistanceResult
    {
        ///<summary>
        ///距离量算结果。
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        ///  量算单位。
        /// </summary>
        [JsonProperty("unit")]
        public Unit Unit { get; set; }
    }
}
