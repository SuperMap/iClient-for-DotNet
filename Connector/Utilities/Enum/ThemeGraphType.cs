using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>统计专题图的统计图类型。</para>
    /// <para>SuperMap iserver Java 定义了13种类型的统计图，分别为面积图、阶梯图、折线图、点状图、柱状图、三维柱状
    /// 图、饼图、三维饼图、玫瑰图、三维玫瑰图、堆叠柱状图、三维堆叠柱状图、环状图。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ThemeGraphType
    {   
        /// <summary>
        /// 面积图。
        /// </summary>
        AREA,

        /// <summary>
        /// 柱状图。
        /// </summary>
        BAR,

        /// <summary>
        /// 三维柱状图。
        /// </summary>
        BAR3D,

        /// <summary>
        /// 折线图。
        /// </summary>
        LINE,

        /// <summary>
        /// 饼图。
        /// </summary>
        PIE,

        /// <summary>
        /// 三维饼图。
        /// </summary>
        PIE3D,

        /// <summary>
        /// 点状图。
        /// </summary>
        POINT,

        /// <summary>
        /// 环状图。
        /// </summary>
        RING,

        /// <summary>
        /// 玫瑰图。
        /// </summary>
        ROSE,

        /// <summary>
        /// 三维玫瑰图。
        /// </summary>
        ROSE3D,

        /// <summary>
        /// 堆叠柱状图。
        /// </summary>
        STACK_BAR,

        /// <summary>
        /// 三维堆叠柱状图。
        /// </summary>
        STACK_BAR3D,

        /// <summary>
        /// 阶梯图。
        /// </summary>
        STEP
    }
}
