using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 服务区分析结果，表示的是某个服务中心的服务范围等信息。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class ServiceAreaResult
#else
    [Serializable]
    public class ServiceAreaResult : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ServiceAreaResult()
        { }

        /// <summary>
        ///本服务区包含的网络弧段要素集合。 
        /// </summary>
        [JsonProperty("edgeFeatures")]
        public List<Feature> EdgeFeatures { get; set; }

        /// <summary>
        /// 本服务区包含的网络弧段的 ID 集合。
        /// </summary>
        [JsonProperty("edgeIDs")]
        public List<int> EdgeIDs { get; set; }
        
        /// <summary>
        ///本服务区包含的网络结点要素集合。 
        /// </summary>
        [JsonProperty("nodeFeatures")]
        public List<Feature> NodeFeatures { get; set; }

        /// <summary>
        ///本服务区包含的网络结点的 ID 集合。 
        /// </summary>
        [JsonProperty("nodeIDs")]
        public List<int> NodeIDs { get; set; }

        /// <summary>
        /// 本服务区的路由对象集合。
        /// </summary>
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }

        /// <summary>
        /// 本服务区对应的面对象，即服务范围。
        /// </summary>
        [JsonProperty("serviceRegion")]
        public Geometry ServiceRegion { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EdgeFeatures", this.EdgeFeatures);
            info.AddValue("EdgeIDs", this.EdgeIDs);
            info.AddValue("this.NodeFeatures", this.NodeFeatures);
            info.AddValue("NodeIDs", this.NodeIDs);
            info.AddValue("Routes", this.Routes);
            info.AddValue("ServiceRegion", this.ServiceRegion);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected ServiceAreaResult(SerializationInfo info, StreamingContext context)
        {
            this.EdgeFeatures = info.GetValue("EdgeFeatures", typeof(List<Feature>)) as List<Feature>;
            this.EdgeIDs = info.GetValue("EdgeIDs", typeof(List<int>)) as List<int>;
            this.NodeFeatures = info.GetValue("NodeFeatures", typeof(List<Feature>)) as List<Feature>;
            this.NodeIDs = info.GetValue("EdgeIDs", typeof(List<int>)) as List<int>;
            this.Routes = info.GetValue("Routes", typeof(List<Route>)) as List<Route>;
            this.ServiceRegion = info.GetValue("ServiceRegion", typeof(Geometry)) as Geometry;
        }
        #endregion
#endif
    }
}
