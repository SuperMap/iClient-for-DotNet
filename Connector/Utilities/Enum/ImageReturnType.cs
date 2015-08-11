using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>图片返回设置。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImageReturnType
    {
        /// <summary>
        /// 只返回二进制内容。 
        /// </summary>
        BINARY,

        ///// <summary>
        ///// 默认返回格式，返回url地址。 
        ///// </summary>
        ////DEFAULT,
        ///// <summary>
        ///// 只返回文件地址。 
        ///// </summary>
        ////FILEURI,

        /// <summary>
        /// 只返回url地址。 
        /// </summary>
        URL
    }
}
