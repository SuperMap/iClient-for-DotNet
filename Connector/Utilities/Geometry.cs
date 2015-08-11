using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 几何对象类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(GeometryConverter))]
#if WINDOWS_PHONE
    public class Geometry
#else
    [Serializable]
    public class Geometry : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Geometry()
        {
            this.Type = GeometryType.UNKNOWN;
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="geometry">几何对象。</param>
        /// <exception cref="ArgumentNullException">几何对象为 null 时抛出异常。</exception>
        public Geometry(Geometry geometry)
        {
            if (geometry == null) throw new ArgumentNullException();
            this.Id = geometry.Id;
            if (geometry.Parts != null)
            {
                int length = geometry.Parts.Length;
                this.Parts = new int[length];
                for (int i = 0; i < length; i++)
                {
                    this.Parts[i] = geometry.Parts[i];
                }
            }
            if (geometry.Points != null)
            {
                int length = geometry.Points.Length;
                this.Points = new Point2D[length];
                for (int i = 0; i < length; i++)
                {
                    this.Points[i] = new Point2D(geometry.Points[i]);
                }
            }
            if (Style != null)
            {
                this.Style = new Style(geometry.Style);
            }
            this.Type = geometry.Type;
        }

        #region FromPoint, FromRect, FromPoints
        /// <summary>
        /// 根据一个地理坐标点创建一个几何点对象。
        /// </summary>
        /// <param name="point">坐标点</param>
        /// <returns>与指定坐标点相吻合的几何点对象。</returns>
        public Geometry(Point2D point)
        {
            if (point == null)
            {
                throw new ArgumentNullException("point", Resources.ArgumentIsNotNull);
            }

            this.Type = GeometryType.POINT;
            this.Parts = new int[1] { 1 };
            this.Points = new Point2D[1] { new Point2D(point) };
        }

        /// <summary>
        /// 根据一个地理矩形创建一个几何多边形对象。
        /// </summary>
        /// <param name="rect">矩形对象。</param>
        /// <returns>与指定矩形位置和形状相吻合的几何多边形对象。</returns>
        /// <remarks>
        /// 返回的几何多边形对象有5个坐标点，其中最后一个点和第一个点的位置相同。
        /// </remarks>
        public Geometry(Rectangle2D rect)
        {
            if (rect == null || rect.LeftBottom == null || rect.RightTop == null)
            {
                throw new ArgumentNullException("rect", Resources.ArgumentIsNotNull);
            }

            this.Type = GeometryType.RECTANGLE;
            this.Parts = new int[1] { 5 };
            this.Points = new Point2D[5];
            this.Points[0] = new Point2D(rect.LeftBottom);
            this.Points[1] = new Point2D(rect.RightTop.X, rect.LeftBottom.Y);
            this.Points[2] = new Point2D(rect.RightTop);
            this.Points[3] = new Point2D(rect.LeftBottom.X, rect.RightTop.Y);
            this.Points[4] = new Point2D(rect.LeftBottom);  //首尾相接是组件的惯用法。
        }

        /// <summary>
        /// 根据一组地理坐标点创建一个几何线对象或几何多边形对象。
        /// </summary>
        /// <param name="points">坐标点数组。</param>
        /// <param name="type">要创建的几何对象的类型，可以是 GeometryType.LINE 或者 GeometryType.REGION。</param>
        /// <returns>返回对应的几何线对象或几何多边形对象。</returns>
        public Geometry(Point2D[] points, GeometryType type)
        {
            if (points == null || points.Length < 2 || (type != GeometryType.LINE && type != GeometryType.REGION))
            {
                throw new ArgumentException(string.Format(Resources.ParamIsInvalid, "points"));
            }

            if (type == GeometryType.REGION && points.Length < 3)
            {
                throw new ArgumentException(string.Format(Resources.ParamIsInvalid, "points"));
            }
            this.Type = type;
            this.Parts = new int[1] { points.Length };
            this.Points = new Point2D[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                this.Points[i] = new Point2D(points[i]);
            }
        }
        #endregion

        ///<summary >
        ///几何对象唯一标识符。
        ///</summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///  描述几何对象中各个子对象所包含的节点的个数。
        /// </summary>
        [JsonProperty("parts")]
        public int[] Parts { get; set; }

        /// <summary>
        /// 组成几何对象的节点的二维坐标对数组。
        /// </summary>
        [JsonProperty("points")]
        public Point2D[] Points { get; set; }

        /// <summary>
        /// 几何对象的风格。
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }

        /// <summary>
        /// 几何对象的类型。
        /// </summary>
        [JsonProperty("type")]
        public GeometryType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", this.Type);
            info.AddValue("Style", this.Style);
            info.AddValue("Points", this.Points);
            info.AddValue("Parts", this.Parts);
            info.AddValue("Id", this.Id);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected Geometry(SerializationInfo info, StreamingContext context)
        {
            this.Type = (GeometryType)info.GetValue("Type", typeof(GeometryType));
            this.Style = (Style)info.GetValue("Style", typeof(Style));
            this.Parts = (int[])info.GetValue("Parts", typeof(int[]));
            this.Points = (Point2D[])info.GetValue("Points", typeof(Point2D[]));
            this.Id = info.GetInt32("Id");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 文本几何对象类。
    /// <para>
    /// 用以确定文本对象的风格和内容。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(GeometryConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class GeometryText : Geometry
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public GeometryText()
            : base()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="geometryText">文本几何对象。</param>
        public GeometryText(GeometryText geometryText)
            : base(geometryText)
        {
            if (geometryText == null) throw new ArgumentNullException();
            if (geometryText != null)
            {
                this.Texts = new string[geometryText.Texts.Length];
                for (int i = 0; i < geometryText.Texts.Length; i++)
                {
                    this.Texts[i] = geometryText.Texts[i];
                }
            }
            if (geometryText.TextStyle != null)
            {
                this.TextStyle = new TextStyle(geometryText.TextStyle);
            }
        }

        /// <summary>
        /// 文本对象的内容。
        /// </summary>
        [JsonProperty("texts")]
        public string[] Texts
        {
            get;
            set;
        }

        /// <summary>
        /// 文本对象的文本风格。
        /// </summary>
        [JsonProperty("textStyle")]
        public TextStyle TextStyle
        {
            get;
            set;
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TextStyle", this.TextStyle);
            info.AddValue("Texts", this.Texts);
            base.GetObjectData(info, context);
        }

        GeometryText(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Texts = (string[])info.GetValue("Texts", typeof(string[]));
            this.TextStyle = (TextStyle)info.GetValue("TextStyle", typeof(TextStyle));
        }

        #endregion
#endif
    }

    ///// <summary>
    ///// CAD几何对象类。
    ///// <para>
    ///// 该类用于描述CAD几何对象的一些特征。例如用中心点和半径来确定圆，用长宽来确定矩形等。
    ///// </para>
    ///// </summary>
    //[Serializable]
    //public sealed class GeometryCAD : Geometry
    //{
    //    /// <summary>
    //    /// 默认的构造函数。
    //    /// </summary>
    //    public GeometryCAD()
    //        : base()
    //    { }

    //    /// <summary>
    //    /// 拷贝的构造函数。
    //    /// </summary>
    //    /// <param name="geometryCAD"></param>
    //    public GeometryCAD(GeometryCAD geometryCAD)
    //        : base(geometryCAD)
    //    {
    //        if (geometryCAD == null) throw new ArgumentNullException();
    //        if (geometryCAD.Center != null)
    //        {
    //            this.Center = new Point2D(geometryCAD.Center);
    //        }
    //        if (geometryCAD.ControlPoints != null)
    //        {
    //            this.ControlPoints = new Point2D[geometryCAD.ControlPoints.Length];
    //            for (int i = 0; i < geometryCAD.ControlPoints.Length; i++)
    //            {
    //                this.ControlPoints[i] = new Point2D(geometryCAD.ControlPoints[i]);
    //            }
    //        }
    //        this.Height = geometryCAD.Height;
    //        this.Radius = geometryCAD.Radius;
    //        this.RadiusX = geometryCAD.RadiusX;
    //        this.RadiusY = geometryCAD.RadiusY;
    //        this.Rotation = geometryCAD.Rotation;
    //        this.SemimajorAxis = geometryCAD.SemimajorAxis;
    //        this.SemiminorAxis = geometryCAD.SemiminorAxis;
    //        this.StartAngle = geometryCAD.StartAngle;
    //        this.SweepAngle = geometryCAD.SweepAngle;
    //        this.Width = geometryCAD.Width;
    //    }

    //    /// <summary>
    //    /// 中心点。
    //    /// </summary>
    //    Point2D Center { get; set; }

    //    /// <summary>
    //    /// 控制点集合。
    //    /// </summary>
    //    Point2D[] ControlPoints { get; set; }

    //    /// <summary>
    //    /// 矩形高度。 
    //    /// </summary>
    //    double Height { get; set; }

    //    /// <summary>
    //    /// 半径。 
    //    /// </summary>
    //    double Radius { get; set; }

    //    /// <summary>
    //    /// 圆角长半轴长度。 
    //    /// </summary>
    //    double RadiusX { get; set; }

    //    /// <summary>
    //    ///圆角短半轴长度。 
    //    /// </summary>
    //    double RadiusY { get; set; }

    //    /// <summary>
    //    ///旋转角度。  
    //    /// </summary>
    //    double Rotation { get; set; }

    //    /// <summary>
    //    /// 椭圆长半轴。 
    //    /// </summary>
    //    double SemimajorAxis { get; set; }

    //    /// <summary>
    //    /// 椭圆短半轴。 
    //    /// </summary>
    //    double SemiminorAxis { get; set; }

    //    /// <summary>
    //    /// 起始角度。 
    //    /// </summary>
    //    double StartAngle { get; set; }

    //    /// <summary>
    //    /// 扫过的角度。 
    //    /// </summary>
    //    double SweepAngle { get; set; }

    //    /// <summary>
    //    /// 矩形宽度。 
    //    /// </summary>
    //    double Width { get; set; }

    //    #region  序列化/反序列化
    //    /// <summary>
    //    /// 序列化对象。
    //    /// </summary>
    //    /// <param name="info">要填充数据的SerializationInfo。</param>
    //    /// <param name="context">此序列化的目标。</param>
    //    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        base.GetObjectData(info, context);
    //        info.AddValue("Center", this.Center);
    //        info.AddValue("ControlPoints", this.ControlPoints);
    //        info.AddValue("Height", this.Height);
    //        info.AddValue("Radius", this.Radius);
    //        info.AddValue("RadiusX", this.RadiusX);
    //        info.AddValue("RadiusY", this.RadiusY);
    //        info.AddValue("Rotation", this.Rotation);
    //        info.AddValue("SemimajorAxis", this.SemimajorAxis);
    //        info.AddValue("SemiminorAxis", this.SemiminorAxis);
    //        info.AddValue("StartAngle", this.StartAngle);
    //        info.AddValue("SweepAngle", this.SweepAngle);
    //        info.AddValue("Width", this.Width);
    //    }

    //    private GeometryCAD(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //        this.Center = (Point2D)info.GetValue("Center", typeof(Point2D));
    //        this.ControlPoints = (Point2D[])info.GetValue("ControlPoints", typeof(Point2D[]));
    //        this.Height = info.GetDouble("Height");
    //        this.Radius = info.GetDouble("Radius");
    //        this.RadiusX = info.GetDouble("RadiusX");
    //        this.RadiusY = info.GetDouble("RadiusY");
    //        this.Rotation = info.GetDouble("Rotation");
    //        this.SemimajorAxis = info.GetDouble("SemimajorAxis");
    //        this.SemiminorAxis = info.GetDouble("SemiminorAxis");
    //        this.StartAngle = info.GetDouble("StartAngle");
    //        this.SweepAngle = info.GetDouble("SweepAngle");
    //        this.Width = info.GetDouble("Width");
    //    }
    //    #endregion
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    //public sealed class GeometryWithPrjCoordSys : Geometry
    //{
    //    /// <summary>
    //    /// 投影坐标系。 
    //    /// </summary>
    //    PrjCoordSys prj

    //}

    ///// <summary>
    ///// 
    ///// </summary>
    //public sealed class Route : Geometry
    //{ 

    //}
}
