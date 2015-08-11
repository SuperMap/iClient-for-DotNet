using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 几何对象空间分析结果设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class GeometrySpatialAnalystResultSetting
#else
    [Serializable]
    public class GeometrySpatialAnalystResultSetting : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public GeometrySpatialAnalystResultSetting()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="geometrySpatialAnalystResultSetting">GeometrySpatialAnalystResultSetting 对象实例。</param>
        /// <exception cref="ArgumentNullException">geometrySpatialAnalystResultSetting 为空时抛出异常。</exception>
        public GeometrySpatialAnalystResultSetting(GeometrySpatialAnalystResultSetting geometrySpatialAnalystResultSetting)
        {
            if (geometrySpatialAnalystResultSetting == null)
                throw new ArgumentNullException("geometrySpatialAnalystResultSetting", Resources.ArgumentIsNotNull);
            if (geometrySpatialAnalystResultSetting.ImageOutputOption != null)
            {
                this.ImageOutputOption = new ImageOutputOption(geometrySpatialAnalystResultSetting.ImageOutputOption);
            }
            if (geometrySpatialAnalystResultSetting.ImageParameter != null)
                this.ImageParameter = new ImageParameter(geometrySpatialAnalystResultSetting.ImageParameter);
            this.ReturnGeometry = geometrySpatialAnalystResultSetting.ReturnGeometry;
            this.ReturnImage = geometrySpatialAnalystResultSetting.ReturnImage;
        }

        /// <summary>
        /// 图片输出设置，包括图片的背景颜色、背景是否透明、图片输出的格式等设置。
        /// </summary>
        [JsonProperty("imageOutputOption")]
        public ImageOutputOption ImageOutputOption { get; set; }

        /// <summary>
        /// 图片参数设置，设置图片的范围、中心点、比例尺等。 
        /// </summary>
        [JsonProperty("imageParameter")]
        public ImageParameter ImageParameter { get; set; }

        private bool _returnGeometry = true;
        /// <summary>
        /// 分析完了是否返回几何对象，默认为true。
        /// </summary>
        [JsonProperty("returnGeometry")]
        public bool ReturnGeometry
        {
            get { return _returnGeometry; }
            set { _returnGeometry = value; }
        }

        /// <summary>
        /// 分析完了是否返回图片。 
        /// </summary>
        [JsonProperty("returnImage")]
        public bool ReturnImage { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ImageOutputOption", this.ImageOutputOption);
            info.AddValue("ImageParameter", this.ImageParameter);
            info.AddValue("ReturnGeometry", this.ReturnGeometry);
            info.AddValue("ReturnImage", this.ReturnImage);
        }

        private GeometrySpatialAnalystResultSetting(SerializationInfo info, StreamingContext context)
        {
            this.ImageParameter = (ImageParameter)info.GetValue("ImageParameter", typeof(ImageParameter));
            this.ImageOutputOption = (ImageOutputOption)info.GetValue("ImageOutputOption", typeof(ImageOutputOption));
            this.ReturnGeometry = info.GetBoolean("ReturnGeometry");
            this.ReturnImage = info.GetBoolean("ReturnGeometry");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 空间分析图片参数类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class ImageParameter
#else
    [Serializable]
    public class ImageParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ImageParameter()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="imageParameter">ImageParameter 对象实例。</param>
        /// <exception cref="ArgumentNullException">imageParameter 为空时抛出异常。</exception>
        public ImageParameter(ImageParameter imageParameter)
        {
            if (imageParameter == null) throw new ArgumentNullException("imageParameter", Resources.ArgumentIsNotNull);
            if (imageParameter.Bounds != null)
                this.Bounds = new Rectangle2D(imageParameter.Bounds);
            if (imageParameter.Center != null)
                this.Center = new Point2D(imageParameter.Center);
            if (imageParameter.PrjCoordSys != null)
                this.PrjCoordSys = new PrjCoordSys(imageParameter.PrjCoordSys);
            this.Scale = imageParameter.Scale;
            if (imageParameter.Style != null)
                this.Style = new Style(imageParameter.Style);
            if (imageParameter.Viewer != null)
                this.Viewer = new Rectangle(imageParameter.Viewer);
        }

        /// <summary>
        /// 图片的范围。 
        /// </summary>
        [JsonProperty("bounds")]
        public Rectangle2D Bounds { get; set; }

        /// <summary>
        /// 中心点,和比例尺一起决定图片范围。 
        /// </summary>
        [JsonProperty("center")]
        public Point2D Center { get; set; }

        /// <summary>
        /// 设置投影。 
        /// </summary>
        [JsonProperty("prjCoordSys")]
        public PrjCoordSys PrjCoordSys { get; set; }

        /// <summary>
        /// 比例尺，和中心点一起决定图片范围。 
        /// </summary>
        [JsonProperty("scale")]
        public double Scale { get; set; }

        /// <summary>
        /// 设置风格，包括点的风格，线的风格，面的风格等。 
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }

        /// <summary>
        /// 视窗。 
        /// </summary>
        [JsonProperty("viewer")]
        public Rectangle Viewer { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bounds", this.Bounds);
            info.AddValue("Center", this.Center);
            info.AddValue("PrjCoordSys", this.PrjCoordSys);
            info.AddValue("Scale", this.Scale);
            info.AddValue("Style", this.Style);
            info.AddValue("Viewer", this.Viewer);
        }

        private ImageParameter(SerializationInfo info, StreamingContext context)
        {
            this.Bounds = (Rectangle2D)info.GetValue("Bounds", typeof(Rectangle2D));
            this.Center = (Point2D)info.GetValue("Center", typeof(Point2D));
            this.PrjCoordSys = (PrjCoordSys)info.GetValue("PrjCoordSys", typeof(PrjCoordSys));
            this.Scale = info.GetDouble("Scale");
            this.Style = (Style)info.GetValue("Style", typeof(Style));
            this.Viewer = (Rectangle)info.GetValue("Viewer", typeof(Rectangle));
        }
        #endregion
#endif
    }
}
