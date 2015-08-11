using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Utility = SuperMap.Connector.Utility;
using System.Collections.Specialized;

namespace SuperMap.Connector.Control.WindowsPhone
{
    public class MapControl : System.Windows.Controls.Control
    {
        public MapControl()
        {
            this.Loaded += new RoutedEventHandler(MapControl_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(MapControl_SizeChanged);
        }

        private void MapControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        #region Fields

        private Utility.Rectangle2D _bounds;
        private Utility.Rectangle2D _viewBounds;
        private double _scale;

        #endregion

        #region Property

        public Utility.Rectangle2D Bounds { get { return _bounds; } }
        public Utility.Rectangle2D ViewBounds { get; set; }
        public double Scale { get { return _scale; } }

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
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
        public static DependencyProperty LayersProperty = DependencyProperty.Register("Layers", typeof(LayerCollection), typeof(MapControl), new PropertyMetadata(new PropertyChangedCallback(OnLayersChanged)));
        private static void OnLayersChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                LayerCollection layerCollection = e.NewValue as LayerCollection;
                if (layerCollection != null)
                {
                    layerCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Layers_CollectionChanged);
                }
            }
            if (e.OldValue != null)
            {
                LayerCollection layerCollection = e.NewValue as LayerCollection;
                if (layerCollection != null)
                    layerCollection.CollectionChanged -= Layers_CollectionChanged;
            }
        }

        private static void Layers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MapControl mapControl = sender as MapControl;
        }

        public Point MapToScreen(Utility.Point2D point2D)
        {
            return new Point();
        }

        public Utility.Point2D ScreenToMap(Point point)
        {
            return new Utility.Point2D();
        }
    }
}
