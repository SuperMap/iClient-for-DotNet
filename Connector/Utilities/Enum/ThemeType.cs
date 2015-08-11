using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>专题图类型枚举类。</para>
    /// <para>矢量数据（vector datas）和光栅数据(raster datas)都可以用来制作专题图，
    /// 所不同的是矢量数据的专题图是基于其属性表中的属性信息，
    /// 而光栅数据则是基于像元值。SuperMap 提供用于矢量数据（点，线，面以及复合数据集）的专题图，
    /// 包括单值专题图，范围分段专题图，点密度专题图，统计专题图，等级符号专题图，
    /// 标签专题图和自定义专题图，也提供了适合于光栅数据（栅格数据集）的专题图功能，
    /// 包括栅格分段专题图（GridRangeTheme）和栅格单值专题图(GridUniqueTheme)。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ThemeType
    {
        /// <summary>
        /// 点密度专题图。
        /// </summary>
        DOTDENSITY,

        /// <summary>
        /// 等级符号专题图。
        /// </summary>
        GRADUATEDSYMBOL,

        /// <summary>
        /// 统计专题图。
        /// </summary>
        GRAPH,

        /// <summary>
        /// 栅格分段专题图。
        /// </summary>
        GRIDRANGE,

        /// <summary>
        /// 栅格单值专题图。
        /// </summary>
        GRIDUNIQUE,

        /// <summary>
        /// 标签专题图。
        /// </summary>
        LABEL,

        /// <summary>
        /// 分段专题图。
        /// </summary>
        RANGE,

        /// <summary>
        /// 単值专题图。
        /// </summary>
        UNIQUE
    }
}
