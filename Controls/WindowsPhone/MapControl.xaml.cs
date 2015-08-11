using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SuperMap.Connector.Control.WindowsPhone
{
    public partial class MapControl : UserControl
    {
        private Canvas _layerCollectionCanvas = null;
        private Size _currentSize = Size.Empty;
        private Utility.Point2D _origin = null;  //地图原点(所有的Layers都将根据此原点进行换算)
        private Utility.Rectangle2D _cacheBounds = null;
        private double _mapResolution = double.NaN;

        public MapControl()
        {
            InitializeComponent();
            this.Layers = new LayerCollection();

            _layerCollectionCanvas = new Canvas();
            this.rootElement.Children.Add(this._layerCollectionCanvas);
            _layerCollectionCanvas.RenderTransform = new TranslateTransform();

            this.SizeChanged += new SizeChangedEventHandler(MapControl_SizeChanged);
            this.Loaded += new RoutedEventHandler(MapControl_Loaded);
        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            //if (this.Layers != null && this.Layers.Count > 0)
            //{
            //    foreach (var layer in this.Layers)
            //    {
            //        if (layer != null && !layer.IsInitialized && !layer.IsInitializing)
            //        {
            //            layer.Initialize();
            //        }
            //    }
            //}
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            UpdateClip(finalSize);
            return base.ArrangeOverride(finalSize);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        //平移_layerCollectionCanvas
        private void PanLayerCollectionCanvas(double offsetX, double offsetY)
        {
            TranslateTransform renderTransform = this._layerCollectionCanvas.RenderTransform as TranslateTransform;
            renderTransform.X += offsetX;
            renderTransform.Y += offsetY;
        }

        //重置_layerCollectionCanvas的偏移量
        private void ResetTranslate()
        {
            TranslateTransform renderTransform = this._layerCollectionCanvas.RenderTransform as TranslateTransform;
            renderTransform.X = 0;
            renderTransform.Y = 0;
        }

        // 当分辨率发生变化时，重新设置各个LayerCanvas的参考点和分辨率，并重置偏移量
        private void SetOriginAndResolution(double newResolution, Utility.Point2D originPoint)
        {
            _origin = originPoint;
            foreach (Layer layer in Layers)
            {
                ResetTranslate();
                layer.LayerCanvas.Resolution = newResolution;
                layer.LayerCanvas.OriginX = originPoint.X;
                layer.LayerCanvas.OriginY = originPoint.Y;
            }
        }

        public Point MapToScreen(Utility.Point2D point2D)
        {
            if ((this._layerCollectionCanvas == null) || (point2D == null))
            {
                return new Point(double.NaN, double.NaN);
            }
            try
            {
                return this._layerCollectionCanvas.TransformToVisual(this).Transform(this.mapToPanLayer(point2D));
            }
            catch
            {
                return new Point(double.NaN, double.NaN);
            }
        }

        public Utility.Point2D ScreenToMap(Point point)
        {

            if (this._layerCollectionCanvas == null)
            {
                return null;
            }
            try
            {
                return this.panLayerToMap(base.TransformToVisual(this._layerCollectionCanvas).Transform(point));
            }
            catch
            {
                return null;
            }
        }

        private Point mapToPanLayer(Utility.Point2D pt)
        {
            if ((_origin != null) && !double.IsNaN(_mapResolution))
            {
                return new Point((pt.X - _origin.X) / _mapResolution, (_origin.Y - pt.Y) / _mapResolution);
            }
            return new Point(double.NaN, double.NaN);
        }

        void MapControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _currentSize = e.NewSize;
        }

        public LayerCollection Layers
        {
            get
            {
                return (LayerCollection)this.GetValue(LayersProperty);
            }
            set
            {
                this.SetValue(LayersProperty, value);
            }
        }

        public static DependencyProperty LayersProperty =
            DependencyProperty.Register("Layers", typeof(LayerCollection), typeof(MapControl), new PropertyMetadata(new PropertyChangedCallback(OnLayersPropertyChanged)));
        private static void OnLayersPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MapControl map = sender as MapControl;
            if (e.NewValue != null)
            {
                LayerCollection layerCollection = e.NewValue as LayerCollection;
                if (layerCollection != null)
                {
                    layerCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(map.Layers_CollectionChanged);
                    layerCollection.LayersInitialized += new EventHandler(map.Layers_LayersInitialized);
                    foreach (var layer in layerCollection)
                    {
                        if (layer != null)
                        {
                            layer.Initialized += new EventHandler<EventArgs>(map.Layer_Initialized);
                            if (!layer.IsInitialized && !layer.IsInitializing)
                            {
                                layer.Initialize();
                            }
                        }
                    }
                }
            }
            if (e.OldValue != null)
            {
                LayerCollection layerCollection = e.OldValue as LayerCollection;
                if (layerCollection != null)
                {
                    layerCollection.CollectionChanged -= map.Layers_CollectionChanged;
                    layerCollection.LayersInitialized -= map.Layers_LayersInitialized;
                    foreach (var layer in layerCollection)
                    {
                        if (layer != null)
                        {
                            layer.Initialized -= map.Layer_Initialized;
                        }
                    }
                }
            }
        }

        private void Layers_LayersInitialized(object sender, EventArgs e)
        {
            if (_origin == null)
            {
                Utility.Rectangle2D bounds = this.Bounds;
                if (bounds.IsEmpty)
                {
                    return;
                }
                if (ViewBounds != null)
                {
                    bounds = ViewBounds;
                }
                _cacheBounds = bounds;
                if ((_currentSize.Width == 0.0) || (_currentSize.Height == 0.0))
                {
                    base.Dispatcher.BeginInvoke(delegate { this.Layers_LayersInitialized(sender, e); });
                    return;
                }
            }
            this.CalculateStartViewBounds(_currentSize);
            foreach (Layer layer in this.Layers)
            {
                this.AssignLayerContainer(layer);
            }
            this.LoadLayersInView(false, this.GetFullViewBounds());
        }

        private void AssignLayerContainer(Layer layer)
        {
            if (layer.LayerCanvas.Parent == null && layer.IsInitialized)
            {
                layer.LayerCanvas.OriginX = this._origin.X;
                layer.LayerCanvas.OriginY = this._origin.Y;
                layer.LayerCanvas.Resolution = this._mapResolution;
                this.InsertLayerContainer(layer);
            }
        }
        private void InsertLayerContainer(Layer layer)
        {
            int index = 0;
            int num = Layers.IndexOf(layer);
            if (num > 0)
            {
                for (int i = num - 1; i >= 0; i--)
                {
                    Layer layer2 = this.Layers[i];
                    if ((layer2.LayerCanvas != null) && (layer2.LayerCanvas.Parent == this._layerCollectionCanvas))
                    {
                        index = this._layerCollectionCanvas.Children.IndexOf(layer2.LayerCanvas) + 1;
                        break;
                    }
                }
            }
            _layerCollectionCanvas.Children.Insert(index, layer.LayerCanvas);
        }

        private void Layer_Initialized(object sender, EventArgs e)
        {
            //if (!System.Windows.Deployment.Current.Dispatcher.CheckAccess())
            //{
            //    System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            //    {
            //        Layer layer = sender as Layer;
            //        this.AddLayer(layer);
            //    });
            //}
            //else
            //{
            //    this.AddLayer(sender as Layer);
            //}
        }

        private void CalculateStartViewBounds(Size size)
        {
            if (this._cacheBounds != null && this._origin == null)
            {
                Utility.Rectangle2D bounds = this._cacheBounds;
                double width = size.Width;
                double height = size.Height;
                double resWidth = bounds.Width / width;
                double resHeight = bounds.Height / height;
                _mapResolution = (resHeight > resWidth) ? resHeight : resWidth;
                _origin = new Utility.Point2D(bounds.Center.X - width * 0.5 * _mapResolution, bounds.Center.Y + height * 0.5 * _mapResolution);
                _cacheBounds = new Utility.Rectangle2D(this.ViewBounds);
                SetOriginAndResolution(_mapResolution, new Utility.Point2D(_origin));
            }
        }

        private Utility.Rectangle2D GetFullViewBounds()
        {
            if (double.IsNaN(this._mapResolution))
            {
                return null;
            }
            Utility.Point2D point = Screen2Map(new Point(0.0, 0.0));
            Utility.Point2D point2 = Screen2Map(new Point(0.0, _currentSize.Height));
            Utility.Point2D point3 = Screen2Map(new Point(_currentSize.Width, _currentSize.Height));
            Utility.Point2D point4 = Screen2Map(new Point(_currentSize.Width, 0.0));
            if (point == null || point2 == null || point3 == null || point4 == null)
            {
                return null;
            }
            Utility.Rectangle2D pointBounds = new Utility.Rectangle2D(point, point);
            Utility.Rectangle2D point2Bounds = new Utility.Rectangle2D(point2, point2);
            Utility.Rectangle2D point3Bounds = new Utility.Rectangle2D(point3, point3);
            Utility.Rectangle2D point4Bounds = new Utility.Rectangle2D(point4, point4);
            Utility.Rectangle2D bounds = pointBounds;
            bounds.Union(point2Bounds);
            bounds.Union(point3Bounds);
            bounds.Union(point4Bounds);
            return bounds;
        }

        private void LoadLayersInView(bool useTransitions, Utility.Rectangle2D drawBounds)
        {
            if (drawBounds != null)
            {
                foreach (var layer in this.Layers)
                {
                    this.LoadLayerInView(useTransitions, drawBounds, layer);
                }
            }
        }

        private void LoadLayerInView(bool useTransitions, Utility.Rectangle2D drawBounds, Layer layer)
        {
            layer.ViewBounds = new Utility.Rectangle2D(drawBounds);
            layer.Resolution = _mapResolution;
            layer.Draw();
        }

        private void Layers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //if (e.NewItems != null)
            //{
            //    foreach (var item in e.NewItems)
            //    {
            //        Layer layer = item as Layer;
            //        if (layer != null)
            //        {
            //            layer.Initialized += new EventHandler<EventArgs>(Layer_Initialized);
            //            if (!layer.IsInitialized && !layer.IsInitializing)
            //            {
            //                layer.Initialize();
            //            }
            //        }
            //    }
            //}
            //else if (e.OldItems != null)
            //{
            //    if (e.OldItems != null)
            //    {
            //        foreach (var item in e.OldItems)
            //        {
            //            Layer layer = item as Layer;
            //            if (layer != null)
            //            {
            //                layer.Initialized -= Layer_Initialized;
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 获取当前地图的分辨率。
        /// </summary>
        public double Resolution
        {
            get
            {
                if (this.Bounds == null || this.Bounds.IsEmpty || this.ActualWidth <= 0.0)
                    return double.NaN;
                else
                    return this.Bounds.Width / this.ActualWidth;
            }
        }

        /// <summary>
        /// 获取当前地图的可视范围。
        /// </summary>
        public Utility.Rectangle2D ViewBounds
        {
            get
            {
                if (_origin == null || double.IsNaN(_mapResolution) || _currentSize.Width == 0.0 || _currentSize.Height == 0.0)
                {
                    return _cacheBounds;
                }

                double left = this._origin.X;
                double top = this._origin.Y;
                return new Utility.Rectangle2D(left, top - _currentSize.Height * _mapResolution, left + _currentSize.Width * _mapResolution, top);
            }
        }

        private double _scale = double.NaN;
        /// <summary>
        /// 获取当前地图的比例尺。
        /// </summary>
        public double Scale
        {
            get { return _scale; }
        }

        public Utility.CoordinateReferenceSystem CRS
        {
            get;
            set;
        }

        public Utility.Rectangle2D Bounds
        {
            get
            {
                if (this.Layers != null)
                {
                    return this.Layers.GetBounds();
                }
                return null;
            }
        }

        private void SetOriginAndResolution(double currentResolution, Utility.Point2D currentOrigin, bool resetTransforms)
        {

        }

        private bool isClipPropertySet;
        private RectangleGeometry clippingRectangle;
        private void UpdateClip(Size arrangeSize)
        {
            if (!this.isClipPropertySet && (this.rootElement != null))
            {
                this.clippingRectangle = new RectangleGeometry();
                this.rootElement.Clip = this.clippingRectangle;
                this.isClipPropertySet = true;
            }
            if (this.clippingRectangle != null)
            {
                this.clippingRectangle.Rect = new Rect(0.0, 0.0, arrangeSize.Width, arrangeSize.Height);
            }
        }

        #region 事件
        public event EventHandler<ViewBoundsChanedEventArgs> ViewBoundsChanged;
        #endregion

        #region 鼠标响应函数
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
        }
        #endregion

        public void Pan(Utility.Rectangle2D bounds)
        {
            //if (this.Layers != null && this.Layers.Count > 0)
            //{
            //    foreach (var item in Layers)
            //    {
            //        if (item != null)
            //        {
            //            UpdateLayer(item, bounds);
            //        }
            //    }
            //    if (ViewBoundsChanged != null)
            //    {
            //        ViewBoundsChanged(this, new ViewBoundsChanedEventArgs(new Utility.Rectangle2D(_viewBounds), new Utility.Rectangle2D(bounds)));
            //    }
            //}
        }

        public Utility.Point2D Screen2Map(Point point)
        {
            if (this._layerCollectionCanvas == null)
            {
                return null;
            }
            try
            {
                return this.panLayerToMap(base.TransformToVisual(this._layerCollectionCanvas).Transform(point));
            }
            catch
            {
                return null;
            }
        }

        private Utility.Point2D panLayerToMap(Point pnt)
        {
            if ((this._origin != null) && !double.IsNaN(this._mapResolution))
            {
                return new Utility.Point2D((pnt.X * this._mapResolution) + this._origin.X, this._origin.Y - (pnt.Y * this._mapResolution));
            }
            return null;
        }

    }
}
