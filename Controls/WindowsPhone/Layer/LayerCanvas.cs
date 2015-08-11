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
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.Control.WindowsPhone
{
    internal sealed class LayerCanvas : Panel
    {
        internal static readonly DependencyProperty ExtentProperty = DependencyProperty.RegisterAttached(
            "Extent", typeof(Rectangle2D), typeof(LayerCanvas), new PropertyMetadata(new PropertyChangedCallback(OnExtentPropertyChanged)));
        internal static readonly DependencyProperty OriginXProperty = DependencyProperty.Register(
            "OriginX", typeof(double), typeof(LayerCanvas), new PropertyMetadata(new PropertyChangedCallback(OnOriginPropertyChanged)));
        internal static readonly DependencyProperty OriginYProperty = DependencyProperty.Register(
            "OriginY", typeof(double), typeof(LayerCanvas), new PropertyMetadata(new PropertyChangedCallback(OnOriginPropertyChanged)));
        internal static readonly DependencyProperty ResolutionProperty = DependencyProperty.Register(
            "Resolution", typeof(double), typeof(LayerCanvas), new PropertyMetadata(new PropertyChangedCallback(OnResolutionPropertyChanged)));

        private static void OnExtentPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is FrameworkElement)
            {
                FrameworkElement element = sender as FrameworkElement;
                LayerCanvas parent = element.Parent as LayerCanvas;
                if (parent != null)
                {
                    Rectangle2D oldValue = e.OldValue as Rectangle2D;
                    Rectangle2D newValue = e.NewValue as Rectangle2D;
                    if (newValue == null)
                    {
                        element.Visibility = Visibility.Collapsed;
                    }
                    else if ((oldValue != null) && (oldValue.Height == newValue.Height) && (oldValue.Width == newValue.Width))
                    {
                        parent.InvalidateArrange();
                    }
                    else
                    {
                        parent.InvalidateMeasure();
                    }
                }
            }
        }

        private static void OnResolutionPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LayerCanvas canvas = sender as LayerCanvas;
            if (canvas != null)
            {
                canvas.InvalidateArrange();
            }
        }

        private static void OnOriginPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LayerCanvas canvas = sender as LayerCanvas;
            if (canvas != null)
            {
                canvas.InvalidateArrange();
            }
        }

        public double OriginX
        {
            get { return Convert.ToDouble(GetValue(OriginXProperty)); }
            set { SetValue(OriginXProperty, value); }
        }

        public double OriginY
        {
            get { return Convert.ToDouble(GetValue(OriginYProperty)); }
            set { SetValue(OriginYProperty, value); }
        }

        public Point2D Origin
        {
            get { return new Point2D(this.OriginX, this.OriginY); }
        }

        public double Resolution
        {
            get { return Convert.ToDouble(GetValue(ResolutionProperty)); }
            set { SetValue(ResolutionProperty, value); }
        }

        public Layer Layer { get; private set; }

        public LayerCanvas(Layer layer)
        {
            this.Layer = layer;
            this.Layer.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Layer_PropertyChanged);
        }

        void Layer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Layer layer = sender as Layer;
            if (layer != null)
            {
                if (e.PropertyName == "Visiable")
                {
                    if (layer.Visiable)
                    {
                        layer.LayerCanvas.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        layer.LayerCanvas.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        public static void SetExtent(DependencyObject obj, Rectangle2D rec)
        {
            obj.SetValue(ExtentProperty, rec);
        }

        public static Rectangle2D GetExtent(DependencyObject obj)
        {
            return obj.GetValue(ExtentProperty) as Rectangle2D;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement element in Children)
            {
                element.Measure(availableSize);
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement element in Children)
            {
                Rectangle2D rec = GetExtent(element);
                double left = (rec.LeftBottom.X - this.OriginX) / Resolution;
                double top = (this.OriginY - rec.RightTop.Y) / Resolution;
                double width=rec.Width/Resolution;
                double height=rec.Height/Resolution;
                element.Arrange(new Rect(left, top, width, height));
            }

            return base.ArrangeOverride(finalSize);
        }
    }
}
