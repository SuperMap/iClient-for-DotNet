using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
#if !WINDOWS_PHONE
using System.Data;
#endif
using System.Globalization;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 记录集。用于存放空间对象信息的记录。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class Recordset
#else
    [Serializable]
    public class Recordset : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public Recordset()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="recordset">Recordset 对象实例。</param>
        public Recordset(Recordset recordset)
        {
            if (recordset == null) throw new ArgumentNullException("recordset", Resources.ArgumentIsNotNull);
            this.DatasetName = recordset.DatasetName;
            if (recordset.FieldCaptions != null)
            {
                this.FieldCaptions = new string[recordset.FieldCaptions.Length];
                for (int i = 0; i < recordset.FieldCaptions.Length; i++)
                {
                    this.FieldCaptions[i] = recordset.FieldCaptions[i];
                }
            }
            if (recordset.Features != null)
            {
                this.Features = new Feature[recordset.Features.Length];
                for (int i = 0; i < recordset.Features.Length; i++)
                {
                    if (recordset.Features[i] != null)
                    {
                        this.Features[i] = new Feature(recordset.Features[i]);
                    }
                }
            }
            if (recordset.Fields != null)
            {
                this.Fields = new string[recordset.Fields.Length];
                for (int i = 0; i < recordset.Fields.Length; i++)
                {
                    this.Fields[i] = recordset.Fields[i];
                }
            }
            if (recordset.FieldTypes != null)
            {
                this.FieldTypes = new FieldType[recordset.FieldTypes.Length];
                for (int i = 0; i < recordset.FieldTypes.Length; i++)
                {
                    this.FieldTypes[i] = recordset.FieldTypes[i];
                }
            }
        }

        /// <summary>
        /// 数据集的名称，是数据集的唯一标识。
        /// </summary>
        [JsonProperty("datasetName")]
        public string DatasetName { get; set; }

        /// <summary>
        /// 记录集中所有的地物要素。
        /// </summary>
        [JsonProperty("features")]
        public Feature[] Features { get; set; }

        /// <summary>
        /// 记录集中所有字段的别名。
        /// </summary>
        [JsonProperty("fieldCaptions")]
        public string[] FieldCaptions { get; set; }

        /// <summary>
        /// 记录集中所有字段的名称。
        /// </summary>
        [JsonProperty("fields")]
        public string[] Fields { get; set; }

        /// <summary>
        /// 记录集中所有字段的类型。
        /// </summary>
        [JsonProperty("fieldTypes")]
        public FieldType[] FieldTypes { get; set; }

#if !WINDOWS_PHONE
        /// <summary>
        /// 将Recordset对象转换为System.Data.DataTable对象。
        /// </summary>
        /// <returns>System.Data.DataTable对象。</returns>
        public DataTable ToDataTable()
        {
            DataTable table = new DataTable();
            table.Locale = CultureInfo.InvariantCulture;
            if (this.DatasetName != null)
            {
                table.TableName = this.DatasetName;
            }
            else
            {
                table.TableName = string.Empty;
            }

            if (this.Features != null && this.Features.Length > 0)
            {
                if (this.Fields != null && this.Fields.Length > 0)
                {
                    int colCount = this.Fields.Length;
                    for (int i = 0; i < colCount; i++)
                    {
                        string colName = this.Fields[i];
                        DataColumn column = new DataColumn(colName);
                        table.Columns.Add(column);
                    }
                }

                int rowCount = this.Features.Length;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = table.NewRow();
                    int offsetIndex = 0;
                    if (this.Features[i].FieldValues != null)
                    {
                        int valueCount = this.Features[i].FieldValues.Length;
                        for (int j = 0; j < valueCount; j++)
                        {
                            row[j + offsetIndex] = this.Features[i].FieldValues[j];
                        }
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
            table = null;
            return null;
        }
#endif

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DatasetName", this.DatasetName);
            info.AddValue("Features", this.Features);
            info.AddValue("FieldCaptions", this.FieldCaptions);
            info.AddValue("Fields", this.Fields);
            info.AddValue("FieldTypes", this.FieldTypes);
        }

        private Recordset(SerializationInfo info, StreamingContext context)
        {
            this.DatasetName = info.GetString("DatasetName");
            this.Features = (Feature[])info.GetValue("Features", typeof(Feature[]));
            this.FieldCaptions = (string[])info.GetValue("FieldCaptions", typeof(string[]));
            this.Fields = (string[])info.GetValue("Fields", typeof(string[]));
            this.FieldTypes = (FieldType[])info.GetValue("FieldTypes", typeof(FieldType[]));
        }
        #endregion
#endif
    }
}
