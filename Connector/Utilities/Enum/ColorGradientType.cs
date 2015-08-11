using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>颜色渐变枚举。</para>
    /// <para>颜色渐变是多种颜色间的逐渐混合，可以是从起始色到终止色两种颜色的渐变，
    /// 或者在起始色到终止色之间具有多种中间颜色进行渐变。该颜色渐变类型可应用于专题图对象的
    /// 颜色方案设置中如：单值专题图、 分段专题图、栅格分段专题图。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ColorGradientType
    {
        /// <summary>黑白渐变色。</summary>
        BLACKWHITE,
        /// <summary>蓝黑渐变色。</summary>
        BLUEBLACK,
        /// <summary>蓝红渐变色。</summary>
        BLUERED,
        /// <summary>蓝白渐变色。</summary>
        BLUEWHITE,
        /// <summary>青黑渐变色。</summary>
        CYANBLACK,
        /// <summary>青蓝渐变色。</summary>
        CYANBLUE,
        /// <summary>青绿渐变色。</summary>
        CYANGREEN,
        /// <summary>青白渐变色。</summary>
        CYANWHITE,
        /// <summary>绿黑渐变色。</summary>
        GREENBLACK,
        /// <summary>绿蓝渐变色。</summary>
        GREENBLUE,
        /// <summary>绿橙紫渐变色。</summary>
        GREENORANGEVIOLET,
        /// <summary>绿红渐变色。</summary>
        GREENRED,
        /// <summary>绿白渐变色。</summary>
        GREENWHITE,
        /// <summary>粉红黑模式</summary>
        PINKBLACK,
        /// <summary>青蓝渐变色。</summary>
        PINKBLUE,
        /// <summary>青红渐变色。</summary>
        PINKRED,
        /// <summary> 粉红白渐变色。</summary>
        PINKWHITE,
        /// <summary> 彩虹色。</summary>
        RAINBOW,
        /// <summary>红黑渐变色。</summary>
        REDBLACK,
        /// <summary>红白渐变色。</summary>
        REDWHITE,
        /// <summary>光谱渐变。</summary>
        SPECTRUM,
        /// <summary>地形渐变,用于三维显示效果较好。</summary>
        TERRAIN,
        /// <summary> 黄黑渐变色。</summary>
        YELLOWBLACK,
        /// <summary>黄蓝渐变色。</summary>
        YELLOWBLUE,
        /// <summary>黄绿渐变色。</summary>
        YELLOWGREEN,
        /// <summary>黄红渐变色。</summary>
        YELLOWRED,
        /// <summary>黄白渐变色。</summary>        
        YELLOWWHITE
    }
}
