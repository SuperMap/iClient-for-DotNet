using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 旅行商路径类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class TSPPath : Path
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public TSPPath()
            : base()
        {
        }

        /// <summary>
        /// 以索引表示的旅行商路径途经结点的顺序。
        /// </summary>
        [JsonProperty("stopIndexes")]
        public int[] StopIndexes { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StopIndexes", this.StopIndexes);
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TSPPath(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.StopIndexes = (int[])info.GetValue("StopIndexes", typeof(int[]));
        }
        #endregion
#endif
    }
}
