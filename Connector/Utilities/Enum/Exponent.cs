using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 	<para>该类定义了泛克吕金（UniversalKriging）插值时样点数据中趋势面方程的阶数的类型常量。 样点数据集中样点之间固有的某种趋势，可以通过函数或者多项式的拟合呈现。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Exponent
    {
        /// <summary>
        /// 阶数为1。表示样点数据集中趋势面呈一阶趋势。 
        /// </summary>
        EXP1,

        /// <summary>
        /// 阶数为2。表示样点数据集中趋势面呈二阶趋势。 
        /// </summary>
        EXP2
    }
}
