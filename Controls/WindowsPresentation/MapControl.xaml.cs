using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SuperMap.Connector.Control.Utility;
using SuperMap.Connector.Utility;
using System.ComponentModel;
using GMap.NET;

namespace SuperMap.Connector.Control.WPF
{
    /// <summary>
    /// 地图控件。
    /// </summary>
    public partial class MapControl : UserControl, IMapNotifyPropertyChanged
    {
        private Rectangle2D _viewBounds;
        private Rectangle2D _bounds;
        private double[] _scales;
        private IAction _currentAction;

        #region 自定义事件
        /// <summary>
        /// 地图加载事件，在地图加载完成后触发。
        /// </summary>
        public event EventHandler MapLoaded;

        protected void OnMapLoaded()
        {
            if (MapLoaded != null)
            {
                MapLoaded(this, new EventArgs());
            }
        }

        /// <summary>
        /// 地图图层异常事件，当地图图层异常时触发。
        /// </summary>
        public event MapErrorEventHandler MapLayerError;

        protected void OnMapMapLayerError(MapErrorEventArgs e)
        {
            if (MapLayerError != null)
            {
                MapLayerError(this, e);
            }
        }
        #endregion

        /// <summary>
        /// 获取当前显示的地图图片
        /// </summary>
        /// <returns></returns>
        public ImageSource GetMapImage()
        {
            return gMapControl1.ToImageSource();
        }

        /// <summary>
        /// 初始化MapControl类的新实例。
        /// </summary>
        public MapControl()
        {
            InitializeComponent();

            gMapControl1.CanDragMap = false;
            gMapControl1.DragButton = MouseButton.Left;

            Binding bZoom = new Binding();
            bZoom.Source = gMapControl1;
            bZoom.Path = new PropertyPath("Zoom");
            bZoom.Mode = BindingMode.TwoWay;
            this.SetBinding(ZoomProperty, bZoom);

            this.gMapControl1.OnPositionChanged += new GMap.NET.PositionChanged(gMapControl1_OnPositionChanged);
            this.gMapControl1.OnTileLoadComplete += new GMap.NET.TileLoadComplete(gMapControl1_OnTileLoadComplete);
            this.gMapControl1.MouseWheel += new MouseWheelEventHandler(gMapControl1_MouseWheel);
        }

        void gMapControl1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            OnPropertyChanged("Center");
        }

        void gMapControl1_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            ViewBounds = GetNowViewBounds();
            OnMapLoaded();
        }

        void gMapControl1_OnPositionChanged(GMap.NET.PointLatLng point)
        {
            OnPropertyChanged("Center");
        }

        /// <summary>
        /// 标识MapLayer依赖属性
        /// </summary>
        public static DependencyProperty MapLayerProperty = DependencyProperty.Register("MapLayer",
            typeof(SuperMap.Connector.Control.Utility.Layer), typeof(MapControl), new PropertyMetadata(new PropertyChangedCallback(MapLayerPropertyChanged)));

        /// <summary>
        /// 地图初始化参数，目前支持两种类型的参数，分别是MapByScalesLayer和MapByZoomCountLayer。
        /// </summary>
        public SuperMap.Connector.Control.Utility.MapLayer MapLayer
        {
            get { return (SuperMap.Connector.Control.Utility.MapLayer)this.GetValue(MapLayerProperty); }
            set { this.SetValue(MapLayerProperty, value); }
        }

        private static void MapLayerPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                MapControl map = (MapControl)sender;
                SuperMapProvider provider = null;
                try
                {
                    if (e.NewValue is MapByScalesLayer)
                    {
                        MapByScalesLayer temp = e.NewValue as MapByScalesLayer;
                        provider = new SuperMapProvider(temp.ServiceUrl, temp.MapName, temp.Scales);
                    }
                    else if (e.NewValue is MapByZoomCountLayer)
                    {
                        MapByZoomCountLayer temp = e.NewValue as MapByZoomCountLayer;
                        provider = new SuperMapProvider(temp.ServiceUrl, temp.MapName, temp.ZoomCount, temp.DefaultScaleIndex);
                    }
                }
                catch (Exception ex)
                {
                    MapErrorEventArgs mapEx = new MapErrorEventArgs("初始化地图图层时发生异常", ex);
                    map.OnMapMapLayerError(mapEx);
                    return;
                }
                map._bounds = new Rectangle2D(
                        provider.Projection.Bounds.Left,
                        provider.Projection.Bounds.Bottom,
                        provider.Projection.Bounds.Right,
                        provider.Projection.Bounds.Top);
                map.gMapControl1.MapProvider = provider;
                map.gMapControl1.MaxZoom = provider.MapScales.Length - 1;
                map.gMapControl1.MinZoom = 0;
                map.gMapControl1.Zoom = 0;
                map.Center = provider.DefaultMapCenter;
                map._scales = provider.MapScales;
                map.OnPropertyChanged(e);
            }
        }

        /// <summary>
        /// 标识Zoom依赖属性
        /// </summary>
        public static DependencyProperty ZoomProperty = DependencyProperty.Register("Zoom", typeof(int), typeof(MapControl), new PropertyMetadata(new PropertyChangedCallback(OnZoomPropertyChanged)));

        /// <summary>
        /// 地图当前缩放级别。
        /// </summary>
        public int Zoom
        {
            get { return (int)this.GetValue(ZoomProperty); }
            set { this.SetValue(ZoomProperty, value); }
        }

        private static void OnZoomPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MapControl map = (MapControl)sender;
            map.OnPropertyChanged(e);
        }

        /// <summary>
        /// 地图当前分辨率。
        /// </summary>
        public double Resolution
        {
            get
            {
                return gMapControl1.MapProvider.Projection.GetGroundResolution(
                    Convert.ToInt32(gMapControl1.Zoom), 0);
            }
        }

        /// <summary>
        /// 当前地图支持的比例尺。
        /// </summary>
        public double[] Scales
        {
            get { return _scales; }
        }

        /// <summary>
        /// 全幅地图的范围
        /// </summary>
        public Rectangle2D Bounds
        {
            get { return _bounds; }
        }

        /// <summary>
        /// 地图当前范围。
        /// </summary>
        public Rectangle2D ViewBounds
        {
            get
            {
                if (_viewBounds == null)
                {
                    _viewBounds = GetNowViewBounds();
                    OnPropertyChanged("ViewBounds");
                }
                return _viewBounds;
            }
            private set
            {
                _viewBounds = value;
                OnPropertyChanged("ViewBounds");
            }
        }

        /// <summary>
        /// 地图当前中心点
        /// </summary>
        public Point2D Center
        {
            get { return Helper.PointLatLng2Point2D(gMapControl1.Position); }
            set
            {
                if (value != null)
                {
                    Point2D temp = new Point2D();
                    if (Bounds == null)
                    {
                        gMapControl1.Position = new PointLatLng(0, 0);
                    }
                    else
                    {
                        temp.X = Math.Max(Math.Min(value.X, Bounds.RightTop.X), Bounds.LeftBottom.X);
                        temp.Y = Math.Max(Math.Min(value.Y, Bounds.RightTop.Y), Bounds.LeftBottom.Y);
                        gMapControl1.Position = Helper.Point2D2PointLatLng(temp);
                    }
                }
            }
        }

        /// <summary>
        /// 将屏幕上的像素坐标转换成地理坐标。
        /// </summary>
        /// <param name="point">屏幕上的像素坐标</param>
        /// <returns>地理坐标</returns>
        public Point2D ScreenToMap(System.Windows.Point point)
        {
            return Helper.PointLatLng2Point2D(gMapControl1.FromLocalToLatLng(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)));
        }

        /// <summary>
        /// 将地理坐标转换成屏幕上的像素坐标。
        /// </summary>
        /// <param name="point">地理坐标。</param>
        /// <returns>屏幕上的像素坐标。</returns>
        public System.Drawing.Point MapToScreen(Point2D point)
        {
            GPoint gPoint = gMapControl1.FromLatLngToLocal(Helper.Point2D2PointLatLng(point));
            return new System.Drawing.Point(Convert.ToInt32(gPoint.X), Convert.ToInt32(gPoint.Y));
        }


        #region IMapNotufyPropertyChanged 成员

        /// <summary>
        /// 当MapControl中的属性发生变化时发生。
        /// </summary>
        public event MapPropertyChangedHandler PropertyChanged;

        /// <summary>
        /// 当依赖属性发生变化时，调用此方法。
        /// </summary>
        /// <param name="e">发生变化的依赖属性的变化详细信息。</param>
        public virtual void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                MapPropertyChangedEventArgs change = new MapPropertyChangedEventArgs(e.Property.Name, e.OldValue, e.NewValue);
                PropertyChanged(this, change);
            }
        }

        /// <summary>
        /// 当属性发生变化时，调用此方法。
        /// </summary>
        /// <param name="name">发生变化的属性名字</param>
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new MapPropertyChangedEventArgs(name, null, null));
            }
        }
        #endregion

        /// <summary>
        /// 获取当前地图可视范围。
        /// </summary>
        /// <returns></returns>
        private Rectangle2D GetNowViewBounds()
        {
            if (gMapControl1.ViewArea == null)
            {
                return null;
            }

            Point2D lefttop = Helper.PointLatLng2Point2D(gMapControl1.ViewArea.LocationTopLeft);
            Point2D rightBottom = Helper.PointLatLng2Point2D(gMapControl1.ViewArea.LocationRightBottom);
            Rectangle2D rec = new Rectangle2D(lefttop, rightBottom);
            return rec;
        }

        /// <summary>
        /// 地图控件的功能属性，所有功能均需实现接口IAction。
        /// </summary>
        public IAction CurrentAction
        {
            get { return _currentAction; }
            set
            {
                if (_currentAction != value)
                {
                    if (_currentAction != null)
                    {
                        _currentAction.Dispose();
                    }
                    _currentAction = value;
                    if (_currentAction != null)
                    {
                        _currentAction.OnLoad(this);
                    }
                }
            }
        }

        /// <summary>
        /// 鼠标滚轮缩放时的缩放方式
        /// </summary>
        public SuperMap.Connector.Control.Utility.MouseWheelZoomType MouseWheelZoomType
        {
            get { return (SuperMap.Connector.Control.Utility.MouseWheelZoomType)((int)gMapControl1.MouseWheelZoomType); }
            set { gMapControl1.MouseWheelZoomType = (GMap.NET.MouseWheelZoomType)((int)value); }
        }
    }
}
