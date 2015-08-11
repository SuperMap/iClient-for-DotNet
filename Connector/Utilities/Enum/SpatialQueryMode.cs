using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>空间查询模式枚举，定义空间查询操作模式常量。</para>
    /// <para>空间查询是通过几何对象之间的空间位置关系来构建过滤条件的一种查询方式。
    /// 例如：通过空间查询可以找到被包含在面中的空间对象，相离或者相邻的空间对象等。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpatialQueryMode
    {   
        /// <summary>
        /// 无空间查询。
        /// </summary>
        NONE,

        /// <summary>
        /// 包含空间查询模式。
        /// </summary>
        CONTAIN,

        /// <summary>
        /// 交叉空间查询模式。
        /// </summary>
        CROSS,

        /// <summary>
        /// 分离空间查询模式。
        /// </summary>
        DISJOINT,

        /// <summary>
        /// 重合空间插叙模式。
        /// </summary>
        IDENTITY,

        /// <summary>
        /// 相交空间查询模式。
        /// </summary>
        INTERSECT,

        /// <summary>
        /// 叠加空间查询模式。
        /// </summary>
        OVERLAP,

        /// <summary>
        /// 邻接空间查询模式。
        /// </summary>
        TOUCH,

        /// <summary>
        /// 被包含空间查询模式。
        /// </summary>
        WITHIN
    }
}
