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
using SuperMap.Connector.Control.WPF;
using System.Threading;

namespace demo.WpfApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SynchronizationContext _sync;
        bool _isMoving;

        public MainWindow()
        {
            InitializeComponent();
            
            _sync = SynchronizationContext.Current;
            Map.PropertyChanged += new SuperMap.Connector.Control.WPF.MapPropertyChangedHandler(Map_PropertyChanged);
            Map.MapLoaded += new EventHandler(Map_MapLoaded);
            Map.MapLayerError += new MapErrorEventHandler(Map_MapLayerError);
            Map.MouseLeftButtonDown += new MouseButtonEventHandler(Map_MouseLeftButtonDown);
            Map.MouseLeftButtonUp += new MouseButtonEventHandler(Map_MouseLeftButtonUp);
            Map.MapLayer= new MapByZoomCountLayer("111","testLayer","http://192.168.120.116:8090/iserver/services/map-world", "世界地图", 7);
            
        }

        void Map_MapLayerError(object sender, MapErrorEventArgs e)
        {
            _sync.Post(ShowMessage, "地图图层异常");
        }

        void Map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMoving = false;
        }

        void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Map.CurrentAction!=null&&Map.CurrentAction.GetType() == typeof(PanAction))
            {
                _isMoving = true;
            }
        }

        void Map_MapLoaded(object sender, EventArgs e)
        {
            _sync.Post(ShowMessage,"地图加载成功");
        }

        private void ShowMessage(object obj)
        {
            if (!_isMoving)
            {
                MessageBox.Show(this, obj.ToString(), "提示", MessageBoxButton.OK);
            }
        }

        void Map_PropertyChanged(object sender, SuperMap.Connector.Control.WPF.MapPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Center")
            {
                NowCenterX.Text = Map.Center.X.ToString();
                NowCenterY.Text = Map.Center.Y.ToString();
            }
            else if (e.PropertyName == "MapLayer")
            {
                this.BoundsLeft.Text = Map.Bounds.LeftBottom.X.ToString();
                this.BoundsTop.Text = Map.Bounds.RightTop.Y.ToString();
                this.BoundsRight.Text = Map.Bounds.RightTop.X.ToString();
                this.BoundsBottom.Text = Map.Bounds.LeftBottom.Y.ToString();
            }
            else if (e.PropertyName == "ViewBounds")
            {
                _sync.Post(new SendOrPostCallback(UpdateViewBounds),null);
            }
        }

        private void UpdateViewBounds(object obj)
        {
            this.ViewBoundsLeft.Text = Map.ViewBounds.LeftBottom.X.ToString();
            this.ViewBoundsTop.Text = Map.ViewBounds.RightTop.Y.ToString();
            this.ViewBoundsRight.Text = Map.ViewBounds.RightTop.X.ToString();
            this.ViewBoundsBottom.Text = Map.ViewBounds.LeftBottom.Y.ToString();
        }

        private void ChangeServer_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Url.Text) && !string.IsNullOrEmpty(MapName.Text))
            {
                Map.MapLayer = new MapByZoomCountLayer("222", "asd", Url.Text, MapName.Text,8);
            }
        }

        private void DragButton_Click(object sender, RoutedEventArgs e)
        {
            Map.CurrentAction = new PanAction();
        }

        private void ZoomChange_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Zoom.Text))
            {
                int zoom = 0;
                Int32.TryParse(Zoom.Text, out zoom);
                Map.Zoom = zoom;
            }
        }

        private void CenterChange_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PanCenter.Text))
            {
                string[] panArray = PanCenter.Text.Split(',');
                if (panArray.Length == 2)
                {
                    double x, y;
                    double.TryParse(panArray[0], out x);
                    double.TryParse(panArray[1], out y);
                    Map.Center = new SuperMap.Connector.Utility.Point2D(x, y);
                }
            }

        }

        private void Map_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

    }
}
