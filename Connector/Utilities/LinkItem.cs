using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 关联信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class LinkItem
    {
        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="linkItem">LinkItem对象</param>
        public LinkItem(LinkItem linkItem)
        {
            if (linkItem.DatasourceConnectionInfo != null)
            {
                this.DatasourceConnectionInfo = new DatasourceConnectionInfo(linkItem.DatasourceConnectionInfo);
            }
            if (linkItem.ForeignKeys != null)
            {
                int length = linkItem.ForeignKeys.Length;
                this.ForeignKeys = new string[length];
                for (int i = 0; i < length; i++)
                {
                    this.ForeignKeys[i] = linkItem.ForeignKeys[i];
                }
            }
            this.ForeignTable = linkItem.ForeignTable;
            if (linkItem.LinkFields != null)
            {
                int length = linkItem.LinkFields.Length;
                this.LinkFields = new string[length];
                for (int i = 0; i < length; i++)
                {
                    this.LinkFields[i] = linkItem.LinkFields[i];
                }
            }
            this.LinkFilter = linkItem.LinkFilter;
            this.Name = linkItem.Name;
            if (linkItem.PrimaryKeys != null)
            {
                int length = linkItem.PrimaryKeys.Length;
                this.PrimaryKeys = new string[length];
                for (int i = 0; i < length; i++)
                {
                    this.PrimaryKeys[i] = linkItem.PrimaryKeys[i];
                }
            }
        }

        /// <summary>
        /// 关联的外部数据源。
        /// </summary>
        [JsonProperty("datasourceConnectionInfo")]
        public DatasourceConnectionInfo DatasourceConnectionInfo { get; set; }

        /// <summary>
        /// 主空间数据集的外键。
        /// </summary>
        [JsonProperty("foreignKeys")]
        public string[] ForeignKeys { get; set; }

        /// <summary>
        /// 关联的外部属性表的名称。
        /// </summary>
        [JsonProperty("foreignTable")]
        public string ForeignTable { get; set; }

        /// <summary>
        /// 欲保留的外部属性表的字段。
        /// </summary>
        [JsonProperty("linkFields")]
        public string[] LinkFields { get; set; }

        /// <summary>
        /// 与外部属性表的连接条件。
        /// </summary>
        [JsonProperty("linkFilter")]
        public string LinkFilter { get; set; }

        /// <summary>
        /// 此关联信息对象的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 外部属性表的主键。
        /// </summary>
        [JsonProperty("primaryKeys")]
        public string[] PrimaryKeys { get; set; }

    }
}
