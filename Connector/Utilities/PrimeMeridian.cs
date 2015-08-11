using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 中央子午线类。
    /// </summary>
    /// <remarks>
    /// 该对象主要应用于地理坐标系中，地理坐标系由三部分组成：中央子午线、参照系或者大地基准（Datum）和角度单位。
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class PrimeMeridian
#else
    [Serializable]
    public sealed class PrimeMeridian : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public PrimeMeridian()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="primeMeridian">中央子午线对象。</param>
        /// <exception cref="ArgumentNullException">当中央子午线对象为 Null 时抛出异常。</exception>
        public PrimeMeridian(PrimeMeridian primeMeridian)
        {
            if (primeMeridian == null) throw new ArgumentNullException();
            this.LongitudeValue = primeMeridian.LongitudeValue;
            this.Name = primeMeridian.Name;
            this.Type = primeMeridian.Type;
        }
        ///<summary>
        /// 中央经线值，单位为度。
        /// </summary>
        [JsonProperty("longitudeValue")]
        public double LongitudeValue { get; set; }

        /// <summary>
        /// 中央经线对象的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 中央经线的类型。
        /// </summary>
        [JsonProperty("type")]
        public PrimeMeridianType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private PrimeMeridian(SerializationInfo info, StreamingContext context)
        {
            this.LongitudeValue = info.GetDouble("LongitudeValue");
            this.Name = info.GetString("Name");
            this.Type = (PrimeMeridianType)info.GetValue("Type", typeof(PrimeMeridianType));
        }
        
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LongitudeValue", this.LongitudeValue);
            info.AddValue("Name", this.Name);
            info.AddValue("Type", this.Type);
        }

        #endregion
#endif
    }
}
