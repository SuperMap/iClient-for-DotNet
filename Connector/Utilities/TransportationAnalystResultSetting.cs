using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 交通网络分析结果设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class TransportationAnalystResultSetting
#else
    [Serializable]
    public sealed class TransportationAnalystResultSetting : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public TransportationAnalystResultSetting()
        {
            this.ReturnEdgeIDs = true;
            this.ReturnNodeIDs = true;
            this.ReturnRoutes = true;
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="setting">交通网络分析结果设置。</param>
        public TransportationAnalystResultSetting(TransportationAnalystResultSetting setting)
        {
            if (setting == null) throw new ArgumentException();
            this.ReturnEdgeFeatures = setting.ReturnEdgeFeatures;
            this.ReturnEdgeGeometry = setting.ReturnEdgeGeometry;
            this.ReturnEdgeIDs = setting.ReturnEdgeIDs;
            this.ReturnNodeFeatures = setting.ReturnNodeFeatures;
            this.ReturnNodeGeometry = setting.ReturnNodeGeometry;
            this.ReturnNodeIDs = setting.ReturnNodeIDs;
            this.ReturnPathGuides = setting.ReturnPathGuides;
            this.ReturnRoutes = setting.ReturnRoutes;
        }

        /// <summary>
        /// 是否在分析结果中包含弧段要素集合。
        /// </summary>
        [JsonProperty("returnEdgeFeatures")]
        public bool ReturnEdgeFeatures { get; set; }

        /// <summary>
        /// 是否在分析结果中返回的弧段要素集合中包含几何对象信息，ReturnEdgeFeatures设置为true时有效。
        /// </summary>
        [JsonProperty("returnEdgeGeometry")]
        public bool ReturnEdgeGeometry { get; set; }

        /// <summary>
        /// 返回分析结果中是否包含经过弧段 ID 集合,默认为true。
        /// </summary>
        [JsonProperty("returnEdgeIDs")]
        public bool ReturnEdgeIDs { get; set; }

        /// <summary>
        /// 是否在分析结果中包含结点要素集合。
        /// </summary>
        [JsonProperty("returnNodeFeatures")]
        public bool ReturnNodeFeatures { get; set; }

        /// <summary>
        /// 是否在分析结果中返回的结点要素集合中包含几何对象信息，ReturnNodeFeatures设置为true时有效。
        /// </summary>
        [JsonProperty("returnNodeGeometry")]
        public bool ReturnNodeGeometry { get; set; }

        /// <summary>
        /// 返回分析结果中是否包含经过的结点 ID 集合,默认为true。
        /// </summary>
        [JsonProperty("returnNodeIDs")]
        public bool ReturnNodeIDs { get; set; }

        /// <summary>
        /// 返回分析结果中是否包含行驶导引集合。
        /// </summary>
        [JsonProperty("returnPathGuides")]
        public bool ReturnPathGuides { get; set; }

        /// <summary>
        /// 返回分析结果中是否包含路由对象的集合（即 <see cref="Route"/> 集合）,默认为true。
        /// </summary>
        [JsonProperty("returnRoutes")]
        public bool ReturnRoutes { get; set; }

#if !WINDOWS_PHONE
        #region ISerializable 成员
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ReturnEdgeFeatures", this.ReturnEdgeFeatures);
            info.AddValue("ReturnEdgeGeometry", this.ReturnEdgeGeometry);
            info.AddValue("ReturnEdgeIDs", this.ReturnEdgeIDs);
            info.AddValue("ReturnNodeFeatures", this.ReturnNodeFeatures);
            info.AddValue("ReturnNodeGeometry", this.ReturnNodeGeometry);
            info.AddValue("ReturnNodeIDs", this.ReturnNodeIDs);
            info.AddValue("ReturnPathGuides", this.ReturnPathGuides);
            info.AddValue("ReturnRoutes", this.ReturnRoutes);
        }

        private TransportationAnalystResultSetting(SerializationInfo info, StreamingContext context)
        {
            this.ReturnEdgeFeatures = info.GetBoolean("ReturnEdgeFeatures");
            this.ReturnEdgeGeometry = info.GetBoolean("ReturnEdgeGeometry");
            this.ReturnEdgeIDs = info.GetBoolean("ReturnEdgeIDs");
            this.ReturnNodeFeatures = info.GetBoolean("ReturnNodeFeatures");
            this.ReturnNodeGeometry = info.GetBoolean("ReturnNodeGeometry");
            this.ReturnNodeIDs = info.GetBoolean("ReturnNodeIDs");
            this.ReturnPathGuides = info.GetBoolean("ReturnPathGuides");
            this.ReturnRoutes = info.GetBoolean("ReturnRoutes");
        }
        #endregion
#endif
    }
}
