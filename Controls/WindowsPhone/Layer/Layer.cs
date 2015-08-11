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
using SuperMap.Connector;
using SuperMap.Connector.Utility;
using System.ComponentModel;
using System.Threading;
using System.Windows.Media.Imaging;

namespace SuperMap.Connector.Control.WindowsPhone
{
    public abstract class Layer : DependencyObject, INotifyPropertyChanged
    {
        public Layer()
        {
            LayerCanvas = new LayerCanvas(this);
        }

        internal LayerCanvas LayerCanvas { get; set; }
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(string), typeof(Layer), null);
        public string ID
        {
            get { return (string)this.GetValue(IDProperty); }
            set { this.SetValue(IDProperty, value); }
        }
        public string Name { get; set; }
        public bool Visiable { get; set; }
        public Rectangle2D ViewBounds { get; set; }
        public System.Windows.Shapes.Rectangle MapSize { get; internal set; }
        public Rectangle2D Bounds { get; set; }
        public bool IsInitialized = false;
        public bool IsInitializing = false;
        public double Scale { get; set; }
        public double Opacity { get; set; }
        public double Resolution { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> Initialized;

        public abstract void Draw();
        public virtual void Initialize()
        {

        }

        protected void OnInitialized()
        {
            if (this.Initialized != null)
            {
                Initialized(this, null);
            }
        }
    }
}
