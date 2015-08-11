using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
#if !WINDOWS_PHONE
using System.Data;
#endif
using System.Globalization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 查询结果类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class QueryResult
    {
        /// <summary>
        /// 自定义操作处理的结果。
        /// </summary>
        [JsonProperty("customResponse")]
        public string CustomResponse { get; set; }

        /// <summary>
        /// 当前查询返回的记录数。
        /// </summary>
        [JsonProperty("currentCount")]
        public int CurrentCount { get; set; }
        /// <summary>
        /// 查询记录集。
        /// </summary>
        [JsonProperty("recordsets")]
        public Recordset[] Recordsets { get; set; }
        /// <summary>
        /// 根据查询条件查询到的记录的总数。
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 获取查询结果资源。 
        /// </summary>
        [JsonProperty("resourceInfo")]
        public ResourceInfo ResourceInfo { get; set; }

#if !WINDOWS_PHONE
        /// <summary>
        /// 将QueryResultd对象转换为System.Data.DataSet对象。
        /// </summary>
        /// <returns>System.Data.DataSet对象。</returns>
        public DataSet ToDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            if (Recordsets != null)
            {
                for (int i = 0; i < Recordsets.Length; i++)
                {
                    DataTable table = Recordsets[i].ToDataTable();
                    dataSet.Tables.Add(table);
                }
                return dataSet;
            }
            return null;
        }
#endif
    }
}
