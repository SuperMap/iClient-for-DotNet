using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Control.Forms;
using SuperMap.Connector.Control.Utility;
using SuperMap.Connector.Utility;
using Draw = System.Drawing;
using System.Windows.Forms;
using SuperMap.Connector;
using System.Collections;
using System.Drawing;

namespace demo.winform
{
    public class QueryByRectAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Polygon _rect;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private Data _data = null;
        private PublicResultForm _resultForm = null;

        public QueryByRectAction()
        {

        }

        public QueryByRectAction(Form mainForm)
        {
            _resultForm = new PublicResultForm();
            _resultForm.Name = "QueryByRect";
            _resultForm.Text = "拉框查询结果";
            _resultForm.ShowInTaskbar = false;
            _resultForm.Owner = mainForm;
        }

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "画矩形";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "QueryByRectActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_rect == null)
            {
                _rect = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            _resultForm.MapControl = mapControl;
        }

        protected override void MouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseDown(e);
            _startFlag = true;
            if (_rect != null)
            {
                if (_layer.Polygons.Contains(_rect))
                {
                    _layer.Polygons.Remove(_rect);
                }
            }
            else
            {
                _rect = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            Point2D startPoint = this.Map.ScreenToMap(e.Location);
            _rect.Point2Ds.Clear();
            _rect.Point2Ds.Add(startPoint);
        }

        protected override void MouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseUp(e);
            _startFlag = false;
            UpdateRect(e.Location);
            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ReturnContent = true;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.QueryParams = QuerySetting.LayerNames.Select(c => new QueryParameter(c)).ToArray();
            Geometry geo = new Geometry(_rect.Point2Ds.ToArray(), GeometryType.REGION);

            QueryResult result = null;
            try
            {
                result = _map.QueryByGeometry(this.MapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
                _resultForm.QueryResult = result;
                _resultForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            HelpGeometry.NormalResult(_layer, result);
        }

        protected override void MouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                UpdateRect(e.Location);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;
            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _rect.Point2Ds.Clear();
        }

        private void UpdateRect(Draw.Point point)
        {
            if (_rect.Point2Ds.Count == 0)
            {
                throw new Exception("矩形点集合异常");
            }
            if (_rect.Point2Ds.Count > 1)
            {
                _rect.Point2Ds.RemoveRange(1, _rect.Point2Ds.Count - 1);
            }

            Point2D end = Map.ScreenToMap(point);
            _rect.Point2Ds.Add(new Point2D(_rect.Point2Ds[0].X, end.Y));//添加左下角点
            _rect.Point2Ds.Add(end);//添加右下角点
            _rect.Point2Ds.Add(new Point2D(end.X, _rect.Point2Ds[0].Y));//添加右上角点
            _rect.Point2Ds.Add(new Point2D(_rect.Point2Ds[0]));//添加结束点，与起始点相同
            if (_layer.Polygons.Contains(_rect))
            {
                _layer.Polygons.Remove(_rect);
            }
            _layer.Polygons.Add(_rect);
        }
    }

    public class QueryByPolygonAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Polygon _polygon;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private List<Point2D> _points;
        private PublicResultForm _resultForm = null;

        public QueryByPolygonAction()
        {

        }

        public QueryByPolygonAction(Form mainForm)
        {
            _resultForm = new PublicResultForm();
            _resultForm.Name = "QueryByPolygon";
            _resultForm.Text = "多边形查询结果";
            _resultForm.ShowInTaskbar = false;
            _resultForm.Owner = mainForm;
        }
        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "画多边形";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "QueryByPolygonActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_polygon == null)
            {
                _polygon = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            if (_points == null)
            {
                _points = new List<Point2D>();
            }
            _resultForm.MapControl = mapControl;
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!_startFlag)
                {
                    _startFlag = true;
                    if (_layer.Polygons.Contains(_polygon))
                    {
                        _layer.Polygons.Remove(_polygon);
                    }
                    _polygon.Point2Ds.Clear();
                    _points.Clear();
                }
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
            }
            else
            {
                _points.Clear();
                if (_layer.Polygons.Contains(_polygon))
                {
                    _layer.Polygons.Remove(_polygon);
                }
                _startFlag = false;
            }
        }

        protected override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                List<Point2D> temp = new List<Point2D>();
                temp.AddRange(_points);
                temp.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(temp);
            }
        }

        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            base.MouseDoubleClick(e);

            if (_startFlag)
            {
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
                _startFlag = false;

                if (_layer.Lines.Count > 0)
                {
                    _layer.Lines.Clear();
                }
                if (_layer.Markers.Count > 0)
                {
                    _layer.Markers.Clear();
                }
                if (_layer.Polygons.Count > 0)
                {
                    _layer.Polygons.Clear();
                }

                QueryParameterSet queryParameterSet = new QueryParameterSet();
                queryParameterSet.ReturnContent = true;
                queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
                queryParameterSet.QueryOption = QuerySetting.QueryOption;
                queryParameterSet.QueryParams = QuerySetting.LayerNames.Select(c => new QueryParameter(c)).ToArray();
                Geometry geo = new Geometry(_points.ToArray(), GeometryType.REGION);

                QueryResult result = null;
                try
                {
                    result = _map.QueryByGeometry(this.MapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                _resultForm.QueryResult = result;
                _resultForm.Show();
                HelpGeometry.NormalResult(_layer, result);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _polygon.Point2Ds.Clear();
            _points.Clear();
        }

        private void UpdatePolygon(List<Point2D> list)
        {
            if (_layer.Polygons.Contains(_polygon))
            {
                _layer.Polygons.Remove(_polygon);
            }
            _polygon.Point2Ds.Clear();
            _polygon.Point2Ds.AddRange(list);
            _layer.Polygons.Add(_polygon);
        }
    }

    public class QueryByPointAction : MapAction
    {
        GraphicsLayer _layer;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private Data _data = null;
        private PublicResultForm _resultForm = null;

        public QueryByPointAction()
        {

        }

        public QueryByPointAction(Form mainForm)
        {
            _resultForm = new PublicResultForm();
            _resultForm.Name = "QueryByPoint";
            _resultForm.Text = "点选查询结果";
            _resultForm.ShowInTaskbar = false;
            _resultForm.Owner = mainForm;
        }
        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "打点";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "QueryByPointActionLayer");
            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;

            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            _resultForm.MapControl = mapControl;
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);


            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ReturnContent = true;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.QueryParams = QuerySetting.LayerNames.Select(c => new QueryParameter(c)).ToArray();

            Geometry geo = new Geometry();
            geo.Type = GeometryType.POINT;
            geo.Parts = new int[] { 1 };
            geo.Points = new Point2D[1];
            geo.Points[0] = Map.ScreenToMap(e.Location);
            geo.Type = GeometryType.POINT;

            QueryResult result = null;
            try
            {
                result = _map.QueryByDistance(this.MapName, geo, 10000, queryParameterSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _resultForm.QueryResult = result;
            _resultForm.Show();
            HelpGeometry.NormalResult(_layer, result);
        }

        public override void Dispose()
        {
            base.Dispose();

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
        }
    }

    class HelpGeometry
    {
        public static void NormalResult(GraphicsLayer graLayer, QueryResult result)
        {
            if (result != null && result.Recordsets != null && result.Recordsets.Length > 0)
            {
                foreach (var v in result.Recordsets)
                {
                    if (v != null && v.Features != null && v.Features.Length > 0)
                    {
                        UGCLayer layer = QuerySetting.Layers.Cast<UGCLayer>().FirstOrDefault(c => c.Name == v.DatasetName);
                        if (layer == null)
                        {
                            continue;
                        }

                        foreach (var w in v.Features)
                        {
                            if (w == null || w.Geometry == null)
                            {
                                continue;
                            }
                            if (w.Geometry.Type == GeometryType.POINT || w.Geometry.Type == GeometryType.TEXT)
                            {
                                HelpGeometry.CreateMarker(graLayer, w, layer, v, MarkerType.Red_Pushpin);
                            }
                            else if (w.Geometry.Type == GeometryType.LINE)
                            {
                                HelpGeometry.CreateLine(graLayer, w, layer, v, Draw.Color.Blue);
                            }
                            else if (w.Geometry.Type == GeometryType.REGION || w.Geometry.Type == GeometryType.RECTANGLE)
                            {
                                HelpGeometry.CreatePolygon(graLayer, w, layer, v, Draw.Color.FromArgb(100, 0, 122, 122), Draw.Color.FromArgb(255, 0, 122, 122));

                            }
                        }
                    }
                }
            }
        }

        public static Marker CreateMarker(GraphicsLayer graLayer, Feature feature, UGCLayer layer, Recordset recordset, MarkerType type)
        {
            Marker marker = new Marker(
                                    feature.Id.ToString() + "@" + layer.DatasetInfo.Name + "@" + layer.DatasetInfo.DataSourceName + "@" + "0", feature.Geometry.Points[0], type,
                                    new SuperMap.Connector.Control.Forms.ToolTip(feature.Id.ToString(),
                                        new Draw.Font(Draw.FontFamily.Families.First(c => c.Name == "微软雅黑"), 12),
                                        Draw.StringFormat.GenericDefault, Draw.Color.White, Draw.Color.Black,
                                        Draw.Color.Black, 1));
            Dictionary<string, string> property = new Dictionary<string, string>();
            property[PropertyName.LayerName] = recordset.DatasetName;
            property[PropertyName.GraphicsLayerID] = graLayer.ID;
            property[PropertyName.SMID] = feature.Id.ToString();
            marker.Tag = property;
            graLayer.Markers.Add(marker);

            return marker;
        }

        public static Line CreateLine(GraphicsLayer graLayer, Feature feature, UGCLayer layer, Recordset recordset, Draw.Color color)
        {
            Line line = new Line(feature.Id.ToString() + "@" + layer.DatasetInfo.Name + "@" + layer.DatasetInfo.DataSourceName + "@" + "0", feature.Geometry.Points.ToList(), 2.0, color);
            Dictionary<string, string> property = new Dictionary<string, string>();
            property[PropertyName.LayerName] = recordset.DatasetName;
            property[PropertyName.GraphicsLayerID] = graLayer.ID;
            property[PropertyName.SMID] = feature.Id.ToString();
            line.Tag = property;
            graLayer.Lines.Add(line);

            return line;
        }

        public static List<Polygon> CreatePolygon(GraphicsLayer graLayer, Feature feature, UGCLayer layer, Recordset recordset, Draw.Color fillColor, Draw.Color strokeColor)
        {
            int index = 0;
            List<Polygon> list = new List<Polygon>();
            int all = feature.Geometry.Parts.Sum();
            for (int i = 0; i < feature.Geometry.Parts.Length; i++)
            {
                Point2D[] points = feature.Geometry.Points.Skip(index).Take(feature.Geometry.Parts[i]).ToArray();
                Polygon polygon = new Polygon(feature.Id.ToString() + "@" + layer.DatasetInfo.Name + "@" + layer.DatasetInfo.DataSourceName + "@" + i.ToString(), points.ToList(), fillColor, strokeColor, 1);
                Dictionary<string, string> property = new Dictionary<string, string>();
                property[PropertyName.LayerName] = recordset.DatasetName;
                property[PropertyName.GraphicsLayerID] = graLayer.ID;
                property[PropertyName.SMID] = feature.Id.ToString();
                polygon.Tag = property;
                graLayer.Polygons.Add(polygon);
                list.Add(polygon);
                index += feature.Geometry.Parts[i];
            }

            return list;
        }

        public static void ClearLayer(GraphicsLayer layer)
        {
            if (layer.Lines.Count > 0)
            {
                layer.Lines.Clear();
            }
            if (layer.Markers.Count > 0)
            {
                layer.Markers.Clear();
            }
            if (layer.Polygons.Count > 0)
            {
                layer.Polygons.Clear();
            }
        }
    }

    public class DelByPointAction : MapAction
    {
        GraphicsLayer _layer;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private Data _data = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "点选删除";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "DelByPointActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }

        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);

            HelpGeometry.ClearLayer(_layer);

            double redius = 5 * Map.Resolution;

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ReturnContent = true;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.QueryParams = QuerySetting.LayerNames.Select(c => new QueryParameter(c)).ToArray();

            Geometry geo = new Geometry();
            geo.Type = GeometryType.POINT;
            geo.Parts = new int[] { 1 };
            geo.Points = new Point2D[1];
            geo.Points[0] = Map.ScreenToMap(e.Location);
            geo.Type = GeometryType.POINT;

            QueryResult result = null;
            try
            {
                result = _map.QueryByDistance(this.MapName, geo, redius, queryParameterSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            HelpGeometry.NormalResult(_layer, result);
        }

        public override void Dispose()
        {
            base.Dispose();

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
        }

        private void DeleteData()
        {
            List<GeometryBase> list = new List<GeometryBase>();
            list.AddRange(_layer.Lines.Cast<GeometryBase>());
            list.AddRange(_layer.Markers.Cast<GeometryBase>());
            list.AddRange(_layer.Polygons.Cast<GeometryBase>());

            var v = (from i in list group i.ID.Split('@')[0] by i.ID.Substring(0, i.ID.LastIndexOf('@')).Substring(i.ID.IndexOf('@') + 1));
            foreach (var v1 in v)
            {
                string datasource = v1.Key.Split('@')[1];
                string dataset = v1.Key.Split('@')[0];
                EditResult result = _data.DeleteFeatures(datasource, dataset, v1.Select(c => int.Parse(c)).Distinct().ToArray());
            }

        }

        protected override void KeyDown(KeyEventArgs e)
        {
            base.KeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                if (_layer != null)
                {
                    DeleteData();
                    HelpGeometry.ClearLayer(_layer);
                }
                Map.ReLoadMap(true);
            }
        }
    }

    public class DelByRectAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Polygon _rect;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private Data _data = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "矩形圈选删除";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "DelByRectActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_rect == null)
            {
                _rect = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
        }

        protected override void MouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseDown(e);
            _startFlag = true;
            if (_rect != null)
            {
                if (_layer.Polygons.Contains(_rect))
                {
                    _layer.Polygons.Remove(_rect);
                }
            }
            else
            {
                _rect = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            Point2D startPoint = this.Map.ScreenToMap(e.Location);
            _rect.Point2Ds.Clear();
            _rect.Point2Ds.Add(startPoint);
        }

        protected override void MouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseUp(e);
            _startFlag = false;
            UpdateRect(e.Location);
            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ReturnContent = true;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.QueryParams = QuerySetting.LayerNames.Select(c => new QueryParameter(c)).ToArray();
            Geometry geo = new Geometry(_rect.Point2Ds.ToArray(), GeometryType.REGION);

            QueryResult result = null;
            try
            {
                result = _map.QueryByGeometry(this.MapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            HelpGeometry.NormalResult(_layer, result);
        }

        protected override void MouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                UpdateRect(e.Location);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;
            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _rect.Point2Ds.Clear();
        }

        private void UpdateRect(Draw.Point point)
        {
            if (_rect.Point2Ds.Count == 0)
            {
                throw new Exception("矩形点集合异常");
            }
            if (_rect.Point2Ds.Count > 1)
            {
                _rect.Point2Ds.RemoveRange(1, _rect.Point2Ds.Count - 1);
            }

            Point2D end = Map.ScreenToMap(point);
            _rect.Point2Ds.Add(new Point2D(_rect.Point2Ds[0].X, end.Y));//添加左下角点
            _rect.Point2Ds.Add(end);//添加右下角点
            _rect.Point2Ds.Add(new Point2D(end.X, _rect.Point2Ds[0].Y));//添加右上角点
            _rect.Point2Ds.Add(new Point2D(_rect.Point2Ds[0]));//添加结束点，与起始点相同
            if (_layer.Polygons.Contains(_rect))
            {
                _layer.Polygons.Remove(_rect);
            }
            _layer.Polygons.Add(_rect);
        }

        private void DeleteData()
        {
            List<GeometryBase> list = new List<GeometryBase>();
            list.AddRange(_layer.Lines.Cast<GeometryBase>());
            list.AddRange(_layer.Markers.Cast<GeometryBase>());
            list.AddRange(_layer.Polygons.Cast<GeometryBase>());

            var v = (from i in list group i.ID.Split('@')[0] by i.ID.Substring(0, i.ID.LastIndexOf('@')).Substring(i.ID.IndexOf('@') + 1));
            foreach (var v1 in v)
            {
                string datasource = v1.Key.Split('@')[1];
                string dataset = v1.Key.Split('@')[0];
                EditResult result = _data.DeleteFeatures(datasource, dataset, v1.Select(c => int.Parse(c)).ToArray());
            }

        }

        protected override void KeyDown(KeyEventArgs e)
        {
            base.KeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                if (_layer != null)
                {
                    DeleteData();
                    HelpGeometry.ClearLayer(_layer);
                }
                Map.ReLoadMap(true);
            }
        }
    }

    public class DelByPolygonAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Polygon _polygon;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private List<Point2D> _points;
        private Data _data = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "多边形圈选删除";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "DelByPolygonActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_polygon == null)
            {
                _polygon = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            if (_points == null)
            {
                _points = new List<Point2D>();
            }
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!_startFlag)
                {
                    _startFlag = true;
                    if (_layer.Polygons.Contains(_polygon))
                    {
                        _layer.Polygons.Remove(_polygon);
                    }
                    _polygon.Point2Ds.Clear();
                    _points.Clear();
                }
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
            }
            else
            {
                _points.Clear();
                if (_layer.Polygons.Contains(_polygon))
                {
                    _layer.Polygons.Remove(_polygon);
                }
                _startFlag = false;
            }
        }

        protected override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                List<Point2D> temp = new List<Point2D>();
                temp.AddRange(_points);
                temp.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(temp);
            }
        }

        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            base.MouseDoubleClick(e);

            if (_startFlag)
            {
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
                _startFlag = false;

                if (_layer.Lines.Count > 0)
                {
                    _layer.Lines.Clear();
                }
                if (_layer.Markers.Count > 0)
                {
                    _layer.Markers.Clear();
                }
                if (_layer.Polygons.Count > 0)
                {
                    _layer.Polygons.Clear();
                }

                QueryParameterSet queryParameterSet = new QueryParameterSet();
                queryParameterSet.ReturnContent = true;
                queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
                queryParameterSet.QueryOption = QuerySetting.QueryOption;
                queryParameterSet.QueryParams = QuerySetting.LayerNames.Select(c => new QueryParameter(c)).ToArray();
                Geometry geo = new Geometry(_points.ToArray(), GeometryType.REGION);

                QueryResult result = null;
                try
                {
                    result = _map.QueryByGeometry(this.MapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                HelpGeometry.NormalResult(_layer, result);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _polygon.Point2Ds.Clear();
            _points.Clear();
        }

        private void UpdatePolygon(List<Point2D> list)
        {
            if (_layer.Polygons.Contains(_polygon))
            {
                _layer.Polygons.Remove(_polygon);
            }
            _polygon.Point2Ds.Clear();
            _polygon.Point2Ds.AddRange(list);
            _layer.Polygons.Add(_polygon);
        }

        private void DeleteData()
        {
            List<GeometryBase> list = new List<GeometryBase>();
            list.AddRange(_layer.Lines.Cast<GeometryBase>());
            list.AddRange(_layer.Markers.Cast<GeometryBase>());
            list.AddRange(_layer.Polygons.Cast<GeometryBase>());

            var v = (from i in list group i.ID.Split('@')[0] by i.ID.Substring(0, i.ID.LastIndexOf('@')).Substring(i.ID.IndexOf('@') + 1));
            foreach (var v1 in v)
            {
                string datasource = v1.Key.Split('@')[1];
                string dataset = v1.Key.Split('@')[0];
                EditResult result = _data.DeleteFeatures(datasource, dataset, v1.Select(c => int.Parse(c)).ToArray());
            }

        }

        protected override void KeyDown(KeyEventArgs e)
        {
            base.KeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                if (_layer != null)
                {
                    DeleteData();
                    HelpGeometry.ClearLayer(_layer);
                }
                Map.ReLoadMap(true);
            }
        }
    }

    public class AddPointAction : MapAction
    {
        GraphicsLayer _layer;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private Data _data = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "添加点";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "AddPointActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);

            if (QuerySetting.LayerNames.Count != 1)
            {
                MessageBox.Show("图层只能有一个");
                return;
            }
            UGCLayer layer = QuerySetting.Layers.First(c => c.Name == QuerySetting.LayerNames[0]) as UGCLayer;

            if (layer.DatasetInfo.Type != DatasetType.CAD && layer.DatasetInfo.Type != DatasetType.POINT)
            {
                MessageBox.Show("图层数据集必须为复合类型或者点类型");
                return;
            }

            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            Point2D point = Map.ScreenToMap(e.Location);
            Marker marker = new Marker("aaa", point, MarkerType.Red_Pushpin, null);
            _layer.Markers.Add(marker);
        }

        public void Add()
        {
            List<Feature> feature = new List<Feature>();
            foreach (Marker marker in _layer.Markers)
            {
                Feature f = new Feature();
                f.Geometry = new Geometry(marker.Point2D);
                feature.Add(f);
            }
            UGCLayer layer = QuerySetting.Layers.First(c => c.Name == QuerySetting.LayerNames[0]) as UGCLayer;
            EditResult result = null;
            try
            {
                result = _data.AddFeatures(layer.DatasetInfo.DataSourceName, layer.DatasetInfo.Name, feature);
                {
                    if (!result.Succeed)
                    {
                        throw new Exception("添加失败");
                    }
                }
                Map.ReLoadMap(true);
            }
            catch (Exception ex)
            {

            }
        }

        public override void Dispose()
        {
            base.Dispose();

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
        }
    }

    public class AddLineAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Line _line;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private List<Point2D> _points;
        private Data _data = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "添加直线";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "AddLineActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_line == null)
            {
                _line = new Line(Guid.NewGuid().ToString(), new List<Point2D>(), 1, Draw.Color.FromArgb(255, 0, 0, 255));
            }
            if (_points == null)
            {
                _points = new List<Point2D>();
            }
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!_startFlag)
                {
                    if (QuerySetting.LayerNames.Count != 1)
                    {
                        MessageBox.Show("图层只能有一个");
                        return;
                    }
                    UGCLayer layer = QuerySetting.Layers.First(c => c.Name == QuerySetting.LayerNames[0]) as UGCLayer;

                    if (layer.DatasetInfo.Type != DatasetType.CAD && layer.DatasetInfo.Type != DatasetType.LINE)
                    {
                        MessageBox.Show("图层数据集必须为复合类型或者线类型");
                        return;
                    }
                    _startFlag = true;
                    if (_layer.Lines.Contains(_line))
                    {
                        _layer.Lines.Remove(_line);
                    }
                    _line.Point2Ds.Clear();
                    _points.Clear();
                }
                _points.Add(Map.ScreenToMap(e.Location));
                UpdateLine(_points);
            }
            else
            {
                _points.Clear();
                if (_layer.Lines.Contains(_line))
                {
                    _layer.Lines.Remove(_line);
                }
                _startFlag = false;
            }
        }

        protected override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                List<Point2D> temp = new List<Point2D>();
                temp.AddRange(_points);
                temp.Add(Map.ScreenToMap(e.Location));
                UpdateLine(temp);
            }
        }

        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            base.MouseDoubleClick(e);

            if (_startFlag)
            {
                _points.Add(Map.ScreenToMap(e.Location));
                UpdateLine(_points);
                _startFlag = false;

            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _line.Point2Ds.Clear();
            _points.Clear();
        }

        private void UpdateLine(List<Point2D> list)
        {
            if (_layer.Lines.Contains(_line))
            {
                _layer.Lines.Remove(_line);
            }
            _line.Point2Ds.Clear();
            _line.Point2Ds.AddRange(list);
            _layer.Lines.Add(_line);
        }

        public void Add()
        {
            List<Feature> feature = new List<Feature>();
            foreach (Line line in _layer.Lines)
            {
                Feature f = new Feature();
                f.Geometry = new Geometry(line.Point2Ds.ToArray(), GeometryType.LINE);
                feature.Add(f);
            }
            UGCLayer layer = QuerySetting.Layers.First(c => c.Name == QuerySetting.LayerNames[0]) as UGCLayer;
            EditResult result = null;
            try
            {
                result = _data.AddFeatures(layer.DatasetInfo.DataSourceName, layer.DatasetInfo.Name, feature);
                {
                    if (!result.Succeed)
                    {
                        throw new Exception("添加失败");
                    }
                }
                Map.ReLoadMap(true);
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class AddPolygonAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Polygon _polygon;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private List<Point2D> _points;
        private Data _data = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "添加多边形";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "AddPolygonActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_polygon == null)
            {
                _polygon = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            if (_points == null)
            {
                _points = new List<Point2D>();
            }
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!_startFlag)
                {
                    if (QuerySetting.LayerNames.Count != 1)
                    {
                        MessageBox.Show("图层只能有一个");
                        return;
                    }
                    UGCLayer layer = QuerySetting.Layers.First(c => c.Name == QuerySetting.LayerNames[0]) as UGCLayer;

                    if (layer.DatasetInfo.Type != DatasetType.CAD && layer.DatasetInfo.Type != DatasetType.REGION)
                    {
                        MessageBox.Show("图层数据集必须为复合类型或者面类型");
                        return;
                    }
                    _startFlag = true;
                    if (_layer.Polygons.Contains(_polygon))
                    {
                        _layer.Polygons.Remove(_polygon);
                    }
                    _polygon.Point2Ds.Clear();
                    _points.Clear();
                }
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
            }
            else
            {
                _points.Clear();
                if (_layer.Polygons.Contains(_polygon))
                {
                    _layer.Polygons.Remove(_polygon);
                }
                _startFlag = false;
            }
        }

        protected override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                List<Point2D> temp = new List<Point2D>();
                temp.AddRange(_points);
                temp.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(temp);
            }
        }

        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            base.MouseDoubleClick(e);

            if (_startFlag)
            {
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
                _startFlag = false;

            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _polygon.Point2Ds.Clear();
            _points.Clear();
        }

        private void UpdatePolygon(List<Point2D> list)
        {
            if (_layer.Polygons.Contains(_polygon))
            {
                _layer.Polygons.Remove(_polygon);
            }
            _polygon.Point2Ds.Clear();
            _polygon.Point2Ds.AddRange(list);
            _layer.Polygons.Add(_polygon);
        }

        public void Add()
        {
            List<Feature> feature = new List<Feature>();
            foreach (Polygon line in _layer.Polygons)
            {
                Feature f = new Feature();
                f.Geometry = new Geometry(line.Point2Ds.ToArray(), GeometryType.REGION);
                feature.Add(f);
            }
            UGCLayer layer = QuerySetting.Layers.First(c => c.Name == QuerySetting.LayerNames[0]) as UGCLayer;
            EditResult result = null;
            try
            {
                result = _data.AddFeatures(layer.DatasetInfo.DataSourceName, layer.DatasetInfo.Name, feature);
                {
                    if (!result.Succeed)
                    {
                        throw new Exception("添加失败");
                    }
                }
                Map.ReLoadMap(true);
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class MeasureDistanceAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Line _line;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private List<Point2D> _points;
        private Data _data = null;
        Marker _marker = null;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "距离量算";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "MeasureDistanceActionLayer");

            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_line == null)
            {
                _line = new Line(Guid.NewGuid().ToString(), new List<Point2D>(), 1, Draw.Color.FromArgb(255, 0, 0, 255));
            }
            if (_points == null)
            {
                _points = new List<Point2D>();
            }
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!_startFlag)
                {
                    if (_layer.Lines.Contains(_line))
                    {
                        _layer.Lines.Remove(_line);
                    }
                    _line.Point2Ds.Clear();
                    _points.Clear();
                }
                _points.Add(Map.ScreenToMap(e.Location));
                if (_startFlag)
                {
                    DrawText(MeasureDistance().ToString() + "千米", e.Location);
                }
                UpdateLine(_points);
                _startFlag = true;
            }
            else
            {
                _points.Clear();
                if (_layer.Lines.Contains(_line))
                {
                    _layer.Lines.Remove(_line);
                }
                if (_layer.Markers.Contains(_marker))
                {
                    _layer.Markers.Remove(_marker);
                }
                _startFlag = false;
            }
        }

        private double MeasureDistance()
        {
            MeasureDistanceResult result = null;
            try
            {
                result = _map.MeasureDistance(MapName, _line.Point2Ds, Unit.KILOMETER);
            }
            catch
            {
                return 0;
            }
            return result.Distance;
        }

        private void DrawText(string text, System.Drawing.Point point)
        {
            //Map.Refresh();
            //Graphics g=Map.CreateGraphics();
            //g.DrawString(text, new Draw.Font(Draw.FontFamily.Families.First(c => c.Name == "微软雅黑"), 20), new SolidBrush(System.Drawing.Color.Black),
            //    new PointF(point.X+10,point.Y));
            //g.Dispose();

            if (_marker != null && _layer.Markers.Contains(_marker))
            {
                _layer.Markers.Remove(_marker);

            }
            Bitmap image = new Bitmap(150, 20);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(new SolidBrush(Draw.Color.White), 0, 0, 148, 18);
            g.DrawRectangle(new Pen(new SolidBrush(Draw.Color.Black), 1), 0, 0, 148, 18);
            g.DrawString(text, new Draw.Font(Draw.FontFamily.Families.First(c => c.Name == "宋体"), 9), new SolidBrush(System.Drawing.Color.Black), new PointF(1, 1));
            _marker = new Marker("1", Map.ScreenToMap(new Draw.Point(point.X + 80, point.Y + 10)), image, null);
            _layer.Markers.Add(_marker);
        }

        protected override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                List<Point2D> temp = new List<Point2D>();
                temp.AddRange(_points);
                temp.Add(Map.ScreenToMap(e.Location));
                UpdateLine(temp);
                //MeasureDistance();
                //DrawText(MeasureDistance().ToString() + "千米", e.Location);
            }
        }

        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            base.MouseDoubleClick(e);

            if (_startFlag)
            {
                _points.Add(Map.ScreenToMap(e.Location));
                UpdateLine(_points);
                _startFlag = false;
                MeasureDistance();
                //DrawText(MeasureDistance().ToString() + "千米", e.Location);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _line.Point2Ds.Clear();
            _points.Clear();
            Map.Refresh();
        }

        private void UpdateLine(List<Point2D> list)
        {
            if (_layer.Lines.Contains(_line))
            {
                _layer.Lines.Remove(_line);
            }
            _line.Point2Ds.Clear();
            _line.Point2Ds.AddRange(list);
            _layer.Lines.Add(_line);
        }

    }

    public class MeasureAreaAction : MapAction
    {
        bool _startFlag;
        GraphicsLayer _layer;
        Polygon _polygon;
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private List<Point2D> _points;
        private Data _data = null;
        Marker _marker;

        /// <summary>
        /// 查询地址
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                _map = new Map(value);
                string dataurl = value.ToLower().Replace("/map-", "/data-");
                _data = new Data(dataurl);
            }
        }

        /// <summary>
        /// 地图名字
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            this.ActionDescription = "面积量算";
            if (_layer == null)
            {
                _layer = new GraphicsLayer(Guid.NewGuid().ToString(), "MeasureAreaActionLayer");
            }
            this.ServiceUrl = ((MapLayer)mapControl.MapLayer).ServiceUrl;
            this._mapName = ((MapLayer)mapControl.MapLayer).MapName;
            if (!mapControl.GraphicsLayers.Contains(_layer, new LayerComparer()))
            {
                mapControl.GraphicsLayers.Add(_layer);
            }
            if (_polygon == null)
            {
                _polygon = new Polygon(Guid.NewGuid().ToString(), new List<Point2D>(), Draw.Color.FromArgb(100, 0, 0, 255), Draw.Color.FromArgb(255, 0, 0, 255), 1);
            }
            if (_points == null)
            {
                _points = new List<Point2D>();
            }
        }

        protected override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!_startFlag)
                {
                    if (_layer.Polygons.Contains(_polygon))
                    {
                        _layer.Polygons.Remove(_polygon);
                    }
                    _polygon.Point2Ds.Clear();
                    _points.Clear();
                    DrawText("0平方千米", e.Location);

                }
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
                if (_startFlag)
                {
                    DrawText(MeasureArea().ToString() + "平方千米", e.Location);
                }
                _startFlag = true;
            }
            else
            {
                _points.Clear();
                if (_layer.Polygons.Contains(_polygon))
                {
                    _layer.Polygons.Remove(_polygon);
                }
                _startFlag = false;
            }
        }

        private double MeasureArea()
        {
            MeasureAreaResult result = null;
            if (_polygon.Point2Ds.Count < 3)
            {
                return 0;
            }
            try
            {
                result = _map.MeasureArea(MapName, _polygon.Point2Ds, Unit.KILOMETER);
            }
            catch
            {
                return 0;
            }
            return result.Area;
        }

        protected override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (_startFlag)
            {
                List<Point2D> temp = new List<Point2D>();
                temp.AddRange(_points);
                temp.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(temp);
            }
        }

        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            base.MouseDoubleClick(e);

            if (_startFlag)
            {
                _points.Add(Map.ScreenToMap(e.Location));
                UpdatePolygon(_points);
                _startFlag = false;
                DrawText(MeasureArea().ToString() + "平方千米", e.Location);
            }
        }

        private void DrawText(string text, System.Drawing.Point point)
        {
            //Map.Refresh();
            //Graphics g=Map.CreateGraphics();
            //g.DrawString(text, new Draw.Font(Draw.FontFamily.Families.First(c => c.Name == "微软雅黑"), 20), new SolidBrush(System.Drawing.Color.Black),
            //    new PointF(point.X+10,point.Y));
            //g.Dispose();

            if (_marker != null && _layer.Markers.Contains(_marker))
            {
                _layer.Markers.Remove(_marker);

            }
            Bitmap image = new Bitmap(150, 20);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(new SolidBrush(Draw.Color.White), 0, 0, 148, 18);
            g.DrawRectangle(new Pen(new SolidBrush(Draw.Color.Black), 1), 0, 0, 148, 18);
            g.DrawString(text, new Draw.Font(Draw.FontFamily.Families.First(c => c.Name == "宋体"), 9), new SolidBrush(System.Drawing.Color.Black), new PointF(1, 1));
            _marker = new Marker("1", Map.ScreenToMap(new Draw.Point(point.X + 80, point.Y + 10)), image, null);
            _layer.Markers.Add(_marker);
        }

        public override void Dispose()
        {
            base.Dispose();
            this._startFlag = false;

            if (_layer.Lines.Count > 0)
            {
                _layer.Lines.Clear();
            }
            if (_layer.Markers.Count > 0)
            {
                _layer.Markers.Clear();
            }
            if (_layer.Polygons.Count > 0)
            {
                _layer.Polygons.Clear();
            }
            _polygon.Point2Ds.Clear();
            _points.Clear();
        }

        private void UpdatePolygon(List<Point2D> list)
        {
            if (_layer.Polygons.Contains(_polygon))
            {
                _layer.Polygons.Remove(_polygon);
            }
            _polygon.Point2Ds.Clear();
            _polygon.Point2Ds.AddRange(list);
            _layer.Polygons.Add(_polygon);
        }

    }
}
