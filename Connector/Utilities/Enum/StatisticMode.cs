using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>
    /// 字段统计方法枚举。
    /// </para>
    /// <para>
    /// 对单一字段提供常用统计功能。SuperMap 提供的统计功能有6种，统计字段的最大值，最小值，平均值，总和，标准差以及方差。
    /// </para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatisticMode
    {
        /// <summary>
        /// 统计所选字段的平均值。 
        /// </summary>
        AVERAGE,

        /// <summary>
        /// 统计所选字段的最大值。 
        /// </summary>
        MAX,

        /// <summary>
        /// 统计所选字段的最小值。 
        /// </summary>
        MIN,

        /// <summary>
        /// 统计所选字段的标准差。 
        /// </summary>
        STDDEVIATION,

        /// <summary>
        /// 统计所选字段的总和。
        /// </summary>
        SUM,

        /// <summary>
        ///  统计所选字段的方差。 
        /// </summary>
        VARIANCE
    }
}
