using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 连接信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class JoinItem
#else
    [Serializable]
    public sealed class JoinItem : ISerializable
#endif
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public JoinItem()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="joinItem">JoinItem对象</param>
        public JoinItem(JoinItem joinItem)
        {
            if (joinItem == null) return;
            this.ForeignTableName = joinItem.ForeignTableName;
            this.JoinFilter = joinItem.JoinFilter;
            this.JoinType = joinItem.JoinType;
        }

        ///<summary>
        /// 外部表的名称。
        ///</summary>
        [JsonProperty("foreignTableName")]
        public string ForeignTableName { get; set; }

        /// <summary>
        /// 与外部表之间的连接表达式，即设定两个表之间关联的字段。
        /// </summary>
        [JsonProperty("joinFilter")]
        public string JoinFilter { get; set; }

        /// <summary>
        /// 两个表之间连接的类型。
        /// </summary>
        [JsonProperty("joinType")]
        public JoinType JoinType { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private JoinItem(SerializationInfo info, StreamingContext context)
        {
            this.ForeignTableName = info.GetString("ForeignTableName");
            this.JoinFilter = info.GetString("JoinFilter");
            this.JoinType = (Utility.JoinType)info.GetValue("JoinType", typeof(JoinType));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ForeignTableName", this.ForeignTableName);
            info.AddValue("JoinFilter", this.JoinFilter);
            info.AddValue("JoinType", this.JoinType);
        }
        #endregion
#endif
    }
}
