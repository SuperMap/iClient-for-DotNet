using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>交通网络分析结果路径。</para>
    /// <para>对交通网络分析结果路径的描述，其中包含一条路径经过的结点、弧段、该路径的路由、行驶引导、耗费等信息。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class Path
#else
    [Serializable]
    public class Path : ISerializable
#endif
    {

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Path()
        { }
        /// <summary>
        /// 分析结果的途经的弧段要素的集合。
        /// </summary>
        [JsonProperty("edgeFeatures")]
        public Feature[] EdgeFeatures { get; set; }

        /// <summary>
        /// 分析结果的途经弧段 ID 的集合。
        /// </summary>
        [JsonProperty("edgeIDs")]
        public int[] EdgeIDs { get; set; }

        /// <summary>
        /// 分析结果的途经的结点要素的集合。
        /// </summary>
        [JsonProperty("nodeFeatures")]
        public Feature[] NodeFeatures { get; set; }

        /// <summary>
        /// 分析结果的途经结点 ID 的集合。
        /// </summary>
        [JsonProperty("nodeIDs")]
        public int[] NodeIDs { get; set; }

        /// <summary>
        /// 分析结果对应的行驶导引子项集合。
        /// </summary>
        [JsonProperty("pathGuideItems")]
        public PathGuideItem[] PathGuideItems { get; set; }

        /// <summary>
        /// 分析结果对应的路由对象。
        /// </summary>
        [JsonProperty("route")]
        public Route Route { get; set; }

        /// <summary>
        /// 返回各条 path 总耗费的数组。
        /// </summary>
        [JsonProperty("stopWeights")]
        public double[] StopWeights { get; set; }

        /// <summary>
        /// 当前路径的总花费。
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

#if !WINDOWS_PHONE
        #region ISerializable 成员
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EdgeFeatures", this.EdgeFeatures);
            info.AddValue("EdgeIDs", this.EdgeIDs);
            info.AddValue("NodeFeatures", this.NodeFeatures);
            info.AddValue("NodeIDs", this.NodeIDs);
            info.AddValue("PathGuideItems", this.PathGuideItems);
            info.AddValue("Route", this.Route);
            info.AddValue("StopWeights", this.StopWeights);
            info.AddValue("Weight", this.Weight);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected Path(SerializationInfo info, StreamingContext context)
        {
            this.EdgeFeatures = (Feature[])info.GetValue("EdgeFeatures", typeof(Feature[]));
            this.EdgeIDs = (int[])info.GetValue("EdgeIDs", typeof(int[]));
            this.NodeFeatures = (Feature[])info.GetValue("NodeFeatures", typeof(Feature[]));
            this.NodeIDs = (int[])info.GetValue("NodeIDs", typeof(int[]));
            this.PathGuideItems = (PathGuideItem[])info.GetValue("PathGuideItems", typeof(PathGuideItem[]));
            this.Route = (Route)info.GetValue("Route", typeof(Route));
            this.StopWeights = (double[])info.GetValue("StopWeights", typeof(double[]));
            this.Weight = info.GetDouble("Weight");

        }
        #endregion
#endif
    }
}
