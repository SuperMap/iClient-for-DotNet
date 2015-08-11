using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>数据源的引擎类型。</para>
    /// <para>SuperMap SDX+ 是 SuperMap 的空间引擎技术，它提供了一种通用的访问机制（或模式）
    /// 来访问存储在不同引擎里的数据。引擎类型包括数据库引擎、文件引擎和 Web 引擎。
    /// 数据库引擎类型主要包括 Oracle 引擎（ORACLEPLUS）、SQL Server 引擎（SQLPLUS）。
    /// 文件引擎主要包括 SDB 引擎（SDBPLUS）、UDB 引擎（UDB）、影像只读引擎（IMAGEPLUGINS）。
    /// Web 引擎主要有 OGC 引擎（OGC）、GoogleMaps 引擎（#GoogleMaps）。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EngineType
    {   
        /// <summary>
        /// DB2 引擎类型.
        /// </summary>
        DB2,

        /// <summary>
        /// GoogleMaps 引擎类型。
        /// </summary>
        GOOGLEMAPS,
        
        /// <summary>
        /// 影像只读引擎类型。
        /// </summary>
        IMAGEPLUGINS,

        /// <summary>
        /// KINGBASE 引擎类型。
        /// </summary>
        KINGBASE,

        /// <summary>
        /// OGC 引擎类型，针对于 Web 数据源。
        /// </summary>
        OGC,

        /// <summary>
        /// Oracle 引擎类型。
        /// </summary>
        ORACLEPLUS,

        /// <summary>
        /// PostgreSQL 引擎类型。
        /// </summary>
        POSTGRESQL,

        /// <summary>
        /// SDB 引擎类型。
        /// </summary>
        SDBPLUS,

        /// <summary>
        ///  SQL Server 引擎类型。
        /// </summary>
        SQLPLUS,

        /// <summary>
        /// SuperMap Cloud 引擎类型.
        /// </summary>
        SUPERMAPCLOUD,

        /// <summary>
        /// UDB 引擎类型。
        /// </summary>
        UDB
    }
}
