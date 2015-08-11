using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>文本对齐枚举。</para>
    /// <para>指定文本中的各子对象的对齐方式。文本对象的每个子对象的位置是由文本的锚点和文本的对齐方式共同确定的。
    /// 当文本子对象的锚点固定，对齐方式确定文本子对象与锚点的相对位置，从而确定文本子对象的位置。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TextAlignment
    {   
        /// <summary>
        /// 基准线居中对齐。
        /// </summary>
        BASELINECENTER,

        /// <summary>
        /// 基准线左对齐。
        /// </summary>
        BASELINELEFT,

        /// <summary>
        /// 基准线右对齐。
        /// </summary>
        BASELINERIGHT,

        /// <summary>
        /// 底部居中对齐。
        /// </summary>
        BOTTOMCENTER,

        /// <summary>
        /// 左下角对齐。
        /// </summary>
        BOTTOMLEFT,

        /// <summary>
        /// 右下角对齐。
        /// </summary>
        BOTTOMRIGHT,

        /// <summary>
        /// 中心对齐。
        /// </summary>
        MIDDLECENTER,

        /// <summary>
        /// 左中对齐。
        /// </summary>
        MIDDLELEFT,

        /// <summary>
        /// 右中对齐。
        /// </summary>
        MIDDLERIGHT,

        /// <summary>
        /// 顶部居中对齐。
        /// </summary>
        TOPCENTER,

        /// <summary>
        /// 左上角对齐。
        /// </summary>
        TOPLEFT,

        /// <summary>
        /// 右上角对齐。
        /// </summary>
        TOPRIGHT
    }
}
