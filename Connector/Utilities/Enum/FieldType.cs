using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>字段类型枚举。</para>
    /// <para>定义一系列字段类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FieldType
    {   
        /// <summary>
        /// 布尔型。
        /// </summary>
        BOOLEAN,

        /// <summary>
        /// 字节型。
        /// </summary>
        BYTE,

        /// <summary>
        /// 变长的宽字节字符类型。
        /// </summary>
        CHAR,

        /// <summary>
        /// 日期型。
        /// </summary>
        DATETIME,

        /// <summary>
        /// 64位精度浮点型。
        /// </summary>
        DOUBLE,

        /// <summary>
        /// 16位整型。
        /// </summary>
        INT16,

        /// <summary>
        /// 32位整型。
        /// </summary>
        INT32,

        /// <summary>
        /// 64位整型。
        /// </summary>
        INT64,

        /// <summary>
        /// 二进制型。
        /// </summary>
        LONGBINARY,

        /// <summary>
        /// 32位精度浮点型。
        /// </summary>
        SINGLE,

        /// <summary>
        /// 文本型。
        /// </summary>
        TEXT,

        /// <summary>
        /// 宽字符类型字段。
        /// </summary>
        WTEXT
    }
}
