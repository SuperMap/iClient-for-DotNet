using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpMap;
using SharpMap.Layers;
using SuperMap.Connector.Utility;
using Brutile.SuperMapProvider;

namespace mapsui.demo.winform
{
    public partial class MainForm : Form
    {
        private string _serviceUrl;
        public MainForm()
        {
            InitializeComponent();
        }

        private static Map CreateMap(ILayer layer)
        {
            var map = new Map();
            map.Layers.Add(layer);
            return map;
        }

        private void tsBtnInit_Click(object sender, EventArgs e)
        {
            Option optionForm = new Option();
            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.comboBox1.Items.Clear();
                this._serviceUrl = optionForm.URL;
                SuperMap.Connector.Map map = new SuperMap.Connector.Map(this._serviceUrl);
                List<string> mapNames = map.GetMapNames();
                if (mapNames != null && mapNames.Count > 0)
                {
                    for (int i = 0; i < mapNames.Count; i++)
                    {
                        this.comboBox1.Items.Add(mapNames[i]);
                    }
                    this.comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mapName = this.comboBox1.Text;
            SuperMap.Connector.Map map = new SuperMap.Connector.Map(this._serviceUrl);
            MapParameter mapParameter = map.GetDefaultMapParameter(mapName);
            double defaultScale = mapParameter.Scale;
            double[] scales = new double[] {defaultScale/16,defaultScale/14,defaultScale/12,defaultScale/10,
                defaultScale/8,defaultScale/6,defaultScale/4,defaultScale/2, defaultScale,defaultScale*2,
            defaultScale*4,defaultScale*6,defaultScale*8,defaultScale*10,defaultScale*12,defaultScale*14,defaultScale*16};
            SuperMapTileSource tileSource =
                new SuperMapTileSource(this._serviceUrl, mapName,
                256, "png", scales);
            TileLayer layer = new TileLayer(tileSource);
            layer.LayerName = mapName;

            mapControl.Map = CreateMap(layer);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mapControl.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mapControl.ZoomOut();
        }

        private void btnThemeUnique_Click(object sender, EventArgs e)
        {
            UGCThemeLayer ugcThemeLayer = new UGCThemeLayer();
            ugcThemeLayer.Type = LayerType.UGC;
            ugcThemeLayer.Visible = true;
            ugcThemeLayer.UgcLayerType = UGCLayerType.THEME;
            ugcThemeLayer.DatasetInfo = new DatasetInfo();
            ugcThemeLayer.DatasetInfo.DataSourceName = "Jingjin";
            ugcThemeLayer.DatasetInfo.Name = "BaseMap_R";
            ugcThemeLayer.DatasetInfo.Type = DatasetType.REGION;

            //theme.graduatedMode = SuperMap.Web.iServerJava6R.GraduatedMode.SQUAREROOT;
            //theme.graphAxes.axesDisplayed = true;
            //theme.graphSize.maxGraphSize = 1;
            //theme.graphSize.minGraphSize = 0.35;
            //theme.graphText.graphTextDisplayed = true;
            //theme.graphText.graphTextFormat = SuperMap.Web.iServerJava6R.ThemeGraphTextFormat.VALUE;
            //theme.graphType = SuperMap.Web.iServerJava6R.ThemeGraphType.BAR3D;


            ThemeGraph themeGraph = new ThemeGraph();
            themeGraph.Type = ThemeType.GRAPH;
            themeGraph.GraphType = ThemeGraphType.BAR3D;
            themeGraph.GraduatedMode = GraduatedMode.SQUAREROOT;
            themeGraph.AxesDisplayed = true;
            themeGraph.MaxGraphSize = 1;
            themeGraph.MinGraphSize = 0.35;
            themeGraph.GraphTextDisplayed = true;
            themeGraph.GraphTextFormat = GraphTextFormat.VALUE;
            themeGraph.BarWidth = 0.03;

            var item1 = new ThemeGraphItem();
            item1.Caption = "1";
            item1.GraphExpression = "Pop_Rate95";
            var style1 = new SuperMap.Connector.Utility.Style();
            style1.FillForeColor = new SuperMap.Connector.Utility.Color(211, 111, 240);
            item1.UniformStyle = style1;

            var item2 = new ThemeGraphItem();
            item2.Caption = "人口";
            item2.GraphExpression = "Pop_Rate99";
            var style2 = new SuperMap.Connector.Utility.Style();
            style2.FillForeColor = new SuperMap.Connector.Utility.Color(92, 73, 234);
            item2.UniformStyle = style2;

            themeGraph.Items = new ThemeGraphItem[] { item1, item2 };

            ugcThemeLayer.Theme = themeGraph;
            SuperMap.Connector.Map map = new SuperMap.Connector.Map("http://localhost:8090/iserver/services/map-jingjin");
            MapParameter defaultMapParameter = map.GetDefaultMapParameter("京津地区人口分布图_专题图");
            List<SuperMap.Connector.Utility.Layer> layers = new List<SuperMap.Connector.Utility.Layer>();
            layers.Add(ugcThemeLayer);
            //layers.Add(defaultMapParameter.Layers[11]);
            //layers.Add(defaultMapParameter.Layers[12]);
            MapParameter requestMapParameter = new MapParameter();
            requestMapParameter.Name = "京津地区人口分布图_专题图";
            requestMapParameter.Bounds = new SuperMap.Connector.Utility.Rectangle2D(defaultMapParameter.Bounds);
            requestMapParameter.CacheEnabled = false;
            requestMapParameter.ColorMode = MapColorMode.DEFAULT;
            requestMapParameter.RectifyType = RectifyType.BYCENTERANDMAPSCALE;

            requestMapParameter.CoordUnit = Unit.METER;
            requestMapParameter.OverlapDisplayed = true;
            requestMapParameter.PaintBackground = true;
            //requestMapParameter.MaxVisibleVertex = 3600000;
            requestMapParameter.Layers = layers;


            double defaultScale = defaultMapParameter.Scale;
            double[] scales = new double[] {defaultScale/16,defaultScale/14,defaultScale/12,defaultScale/10,
                defaultScale/8,defaultScale/6,defaultScale/4,defaultScale/2, defaultScale,defaultScale*2,
            defaultScale*4,defaultScale*6,defaultScale*8,defaultScale*10,defaultScale*12,defaultScale*14,defaultScale*16};
            SuperMapTileSource tileSource =
                new SuperMapTileSource("http://localhost:8090/iserver/services/map-jingjin", "京津地区人口分布图_专题图",
                256, "png", scales, requestMapParameter);
            TileLayer layer = new TileLayer(tileSource);
            layer.LayerName = "京津地区人口分布图_专题图1";

            mapControl.Map = CreateMap(layer);
        }

        private void btnSqlQuery_Click(object sender, EventArgs e)
        {

        }
    }
}
