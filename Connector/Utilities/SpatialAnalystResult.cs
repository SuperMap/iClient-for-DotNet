using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.IO;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 空间分析结果类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class SpatialAnalystResult
#else
    [Serializable]
    public class SpatialAnalystResult : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public SpatialAnalystResult()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="spatialAnalystResult">SpatialAnalystResult 对象实例。</param>
        /// <exception cref="ArgumentNullException">spatialAnalystResult 为空时抛出异常。</exception>
        public SpatialAnalystResult(SpatialAnalystResult spatialAnalystResult)
        {
            if (spatialAnalystResult == null) throw new ArgumentNullException("spatialAnalystResult", Resources.ArgumentIsNotNull);
            this.Message = spatialAnalystResult.Message;
            this.Succeed = spatialAnalystResult.Succeed;
        }

        /// <summary>
        /// 空间分析失败时返回的信息。
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 空间分析是否成功。
        /// </summary>
        [JsonProperty("succeed")]
        public bool Succeed { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Message", this.Message);
            info.AddValue("Message", this.Succeed);
        }

        protected SpatialAnalystResult(SerializationInfo info, StreamingContext context)
        {
            this.Message = info.GetString("Message");
            this.Succeed = info.GetBoolean("Succeed");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 数据集空间分析结果类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class DatasetSpatialAnalystResult : SpatialAnalystResult
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public DatasetSpatialAnalystResult()
            : base()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="datasetSpatialAnalystResult">DatasetSpatialAnalystResult 对象实例。</param>
        /// <exception cref="ArgumentNullException">datasetSpatialAnalystResult 为空时抛出异常。</exception>
        public DatasetSpatialAnalystResult(DatasetSpatialAnalystResult datasetSpatialAnalystResult)
            : base(datasetSpatialAnalystResult)
        {
            if (datasetSpatialAnalystResult == null) throw new ArgumentNullException("datasetSpatialAnalystResult", Resources.ArgumentIsNotNull);
            this.Dataset = datasetSpatialAnalystResult.Dataset;
            if (datasetSpatialAnalystResult.Recordset != null)
                this.Recordset = new Recordset(datasetSpatialAnalystResult.Recordset);
        }

        /// <summary>
        /// 结果数据集标识。
        /// </summary>
        [JsonProperty("dataset")]
        public string Dataset { get; set; }

        /// <summary>
        /// 结果记录集。 
        /// </summary>
        [JsonProperty("recordset")]
        public Recordset Recordset { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Dataset", this.Dataset);
            info.AddValue("Recordset", this.Recordset);
            base.GetObjectData(info, context);
        }

        protected DatasetSpatialAnalystResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Dataset = info.GetString("Dataset");
            this.Recordset = (Recordset)info.GetValue("Recordset", typeof(Recordset));
        }
        #endregion
#endif
    }

    /// <summary>
    /// 几何对象空间分析结果类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class GeometrySpatialAnalystResult : SpatialAnalystResult
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public GeometrySpatialAnalystResult()
            : base()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="geometrySpatialAnalystResult">GeometrySpatialAnalystResult 对象实例。</param>
        /// <exception cref="ArgumentNullException">geometrySpatialAnalystResult 为空时抛出异常。</exception>
        public GeometrySpatialAnalystResult(GeometrySpatialAnalystResult geometrySpatialAnalystResult)
            : base(geometrySpatialAnalystResult)
        {
            if (geometrySpatialAnalystResult == null) throw new ArgumentNullException("geometrySpatialAnalystResult", Resources.ArgumentIsNotNull);
            if (geometrySpatialAnalystResult.ResultGeometry != null)
                this.ResultGeometry = new Geometry(geometrySpatialAnalystResult.ResultGeometry);
            //if (geometrySpatialAnalystResult.Image != null)
            //    this.Image = new ImageResult(geometrySpatialAnalystResult.Image);
        }

        /// <summary>
        /// 空间分析结果几何对象。
        /// </summary>
        [JsonProperty("resultGeometry")]
        public Geometry ResultGeometry { get; set; }

        /// <summary>
        /// 空间分析结果图片。 
        /// </summary>
        //[JsonProperty("image")]
        //public ImageResult Image { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ResultGeometry", this.ResultGeometry);
            //info.AddValue("Image", this.Image);
            base.GetObjectData(info, context);
        }

        protected GeometrySpatialAnalystResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ResultGeometry = (Geometry)info.GetValue("ResultGeometry", typeof(Geometry));
            //this.Image = (ImageResult)info.GetValue("Image", typeof(ImageResult));
        }
        #endregion
#endif
    }

    /// <summary>
    /// 空间分析结果图片类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class ImageResult
#else
    [Serializable]
    public class ImageResult : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ImageResult()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="imageResult">ImageResult 对象实例。</param>
        /// <exception cref="ArgumentNullException">imageResult 为空时抛出异常。</exception>
        public ImageResult(ImageResult imageResult)
        {
            if (imageResult == null) throw new ArgumentNullException("imageResult", Resources.ArgumentIsNotNull);
            this.ImageURL = imageResult.ImageURL;
            if (imageResult.ImageParameter != null)
                this.ImageParameter = new ImageParameter(imageResult.ImageParameter);
            if (imageResult.ImageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageResult.ImageData))
                {
                    this.ImageData = ms.ToArray();
                }
            }
        }

        /// <summary>
        /// 图片的二进制流。 
        /// </summary>
        [JsonProperty("imageData")]
        public byte[] ImageData { get; set; }

        /// <summary>
        /// 图片的参数，如图片的范围、比例尺、风格等。 
        /// </summary>
        [JsonProperty("imageParameter")]
        public ImageParameter ImageParameter { get; set; }

        /// <summary>
        /// 图片的 URL 地址。 
        /// </summary>
        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ImageData", this.ImageData);
            info.AddValue("ImageParameter", this.ImageParameter);
            info.AddValue("ImageURL", this.ImageURL);
        }

        private ImageResult(SerializationInfo info, StreamingContext context)
        {
            this.ImageURL = info.GetString("ImageURL");
            this.ImageParameter = (ImageParameter)info.GetValue("ImageParameter", typeof(ImageParameter));
            this.ImageData = (byte[])info.GetValue("ImageData", typeof(byte[]));
        }
        #endregion
#endif
    }
}
