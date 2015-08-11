using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>距离单位枚举类。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Unit
    {
        /// <summary>
        /// 米。
        /// </summary>
        METER,

        /// <summary>
        /// 厘米。
        /// </summary>
        CENTIMETER,

        /// <summary>
        /// 分米。
        /// </summary>
        DECIMETER,

        /// <summary>
        ///  度。
        /// </summary>
        DEGREE,

        /// <summary>
        /// 英尺。
        /// </summary>
        FOOT,

        /// <summary>
        /// 英寸。
        /// </summary>
        INCH,

        /// <summary>
        /// 千米。
        /// </summary>
        KILOMETER,

        /// <summary>
        /// 英里。
        /// </summary>
        MILE,

        /// <summary>
        /// 毫米。
        /// </summary>
        MILLIMETER,

        /// <summary>
        /// 分。
        /// </summary>
        MINUTE,

        /// <summary>
        /// 弧度。
        /// </summary>
        RADIAN,

        /// <summary>
        /// 秒。
        /// </summary>
        SECOND,

        /// <summary>
        /// 码。
        /// </summary>
        YARD,
        /// <summary>
        /// 未定义。
        /// </summary>
        UNDEFINED,
    }
}
