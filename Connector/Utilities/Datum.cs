using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 大地参照系类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Datum
#else
    [Serializable]
    public sealed class Datum : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Datum()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="datum">大地坐标系对象。</param>
        /// <exception cref="ArgumentNullException">当大地坐标系对象为 Null 时抛出异常。</exception>
        public Datum(Datum datum)
        {
            if (datum == null) throw new ArgumentNullException();
            this.Name = datum.Name;
            if (datum.Spheroid != null)
                this.Spheroid = new Spheroid(datum.Spheroid);
            this.Type = datum.Type;
        }

        ///<summary>
        ///大地参照系名称。
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地球椭球体对象。
        /// </summary>
        [JsonProperty("spheroid")]
        public Spheroid Spheroid { get; set; }

        /// <summary>
        /// 大地参照系类型对象。
        /// </summary>
        [JsonProperty("type")]
        public DatumType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private Datum(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("Name");
            this.Spheroid = (Spheroid)info.GetValue("Spheroid", typeof(Spheroid));
            this.Type = (DatumType)info.GetValue("Type", typeof(DatumType));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Spheroid", this.Spheroid);
            info.AddValue("Type", this.Type);
        }
        #endregion
#endif
    }
}
