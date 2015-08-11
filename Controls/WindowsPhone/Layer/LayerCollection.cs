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
    public sealed class LayerCollection : System.Collections.ObjectModel.ObservableCollection<Layer>
    {
        public LayerCollection()
            : base()
        {
            this.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(LayerCollection_CollectionChanged);
        }

        private void LayerCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    Layer layer = item as Layer;
                    if (layer != null)
                    {
                        layer.Initialized += new EventHandler<EventArgs>(Layer_Initialized);
                        if (!layer.IsInitialized && !layer.IsInitializing)
                        {
                            layer.Initialize();
                        }
                    }
                }
            }
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    Layer layer = item as Layer;
                    if (layer != null)
                    {
                        layer.Initialized -= new EventHandler<EventArgs>(Layer_Initialized);
                    }
                }
            }
        }

        void Layer_Initialized(object sender, EventArgs e)
        {
            TouchLayersInitialized();
        }

        private void TouchLayersInitialized()
        {
            if (this.LayersInitialized != null && this.IsLayersInitialized)
            {
                System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    LayersInitialized(this, new EventArgs());
                });
            }
        }
        public event EventHandler LayersInitialized;

        public Rectangle2D GetBounds()
        {
            if (this.Count <= 0) return null;
            Rectangle2D bounds = null;
            foreach (var item in this)
            {
                if (item != null && item.Bounds != null && !item.Bounds.IsEmpty)
                {
                    if (bounds != null)
                    {
                        bounds.Union(item.Bounds);
                    }
                    else
                    {
                        bounds = new Rectangle2D(item.Bounds);  
                    }
                }
            }
            return bounds;
        }

        /// <summary>
        /// 当前图层集中是否所有地图都已经初始化完成。
        /// </summary>
        internal bool IsLayersInitialized
        {
            get
            {
                bool isLayersInitialized = true;
                foreach (var item in this)
                {
                    if (item != null && item.IsInitializing && !item.IsInitialized)
                    {
                        isLayersInitialized = false;
                        break;
                    }
                }
                return isLayersInitialized;
            }
        }
    }
}
