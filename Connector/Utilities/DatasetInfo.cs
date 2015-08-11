using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 数据集信息。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(DatasetInfoConverter))]
#if WINDOWS_PHONE
    public class DatasetInfo
#else
    [Serializable]
    public class DatasetInfo : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public DatasetInfo()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="datasetInfo">数据集信息对象。</param>
        /// <exception cref="ArgumentNullException">当数据集信息对象为 Null 时抛出异常。</exception>
        public DatasetInfo(DatasetInfo datasetInfo)
        {
            if (datasetInfo == null) throw new ArgumentNullException("datasetInfo", Resources.ArgumentIsNotNull);
            if (datasetInfo.Bounds != null)
                this.Bounds = new Rectangle2D(datasetInfo.Bounds);
            this.DataSourceName = datasetInfo.DataSourceName;
            this.Description = datasetInfo.Description;
            this.EncodeType = datasetInfo.EncodeType;
            this.IsReadOnly = datasetInfo.IsReadOnly;
            this.Name = datasetInfo.Name;
            if (datasetInfo.PrjCoordSys != null)
                this.PrjCoordSys = new PrjCoordSys(datasetInfo.PrjCoordSys);
            this.TableName = datasetInfo.TableName;
            this.Type = datasetInfo.Type;
        }
        ///<summary>
        ///数据集范围。
        ///</summary>
        [JsonProperty("bounds")]
        public Rectangle2D Bounds { get; set; }

        /// <summary>
        /// 数据源名称。
        /// </summary>
        [JsonProperty("dataSourceName")]
        public string DataSourceName { get; set; }

        /// <summary>
        /// 数据集的描述信息。
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 数据集存储时的压缩编码方式。
        /// </summary>
        [JsonProperty("encodeType")]
        public EncodeType EncodeType { get; set; }

        /// <summary>
        /// 数据集是否为只读。
        /// </summary>
        [JsonProperty("isReadOnly")]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// 数据集名称，该字段必须。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 数据集的投影信息。
        /// </summary>
        [JsonProperty("prjCoordSys")]
        public PrjCoordSys PrjCoordSys { get; set; }

        /// <summary>
        /// 表名。
        /// </summary>
        [JsonProperty("tableName")]
        public string TableName { get; set; }

        /// <summary>
        /// 数据集类型，该字段必须。
        /// </summary>
        [JsonProperty("type")]
        public DatasetType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected DatasetInfo(SerializationInfo info, StreamingContext context)
        {
            this.Bounds = (Rectangle2D)info.GetValue("Bounds", typeof(Rectangle2D));
            this.DataSourceName = info.GetString("DataSourceName");
            this.Description = info.GetString("Description");
            this.EncodeType = (EncodeType)info.GetValue("EncodeType", typeof(EncodeType));
            this.IsReadOnly = info.GetBoolean("IsReadOnly");
            this.Name = info.GetString("Name");
            this.PrjCoordSys = (PrjCoordSys)info.GetValue("PrjCoordSys", typeof(PrjCoordSys));
            this.TableName = info.GetString("TableName");
            this.Type = (DatasetType)info.GetValue("Type", typeof(DatasetType));
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bounds", this.Bounds);
            info.AddValue("DataSourceName", this.DataSourceName);
            info.AddValue("Description", this.Description);
            info.AddValue("EncodeType", this.EncodeType);
            info.AddValue("IsReadOnly", this.IsReadOnly);
            info.AddValue("Name", this.Name);
            info.AddValue("PrjCoordSys", this.PrjCoordSys);
            info.AddValue("TableName", this.TableName);
            info.AddValue("Type", this.Type);
        }
        #endregion
#endif
    }

    /// <summary>
    /// 栅格数据集信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(DatasetInfoConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class DatasetGridInfo : DatasetInfo
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public DatasetGridInfo()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="datasetGridInfo">栅格数据集对象。</param>
        /// <exception cref="ArgumentNullException">当栅格数据集信息对象为 Null 时抛出异常。</exception>
        public DatasetGridInfo(DatasetGridInfo datasetGridInfo)
            : base(datasetGridInfo)
        {
            if (datasetGridInfo == null) throw new ArgumentNullException("datasetGridInfo", Resources.ArgumentIsNotNull);
            this.BlockSize = datasetGridInfo.BlockSize;
            this.Height = datasetGridInfo.Height;
            this.MaxValue = datasetGridInfo.MaxValue;
            this.MinValue = datasetGridInfo.MinValue;
            this.NoValue = datasetGridInfo.NoValue;
            this.PixelFormat = datasetGridInfo.PixelFormat;
            this.Width = datasetGridInfo.Width;
        }

        /// <summary>
        /// 栅格数据集按像素分块存储，每一块的大小，该字段只读。
        /// </summary>
        [JsonProperty("blockSize")]
        public int BlockSize { get; set; }

        /// <summary>
        /// 栅格数据的高度，该字段只读。
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 栅格数据集栅格行列中的最大值。
        /// </summary>
        [JsonProperty("maxValue")]
        public double MaxValue { get; set; }

        /// <summary>
        /// 栅格数据集栅格行列中的最小值。
        /// </summary>
        [JsonProperty("minValue")]
        public double MinValue { get; set; }

        /// <summary>
        /// 栅格数据集中没有数据的像元的栅格值。
        /// </summary>
        [JsonProperty("noValue")]
        public double NoValue { get; set; }

        /// <summary>
        /// 栅格数据存储的像素格式，该字段只读。
        /// </summary>
        [JsonProperty("pixelFormat")]
        public PixelFormat PixelFormat { get; set; }

        /// <summary>
        /// 栅格数据的宽度，该字段只读。
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BlockSize", this.BlockSize);
            info.AddValue("Height", this.Height);
            info.AddValue("MaxValue", this.MaxValue);
            info.AddValue("MinValue", this.MinValue);
            info.AddValue("NoValue", this.NoValue);
            info.AddValue("PixelFormat", this.PixelFormat);
            info.AddValue("Width", this.Width);
            base.GetObjectData(info, context);
        }

        DatasetGridInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.BlockSize = info.GetInt32("BlockSize");
            this.Height = info.GetInt32("Height");
            this.MaxValue = info.GetDouble("MaxValue");
            this.MinValue = info.GetDouble("MinValue");
            this.NoValue = info.GetDouble("NoValue");
            this.PixelFormat = (PixelFormat)info.GetValue("PixelFormat", typeof(PixelFormat));
            this.Width = info.GetInt32("Width");
        }
        #endregion
#endif
    }


    /// <summary>
    /// 影像数据集信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(DatasetInfoConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class DatasetImageInfo : DatasetInfo
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public DatasetImageInfo()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="datasetImageInfo">影像数据集对象。</param>
        /// <exception cref="ArgumentNullException">当影像数据集信息对象为 Null 时抛出异常。</exception>
        public DatasetImageInfo(DatasetImageInfo datasetImageInfo)
            : base(datasetImageInfo)
        {
            if (datasetImageInfo == null) throw new ArgumentNullException("datasetImageInfo", Resources.ArgumentIsNotNull);
            this.BlockSize = datasetImageInfo.BlockSize;
            this.Height = datasetImageInfo.Height;
            this.PixelFormat = datasetImageInfo.PixelFormat;
            this.Width = datasetImageInfo.Width;
            this.IsMultiBand = datasetImageInfo.IsMultiBand;
            if (datasetImageInfo.Palette != null)
            {
                int length = datasetImageInfo.Palette.Length;
                this.Palette = new Color[length];
                for (int i = 0; i < length; i++)
                {
                    this.Palette[i] = new Color(datasetImageInfo.Palette[i]);
                }
            }
        }

        /// <summary>
        /// 影像数据集按像素分块存储，每一块的大小，该字段只读。
        /// </summary>
        [JsonProperty("blockSize")]
        public int BlockSize { get; set; }

        /// <summary>
        /// 影像数据的高度，该字段只读。
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 影像数据集是否是多波段影像数据集，该字段只读。
        /// </summary>
        [JsonProperty("isMultiBand")]
        public bool IsMultiBand { get; set; }

        /// <summary>
        /// 影像数据的颜色调色板。
        /// </summary>
        [JsonProperty("palette")]
        public Color[]  Palette { get; set; }

        /// <summary>
        /// 影像数据存储的像素格式，该字段只读。
        /// </summary>
        [JsonProperty("pixelFormat")]
        public PixelFormat PixelFormat { get; set; }

        /// <summary>
        /// 影像数据的宽度，该字段只读。
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BlockSize", this.BlockSize);
            info.AddValue("Height", this.Height);
            info.AddValue("IsMultiBand", this.IsMultiBand);
            info.AddValue("Palette", this.Palette);
            info.AddValue("PixelFormat", this.PixelFormat);
            info.AddValue("Width", this.Width);
            base.GetObjectData(info, context);
        }

        DatasetImageInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.BlockSize = info.GetInt32("BlockSize");
            this.Height = info.GetInt32("Height");
            this.IsMultiBand = info.GetBoolean("IsMultiBand");
            this.Palette = (Color[])info.GetValue("Palette", typeof(Color[]));
            this.PixelFormat = (PixelFormat)info.GetValue("PixelFormat", typeof(PixelFormat));
            this.Width = info.GetInt32("Width");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 矢量数据集信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(DatasetInfoConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class DatasetVectorInfo : DatasetInfo
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public DatasetVectorInfo()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="datasetVectorInfo">矢量数据集对象。</param>
        /// <exception cref="ArgumentNullException">当影像数据集信息对象为 Null 时抛出异常。</exception>
        public DatasetVectorInfo(DatasetVectorInfo datasetVectorInfo)
            : base(datasetVectorInfo)
        {
            if (datasetVectorInfo == null) throw new ArgumentNullException("datasetVectorInfo", Resources.ArgumentIsNotNull);
            this.Charset = datasetVectorInfo.Charset;
            this.IsFileCache = datasetVectorInfo.IsFileCache;
            this.RecordCount = datasetVectorInfo.RecordCount;
        }

        /// <summary>
        /// 矢量数据集的字符集。
        /// </summary>
        [JsonProperty("charset")]
        public Charset Charset { get; set; }

        /// <summary>
        /// 是否使用文件形式的缓存。
        /// </summary>
        [JsonProperty("isFileCache")]
        public bool IsFileCache { get; set; }

        /// <summary>
        /// 矢量数据集中的记录数。
        /// </summary>
        [JsonProperty("recordCount")]
        public int RecordCount { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Charset", this.Charset);
            info.AddValue("IsFileCache", this.IsFileCache);
            info.AddValue("RecordCount", this.RecordCount);
            base.GetObjectData(info, context);
        }

        DatasetVectorInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.RecordCount = info.GetInt32("RecordCount");
            this.IsFileCache = info.GetBoolean("IsFileCache");
            this.Charset = (Charset)info.GetValue("Charset", typeof(Charset));
        }
        #endregion
#endif
    }
}
