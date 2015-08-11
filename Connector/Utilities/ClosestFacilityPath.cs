using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 最近设施分析结果路径。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ClosestFacilityPath<T> : Path
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ClosestFacilityPath()
            : base()
        { }

        /// <summary>
        /// 最近设施点。当设置最近设施分析参数时，如果指定设施点时使用的是 ID 号，则返回结果也为 ID 号；如果使用的是坐标值，则返回结果也为坐标值。  
        /// </summary>
        [JsonProperty("facility")]
        public T Facility;

        /// <summary>
        /// 该路径所到达的最近设施点在候选设施点序列中的索引。  
        /// </summary>
        [JsonProperty("facilityIndex")]
        public int FacilityIndex;

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Facility", this.Facility);
            info.AddValue("FacilityIndex", this.FacilityIndex);
            base.GetObjectData(info, context);
        }

        private ClosestFacilityPath(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Facility = (T)info.GetValue("Facility", typeof(T));
            this.FacilityIndex = info.GetInt32("FacilityIndex");
        }
        #endregion
#endif
    }
}
