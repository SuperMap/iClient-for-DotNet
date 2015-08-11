using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 交通换乘方案集合类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferSolutions
#else
    [Serializable]
    public class TransferSolutions : ISerializable
#endif
    {
        private TransferGuide _defaultGuide;
        private TransferSolution[] _solutionItems;

        /// <summary>
        /// 初始化TransferSolutions类的新实例。
        /// </summary>
        public TransferSolutions()
        {

        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="transferSolutions">TransferSolutions对象。</param>
        public TransferSolutions(TransferSolutions transferSolutions)
        {
            if (transferSolutions == null || transferSolutions.SolutionItems == null)
            {
                throw new ArgumentNullException();
            }
            this.DefaultGuide = new TransferGuide(transferSolutions.DefaultGuide);
            this.SolutionItems = new TransferSolution[transferSolutions.SolutionItems.Length];
            for (int i = 0; i < transferSolutions.SolutionItems.Length; i++)
            {
                this.SolutionItems[i] = new TransferSolution(transferSolutions.SolutionItems[i]);
            }
        }

        /// <summary>
        /// 交通换乘方案集合对应的默认换乘路线。
        /// </summary>
        [JsonProperty("defaultGuide")]
        public TransferGuide DefaultGuide
        {
            get { return _defaultGuide; }
            set { _defaultGuide = value; }
        }

        /// <summary>
        /// 交通换乘方案子项数组。
        /// </summary>
        [JsonProperty("solutionItems")]
        public TransferSolution[] SolutionItems
        {
            get { return _solutionItems; }
            set { _solutionItems = value; }
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
            info.AddValue("DefaultGuide", DefaultGuide);
            info.AddValue("SolutionItems", SolutionItems);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferSolutions(SerializationInfo info, StreamingContext context)
        {
            SolutionItems = (TransferSolution[])info.GetValue("SolutionItems", typeof(TransferSolution[]));
            DefaultGuide = (TransferGuide)info.GetValue("DefaultGuide", typeof(TransferGuide));
        }

        #endregion
#endif
    }
}
