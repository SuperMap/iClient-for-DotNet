using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SuperMap.Connector.Utility;
using SuperMap.Connector;
using SuperMap.Connector.Control.Utility;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Specialized;

namespace SuperMap.Connector.Control.Forms
{
    /// <summary>
    /// 地图控件。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>MapControl地图控件通过设定地图图层来获取地图进行展示。</item>
    /// <item>MapControl地图控件是基于开源GMap.NET<seealso cref="http://www.greatmaps.codeplex.com"/>地图控件封装。</item>
    /// </list>
    /// </remarks>
    public partial class MapControl : UserControl
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public MapControl()
        {
            InitializeComponent();

            this.gMapControl1.DragButton = System.Windows.Forms.MouseButtons.Left;
            this.gMapControl1.CanDragMap = false;
            this.gMapControl1.EmptyMapBackground = System.Drawing.Color.White;
            this._center = new Point2D(0, 0);

            this.gMapControl1.MouseMove += new MouseEventHandler(gMapControl1_MouseMove);
            this.gMapControl1.MouseDown += new MouseEventHandler(gMapControl1_MouseDown);
            this.gMapControl1.MouseUp += new MouseEventHandler(gMapControl1_MouseUp);
            this.gMapControl1.MouseCaptureChanged += new EventHandler(gMapControl1_MouseCaptureChanged);
            this.gMapControl1.MouseClick += new MouseEventHandler(gMapControl1_MouseClick);
            this.gMapControl1.MouseDoubleClick += new MouseEventHandler(gMapControl1_MouseDoubleClick);
            this.gMapControl1.MouseEnter += new EventHandler(gMapControl1_MouseEnter);
            this.gMapControl1.MouseHover += new EventHandler(gMapControl1_MouseHover);
            this.gMapControl1.MouseLeave += new EventHandler(gMapControl1_MouseLeave);
            this.gMapControl1.MouseWheel += new MouseEventHandler(gMapControl1_MouseWheel);
            this.gMapControl1.KeyDown += new KeyEventHandler(gMapControl1_KeyDown);
            this.gMapControl1.KeyUp += new KeyEventHandler(gMapControl1_KeyUp);
            this.gMapControl1.Click += new EventHandler(gMapControl1_Click);
            this.gMapControl1.DoubleClick += new EventHandler(gMapControl1_DoubleClick);
            this.gMapControl1.DragDrop += new DragEventHandler(gMapControl1_DragDrop);
            this.gMapControl1.DragEnter += new DragEventHandler(gMapControl1_DragEnter);
            this.gMapControl1.DragLeave += new EventHandler(gMapControl1_DragLeave);
            this.gMapControl1.DragOver += new DragEventHandler(gMapControl1_DragOver);
            this.gMapControl1.OnMapZoomChanged += new GMap.NET.MapZoomChanged(gMapControl1_OnMapZoomChanged);
            this.gMapControl1.OnPositionChanged += new PositionChanged(gMapControl1_OnPositionChanged);

            this.gMapControl1.OnTileLoadComplete += new GMap.NET.TileLoadComplete(gMapControl1_OnTileLoadComplete);
            this.GraphicsLayers.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(GraphicsLayers_CollectionChanged);
        }

        void gMapControl1_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            this.ViewBounds = GetNowViewBounds();
        }

        /// <summary>
        /// 获取地图当前可视区域的图片
        /// </summary>
        /// <returns></returns>
        public Image GetMapImage()
        {
            return gMapControl1.ToImage();
        }

        #region 路由GMapControl系统事件
        void gMapControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            OnMouseWheel(e);
        }

        void gMapControl1_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        void gMapControl1_MouseHover(object sender, EventArgs e)
        {
            OnMouseHover(e);
        }

        void gMapControl1_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

        void gMapControl1_MouseCaptureChanged(object sender, EventArgs e)
        {
            OnMouseCaptureChanged(e);
        }

        void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        void gMapControl1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        void gMapControl1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }


        void gMapControl1_DragOver(object sender, DragEventArgs e)
        {
            OnDragOver(e);
        }

        void gMapControl1_DragLeave(object sender, EventArgs e)
        {
            OnDragLeave(e);
        }

        void gMapControl1_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }

        void gMapControl1_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(e);
        }

        void gMapControl1_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        void gMapControl1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        void gMapControl1_OnMapZoomChanged()
        {
            //ZoomChangeEventArgs e = new ZoomChangeEventArgs(_oldZoom, _zoom);
            //if (_isMouseWheel)
            //{
            //    this.Zoom = Convert.ToInt32(gMapControl1.Zoom);
            //}
            //OnZoomChanged(e);
        }

        void gMapControl1_OnPositionChanged(PointLatLng point)
        {
            //CenterChangeEventArgs e = new CenterChangeEventArgs(_oldCenter, _center);
            //OnCenterChanged(e);
        }

        #endregion

        #region 提升GMapControl事件

        /// <summary>
        /// 地图更新事件，在修改MapLayer后触发。
        /// </summary>
        public event MapTypeChanged MapTypeChanged
        {
            add { this.gMapControl1.OnMapTypeChanged += value; }
            remove { this.gMapControl1.OnMapTypeChanged -= value; }
        }

        /// <summary>
        /// 加载地图完成事件。
        /// </summary>
        public event TileLoadComplete TileLoadComplete
        {
            add { this.gMapControl1.OnTileLoadComplete += value; }
            remove { this.gMapControl1.OnTileLoadComplete -= value; }
        }

        /// <summary>
        /// 开始加载地图事件。
        /// </summary>
        public event TileLoadStart TileLoadStart
        {
            add { this.gMapControl1.OnTileLoadStart += value; }
            remove { this.gMapControl1.OnTileLoadStart -= value; }
        }

        /// <summary>
        /// 开始加载地图事件。
        /// </summary>
        public event EmptyTileError EmptyTileError
        {
            add { this.gMapControl1.OnEmptyTileError += value; }
            remove { this.gMapControl1.OnEmptyTileError -= value; }
        }
        #endregion

        /// <summary>
        /// 将屏幕上的像素坐标转换成地理坐标。
        /// </summary>
        /// <param name="point">屏幕上的像素坐标。</param>
        /// <returns>返回的地理坐标。</returns>
        public Point2D ScreenToMap(System.Drawing.Point point)
        {
            return Helper.PointLatLng2Point2D(gMapControl1.FromLocalToLatLng(point.X, point.Y));
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

        /// <summary>
        /// 重新加载地图。
        /// </summary>
        /// <param name="clearCache">在加载前是否需要清理客户端缓存。</param>
        public void ReLoadMap(bool clearCache)
        {
            if (gMapControl1 != null)
            {
                if (clearCache)
                {
                    GMaps.Instance.MemoryCache.Clear();
                    GMaps.Instance.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                }
                gMapControl1.ReloadMap();
            }
        }

        #region fields
        private SuperMap.Connector.Control.Utility.MapLayer _mapLayer;
        private Point2D _center;
        private Point2D _oldCenter;
        private double[] _scales;
        private double? _scale;
        private int _zoom;
        private int _oldZoom;
        private Rectangle2D _viewBounds;
        private Rectangle2D _oldViewBounds;
        private IAction _currentAction;
        private bool _isMouseWheel;
        private Rectangle2D _bounds;

        #endregion

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
        /// 地图当前范围。
        /// </summary>
        public Rectangle2D ViewBounds
        {
            get
            {
                if (_viewBounds == null)
                {
                    _viewBounds = GetNowViewBounds();
                }
                return _viewBounds;
            }
            private set
            {
                _viewBounds = value;
            }
        }

        /// <summary>
        /// 地图当前缩放级别。
        /// </summary>
        public int Zoom
        {
            get { return Convert.ToInt32(gMapControl1.Zoom); }
            set { gMapControl1.Zoom = value; }
        }

        /// <summary>
        /// 地图初始化参数，目前支持两种类型的参数，分别是MapByScalesLayer和MapByZoomCountLayer。
        /// </summary>
        [Browsable(false)]
        public SuperMap.Connector.Control.Utility.MapLayer MapLayer
        {
            get { return _mapLayer; }
            set
            {
                if (_mapLayer != value & value != null)
                {
                    _mapLayer = value;
                    SuperMapProvider provider = null;
                    if (value is MapByScalesLayer)
                    {
                        MapByScalesLayer temp = _mapLayer as MapByScalesLayer;
                        provider = new SuperMapProvider(temp.ServiceUrl, temp.MapName, temp.Scales);
                    }
                    else if (value is MapByZoomCountLayer)
                    {
                        MapByZoomCountLayer temp = _mapLayer as MapByZoomCountLayer;
                        provider = new SuperMapProvider(temp.ServiceUrl, temp.MapName, temp.ZoomCount, temp.DefaultScaleIndex);
                    }
                    this._bounds = new Rectangle2D(
                        provider.Projection.Bounds.Left,
                        provider.Projection.Bounds.Bottom,
                        provider.Projection.Bounds.Right,
                        provider.Projection.Bounds.Top);
                    this.gMapControl1.MapProvider = provider;
                    this.gMapControl1.MaxZoom = provider.MapScales.Length - 1;
                    this.gMapControl1.MinZoom = 0;
                    this.Center = provider.DefaultMapCenter;
                    this._scales = provider.MapScales;
                    this.Zoom = 0;
                }
            }
        }

        /// <summary>
        /// 中心点坐标。
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
        /// 全幅地图的范围
        /// </summary>
        public Rectangle2D Bounds
        {
            get { return _bounds; }
        }

        /// <summary>
        /// 当前地图支持的比例尺。
        /// </summary>
        public double[] Scales
        {
            get { return _scales; }
        }

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

        private readonly System.Collections.ObjectModel.ObservableCollection<GraphicsLayer> _graphicsLayers = new System.Collections.ObjectModel.ObservableCollection<GraphicsLayer>();

        /// <summary>
        /// 自定义图形图层列表。
        /// </summary>
        /// <remarks>
        /// <para>多个<see cref="GraphicsLayer"/>对象不能使用相同的ID，如果使用相同的ID则会把上一次添加的移除然后再添加。</para>
        /// </remarks>
        public System.Collections.ObjectModel.ObservableCollection<GraphicsLayer> GraphicsLayers
        {
            get { return _graphicsLayers; }
        }

        private void GraphicsLayers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (GraphicsLayer item in e.NewItems)
                {
                    GMapOverlay overlay = new GMapOverlay(item.ID);
                    if (_layerMapOverlay.ContainsKey(item.ID))
                    {
                        this.GraphicsLayers.Remove(_layerMapOverlay[item.ID].GraphicsLayer);
                    }
                    if (!_layerMapOverlay.ContainsKey(item.ID))
                    {
                        _layerMapOverlay.Add(item.ID, new GraphicsLayerMapOverlay()
                        {
                            GraphicsLayer = item,
                            GMapOverlay = overlay
                        });
                        this.gMapControl1.Overlays.Add(overlay);
                        item.PolygonsChanged += new NotifyCollectionChangedEventHandler(item_PolygonChanged);
                        item.LineCollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(item_LineCollectionChanged);
                        item.MarkCollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(item_MarkCollectionChanged);
                        if (item.Polygons != null && item.Polygons.Count > 0)
                        {
                            if (!_polygonMapGMapPolygon.ContainsKey(item.ID))
                            {
                                _polygonMapGMapPolygon.Add(item.ID, new Dictionary<string, PolygonMapGMapPolygon>());
                            }
                            foreach (Polygon polygonItem in item.Polygons)
                            {
                                if (polygonItem != null)
                                {
                                    GMapPolygon gMapPolygon = new GMapPolygon(Helper.Point2Ds2PointLatLngs(polygonItem.Point2Ds), polygonItem.ID);
                                    gMapPolygon.IsVisible = true;
                                    gMapPolygon.IsHitTestVisible = true;
                                    gMapPolygon.Fill = new SolidBrush(polygonItem.FillColor);
                                    gMapPolygon.Stroke = new Pen(polygonItem.StrokeColor, (float)polygonItem.StrokeWeight);
                                    overlay.Polygons.Add(gMapPolygon);
                                    _polygonMapGMapPolygon[item.ID].Add(polygonItem.ID, new PolygonMapGMapPolygon(polygonItem, gMapPolygon));
                                }
                            }
                        }
                        if (item.Lines != null && item.Lines.Count > 0)
                        {
                            this.AddLine(item, overlay, item.Lines);
                        }
                        if (item.Markers != null && item.Markers.Count > 0)
                        {
                            this.AddMarker(item, overlay, item.Markers);
                        }
                    }
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null)
            {
                foreach (GraphicsLayer item in e.OldItems)
                {
                    if (_layerMapOverlay.ContainsKey(item.ID))
                    {
                        item.PolygonsChanged -= item_PolygonChanged;
                        item.LineCollectionChanged -= item_LineCollectionChanged;
                        item.MarkCollectionChanged -= item_MarkCollectionChanged;
                        this.gMapControl1.Overlays.Remove(_layerMapOverlay[item.ID].GMapOverlay);
                        _layerMapOverlay.Remove(item.ID);
                        _polygonMapGMapPolygon.Remove(item.ID);
                        _lineMapGMapRoute.Remove(item.ID);
                        _markerMapGMapMarker.Remove(item.ID);
                    }
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                foreach (KeyValuePair<string, GraphicsLayerMapOverlay> pair in _layerMapOverlay)
                {
                    pair.Value.GraphicsLayer.PolygonsChanged -= item_PolygonChanged;
                    pair.Value.GraphicsLayer.MarkCollectionChanged -= item_MarkCollectionChanged;
                    pair.Value.GraphicsLayer.LineCollectionChanged -= item_LineCollectionChanged;
                }

                this.gMapControl1.Overlays.Clear();
                foreach (GMapOverlay item in this.gMapControl1.Overlays)
                {
                    if (item != null)
                    {
                        item.Markers.Clear();
                        item.Polygons.Clear();
                        item.Routes.Clear();
                    }
                }

                this._layerMapOverlay.Clear();
                _polygonMapGMapPolygon.Clear();
                _lineMapGMapRoute.Clear();
                _markerMapGMapMarker.Clear();
                this.Refresh();
            }
        }

        private void AddLine(GraphicsLayer graphicsLayer, GMapOverlay overlay, IList<Line> items)
        {
            if (graphicsLayer == null || overlay == null) return;
            if (items == null && items.Count <= 0) return;
            if (!_lineMapGMapRoute.ContainsKey(graphicsLayer.ID))
            {
                _lineMapGMapRoute.Add(graphicsLayer.ID, new Dictionary<string, LineMapGMapRoute>());
            }
            foreach (Line lineItem in items)
            {
                if (lineItem != null)
                {
                    if (_lineMapGMapRoute[graphicsLayer.ID].ContainsKey(lineItem.ID))
                    {
                        graphicsLayer.Lines.Remove(lineItem);
                    }
                    GMapRoute route = new GMapRoute(Helper.Point2Ds2PointLatLngs(lineItem.Point2Ds), lineItem.ID);
                    route.IsHitTestVisible = true;
                    route.IsVisible = true;
                    route.Stroke = new Pen(lineItem.StrokeColor, (float)lineItem.StrokeWeight);
                    overlay.Routes.Add(route);
                    _lineMapGMapRoute[graphicsLayer.ID].Add(lineItem.ID, new LineMapGMapRoute(lineItem, route));
                }
            }
        }

        private void AddMarker(GraphicsLayer graphicsLayer, GMapOverlay overlay, IList<Marker> items)
        {
            if (graphicsLayer == null || overlay == null) return;
            if (items == null && items.Count <= 0) return;
            if (!_markerMapGMapMarker.ContainsKey(graphicsLayer.ID))
            {
                _markerMapGMapMarker.Add(graphicsLayer.ID, new Dictionary<string, MarkerMapGMapMaker>());
            }
            foreach (Marker item in items)
            {
                if (item != null)
                {
                    if (_markerMapGMapMarker[graphicsLayer.ID].ContainsKey(item.ID))
                    {
                        graphicsLayer.Markers.Remove(item);
                    }
                    GMarkerGoogle gMarker ;
                    if(item.Image!=null)
                    {
                        gMarker = new GMarkerGoogle(Helper.Point2D2PointLatLng(item.Point2D), item.Image);
                    }
                    else
                    {
                        gMarker = new GMarkerGoogle(Helper.Point2D2PointLatLng(item.Point2D), (GMarkerGoogleType)item.MarkerType);
                    }
                    gMarker.IsHitTestVisible = true;
                    gMarker.IsVisible = true;
                    overlay.Markers.Add(gMarker);
                    _markerMapGMapMarker[graphicsLayer.ID].Add(item.ID, new MarkerMapGMapMaker(item, gMarker));
                }
            }
        }

        void item_MarkCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GraphicsLayer graphicsLayer = sender as GraphicsLayer;
            if (graphicsLayer != null && _layerMapOverlay.ContainsKey(graphicsLayer.ID))
            {
                GMapOverlay overlay = _layerMapOverlay[graphicsLayer.ID].GMapOverlay;
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add && e.NewItems != null)
                {
                    List<Marker> markers = new List<Marker>();
                    foreach (Marker item in e.NewItems)
                    {
                        markers.Add(item);
                    }
                    this.AddMarker(graphicsLayer, overlay, markers);
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove && e.OldItems != null)
                {
                    foreach (Marker item in e.OldItems)
                    {
                        if (item != null)
                        {
                            overlay.Markers.Remove(_markerMapGMapMarker[graphicsLayer.ID][item.ID].GMapMarker);
                            _markerMapGMapMarker[graphicsLayer.ID].Remove(item.ID);
                        }
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
                {
                    overlay.Markers.Clear();
                    if (_markerMapGMapMarker.ContainsKey(graphicsLayer.ID))
                    {
                        _markerMapGMapMarker[graphicsLayer.ID].Clear();
                    }
                }
            }
        }

        void item_LineCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            GraphicsLayer graphicsLayer = sender as GraphicsLayer;
            if (graphicsLayer != null && _layerMapOverlay.ContainsKey(graphicsLayer.ID))
            {
                GMapOverlay overlay = _layerMapOverlay[graphicsLayer.ID].GMapOverlay;
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add && e.NewItems != null)
                {
                    List<Line> lines = new List<Line>();
                    foreach (Line lineItem in e.NewItems)
                    {
                        lines.Add(lineItem);
                    }
                    this.AddLine(graphicsLayer, overlay, lines);
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove && e.OldItems != null)
                {
                    foreach (Line lineItem in e.OldItems)
                    {
                        if (lineItem != null)
                        {
                            overlay.Routes.Remove(_lineMapGMapRoute[graphicsLayer.ID][lineItem.ID].GMapRoute);
                            _lineMapGMapRoute[graphicsLayer.ID].Remove(lineItem.ID);
                        }
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
                {
                    overlay.Routes.Clear();
                    if (_lineMapGMapRoute.ContainsKey(graphicsLayer.ID))
                    {
                        _lineMapGMapRoute[graphicsLayer.ID].Clear();
                    }
                }
            }
        }

        private void item_PolygonChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            GraphicsLayer graphicsLayer = sender as GraphicsLayer;
            if (graphicsLayer != null)
            {
                if (_layerMapOverlay.ContainsKey(graphicsLayer.ID))
                {
                    GMapOverlay overlay = _layerMapOverlay[graphicsLayer.ID].GMapOverlay;
                    if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
                    {
                        if (!_polygonMapGMapPolygon.ContainsKey(graphicsLayer.ID))
                        {
                            _polygonMapGMapPolygon.Add(graphicsLayer.ID, new Dictionary<string, PolygonMapGMapPolygon>());
                        }
                        foreach (Polygon polygonItem in e.NewItems)
                        {
                            if (polygonItem != null)
                            {
                                if (_polygonMapGMapPolygon[graphicsLayer.ID].ContainsKey(polygonItem.ID))
                                {
                                    graphicsLayer.Polygons.Remove(polygonItem);
                                }
                                GMapPolygon gMapPolygon = new GMapPolygon(Helper.Point2Ds2PointLatLngs(polygonItem.Point2Ds), polygonItem.ID);
                                gMapPolygon.IsVisible = true;
                                gMapPolygon.IsHitTestVisible = true;
                                gMapPolygon.Fill = new SolidBrush(polygonItem.FillColor);
                                gMapPolygon.Stroke = new Pen(polygonItem.StrokeColor, (float)polygonItem.StrokeWeight);
                                overlay.Polygons.Add(gMapPolygon);
                                _polygonMapGMapPolygon[graphicsLayer.ID].Add(polygonItem.ID, new PolygonMapGMapPolygon(polygonItem, gMapPolygon));
                            }
                        }
                    }
                    else if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null)
                    {
                        foreach (Polygon polygonItem in e.OldItems)
                        {
                            if (polygonItem != null)
                            {
                                overlay.Polygons.Remove(_polygonMapGMapPolygon[graphicsLayer.ID][polygonItem.ID].GMapPolygon);
                                if (_polygonMapGMapPolygon[graphicsLayer.ID].ContainsKey(polygonItem.ID))
                                {
                                    _polygonMapGMapPolygon[graphicsLayer.ID].Remove(polygonItem.ID);
                                }
                            }
                        }
                    }
                    else if (e.Action == NotifyCollectionChangedAction.Reset)
                    {
                        overlay.Polygons.Clear();
                        if (_polygonMapGMapPolygon.ContainsKey(graphicsLayer.ID))
                        {
                            _polygonMapGMapPolygon[graphicsLayer.ID].Clear();
                        }
                    }
                }
            }
        }

        Dictionary<string, GraphicsLayerMapOverlay> _layerMapOverlay = new Dictionary<string, GraphicsLayerMapOverlay>();
        Dictionary<string, Dictionary<string, PolygonMapGMapPolygon>> _polygonMapGMapPolygon = new Dictionary<string, Dictionary<string, PolygonMapGMapPolygon>>();
        Dictionary<string, Dictionary<string, LineMapGMapRoute>> _lineMapGMapRoute = new Dictionary<string, Dictionary<string, LineMapGMapRoute>>();
        Dictionary<string, Dictionary<string, MarkerMapGMapMaker>> _markerMapGMapMarker = new Dictionary<string, Dictionary<string, MarkerMapGMapMaker>>();
    }

    internal class GraphicsLayerMapOverlay
    {
        public GMapOverlay GMapOverlay;
        public GraphicsLayer GraphicsLayer;
    }

    internal class PolygonMapGMapPolygon
    {
        public PolygonMapGMapPolygon(Polygon polygon, GMapPolygon gMapPolygon)
        {
            this._gMapPolygon = gMapPolygon;
            this._polygon = polygon;
        }

        private Polygon _polygon;
        public Polygon Polygon { get { return _polygon; } }

        private GMapPolygon _gMapPolygon;
        public GMapPolygon GMapPolygon
        {
            get { return _gMapPolygon; }
        }
    }

    internal class LineMapGMapRoute
    {
        private Line _line = null;
        private GMapRoute _gMapRoute = null;
        public LineMapGMapRoute(Line line, GMapRoute gMapRoute)
        {
            this._gMapRoute = gMapRoute;
            this._line = line;
        }

        public Line Line
        {
            get { return this._line; }
        }

        public GMapRoute GMapRoute
        {
            get { return this._gMapRoute; }
        }
    }

    internal class MarkerMapGMapMaker
    {
        private Marker _marker = null;
        private GMapMarker _gMapMarker = null;

        public MarkerMapGMapMaker(Marker marker, GMapMarker gMapMarker)
        {
            this._marker = marker;
            this._gMapMarker = gMapMarker;
        }

        public Marker Marker
        {
            get { return this._marker; }
        }

        public GMapMarker GMapMarker
        {
            get { return this._gMapMarker; }
        }
    }
}
