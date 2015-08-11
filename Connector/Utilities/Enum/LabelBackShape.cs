using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>标签专题图中标签背景的形状类型枚举。</para>
    /// <para>标签背景是 SuperMap iServer Java 支持的一种标签的显示风格，使用一定颜色的各种形状作为各标签背景，
    /// 从而可以突出显示标签或者使标签专题图更美观。
    /// 标签背景支持的形状共有6种。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LabelBackShape
    {   
        /// <summary>
        /// 空背景。
        /// </summary>
        NONE,

        /// <summary>
        /// 菱形背景。
        /// </summary>
        DIAMOND,

        /// <summary>
        /// 椭圆形背景。
        /// </summary>
        ELLIPSE,

        /// <summary>
        /// 符号背景。
        /// </summary>
        MARKER,

        /// <summary>
        /// 矩形背景。
        /// </summary>
        RECT,

        /// <summary>
        /// 圆角矩形背景。
        /// </summary>
        ROUNDRECT,

        /// <summary>
        /// 三角形背景。
        /// </summary>
        TRIANGLE
    }
}
