using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;
using System.Drawing;
using GMap.NET.WindowsForms.Markers;

namespace SuperMap.Connector.Control.Forms
{

    /// <summary>
    /// 几何对象图层。主要用于在地图上添加点、线、面等。
    /// </summary>
    public class GraphicsLayer : SuperMap.Connector.Control.Utility.Layer
    {
        private readonly System.Collections.ObjectModel.ObservableCollection<Polygon> _polygons = new System.Collections.ObjectModel.ObservableCollection<Polygon>();
        private readonly System.Collections.ObjectModel.ObservableCollection<Line> _lines = new System.Collections.ObjectModel.ObservableCollection<Line>();
        private readonly System.Collections.ObjectModel.ObservableCollection<Marker> _markers = new System.Collections.ObjectModel.ObservableCollection<Marker>();

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">几何对象图层id。</param>
        /// <param name="name">几何对象图层名称。</param>
        public GraphicsLayer(string id, string name)
            : base(id, name)
        {
            this.Polygons.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Polygons_CollectionChanged);
            this.Lines.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Lines_CollectionChanged);
            this.Markers.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
        }

        /// <summary>
        ///当前图层中多边形列表。 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<Polygon> Polygons
        {
            get { return _polygons; }
        }

        /// <summary>
        /// 获取当前图层中线。
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<Line> Lines
        {
            get { return _lines; }
        }

        /// <summary>
        /// 获取当前图层中所有标注。
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<Marker> Markers
        {
            get { return _markers; }
        }

        void Polygons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.PolygonsChanged != null)
            {
                PolygonsChanged(this, e);
            }
        }

        void Lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.LineCollectionChanged != null)
            {
                LineCollectionChanged(this, e);
            }
        }

        void Markers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.MarkCollectionChanged != null)
            {
                MarkCollectionChanged(this, e);
            }
        }

        internal event System.Collections.Specialized.NotifyCollectionChangedEventHandler PolygonsChanged;
        internal event System.Collections.Specialized.NotifyCollectionChangedEventHandler LineCollectionChanged;
        internal event System.Collections.Specialized.NotifyCollectionChangedEventHandler MarkCollectionChanged;
    }

    /// <summary>
    /// 几何形状的基类
    /// </summary>
    public abstract class GeometryBase
    {
        protected string _id = string.Empty;
        protected object _tag;

        protected GeometryType _type;

        /// <summary>
        /// 对象的ID。
        /// </summary>
        public string ID
        {
            get
            {
                return this._id;
            }
        }

        /// <summary>
        /// 获取或设置有关几何形状的数据的对象。
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// 几何形状的类型
        /// </summary>
        public GeometryType Type
        {
            get { return _type; }
        }
    }

    /// <summary>
    /// 多边形对象。
    /// </summary>
    public class Polygon : GeometryBase
    {
        private List<Point2D> _point2Ds = null;
        private System.Drawing.Color _fillColor;
        private System.Drawing.Color _strokeColor;
        private double _strokeWeight;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">多边形对象的ID，在同一个GraphicsLayer中不能存在相同ID的两个Polygon对象，
        /// 若已经存在一个相同的ID对象，则新加入到GraphicsLayer中的Polygon对象将覆盖前一个Polygon对象。</param>
        /// <param name="point2Ds">面所有节点坐标列表。</param>
        /// <param name="fillColor">填充色。</param>
        /// <param name="strokeColor">面边线颜色。</param>
        /// <param name="strokeWeight">面边线宽度。</param>
        public Polygon(string id, List<Point2D> point2Ds, System.Drawing.Color fillColor, System.Drawing.Color strokeColor, double strokeWeight)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException();
            this._point2Ds = point2Ds;
            this._strokeColor = strokeColor;
            this._fillColor = fillColor;
            this._strokeWeight = strokeWeight;
            this._id = id;
            this._type = GeometryType.REGION;
        }

        /// <summary>
        /// 坐标点数组。
        /// </summary>
        public List<Point2D> Point2Ds
        {
            get { return this._point2Ds; }
        }

        /// <summary>
        /// 面对象填充颜色。
        /// </summary>
        public System.Drawing.Color FillColor
        {
            get { return this._fillColor; }
        }

        /// <summary>
        /// 面边线颜色。
        /// </summary>
        public System.Drawing.Color StrokeColor
        { get { return this._strokeColor; } }

        /// <summary>
        /// 面边线宽度。
        /// </summary>
        public double StrokeWeight
        {
            get { return this._strokeWeight; }
        }

    }

    /// <summary>
    /// 线对象。
    /// </summary>
    public class Line:GeometryBase
    {
        #region 字段
        private List<Point2D> _point2Ds = null;
        private double _strokeWeight = 0.5;
        System.Drawing.Color _strokeColor = System.Drawing.Color.FromArgb(125, 255, 0, 0);
        #endregion

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">线对象的id，在同一个GraphicsLayer中不能存在相同idID的两个Line对象，
        /// 若已经存在一个相同的id对象，则新加入到GraphicsLayer中的Line对象将覆盖前一个Line对象。</param>
        /// <param name="point2Ds">线坐标列表。</param>
        /// <param name="strokeWeight">线宽度。</param>
        /// <param name="strokeColor">线颜色。</param>
        public Line(string id, List<Point2D> point2Ds, double strokeWeight, System.Drawing.Color strokeColor)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException();
            this._id = id;
            this._point2Ds = point2Ds;
            this._strokeWeight = strokeWeight;
            this._strokeColor = strokeColor;
            this._type = GeometryType.LINE;
        }

        /// <summary>
        /// 线坐标点列表。
        /// </summary>
        public List<Point2D> Point2Ds
        {
            get { return this._point2Ds; }
        }

        /// <summary>
        /// 线宽度。
        /// </summary>
        public double StrokeWeight
        {
            get { return this._strokeWeight; }
        }

        /// <summary>
        /// 线颜色。
        /// </summary>
        public System.Drawing.Color StrokeColor
        {
            get { return this._strokeColor; }
        }

    }

    /// <summary>
    /// 标注点对象。
    /// </summary>
    public class Marker:GeometryBase
    {
        #region 字段
        private Point2D _point2D = null;
        private MarkerType _markerType = MarkerType.Blue_Pushpin;
        private ToolTip _toolTip = null;
        private Bitmap _bitmap;
        #endregion

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">标注的ID。</param>
        /// <param name="point2D">坐标点。</param>
        /// <param name="markerType">标注的类型。</param>
        /// <param name="toolTip">标注的提示。</param>
        public Marker(string id, Point2D point2D, MarkerType markerType, ToolTip toolTip)
        {
            this._id = id;
            this._point2D = point2D;
            this._markerType = markerType;
            this._toolTip = toolTip;
            this._type = GeometryType.POINT ;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">标注的ID。</param>
        /// <param name="point2D">坐标点。</param>
        /// <param name="bitmap">标识的自定义图片</param>
        /// <param name="toolTip">标注的提示。</param>
        public Marker(string id, Point2D point2D, Bitmap bitmap, ToolTip toolTip)
        {
            this._id = id;
            this._point2D = point2D;
            this._bitmap = bitmap;
            this._toolTip = toolTip;
            this._type = GeometryType.POINT;
        }

        /// <summary>
        /// 获取标注点对象的坐标点。
        /// </summary>
        public Point2D Point2D
        {
            get { return this._point2D; }
        }

        public Bitmap Image
        {
            get { return _bitmap; }
        }

        /// <summary>
        /// 获取标注的类型。
        /// </summary>
        public MarkerType MarkerType
        {
            get { return this._markerType; }
        }

        /// <summary>
        /// 获取标注的提示。
        /// </summary>
        public ToolTip ToolTip
        { get { return this._toolTip; } }

    }

    /// <summary>
    /// 标注点类型。
    /// </summary>
    public enum MarkerType
    {
        /// <summary>
        /// 
        /// </summary>
        None = GMarkerGoogleType.none,
        /// <summary>
        /// 
        /// </summary>
        Arrow = GMarkerGoogleType.arrow,
        /// <summary>
        /// 
        /// </summary>
        Blue = GMarkerGoogleType.blue,
        /// <summary>
        /// 
        /// </summary>
        Blue_Small = GMarkerGoogleType.black_small,
        /// <summary>
        /// 
        /// </summary>
        Blue_Dot = GMarkerGoogleType.blue_dot,
        Blue_Pushpin = GMarkerGoogleType.blue_pushpin,
        Brown_Small = GMarkerGoogleType.brown_small,
        Gray_Small = GMarkerGoogleType.gray_small,
        Green = GMarkerGoogleType.green,
        Green_Small = GMarkerGoogleType.green_small,
        Green_Dot = GMarkerGoogleType.green_dot,
        Green_Pushpin = GMarkerGoogleType.green_pushpin,
        Green_Big_Go = GMarkerGoogleType.green_big_go,
        Yellow = GMarkerGoogleType.yellow,
        Yellow_Small = GMarkerGoogleType.yellow_small,
        Yellow_Dot = GMarkerGoogleType.yellow_dot,
        Yellow_Big_Pause = GMarkerGoogleType.yellow_big_pause,
        Yellow_Pushpin = GMarkerGoogleType.yellow_pushpin,
        Light_Blue = GMarkerGoogleType.lightblue,
        Light_Blue_Dot = GMarkerGoogleType.lightblue_dot,
        Light_Blue_Pushpin = GMarkerGoogleType.lightblue_pushpin,
        Orange = GMarkerGoogleType.orange,
        Orange_Small = GMarkerGoogleType.orange_small,
        Orange_Dot = GMarkerGoogleType.orange_dot,
        Pink = GMarkerGoogleType.pink,
        Pink_Dot = GMarkerGoogleType.pink_dot,
        Pink_Pushpin = GMarkerGoogleType.pink_pushpin,
        Purple = GMarkerGoogleType.purple,
        Purple_Small = GMarkerGoogleType.purple_small,
        Purple_Dot = GMarkerGoogleType.purple_dot,
        Purple_Pushpin = GMarkerGoogleType.purple_pushpin,
        Red = GMarkerGoogleType.red,
        Red_Small = GMarkerGoogleType.red_small,
        Red_Dot = GMarkerGoogleType.red_dot,
        Red_Pushpin = GMarkerGoogleType.red_pushpin,
        Red_Big_Stop = GMarkerGoogleType.red_big_stop,
        Black_Small = GMarkerGoogleType.black_small,
        White_Small = GMarkerGoogleType.white_small
    }

    /// <summary>
    /// 
    /// </summary>
    public class ToolTip
    {
        private string _toolTipText = string.Empty;
        private Font _font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold, GraphicsUnit.Pixel);
        private StringFormat _format = new StringFormat();
        private System.Drawing.Color _backColor = System.Drawing.Color.FromArgb(222, System.Drawing.Color.AliceBlue);
        private System.Drawing.Color _foreColor = System.Drawing.Color.Navy;
        private System.Drawing.Color _outlineColoe = System.Drawing.Color.FromArgb(140, System.Drawing.Color.MidnightBlue);
        private double _outlineWeight = 1.0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolTipText"></param>
        public ToolTip(string toolTipText)
        {
            if (string.IsNullOrWhiteSpace(toolTipText)) throw new ArgumentNullException();
            this._toolTipText = toolTipText;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolTipText"></param>
        /// <param name="font"></param>
        /// <param name="format"></param>
        /// <param name="backColor"></param>
        /// <param name="foreColor"></param>
        /// <param name="outlineColor"></param>
        /// <param name="outlineWeight"></param>
        public ToolTip(string toolTipText, Font font, StringFormat format, System.Drawing.Color backColor,
            System.Drawing.Color foreColor, System.Drawing.Color outlineColor, double outlineWeight)
        {
            if (string.IsNullOrWhiteSpace(toolTipText)) throw new ArgumentNullException();
            this._toolTipText = toolTipText;
            this._font = font;
            this._format = format;
            this._backColor = backColor;
            this._foreColor = foreColor;
            this._outlineColoe = outlineColor;
            this._outlineWeight = outlineWeight;
        }

        /// <summary>
        /// 获取提示文本字符串。
        /// </summary>
        public string ToolTipText
        {
            get { return this._toolTipText; }
        }
    }
}
