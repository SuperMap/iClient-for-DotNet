using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 多旅行商（物流配送）分析结果路径。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class MTSPPath<T> :TSPPath 
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MTSPPath()
            :base()
        { }

        /// <summary>
        /// 本路径对应的配送中心。
        /// </summary>
        [JsonProperty("center")]
        public T Center { get; set; }

        /// <summary>
        /// 本路径途经的网络结点。
        /// </summary>
        [JsonProperty("nodesVisited")]
        public T[] NodesVisited { get; set; }
 
#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Center", this.Center);
            info.AddValue("NodesVisited", this.NodesVisited);
            base.GetObjectData(info, context);
        }

        MTSPPath(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Center = (T)info.GetValue("Center", typeof(T));
            this.NodesVisited = (T[])info.GetValue("NodesVisited", typeof(T[]));
        }

        #endregion
#endif

    }
}
