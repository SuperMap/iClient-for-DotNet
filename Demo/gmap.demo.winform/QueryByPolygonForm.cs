using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using SuperMap.Connector.Utility;
using GMap.NET;
using GMap.SuperMapProvider;
using SuperMap.Connector;
using GMap.NET.WindowsForms.Markers;

namespace gmap.demo.winform
{
    public partial class QueryByPolygonForm : ActionForm
    {
        public QueryByPolygonForm()
            : base()
        {
            InitializeComponent();
        }

        private QueryResultForm _queryResultForm = null;
        private GMapControl _gMapControl = null;
        private GMapOverlay _gMapOverlay = new GMapOverlay("queryByPolygon");
        private GMapOverlay _highLightOverlay = new GMapOverlay("highlight");
        private bool _start = false;
        GMapPolygon _polygon = null;
        List<PointLatLng> _points = null;
        List<Point2D> _point2Ds = new List<Point2D>();
        bool flag = false;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        Dictionary<string, Recordset> _recordsets = new Dictionary<string, Recordset>();

        private int _exceptionCount = 100000;
        public int ExceptionCount
        {
            get
            {
                try
                {
                    int.TryParse(this.tbExceptionCount.Text, out _exceptionCount);
                }
                catch { _exceptionCount = 100000; }
                finally
                { }
                return _exceptionCount;
            }
        }

        public QueryOption QueryOption
        {
            get
            {
                if (this.radioButton1.Checked)
                    return SuperMap.Connector.Utility.QueryOption.GEOMETRY;
                else if (this.radioButton2.Checked)
                    return SuperMap.Connector.Utility.QueryOption.ATTRIBUTE;
                else if (this.radioButton3.Checked)
                    return SuperMap.Connector.Utility.QueryOption.ATTRIBUTEANDGEOMETRY;
                else return QueryOption.ATTRIBUTEANDGEOMETRY;
            }
        }

        public override void OnLoad(GMapControl gMapControl)
        {
            _gMapControl = gMapControl;
            _gMapControl.Overlays.Add(_gMapOverlay);

            _points = new List<PointLatLng>();
            _gMapControl.Overlays.Add(_gMapOverlay);
            _gMapControl.Overlays.Add(_highLightOverlay);
            _start = false;
            _queryResultForm = new QueryResultForm();
            this._mapUrl = ((SuperMapProvider)gMapControl.MapProvider).ServiceUrl;
            this._mapName = ((SuperMapProvider)gMapControl.MapProvider).MapName;
            InitLayers();
            base.OnLoad(gMapControl);
        }

        private void InitLayers()
        {
            this.clbLayers.Items.Clear();
            Map map = new Map(_mapUrl);
            MapParameter mapParameter = map.GetDefaultMapParameter(_mapName);
            if (mapParameter != null)
            {
                for (int i = 0; i < mapParameter.Layers.Count; i++)
                {
                    this.clbLayers.Items.Add(new LayerItem(mapParameter.Layers[i].Name, mapParameter.Layers[i].Caption));
                }
            }
        }

        public override void OnMapMouseDown(object sender, MouseEventArgs e)
        {
            _start = true;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
            Point2D point2D = new Point2D(mercatorX, mercatorY);
            _point2Ds.Add(point2D);
            _points.Add(currentPoint);
            base.OnMapMouseDown(sender, e);
        }

        public override void OnMapMouseMove(object sender, MouseEventArgs e)
        {
            if (!_start) return;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);

            if (flag)
            {
                _points.RemoveAt(_points.Count - 1);
            }
            if (!flag) flag = true;
            _points.Add(currentPoint);
            _polygon = new GMapPolygonExtension("", _points, 2.0F,
                System.Drawing.Color.FromArgb(100, 0, 0, 255), System.Drawing.Color.FromArgb(25, 0, 0, 255));
            if (_gMapOverlay.Polygons.Count > 0)
            {
                _gMapOverlay.Polygons[0] = _polygon;
            }
            else
            {
                _gMapOverlay.Polygons.Add(_polygon);
            }
            base.OnMapMouseMove(sender, e);
        }

        public override void OnMapMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!_start) return;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
            Point2D point2D = new Point2D(mercatorX, mercatorY);
            _point2Ds.Add(point2D);
            Map map = new Map(_mapUrl);

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ReturnContent = true;
            queryParameterSet.QueryOption = QueryOption;
            queryParameterSet.ExpectCount = this.ExceptionCount;
            queryParameterSet.QueryParams = new QueryParameter[this.clbLayers.CheckedItems.Count];
            for (int i = 0; i < this.clbLayers.CheckedItems.Count; i++)
            {
                queryParameterSet.QueryParams[i] = new QueryParameter();
                queryParameterSet.QueryParams[i].Name = (this.clbLayers.CheckedItems[i] as LayerItem).Name;
            }

            Geometry geo = new Geometry();
            geo.Parts = new int[1] { 1 };
            geo.Points = _point2Ds.ToArray();
            QueryResult queryResult = null;
            try
            {
                queryResult = map.QueryByGeometry(_mapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
            }
            catch (ServiceException serviceException)
            {
                MessageBox.Show(serviceException.Message);
            }

            ShowResultSet(queryResult);
            _gMapOverlay.Polygons.Clear();
            _points.Clear();
            _point2Ds.Clear();
            flag = false;
            _start = false;

            base.OnMapMouseDoubleClick(sender, e);
        }

        private void TreeFrame_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string key = e.Node.Text;
            if (_recordsets != null && _recordsets.ContainsKey(key))
            {
                FillDataFrame(_recordsets[key]);
            }
        }

        private void FillDataFrame(Recordset recordset)
        {
            this.DataFrame.Rows.Clear();
            this.DataFrame.Columns.Clear();
            if (recordset != null)
            {
                //this.DataFrame.DataSource = recordset.ToDataTable();
                for (int i = 0; i < recordset.FieldCaptions.Length; i++)
                {
                    this.DataFrame.Columns.Add(recordset.FieldCaptions[i], recordset.Fields[i]);
                }
                for (int i = 0; i < recordset.Features.Length; i++)
                {
                    int index = this.DataFrame.Rows.Add(recordset.Features[i].FieldValues);
                    this.DataFrame.Rows[i].Tag = recordset.Features[i].Geometry;
                    //DataGridViewRow row = new DataGridViewRow();
                    //row.Cells.Add(new DataGridViewCell());

                    //this.DataFrame.Rows.Add(new DataGridViewRow() { });
                }
            }
        }

        private void ShowResultSet(QueryResult resultsetValue)
        {
            _recordsets.Clear();
            this.TreeFrame.Nodes.Clear();
            if (resultsetValue != null && resultsetValue.Recordsets != null && resultsetValue.Recordsets.Length > 0)
            {
                for (int i = 0; i < resultsetValue.Recordsets.Length; i++)
                {
                    if (resultsetValue.Recordsets[i].Features.Length > 0)
                    {
                        this.TreeFrame.Nodes.Add(resultsetValue.Recordsets[i].DatasetName);
                        _recordsets.Add(resultsetValue.Recordsets[i].DatasetName, resultsetValue.Recordsets[i]);
                    }
                }
            }
        }

        private void DataFrame_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Geometry selectedGeometry = this.DataFrame.Rows[e.RowIndex].Tag as Geometry;
            _highLightOverlay.Markers.Clear();
            _highLightOverlay.Polygons.Clear();
            _highLightOverlay.Routes.Clear();

            if (selectedGeometry.Type == GeometryType.POINT || selectedGeometry.Type == GeometryType.TEXT)
            {
                double lat, lng;
                Helper.Mercator2LonLat(selectedGeometry.Points[0].X, selectedGeometry.Points[0].Y, out lng, out lat);
                PointLatLng pointLatLng = new PointLatLng(lat, lng);
                GMapMarkerGoogleRed marker = new GMapMarkerGoogleRed(pointLatLng);
                _highLightOverlay.Markers.Add(marker);
            }
            else if (selectedGeometry.Type == GeometryType.LINE)
            {

            }
            else if (selectedGeometry.Type == GeometryType.RECTANGLE || selectedGeometry.Type == GeometryType.REGION ||
                selectedGeometry.Type == GeometryType.ROUNDRECTANGLE)
            {

            }
        }

        class LayerItem
        {
            private string _name = string.Empty;
            private string _caption = string.Empty;
            public LayerItem(string name, string caption)
            {
                this._name = name;
                this._caption = caption;
            }

            public string Name
            {
                get { return this._name; }
            }

            public string Caption
            {
                get { return this._caption; }
            }

            public override string ToString()
            {
                return this.Name;
            }
        }
    }
}
