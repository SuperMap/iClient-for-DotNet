using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>标签沿线标注方向枚举。</para>
    /// <para>路线与水平方向的锐角夹角在60度以上表示上下方向，60度以下表示左右方向。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlongLineDirection
    {
        /// <summary> 
        /// 沿线的法线方向放置标签。
        /// </summary>
        ALONG_LINE_NORMAL,

        /// <summary>
        /// 从下到上，从左到右放置。
        /// </summary>
        LEFT_BOTTOM_TO_RIGHT_TOP,

        /// <summary>
        /// 从上到下，从左到右放置。
        /// </summary>
        LEFT_TOP_TO_RIGHT_BOTTOM,

        /// <summary>
        /// 从下到上，从右到左放置。
        /// </summary>
        RIGHT_BOTTOM_TO_LEFT_TOP,

        /// <summary>
        /// 从上到下，从右到左放置
        /// </summary>
        RIGHT_TOP_TO_LEFT_BOTTOM
    }
}
