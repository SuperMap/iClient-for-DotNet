using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 文本复合风格类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class LabelMixedTextStyle
    {   
        ///<summary>
        ///默认的文本复合风格。
        ///</summary>
        [JsonProperty("defaultStyle")]
        public TextStyle DefaultStyle { get; set; }
       
        /// <summary>
        /// 文本的分隔符，分隔符的风格与前一个字符的风格一样。
        /// </summary>
        [JsonProperty("separator")]
        public string Separator { set; get; }
        
        /// <summary>
        /// 文本的分隔符是否有效。
        /// </summary>
        [JsonProperty("separatorEnabled")]
        public bool SeparatorEnabled { get; set; }
       
        /// <summary>
        ///  分段索引值，分段索引值用来对文本中的字符进行分段。
        /// </summary>
        [JsonProperty("splitIndexes")]
        public int[] SplitIndexes { get; set; }
       
        /// <summary>
        /// 文本样式集合。文本样式集合中的样式用于不同分段内的字符。
        /// </summary>
        [JsonProperty("styles")]
        public TextStyle[] Styles { get; set; }
    }
}
