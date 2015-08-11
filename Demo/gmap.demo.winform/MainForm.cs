using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using SuperMap.Connector.Utility;
using GMap.SuperMapProvider;
using SuperMap.Connector;
using GMap.NET.MapProviders;

namespace gmap.demo.winform
{
    public partial class MainForm : Form
    {
        GMapProvider _gMapProvider = null;
        private InitForm _initForm = null;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        QuerySettingForm _settingForm = null;
        SQLForm _SQLForm = null;

        public MainForm()
        {
            InitializeComponent();
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            #region 注册事件

            this.tsbOpen.Click += new EventHandler(tsbOpen_Click);
            this.tsbtnQuerySetting.Click += new EventHandler(tsbtnQuerySetting_Click);

            #endregion

            this.mapControl1.MapProvider = GMapProviders.EmptyProvider;

            for (int i = 0; i < this.toolStrip1.Items.Count; i++)
            {
                ToolStripItem item = this.toolStrip1.Items[i];
                if (item.Name == "tsbOpen") continue;
                item.Enabled = false;
            }
            this.mapControl1.CurrentAction = _panAction;
        }

        #region
        IAction _panAction = new PanAction();
        IAction _measureAreaAction = null;
        IAction _measureDistanceAction = null;
        IAction _queryByPolygonAction = null;
        IAction _queryByPointAction = null;
        IAction _queryByRect = null;
        #endregion

        private void tsbPan_Click(object sender, EventArgs e)
        {
            if (_panAction == null)
            {
                _panAction = new PanAction();
            }
            this.mapControl1.CurrentAction = _panAction;
            ToolCheckChanged((sender as ToolStripItem).Name);
        }

        private void tsbZoomIn_Click(object sender, EventArgs e)
        {
            this.mapControl1.Zoom += 1;
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            this.mapControl1.Zoom -= 1;
        }

        private void tsbMeasureArea_Click(object sender, EventArgs e)
        {
            if (_measureAreaAction == null)
            {
                _measureAreaAction = new MeasureAreaAction();
            }
            this.mapControl1.CurrentAction = _measureAreaAction;
            ToolCheckChanged((sender as ToolStripItem).Name);
        }

        private void tsbMeasureDistance_Click(object sender, EventArgs e)
        {
            if (_measureDistanceAction == null)
            {
                _measureDistanceAction = new MeasureDistanceAction();
            }
            this.mapControl1.CurrentAction = _measureDistanceAction;
            ToolCheckChanged((sender as ToolStripItem).Name);
        }

        private void tsbQueryByPolygon_Click(object sender, EventArgs e)
        {
            if (_queryByPolygonAction == null)
            {
                _queryByPolygonAction = new QueryByPolygonAction();
            }
            this.mapControl1.CurrentAction = _queryByPolygonAction;
            ToolCheckChanged((sender as ToolStripItem).Name);
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (this._initForm == null)
            {
                this._initForm = new InitForm();
            }
            if (this._initForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Map map = new Map(this._initForm.MapUrl);
                MapParameter defaultMapParameter = map.GetDefaultMapParameter(this._initForm.SelectedMapName);
                double[] mapScales = new double[21];
                mapScales[0] = defaultMapParameter.Scale / 6;
                mapScales[1] = defaultMapParameter.Scale / 4;
                mapScales[2] = defaultMapParameter.Scale / 2;
                mapScales[3] = defaultMapParameter.Scale;
                for (int i = 0; i < 17; i++)
                {
                    mapScales[i + 4] = mapScales[i + 3] * 2;
                }
                _gMapProvider = new SuperMapProvider(this._initForm.MapUrl, this._initForm.SelectedMapName, mapScales);
                //_gMapProvider = new SuperMapProvider(this._initForm.MapUrl, this._initForm.SelectedMapName, 256, "png", null);
                this.mapControl1.Init();
                this.mapControl1.MapProvider = _gMapProvider;
                this._mapUrl = this._initForm.MapUrl;
                this._mapName = this._initForm.SelectedMapName;
                this.mapControl1.DragButton = System.Windows.Forms.MouseButtons.Left;
                this.mapControl1.Position = new PointLatLng(defaultMapParameter.Center.Y, defaultMapParameter.Center.X);
                this.mapControl1.MinZoom = 0;
                this.mapControl1.MaxZoom = mapScales.Length - 1;
                this.mapControl1.Zoom = 3;
                this.mapControl1.ReloadMap();

                //工具条按钮可见。
                for (int i = 0; i < this.toolStrip1.Items.Count; i++)
                {
                    this.toolStrip1.Items[i].Enabled = true;
                }
                for (int i = 0; i < this.tsbDropdownbtn.DropDownItems.Count; i++)
                {
                    if (this.tsbDropdownbtn.DropDownItems[i].Name == "tsbtnQuerySetting")
                        this.tsbDropdownbtn.DropDownItems[i].Enabled = true;
                    else this.tsbDropdownbtn.DropDownItems[i].Enabled = false;
                    this.tsbDropdownbtn.DropDownItems["sQLQuery"].Enabled = true;
                }
            }
        }

        void tsbtnQuerySetting_Click(object sender, EventArgs e)
        {
            _settingForm = new QuerySettingForm(this._mapUrl, this._mapName);
            this.AddOwnedForm(_settingForm);

            if (_settingForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (QuerySetting.LayerNames.Count == 0)
                {
                    MessageBox.Show("至少选择一个查询图层！");
                    for (int i = 0; i < this.tsbDropdownbtn.DropDownItems.Count; i++)
                    {
                        if (this.tsbDropdownbtn.DropDownItems[i].Name != "tsbtnQuerySetting")
                            this.tsbDropdownbtn.DropDownItems[i].Enabled = false;
                    }
                    return;
                }
                for (int i = 0; i < this.tsbDropdownbtn.DropDownItems.Count; i++)
                {
                    this.tsbDropdownbtn.DropDownItems[i].Enabled = true;
                }
            }
        }

        private void tsbtnClearhighlight_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.mapControl1.Overlays.Count; i++)
            {
                this.mapControl1.Overlays[i].Markers.Clear();
                this.mapControl1.Overlays[i].Polygons.Clear();
                this.mapControl1.Overlays[i].Routes.Clear();
            }
            this.mapControl1.Refresh();
        }

        private void ToolCheckChanged(string toolName)
        {
            for (int i = 0; i < this.tsbDropdownbtn.DropDownItems.Count; i++)
            {
                if ((this.tsbDropdownbtn.DropDownItems[i] as ToolStripMenuItem).Name != toolName)
                    (this.tsbDropdownbtn.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                else
                    (this.tsbDropdownbtn.DropDownItems[i] as ToolStripMenuItem).Checked = true;
            }
            for (int i = 0; i < this.toolStrip1.Items.Count; i++)
            {
                if (this.toolStrip1.Items[i] is ToolStripButton)
                {
                    if (this.toolStrip1.Items[i].Name != toolName)
                        (this.toolStrip1.Items[i] as ToolStripButton).Checked = false;
                    else
                        (this.toolStrip1.Items[i] as ToolStripButton).Checked = true;
                }
            }
        }

        private void tsbPointQuery_Click(object sender, EventArgs e)
        {
            if (_queryByPointAction == null)
            {
                _queryByPointAction = new QueryByPointAction();
            }
            this.mapControl1.CurrentAction = _queryByPointAction;
            ToolCheckChanged((sender as ToolStripItem).Name);
        }

        private void tsbRectQuery_Click(object sender, EventArgs e)
        {
            if (_queryByRect == null)
            {
                _queryByRect = new QueryByRectAction();
            }
            this.mapControl1.CurrentAction = _queryByRect;
            ToolCheckChanged((sender as ToolStripItem).Name);
        }

        private void sQLQuery_Click(object sender, EventArgs e)
        {
            if (_SQLForm == null)
            {
                _SQLForm = new SQLForm(this._mapUrl, this._mapName);
            }
            _SQLForm.ShowDialog(this);
        }
    }

    public class QuerySetting
    {
        public static List<string> LayerNames { get; set; }

        private static int _defaultExceptionCount = 20;
        public static int ExceptionCount
        {
            get { return _defaultExceptionCount; }
            set { _defaultExceptionCount = value; }
        }

        private static QueryOption _defaultQueryOption = QueryOption.ATTRIBUTEANDGEOMETRY;
        public static QueryOption QueryOption
        {
            get { return _defaultQueryOption; }
            set { _defaultQueryOption = value; }
        }
    }
}
