using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>渐变填充风格的渐变类型。</para>
    /// <para>所有渐变类型都是两种颜色之间的渐变，即从渐变起始色到渐变终止色之间的渐变。
    /// 渐变风格的计算都是以填充区域的边界矩形，即最小外接矩形作为基础的，因而以下提到的填充区域范围即为填充区域的最小外接矩形。</para>>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FillGradientMode
    {   
        /// <summary>
        /// 无渐变。
        /// </summary>
        NONE,

        /// <summary>
        /// 圆锥渐变。
        /// </summary>
        CONICAL,

        /// <summary>
        /// 线性渐变。
        /// </summary>
        LINEAR,
        
        /// <summary>
        /// 肤辐射渐变。
        /// </summary>
        RADIAL,
        
        /// <summary>
        /// 四角渐变。
        /// </summary>
        SQUARE
    }
}
