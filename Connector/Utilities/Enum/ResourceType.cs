using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>资源对象类型枚举。</para>
    /// <para>具体类型包括：符号、线形、填充类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceType
    {
        /// <summary>
        /// 填充类型资源。
        /// </summary>
        SYMBOLFILL,

        /// <summary>
        /// 外挂符号类型资源。
        /// </summary>
        EXTERNALFILE,

        /// <summary>
        /// 线形类型资源。
        /// </summary>
        SYMBOLLINE,

        /// <summary>
        /// 三维线型类型资源。
        /// </summary>
        SYMBOLLINE3D,

        /// <summary>
        ///  符号类型资源。
        /// </summary>
        SYMBOLMARKER,

        /// <summary>
        ///  三维符号类型资源。
        /// </summary>
        SYMBOLMARKER3D
    }
}
