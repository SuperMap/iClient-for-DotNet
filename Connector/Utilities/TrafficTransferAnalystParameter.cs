using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 公交换乘分析参数类。
    /// <para>
    /// 对公交换乘分析的参数进行设置。 通过交通换乘分析参数类可以设置最大换乘导引次数、步行与公交的权重比、乘车偏好以及交通换乘策略。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TrafficTransferAnalystParameter
#else
    [Serializable]
    public class TrafficTransferAnalystParameter : ISerializable
#endif
    {
        private int _solutionCount = 5;
        private TransferTactic _transferTactic = TransferTactic.LESS_TIME;
        private TransferPreference _transferPreference = TransferPreference.NONE;
        private double _walkingRatio = 10;

        /// <summary>
        /// 初始化TrafficTransferAnalystParameter类的新实例。
        /// </summary>
        public TrafficTransferAnalystParameter()
        {

        }

        /// <summary>
        /// 拷贝构造函数
        /// </summary>
        /// <param name="trafficTransferAnalystParameter">TrafficTransferAnalystParameter对象。</param>
        public TrafficTransferAnalystParameter(TrafficTransferAnalystParameter trafficTransferAnalystParameter)
        {
            if (trafficTransferAnalystParameter == null)
            {
                throw new ArgumentNullException();
            }
            SolutionCount = trafficTransferAnalystParameter.SolutionCount;
            TransferTactic = trafficTransferAnalystParameter.TransferTactic;
            TransferPreference = trafficTransferAnalystParameter.TransferPreference;
            WalkingRatio = trafficTransferAnalystParameter.WalkingRatio;
        }

        /// <summary>
        /// 返回的解决方案数量，默认值为 5。
        /// </summary>
        [JsonProperty("solutionCount")]
        public int SolutionCount
        {
            get { return _solutionCount; }
            set { _solutionCount = value; }
        }

        /// <summary>
        /// 公交换乘策略类型，默认为 TransferTactic.LESS_TIME。
        /// </summary>
        [JsonProperty("transferTactic")]
        public TransferTactic TransferTactic
        {
            get { return _transferTactic; }
            set { _transferTactic = value; }
        }

        /// <summary>
        /// 乘车偏好，默认为 TransferPreference.NONE。
        /// </summary>
        public TransferPreference TransferPreference
        {
            get { return _transferPreference; }
            set { _transferPreference = value; }
        }

        /// <summary>
        /// 步行与公交的权重比，默认值为 10。
        /// </summary>
        [JsonProperty("walkingRatio")]
        public double WalkingRatio
        {
            get { return _walkingRatio; }
            set { _walkingRatio = value; }
        }


#if !WINDOWS_PHONE
        #region ISerializable 成员

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SolutionCount", SolutionCount);
            info.AddValue("TransferTactic", TransferTactic);
            info.AddValue("TransferPreference", TransferPreference);
            info.AddValue("WalkingRatio", WalkingRatio);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TrafficTransferAnalystParameter(SerializationInfo info, StreamingContext context)
        {
            SolutionCount = info.GetInt32("SolutionCount");
            TransferTactic = (TransferTactic)info.GetValue("TransferTactic", typeof(TransferTactic));
            TransferPreference = (TransferPreference)info.GetValue("TransferPreference", typeof(TransferPreference));
            WalkingRatio = info.GetDouble("WalkingRatio");
        }

        #endregion
#endif
    }
  
}
