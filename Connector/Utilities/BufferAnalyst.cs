using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 缓冲区分析参数类。左/右缓冲距离的设置仅对线对象/数据集有效，如果是点/面对象/数据集， 
    /// 则只需要设置左缓冲距离，即使设置了右缓冲距离，在做缓冲分析时也不起作用。
    /// 用于为缓冲区分析提供必要的参数信息。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class BufferAnalystParameter
#else
    [Serializable]
    public class BufferAnalystParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public BufferAnalystParameter()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="bufferAnalystParameter">BufferAnalystParameter 对象实例。</param>
        /// <exception cref="ArgumentNullException">bufferAnalystParameter 为空时抛出异常。</exception>
        public BufferAnalystParameter(BufferAnalystParameter bufferAnalystParameter)
        {
            if (bufferAnalystParameter == null)
                throw new ArgumentNullException("bufferAnalystParameter", Resources.ArgumentIsNotNull);
            this.EndType = bufferAnalystParameter.EndType;
            if (bufferAnalystParameter.LeftDistance != null)
                this.LeftDistance = new BufferDistance(bufferAnalystParameter.LeftDistance);
            if (bufferAnalystParameter.RightDistance != null)
                this.RightDistance = new BufferDistance(bufferAnalystParameter.RightDistance);
            this.SemicircleLineSegment = bufferAnalystParameter.SemicircleLineSegment;
        }

        /// <summary>
        /// 缓冲区端点类型。暂不支持平头缓冲。
        /// </summary>
        [JsonProperty("endType")]
        public BufferEndType EndType { get; set; }

        /// <summary>
        /// 左侧缓冲距离，单位：米。
        /// </summary>
        [JsonProperty("leftDistance")]
        public BufferDistance LeftDistance { get; set; }

        /// <summary>
        /// 右侧缓冲距离，单位：米。
        /// </summary>
        /// <remarks>右侧缓冲距离只对线类型的缓冲分析有效。</remarks>
        [JsonProperty("rightDistance")]
        public BufferDistance RightDistance { get; set; }

        private int _semicircleLineSegment = 4;
        /// <summary>
        /// 圆头缓冲圆弧处线段的个数，即用多少个线段来模拟一个半圆，默认值为4。
        /// </summary>
        [JsonProperty("semicircleLineSegment")]
        public int SemicircleLineSegment
        {
            get
            {
                return _semicircleLineSegment;
            }
            set { _semicircleLineSegment = value; }
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EndType", this.EndType);
            info.AddValue("RightDistance", this.RightDistance);
            info.AddValue("LeftDistance", this.LeftDistance);
            info.AddValue("SemicircleLineSegment", this.SemicircleLineSegment);
        }

        private BufferAnalystParameter(SerializationInfo info, StreamingContext context)
        {
            this.EndType = (BufferEndType)info.GetValue("EndType", typeof(BufferEndType));
            this.LeftDistance = (BufferDistance)info.GetValue("LeftDistance", typeof(BufferDistance));
            this.RightDistance = (BufferDistance)info.GetValue("RightDistance", typeof(BufferDistance));
            this.SemicircleLineSegment = info.GetInt32("SemicircleLineSegment");
        }

        #endregion
#endif
    }

    /// <summary>
    /// 缓冲距离，可以是数值型的或者是字段表达式。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class BufferDistance
#else
    [Serializable]
    public class BufferDistance : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public BufferDistance()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="bufferDistance">BufferDistance 对象实例。</param>
        /// <exception cref="ArgumentNullException">当参数 bufferDistance 为空时抛出异常。</exception>
        public BufferDistance(BufferDistance bufferDistance)
        {
            if (bufferDistance == null)
                throw new ArgumentNullException("bufferDistance", Resources.ArgumentIsNotNull);
            this.Exp = bufferDistance.Exp;
            this._value = bufferDistance.Value;
        }

        /// <summary>
        /// 使用表达式的计算值作为缓冲距离，表达式的结果需大于 0。
        /// </summary>
        [JsonProperty("exp")]
        public string Exp { get; set; }

        private double _value = uint.MinValue;
        /// <summary>
        /// 使用数值作为缓冲距离，为大于 0 的值。
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">当 value 不大于0时抛出异常。</exception>
        [JsonProperty("value")]
        public double Value
        {
            get { return _value; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value", string.Format(Resources.BufferDistanceGreateThan, "Value"));
                this._value = value;
            }
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", this.Value);
            info.AddValue("Exp", this.Exp);
        }

        private BufferDistance(SerializationInfo info, StreamingContext context)
        {
            this.Exp = info.GetString("Exp");
            this.Value = info.GetDouble("Value");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 缓冲区分析结果设置类。
    /// <para>对缓冲区分析的结果进行设置。包括是否合并结果数据集中相交的面、是否保留属性字段、是否 返回数据集、返回数据集的名称等。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class BufferResultSetting
#else
    [Serializable]
    public class BufferResultSetting : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public BufferResultSetting()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="bufferResultSetting">BufferResultSetting 对象实例。</param>
        /// <exception cref="ArgumentNullException">bufferResultSetting 为空时抛出异常。</exception>
        public BufferResultSetting(BufferResultSetting bufferResultSetting)
        {
            if (bufferResultSetting == null)
                throw new ArgumentNullException("bufferDistance", Resources.ArgumentIsNotNull);
            if (bufferResultSetting.DataReturnOption != null)
                this.DataReturnOption = new DataReturnOption(bufferResultSetting.DataReturnOption);
            this.IsAttributeRetained = bufferResultSetting.IsAttributeRetained;
            this.IsUnion = bufferResultSetting.IsUnion;
        }

        /// <summary>
        /// 数据返回选项。
        /// </summary>
        [JsonProperty("dataReturnOption")]
        public DataReturnOption DataReturnOption { get; set; }

        /// <summary>
        /// 是否保留进行缓冲区分析的对象的字段属性，当 IsUnion 为 ture 时无效。
        /// </summary>
        [JsonProperty("isAttributeRetained")]
        public bool IsAttributeRetained { get; set; }

        /// <summary>
        /// 是否合并结果数据集中相交的面。
        /// </summary>
        [JsonProperty("isUnion")]
        public bool IsUnion { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DataReturnOption", this.DataReturnOption);
            info.AddValue("IsUnion", this.IsUnion);
            info.AddValue("IsAttributeRetained", this.IsAttributeRetained);
        }

        BufferResultSetting(SerializationInfo info, StreamingContext context)
        {
            this.DataReturnOption = (DataReturnOption)info.GetValue("DataReturnOption", typeof(DataReturnOption));
            this.IsAttributeRetained = info.GetBoolean("IsAttributeRetained");
            this.IsUnion = info.GetBoolean("IsUnion");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 空间分析数据返回选项类。
    /// <para
    /// <para>该类主要用来设置空间分析完成后，返回的数据的一些选项。包括数据返回模式、返回的最大记录数、 结果数据集名称，如果重名如何处置等。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class DataReturnOption
#else
    [Serializable]
    public class DataReturnOption : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public DataReturnOption()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="dataReturnOption">DataReturnOption 对象实例。</param>
        /// <exception cref="ArgumentNullException">dataReturnOption 为空时抛出异常。</exception>
        public DataReturnOption(DataReturnOption dataReturnOption)
        {
            if (dataReturnOption == null)
                throw new ArgumentNullException("dataReturnOption", Resources.ArgumentIsNotNull);
            this.DataReturnMode = dataReturnOption.DataReturnMode;
            this.Dataset = dataReturnOption.Dataset;
            this.DeleteExistResultDataset = dataReturnOption.DeleteExistResultDataset;
            this.ExpectCount = dataReturnOption.ExpectCount;
        }

        /// <summary>
        /// 数据返回模式，默认为DataReturnMode.DATASET_ONLY。
        /// </summary>
        [JsonProperty("dataReturnMode")]
        public DataReturnMode DataReturnMode { get; set; }

        /// <summary>
        /// 设置结果数据集标识 当dataReturnMode为 DataReturnMode.DATASET_ONLY或DataReturnMode.DATASET_AND_RECORDSET时有效，作为返回数据集的名称。
        /// </summary>
        [JsonProperty("dataset")]
        public string Dataset { get; set; }

        /// <summary>
        ///  如果命名的结果数据集名称与已有的数据集重名，是否删除已有的数据集。
        /// </summary>
        [JsonProperty("deleteExistResultDataset")]
        public bool DeleteExistResultDataset { get; set; }

        /// <summary>
        /// 设置返回的最大记录数，当dataReturnMode为 DataReturnMode.RECORDSET_ONLY或DataReturnMode.DATASET_AND_RECORDSET时有效，小于或者等于0时表示返回所有。
        /// </summary>
        [JsonProperty("expectCount")]
        public int ExpectCount { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DataReturnMode", this.DataReturnMode);
            info.AddValue("Dataset", this.Dataset);
            info.AddValue("DeleteExistResultDataset", this.DeleteExistResultDataset);
            info.AddValue("ExpectCount", this.ExpectCount);
        }

        private DataReturnOption(SerializationInfo info, StreamingContext context)
        {
            this.DataReturnMode = (Utility.DataReturnMode)info.GetValue("DataReturnMode", typeof(DataReturnMode));
            this.Dataset = info.GetString("Dataset");
            this.DeleteExistResultDataset = info.GetBoolean("DeleteExistResultDataset");
            this.ExpectCount = info.GetInt32("ExpectCount");
        }
        #endregion
#endif
    }
}
