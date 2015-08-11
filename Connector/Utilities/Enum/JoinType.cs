using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>两个表之间连接类型枚举。</para>
    /// <para>定义两个表之间连接类型常量。该类型用于对相连接的两个表之间进行查询时，
    /// 决定了查询结果中得到的记录的情况。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JoinType
    {   
        /// <summary>
        ///  内连接。
        /// </summary>
        INNERJOIN,

        /// <summary>
        /// 左连接。
        /// </summary>
        LEFTJOIN
    }
}
