using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>矩阵标签元素枚举类。</para>
    /// <para>包括图片类型的矩阵标签元素Image、符号类型的矩阵标签元素Symbol、专题图类型的矩阵标签元素Theme三种类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LabelMatrixCellType
    {   
        /// <summary>
        /// 图片类型的矩阵标签元素。
        /// </summary>
        IMAGE,

        /// <summary>
        /// 符号类型的矩阵标签元素。
        /// </summary>
        SYMBOL,

        /// <summary>
        /// 专题图类型的矩阵标签元素。
        /// </summary>
        THEME
    }
}
