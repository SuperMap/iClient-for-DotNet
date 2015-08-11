using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>色彩空间枚举。</para>
    /// <para>由于成色原理的不同，决定了显示器、投影仪这类靠色光直接合成颜色的颜色设备
    /// 和打印机、印刷机这类靠使用颜料的印刷设备在生成颜色方式上的区别。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ColorSpaceType
    {
        /// <summary>
        /// 该类型主要在印刷系统使用。  
        /// </summary>
        CMYK,

        /// <summary> 
        /// 该类型主要在显示系统中使用。
        /// </summary>
        RGB
    }
}
