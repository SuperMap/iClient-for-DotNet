using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>统计图专题标注文本格式。</para>
    /// <para>在统计专题图中，可以设置各子项文本的显示形式，有百分数PERCENT、真实数值VALUE、标题CAPTION、标题+百分数
    /// CAPTION_PERCENT、标题+真实数值CAPTION_VALUE五种形式。以下图示均以三维柱状图为例。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GraphTextFormat
    {   
        /// <summary>
        /// 标题。
        /// </summary>
        CAPTION,

        /// <summary>
        /// 标题加百分数。
        /// </summary>
        CAPTION_PERCENT,        
        
        /// <summary>
        /// 标题加实际数值。
        /// </summary>
        CAPTION_VALUE,

        /// <summary>
        /// 百分数。
        /// </summary>
        PERCENT,

        /// <summary>
        /// 实际数值。
        /// </summary>
        VALUE
    }
}
