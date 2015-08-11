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
using SharpMap;
using SharpMap.Layers;
using Brutile.SuperMapProvider;

namespace mapsui.demo.wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double[] scales = new double[] { 1.0 / 500000000.0, 1.0 / 250000000.0, 1.0 / 125000000.0, 1.0 / 62500000.0, 1.0 / 31250000, 1.0 / 15624000 };
            SuperMapTileSource tileSource = new SuperMapTileSource("http://localhost:8090/iserver/services/map-world/rest", "世界地图_Day",
                256, "png", scales);

            mapControl.Map = CreateMap(new TileLayer(tileSource) { LayerName = "iServer" });
        }

        private static Map CreateMap(ILayer layer)
        {
            var map = new Map();
            map.Layers.Add(layer);
            return map;
        }
    }
}
