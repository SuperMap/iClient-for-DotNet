using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 交通换乘方案类。在一个换乘方案内的所有乘车路线中换乘次数是相同的。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferSolution
#else
    [Serializable]
    public class TransferSolution : ISerializable
#endif
    {
        private int _transferCount;
        private TransferLines[] _linesItems;

        /// <summary>
        /// 初始化TransferSolution类的新实例。
        /// </summary>
        public TransferSolution()
        {

        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="transferSolution">TransferSolution对象。</param>
        public TransferSolution(TransferSolution transferSolution)
        {
            if (transferSolution == null||transferSolution.LinesItems==null)
            {
                throw new ArgumentNullException();
            }
            this.TransferCount = transferSolution.TransferCount;
            this.LinesItems = new TransferLines[transferSolution.LinesItems.Length];
            for (int i = 0; i < transferSolution.LinesItems.Length; i++)
            {
                this.LinesItems[i] = new TransferLines(transferSolution.LinesItems[i]);
            }
        }

        /// <summary>
        /// 换乘方案对应的换乘次数。
        /// </summary>
        [JsonProperty("transferCount")]
        public int TransferCount
        {
            get { return _transferCount; }
            set { _transferCount = value; }
        }

        /// <summary>
        /// 换乘分段数组。
        /// </summary>
        [JsonProperty("linesItems")]
        public TransferLines[] LinesItems
        {
            get { return _linesItems; }
            set { _linesItems = value; }
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
            info.AddValue("LinesItems", LinesItems);
            info.AddValue("TransferCount", TransferCount);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferSolution(SerializationInfo info, StreamingContext context)
        {
            LinesItems = (TransferLines[])info.GetValue("LinesItems", typeof(TransferLines[]));
            TransferCount = info.GetInt32("TransferCount");
        }

        #endregion
#endif
    }
}
