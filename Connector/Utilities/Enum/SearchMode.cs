using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 	<para>内插时使用的样本点的查找方式枚举。</para>
    /// 	<para>对于同一种插值方法，样本点的选择方法不同，得到的插值结果也会不同。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SearchMode
    {
        /// <summary>
        /// 使用 KDTREE 的固定点数方式查找参与内插分析的点。
        /// </summary>
        KDTREE_FIXED_COUNT,

        /// <summary>
        /// 使用 KDTREE 的定长方式查找参与内插分析的点。
        /// </summary>
        KDTREE_FIXED_RADIUS,

        /// <summary>
        /// 不进行查找，使用所有的输入点进行内插分析。
        /// </summary>
        NONE,

        /// <summary>
        /// 使用 QUADTREE 方式查找参与内插分析的点，仅对样条（Radial Basis Function）插值和普通克吕金（Kriging）有用。
        /// </summary>
        QUADTREE
    }
}
