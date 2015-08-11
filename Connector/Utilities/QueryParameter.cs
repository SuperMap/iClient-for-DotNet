using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 查询参数类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class QueryParameter
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public QueryParameter()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="queryParam">查询参数对象。</param>
        /// <exception cref="ArgumentNullException">当查询参数对象为 Null 时抛出异常。</exception>
        public QueryParameter(QueryParameter queryParam)
        {
            if (queryParam == null) throw new ArgumentNullException();
            this.AttributeFilter = queryParam.AttributeFilter;
            if (queryParam.Fields != null)
            {
                int length = queryParam.Fields.Length;
                this.Fields = new string[length];
                for (int i = 0; i < length; i++)
                {
                    this.Fields[i] = queryParam.Fields[i];
                }
            }
            this.GroupBy = queryParam.GroupBy;
            if (queryParam.Ids != null)
            {
                int length = queryParam.Ids.Length;
                this.Ids = new int[length];
                for (int i = 0; i < length; i++)
                {
                    this.Ids[i] = queryParam.Ids[i];
                }
            }
            if (queryParam.JoinItems != null)
            {
                int length = queryParam.JoinItems.Length;
                this.JoinItems = new JoinItem[length];
                for (int i = 0; i < length; i++)
                {
                    this.JoinItems[i] = new JoinItem(queryParam.JoinItems[i]);
                }
            }
            if (queryParam.LinkItems != null)
            {
                int length = queryParam.LinkItems.Length;
                this.LinkItems = new LinkItem[length];
                for (int i = 0; i < length; i++)
                {
                    this.LinkItems[i] = new LinkItem(queryParam.LinkItems[i]);
                }
            }
            this.Name = queryParam.Name;
            this.OrderBy = queryParam.OrderBy;
        }
        /// <summary>
        /// 带参构造函数。
        /// </summary>
        /// <param name="name">查询数据集名称。</param>
        /// <exception cref="ArgumentNullException">当查询数据集名称为 Null 时抛出异常。</exception>
        public QueryParameter(string name)
        {
            if (name == string.Empty) throw new ArgumentNullException();
            this.Name = name;
        }

        /// <summary>
        /// 带参构造函数。
        /// </summary>
        /// <param name="name">查询数据集名称。</param>
        /// <param name="attributeFilter">查询 where 语句。</param>
        /// <exception cref="ArgumentNullException">当查询数据集名称为 Null 时抛出异常。</exception>
        public QueryParameter(string name, string attributeFilter)
        {
            if (name == string.Empty) throw new ArgumentNullException();
            this.Name = name;
            this.AttributeFilter = attributeFilter;
        }
        /// <summary>
        /// 属性过滤条件。
        /// </summary>
        [JsonProperty("attributeFilter")]
        public string AttributeFilter { get; set; }

        /// <summary>
        /// 查询字段数组，如果不设置则使用系统返回的所有字段。
        /// </summary>
        [JsonProperty("fields")]
        public string[] Fields { get; set; }

        /// <summary>
        /// SQL 查询分组条件的字段。
        /// </summary>
        [JsonProperty("groupBy")]
        public string GroupBy { get; set; }

        /// <summary>
        /// 查询 id 数组。
        /// </summary>
        [JsonProperty("ids")]
        public int[] Ids { get; set; }

        /// <summary>
        /// 关联查询项数组。
        /// </summary>
        [JsonProperty("joinItems")]
        public JoinItem[] JoinItems { get; set; }

        /// <summary>
        /// 与外部表的关联信息。
        /// </summary>
        [JsonProperty("linkItems")]
        public LinkItem[] LinkItems { get; set; }

        /// <summary>
        /// 数据集名称，或者图层名称，根据实际的功能而定。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// SQL 查询排序的字段。
        /// </summary>
        [JsonProperty("orderBy")]
        public string OrderBy { get; set; }
    }
}
