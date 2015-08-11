using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>标签专题图中超长标签的处理模式枚举。</para>
    /// <para>对于标签的长度超过设置的标签称为超长标签，标签的最大长度可以通过ThemeLabel.maxLabelLength 来设置。
    /// SuperMap 提供三种超长标签的处理方式来控制超长标签的显示行为，即换行行为、对超长标签不进行处理、省略超出部分。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LabelOverLengthMode
    {   
        /// <summary>
        /// 对超长部分不进行处理。
        /// </summary>
        NONE,

        /// <summary>
        /// 换行显示。
        /// </summary>
        NEWLINE,

        /// <summary>
        /// 省略超出部分。
        /// </summary>
        OMIT
    }
}
