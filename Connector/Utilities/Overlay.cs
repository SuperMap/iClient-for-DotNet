using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 数据集叠加分析结果设置类。
    /// </summary>
    /// <remarks>设置结果数据集字段时，如果 sourceDataset 和 operateDataset 中有相同的字段名（比如两个数据集都有 Code 字段），
    /// 则 sourceDataset 中的字段保留到结果数据集中自动设为 Code_1，operateDataset 中的 Code 字段保留到结果数据集中自动设为 Code_2。</remarks>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class DatasetOverlayResultSetting
#else
    [Serializable]
    public class DatasetOverlayResultSetting : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public DatasetOverlayResultSetting()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="datasetOverlayResultSetting">DatasetOverlayResultSetting 对象实例。</param>
        /// <exception cref="ArgumentNullException">datasetOverlayResultSetting 为空时抛出异常。</exception>
        public DatasetOverlayResultSetting(DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
            if (datasetOverlayResultSetting == null)
                throw new ArgumentNullException("datasetOverlayResultSetting", Resources.ArgumentIsNotNull);
            if (datasetOverlayResultSetting.DataReturnOption != null)
                this.DataReturnOption = new DataReturnOption(datasetOverlayResultSetting.DataReturnOption);
            if (datasetOverlayResultSetting.OperateDatasetFields != null)
            {
                this.OperateDatasetFields = new string[datasetOverlayResultSetting.OperateDatasetFields.Length];
                for (int i = 0; i < datasetOverlayResultSetting.OperateDatasetFields.Length; i++)
                {
                    this.OperateDatasetFields[i] = datasetOverlayResultSetting.OperateDatasetFields[i];
                }
            }
            if (datasetOverlayResultSetting.SourceDatasetFields != null)
            {
                this.SourceDatasetFields = new string[datasetOverlayResultSetting.SourceDatasetFields.Length];
                for (int i = 0; i < datasetOverlayResultSetting.SourceDatasetFields.Length; i++)
                {
                    this.SourceDatasetFields[i] = datasetOverlayResultSetting.SourceDatasetFields[i];
                }
            }
            this.Tolerance = datasetOverlayResultSetting.Tolerance;
        }

        /// <summary>
        /// 返回的结果设置，包括返回的结果数据集的名称、返回的最大记录数、数据返回模式等。
        /// </summary>
        [JsonProperty("dataReturnOption")]
        public DataReturnOption DataReturnOption { get; set; }

        /// <summary>
        /// 叠加数据集保留在结果数据集中的字段名列表。
        /// </summary>
        [JsonProperty("operateDatasetFields")]
        public string[] OperateDatasetFields { get; set; }

        /// <summary>
        /// 源数据集保留在结果数据集中的字段名列表。
        /// </summary>
        [JsonProperty("sourceDatasetFields")]
        public string[] SourceDatasetFields { get; set; }

        /// <summary>
        /// 叠加分析的容限值。
        /// </summary>
        [JsonProperty("tolerance")]
        public double Tolerance { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private DatasetOverlayResultSetting(SerializationInfo info, StreamingContext context)
        {
            this.Tolerance = info.GetDouble("Tolerance");
            this.SourceDatasetFields = (string[])info.GetValue("SourceDatasetFields", typeof(string[]));
            this.OperateDatasetFields = (string[])info.GetValue("OperateDatasetFields", typeof(string[]));
            this.DataReturnOption = (DataReturnOption)info.GetValue("DataReturnOption", typeof(DataReturnOption));
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Tolerance", this.Tolerance);
            info.AddValue("SourceDatasetFields", this.SourceDatasetFields);
            info.AddValue("OperateDatasetFields", this.OperateDatasetFields);
            info.AddValue("DataReturnOption", this.DataReturnOption);
        }
        #endregion
#endif
    }
}
