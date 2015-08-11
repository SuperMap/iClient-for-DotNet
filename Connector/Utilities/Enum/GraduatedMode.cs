using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 	<para>专题图分级模式枚举，主要用在统计专题图和等级符号专题图中。</para>
    /// 	<para>分级主要是为了减少制作专题图时数据大小之间的差异。如果数据之间差距较大，则可以采用数或者平方根的分
    /// 	级方式来进行，这样就减少了数据之间的绝对大小的差异，使得专题图的视觉效果比较好，同时不同类别之间的比较也
    /// 	还是有意义的。有三种分级模式：常数、对数和平方根，对于有值为负数的字段，不可以采用对数和平方根的分级方式。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GraduatedMode
    {
        /// <summary>
        /// 常量分级模式。
        /// </summary>
        CONSTANT,

        /// <summary>
        /// 对数分级模式。
        /// </summary>
        LOGARITHM,
        
        /// <summary>
        /// 平方根分级模式。
        /// </summary>
        SQUAREROOT,
        

    }
}
