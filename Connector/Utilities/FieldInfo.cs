using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>
    /// 字段信息类。
    /// </para>
    /// <para>一个字段对应属性表的一列。字段名称以“SM”开头的表示是 SuperMap 系统字段，对于系统字段，只有字段的别名（<see cref="Caption"/>）可以修改，其他属性不能被修改。</para>
    /// <para>
    /// 字段信息类用来存储字段的名称、类型、默认值以及长度等相关信息。 每一个字段对应一个 <see cref="FieldInfo"/>。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class FieldInfo
#else
    [Serializable]
    public class FieldInfo : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public FieldInfo()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="fieldInfo"><see cref="FieldInfo"/> 对象实例。</param>
        /// <exception cref="ArgumentNullException">参数 fieldInfo 为空时抛出异常。</exception>
        public FieldInfo(FieldInfo fieldInfo)
        {
            if (fieldInfo == null)
            {
                throw new ArgumentNullException("fieldInfo");
            }
            else
            {
                this.Caption = fieldInfo.Caption;
                this.DefaultValue = fieldInfo.DefaultValue;
                this.IsRequired = fieldInfo.IsRequired;
                this.IsSystemField = fieldInfo.IsSystemField;
                this.IsZeroLengthAllowed = fieldInfo.IsZeroLengthAllowed;
                this.MaxLength = fieldInfo.MaxLength;
                this.Name = fieldInfo.Name;
                this.Type = fieldInfo.Type;
            }
        }

        /// <summary>
        /// 字段别名。 
        /// <para>
        /// 别名可以不唯一，即不同的字段可以有相同的别名。
        /// </para>
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 字段的默认值。 
        /// </summary>
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        /// <summary>
        /// 是否为必填字段。 
        /// <para>true 表示是必填字段，false 表示非必填字段。 </para>
        /// </summary>
        [JsonProperty("isRequired")]
        public bool IsRequired { get; set; }

        /// <summary>
        /// 是否为 SuperMap 系统字段，true 表示是 SuperMap 系统字段。 只读。
        /// <para>SuperMap 系统字段是以 SM 为前缀的字段，SMUserID 除外。</para>
        /// </summary>
        [JsonProperty("isSystemField")]
        public bool IsSystemField { get; set; }

        /// <summary>
        /// 是否允许零长度。 
        /// </summary>
        [JsonProperty("isZeroLengthAllowed")]
        public bool IsZeroLengthAllowed { get; set; }

        /// <summary>
        /// 字段的最大长度。 
        /// </summary>
        [JsonProperty("maxLength")]
        public int MaxLength { get; set; }

        /// <summary>
        /// 字段名称。 
        /// <para>
        /// 名称是用来唯一标识一个字段的，不可重名。
        /// </para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 字段类型。
        /// </summary>
        [JsonProperty("type")]
        public FieldType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Caption", this.Caption);
            info.AddValue("DefaultValue", this.DefaultValue);
            info.AddValue("IsRequired", this.IsRequired);
            info.AddValue("IsSystemField", this.IsSystemField);
            info.AddValue("IsZeroLengthAllowed", this.IsZeroLengthAllowed);
            info.AddValue("MaxLength", this.MaxLength);
            info.AddValue("Name", this.Name);
            info.AddValue("Type", this.Type);
        }

        private FieldInfo(SerializationInfo info, StreamingContext context)
        {
            this.Caption = info.GetString("Caption");
            this.DefaultValue = info.GetString("DefaultValue");
            this.IsRequired = info.GetBoolean("IsRequired");
            this.IsSystemField = info.GetBoolean("IsSystemField");
            this.IsZeroLengthAllowed = info.GetBoolean("IsZeroLengthAllowed");
            this.MaxLength = info.GetInt32("MaxLength");
            this.Name = info.GetString("Name");
            this.Type = (FieldType)info.GetValue("Type", typeof(FieldType));
        }
        #endregion
#endif
    }
}
