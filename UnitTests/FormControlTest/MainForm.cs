using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Connector.Control.Utility;
using SuperMap.Connector.Control.Forms;

namespace FormMapControlTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MapByZoomCountLayer mapLayer = new MapByZoomCountLayer("1", "世界地图",
                "http://192.168.116.114:8090/iserver/services/map-world/rest", "世界地图", 5, 3);
            this.mapControl1.MapLayer = mapLayer;
        }

        private void btnTestGraphicsLayer_Click(object sender, EventArgs e)
        {
            Marker marker = new Marker("1", new SuperMap.Connector.Utility.Point2D(80, 30), MarkerType.Arrow, null);
            GraphicsLayer layer = new GraphicsLayer("2", "高亮");
            layer.Markers.Add(marker);
            this.mapControl1.GraphicsLayers.Add(layer);
        }
    }
}
