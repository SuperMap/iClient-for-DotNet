using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 数据返回模式枚举类。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataReturnMode
    {
        /// <summary>
        /// 只返回数据集标识(数据集名称@数据源名称)。
        /// </summary>
        DATASET_ONLY,

        /// <summary>
        /// 返回数据集标识和记录集。
        /// </summary>
        DATASET_AND_RECORDSET,

        /// <summary>
        /// 只返回记录集。
        /// </summary>
        RECORDSET_ONLY
    }
}
