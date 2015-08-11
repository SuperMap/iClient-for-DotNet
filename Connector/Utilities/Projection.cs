using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 投影坐标系地图投影类。
    /// </summary>
    /// <remarks>
    /// 地图投影就是将球面坐标转化为平面坐标的过程。
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Projection
#else
    [Serializable]
    public sealed class Projection : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Projection()
        { }
        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="projection">投影坐标系地图投影对象。</param>
        /// <exception cref="ArgumentNullException">投影坐标系地图投影对象为 Null 时抛出异常。</exception>
        public Projection(Projection projection)
        { 
            if(projection == null) throw new ArgumentNullException();
            this.Name = projection.Name;
            this.Type = projection.Type;
        }

        ///<summary>
        ///投影方式名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
       
        /// <summary>
        /// 投影类型对象。
        /// </summary>
        [JsonProperty("type")]
        public ProjectionType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 特殊的构造函数。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        private Projection(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("Name");
            this.Type = (ProjectionType)info.GetValue("Type", typeof(ProjectionType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Type", this.Type);
        }
        #endregion
#endif
    }
}
