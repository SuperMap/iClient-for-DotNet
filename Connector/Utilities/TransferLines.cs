using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 交通换乘分段类，记录了本分段中可乘坐的路线信息。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferLines
#else
    [Serializable]
    public class TransferLines : ISerializable
#endif
    {
        private TransferLine[] _lineItems;

        /// <summary>
        /// 初始化TransferLines类的新实例。
        /// </summary>
        public TransferLines()
        {

        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="transferLines">TransferLines对象。</param>
        public TransferLines(TransferLines transferLines)
        {
            if (transferLines == null||transferLines.LineItems==null)
            {
                throw new ArgumentNullException();
            }
            _lineItems = new TransferLine[transferLines.LineItems.Length];
            for (int i = 0; i < transferLines.LineItems.Length; i++)
            {
                _lineItems[i] = new TransferLine(transferLines.LineItems[i]);
            }
        }

        /// <summary>
        /// 本换乘分段内可乘车的路线集合。
        /// </summary>
        [JsonProperty("lineItems")]
        public TransferLine[] LineItems
        {
            get { return _lineItems; }
            set { _lineItems = value; }
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LineItems", LineItems);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferLines(SerializationInfo info, StreamingContext context)
        {
            LineItems = (TransferLine[])info.GetValue("LineItems", typeof(TransferLine[]));
        }

        #endregion
#endif
    }
}
