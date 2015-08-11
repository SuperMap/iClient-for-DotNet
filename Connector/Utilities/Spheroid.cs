using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 地球椭球体类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Spheroid
#else
    [Serializable]
    public sealed class Spheroid : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Spheroid()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="spheroid">地球椭球体对象。</param>
        /// <exception cref="ArgumentNullException">当地球椭球体对象为 Null 时抛出异常。</exception>
        public Spheroid(Spheroid spheroid)
        {
            if (spheroid == null) throw new ArgumentNullException();
            this.Axis = spheroid.Axis;
            this.Flatten = spheroid.Flatten;
            this.Name = spheroid.Name;
            this.Type = spheroid.Type;
        }
        /// <summary>
        /// 地球椭球体的长半径。
        /// </summary>
        [JsonProperty("axis")]
        public double Axis { get; set; }

        /// <summary>
        /// 地球椭球体的扁率。
        /// </summary>
        [JsonProperty("flatten")]
        public double Flatten { get; set; }

        /// <summary>
        /// 地球椭球体对象的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地球椭球体的类型。
        /// </summary>
        [JsonProperty("type")]
        public SpheroidType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private Spheroid(SerializationInfo info, StreamingContext context)
        {
            this.Axis = info.GetDouble("Axis");
            this.Flatten = info.GetDouble("Flatten");
            this.Name = info.GetString("Name");
            this.Type = (SpheroidType)info.GetValue("Type", typeof(SpheroidType));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Axis", this.Axis);
            info.AddValue("Flatten", this.Flatten);
            info.AddValue("Name", this.Name);
            info.AddValue("Type", this.Type);
        }
        #endregion
#endif
    }
}
