using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using SuperMap.Connector.Utility;
using SuperMap.Connector;
using GMap.SuperMapProvider;
using GMap.NET.WindowsForms.Markers;

namespace gmap.demo.winform
{
    //public class ActionForm : Form, IAction
    //{
    //    public ActionForm()
    //        : base()
    //    {
    //        this._emptyTileError = new GMap.NET.EmptyTileError(OnEmptyTileError);
    //        this._mapTypeChanged = new MapTypeChanged(OnMapTypeChanged);
    //        this._mapZoomChanged = new MapZoomChanged(OnMapZoomChanged);
    //        this._mapDrag = new MapDrag(OnMapDrag);
    //        this._tileLoadStart = new TileLoadStart(OnTileLoadStart);
    //        this._tileLoadComplete = new TileLoadComplete(OnTileLoadComplete);
    //        this._markerClick = new MarkerClick(OnMarkerClick);
    //        this._markerEnter = new MarkerEnter(OnMarkerEnter);
    //        this._markerLeave = new MarkerLeave(OnMarkerLeave);

    //        this._mouseDown = new MouseEventHandler(OnMapMouseDown);
    //        this._mouseMove = new MouseEventHandler(OnMapMouseMove);
    //        this._mouseUp = new MouseEventHandler(OnMapMouseUp);
    //        this._mouseClick = new MouseEventHandler(OnMapMouseClick);
    //        this._mouseDoubleClick = new MouseEventHandler(OnMapMouseDoubleClick);
    //    }

    //    public virtual void OnLoad(GMapControl gMapControl)
    //    {
    //        gMapControl.ParentForm.AddOwnedForm(this);
    //    }

    //    private string _actionName = string.Empty;
    //    string IAction.ActionName
    //    {
    //        get
    //        {
    //            return _actionName;
    //        }
    //        set
    //        {
    //            _actionName = value;
    //        }
    //    }

    //    #region 属性
    //    private string _actionDescription = string.Empty;
    //    string IAction.ActionDescription
    //    {
    //        get
    //        {
    //            return _actionDescription;
    //        }
    //        set
    //        {
    //            _actionDescription = value;
    //        }
    //    }
    //    #endregion

    //    #region GMap上的加载事件。
    //    private GMap.NET.EmptyTileError _emptyTileError = null;
    //    public GMap.NET.EmptyTileError EmptyTileError
    //    {
    //        get { return _emptyTileError; }
    //    }

    //    private GMap.NET.MapTypeChanged _mapTypeChanged = null;
    //    public GMap.NET.MapTypeChanged MapTypeChanged
    //    {
    //        get { return _mapTypeChanged; }
    //    }

    //    private GMap.NET.MapZoomChanged _mapZoomChanged = null;
    //    public GMap.NET.MapZoomChanged MapZoomChanged
    //    {
    //        get { return _mapZoomChanged; }
    //    }

    //    private MapDrag _mapDrag = null;
    //    public GMap.NET.MapDrag MapDrag
    //    {
    //        get { return _mapDrag; }
    //    }

    //    private TileLoadStart _tileLoadStart = null;
    //    public GMap.NET.TileLoadStart TileLoadStart
    //    {
    //        get { return _tileLoadStart; }
    //    }

    //    private TileLoadComplete _tileLoadComplete = null;
    //    public GMap.NET.TileLoadComplete TileLoadComplete
    //    {
    //        get { return _tileLoadComplete; }
    //    }

    //    private PositionChanged _positionChanged = null;
    //    public GMap.NET.PositionChanged PositionChanged
    //    {
    //        get { return _positionChanged; }
    //    }

    //    private MarkerClick _markerClick = null;
    //    public GMap.NET.WindowsForms.MarkerClick MarkerClick
    //    {
    //        get { return _markerClick; }
    //    }

    //    private MarkerEnter _markerEnter = null;
    //    public GMap.NET.WindowsForms.MarkerEnter MarkerEnter
    //    {
    //        get { return _markerEnter; }
    //    }

    //    private MarkerLeave _markerLeave = null;
    //    public GMap.NET.WindowsForms.MarkerLeave MarkerLeave
    //    {
    //        get { return _markerLeave; }
    //    }

    //    #endregion

    //    #region 地图上鼠标事件。
    //    private MouseEventHandler _mouseDown = null;
    //    public MouseEventHandler MapMouseDown
    //    {
    //        get { return _mouseDown; }
    //    }

    //    private MouseEventHandler _mouseMove = null;
    //    public MouseEventHandler MapMouseMove
    //    {
    //        get { return _mouseMove; }
    //    }

    //    private MouseEventHandler _mouseUp = null;
    //    public MouseEventHandler MapMouseUp
    //    {
    //        get { return _mouseUp; }
    //    }

    //    private MouseEventHandler _mouseClick = null;
    //    public MouseEventHandler MapMouseClick
    //    {
    //        get { return _mouseClick; }
    //    }

    //    private MouseEventHandler _mouseDoubleClick = null;
    //    public MouseEventHandler MapMouseDoubleClick
    //    {
    //        get { return _mouseDoubleClick; }
    //    }

    //    #endregion

    //    public virtual void OnPositionChanged(PointLatLng point) { }
    //    public virtual void OnTileLoadComplete(long ElapsedMilliseconds) { }
    //    public virtual void OnMapTypeChanged(GMapProvider type) { }
    //    public virtual void OnMapZoomChanged() { }
    //    public virtual void OnEmptyTileError(int zoom, GPoint pos) { }
    //    public virtual void OnMapDrag() { }
    //    public virtual void OnTileLoadStart() { }
    //    public virtual void OnMarkerClick(GMapMarker item, MouseEventArgs e) { }
    //    public virtual void OnMarkerEnter(GMapMarker item) { }
    //    public virtual void OnMarkerLeave(GMapMarker item) { }

    //    public virtual void OnMapMouseDown(object sender, MouseEventArgs e) { }
    //    public virtual void OnMapMouseMove(object sender, MouseEventArgs e) { }
    //    public virtual void OnMapMouseUp(object sender, MouseEventArgs e) { }
    //    public virtual void OnMapMouseClick(object sender, MouseEventArgs e) { }
    //    public virtual void OnMapMouseDoubleClick(object sender, MouseEventArgs e) { }

    //    protected override void OnFormClosing(FormClosingEventArgs e)
    //    {
    //        if (e.CloseReason == CloseReason.UserClosing)
    //        {
    //            e.Cancel = true;
    //            this.Hide();
    //        }
    //        else
    //        {
    //            base.OnFormClosing(e);
    //        }
    //    }
    //}

    /// <summary>
    /// 所有Action抽象的基类。
    /// </summary>
    public abstract class Action : IAction
    {
        public Action()
        {
            this._emptyTileError = new GMap.NET.EmptyTileError(OnEmptyTileError);
            this._mapTypeChanged = new MapTypeChanged(OnMapTypeChanged);
            this._mapZoomChanged = new MapZoomChanged(OnMapZoomChanged);
            this._mapDrag = new MapDrag(OnMapDrag);
            this._tileLoadStart = new TileLoadStart(OnTileLoadStart);
            this._tileLoadComplete = new TileLoadComplete(OnTileLoadComplete);
            this._markerClick = new MarkerClick(OnMarkerClick);
            this._markerEnter = new MarkerEnter(OnMarkerEnter);
            this._markerLeave = new MarkerLeave(OnMarkerLeave);

            this._mouseDown = new MouseEventHandler(OnMapMouseDown);
            this._mouseMove = new MouseEventHandler(OnMapMouseMove);
            this._mouseUp = new MouseEventHandler(OnMapMouseUp);
            this._mouseClick = new MouseEventHandler(OnMapMouseClick);
            this._mouseDoubleClick = new MouseEventHandler(OnMapMouseDoubleClick);
        }

        public abstract void OnLoad(GMapControl gMapControl);
        public virtual void Dispose() { }

        private string _actionName = string.Empty;
        string IAction.ActionName
        {
            get
            {
                return _actionName;
            }
            set
            {
                _actionName = value;
            }
        }

        #region 属性
        private string _actionDescription = string.Empty;
        string IAction.ActionDescription
        {
            get
            {
                return _actionDescription;
            }
            set
            {
                _actionDescription = value;
            }
        }
        #endregion

        #region GMap上的加载事件。
        private GMap.NET.EmptyTileError _emptyTileError = null;
        public GMap.NET.EmptyTileError EmptyTileError
        {
            get { return _emptyTileError; }
        }

        private GMap.NET.MapTypeChanged _mapTypeChanged = null;
        public GMap.NET.MapTypeChanged MapTypeChanged
        {
            get { return _mapTypeChanged; }
        }

        private GMap.NET.MapZoomChanged _mapZoomChanged = null;
        public GMap.NET.MapZoomChanged MapZoomChanged
        {
            get { return _mapZoomChanged; }
        }

        private MapDrag _mapDrag = null;
        public GMap.NET.MapDrag MapDrag
        {
            get { return _mapDrag; }
        }

        private TileLoadStart _tileLoadStart = null;
        public GMap.NET.TileLoadStart TileLoadStart
        {
            get { return _tileLoadStart; }
        }

        private TileLoadComplete _tileLoadComplete = null;
        public GMap.NET.TileLoadComplete TileLoadComplete
        {
            get { return _tileLoadComplete; }
        }

        private PositionChanged _positionChanged = null;
        public GMap.NET.PositionChanged PositionChanged
        {
            get { return _positionChanged; }
        }

        private MarkerClick _markerClick = null;
        public GMap.NET.WindowsForms.MarkerClick MarkerClick
        {
            get { return _markerClick; }
        }

        private MarkerEnter _markerEnter = null;
        public GMap.NET.WindowsForms.MarkerEnter MarkerEnter
        {
            get { return _markerEnter; }
        }

        private MarkerLeave _markerLeave = null;
        public GMap.NET.WindowsForms.MarkerLeave MarkerLeave
        {
            get { return _markerLeave; }
        }

        #endregion

        #region 地图上鼠标事件。
        private MouseEventHandler _mouseDown = null;
        public MouseEventHandler MapMouseDown
        {
            get { return _mouseDown; }
        }

        private MouseEventHandler _mouseMove = null;
        public MouseEventHandler MapMouseMove
        {
            get { return _mouseMove; }
        }

        private MouseEventHandler _mouseUp = null;
        public MouseEventHandler MapMouseUp
        {
            get { return _mouseUp; }
        }

        private MouseEventHandler _mouseClick = null;
        public MouseEventHandler MapMouseClick
        {
            get { return _mouseClick; }
        }

        private MouseEventHandler _mouseDoubleClick = null;
        public MouseEventHandler MapMouseDoubleClick
        {
            get { return _mouseDoubleClick; }
        }

        #endregion

        public virtual void OnPositionChanged(PointLatLng point) { }
        public virtual void OnTileLoadComplete(long ElapsedMilliseconds) { }
        public virtual void OnMapTypeChanged(GMapProvider type) { }
        public virtual void OnMapZoomChanged() { }
        public virtual void OnEmptyTileError(int zoom, GPoint pos) { }
        public virtual void OnMapDrag() { }
        public virtual void OnTileLoadStart() { }
        public virtual void OnMarkerClick(GMapMarker item, MouseEventArgs e) { }
        public virtual void OnMarkerEnter(GMapMarker item) { }
        public virtual void OnMarkerLeave(GMapMarker item) { }

        public virtual void OnMapMouseDown(object sender, MouseEventArgs e) { }
        public virtual void OnMapMouseMove(object sender, MouseEventArgs e) { }
        public virtual void OnMapMouseUp(object sender, MouseEventArgs e) { }
        public virtual void OnMapMouseClick(object sender, MouseEventArgs e) { }
        public virtual void OnMapMouseDoubleClick(object sender, MouseEventArgs e) { }
    }

    public class PanAction : Action
    {
        private GMapControl _gMapControl = null;
        public override void OnLoad(GMapControl gMapControl)
        {
            this._gMapControl = gMapControl;
            if (this._gMapControl != null)
            {
                this._gMapControl.CanDragMap = true;
            }
        }

        public override void OnMapMouseDown(object sender, MouseEventArgs e)
        {
            base.OnMapMouseDown(sender, e);
        }

        public override void OnMapMouseMove(object sender, MouseEventArgs e)
        {
            //_gMapControl.Position
            base.OnMapMouseMove(sender, e);
        }
    }

    //public class QuickZoomInAction : Action
    //{
    //    public override void OnLoad(GMapControl gMapControl)
    //    {
    //        if (gMapControl != null)
    //        {
    //            gMapControl.Zoom += 1;
    //        }
    //    }
    //}

    //public class QuickZoomOutAction : Action
    //{

    //    public override void OnLoad(GMapControl gMapControl)
    //    {
    //        if (gMapControl != null)
    //        {
    //            gMapControl.Zoom -= 1;
    //        }
    //    }
    //}

    public class MeasureAreaAction : Action
    {
        private GMapControl _gMapControl = null;
        private GMapOverlay _gMapOverlay = new GMapOverlay("measureArea");

        private bool _start = false;
        GMapPolygon _polygon = null;
        List<PointLatLng> _points = null;
        List<Point2D> _point2Ds = new List<Point2D>();
        GMapMarkerExtension _resultMarker = null;
        bool flag = false;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;

        public override void OnLoad(GMapControl gMapControl)
        {
            _gMapControl = gMapControl;
            _gMapControl.Overlays.Add(_gMapOverlay);

            _points = new List<PointLatLng>();
            _gMapControl.Overlays.Add(_gMapOverlay);
            _start = false;

            this._mapUrl = ((SuperMapProvider)gMapControl.MapProvider).ServiceUrl;
            this._mapName = ((SuperMapProvider)gMapControl.MapProvider).MapName;

            _map = new Map(_mapUrl);
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

            if (_point2Ds.Count > 1)
            {
                List<Point2D> tempPoints = new List<Point2D>();
                tempPoints.AddRange(_point2Ds);
                double mercatorX, mercatorY;
                Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
                Point2D point2D = new Point2D(mercatorX, mercatorY);
                tempPoints.Add(point2D);
                Map map = new Map(_mapUrl);
                MeasureAreaResult areaResult = map.MeasureArea(_mapName, tempPoints, Unit.KILOMETER);
                if (_resultMarker == null || _gMapOverlay.Markers.Count < 1)
                {
                    _resultMarker = new GMapMarkerExtension(currentPoint);
                    _resultMarker.ToolTipMode = MarkerTooltipMode.Always;
                    _gMapOverlay.Markers.Add(_resultMarker);
                }
                _resultMarker.Position = currentPoint;
                _resultMarker.ToolTipText = string.Format("{0:f1}平方千米", areaResult.Area);
            }
            if (_gMapOverlay.Polygons.Count > 0)
            {
                _gMapOverlay.Polygons[0] = _polygon;
            }
            else
            {
                _gMapOverlay.Polygons.Add(_polygon);
            }
        }

        public override void OnMapMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!_start) return;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
            Point2D point2D = new Point2D(mercatorX, mercatorY);
            _point2Ds.Add(point2D);
            _gMapOverlay.Polygons.Clear();
            _gMapOverlay.Markers.Clear();
            _points.Clear();
            _point2Ds.Clear();
            flag = false;
            _start = false;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    public class MeasureDistanceAction : Action
    {
        private GMapControl _gMapControl = null;
        private GMapOverlay _gMapOverlay = new GMapOverlay("measureLine");

        private bool _start = false;
        GMapRouteExtension _route = null;
        List<PointLatLng> _points = null;
        List<Point2D> _point2Ds = new List<Point2D>();
        bool flag = false;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        Map _map = null;

        public MeasureDistanceAction()
        { 
            
        }

        public override void OnLoad(GMapControl gMapControl)
        {
            _gMapControl = gMapControl;
            _gMapControl.Overlays.Add(_gMapOverlay);

            _points = new List<PointLatLng>();
            _gMapControl.Overlays.Add(_gMapOverlay);
            _start = false;

            this._mapUrl = ((SuperMapProvider)gMapControl.MapProvider).ServiceUrl;
            this._mapName = ((SuperMapProvider)gMapControl.MapProvider).MapName;
            this._map = new Map(this._mapUrl);
        }

        public override void OnMapMouseDown(object sender, MouseEventArgs e)
        {
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
            Point2D point2D = new Point2D(mercatorX, mercatorY);
            _point2Ds.Add(point2D);
            _points.Add(currentPoint);
            if (_start)
            {
                MeasureDistanceResult result = _map.MeasureDistance(_mapName, _point2Ds, Unit.KILOMETER);
                GMapMarkerExtension mBorders = new GMapMarkerExtension(currentPoint);
                mBorders.ToolTipText = string.Format("{0:f1}千米", result.Distance);
                mBorders.ToolTipMode = MarkerTooltipMode.Always;
                _gMapOverlay.Markers.Add(mBorders);
            }
            _start = true;
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
            if (_route == null)
            {
                _route = new GMapRouteExtension("mearsureLine", _points, System.Drawing.Color.FromArgb(100, 255, 0, 0), 2.5F,
                    true);
            }
            else
            {
                ((GMapRouteExtension)_route).GPoints = _points;
            }

            if (_gMapOverlay.Routes.Count > 0)
            {
                _gMapOverlay.Routes[0] = _route;
            }
            else
            {
                _gMapOverlay.Routes.Add(_route);
            }
        }

        public override void OnMapMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!_start) return;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
            Point2D point2D = new Point2D(mercatorX, mercatorY);
            _point2Ds.Add(point2D);
            MeasureDistanceResult result = _map.MeasureDistance(this._mapName, _point2Ds, Unit.METER);
            _gMapOverlay.Routes.Remove(_route);
            _gMapOverlay.Markers.Clear();
            _points.Clear();
            _point2Ds.Clear();
            flag = false;
            _start = false;
        }

        public override void OnMapMouseClick(object sender, MouseEventArgs e)
        {
            base.OnMapMouseClick(sender, e);
        }

        public override void OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            base.OnMarkerClick(item, e);
        }
    }

    public class QueryByPolygonAction : Action
    {
        private GMapControl _gMapControl = null;
        private GMapOverlay _gMapOverlay = new GMapOverlay("queryByPolygon");
        private GMapOverlay _highLightOverlay = new GMapOverlay("highlight_polygon");
        private bool _start = false;
        GMapPolygon _polygon = null;
        List<PointLatLng> _points = null;
        List<Point2D> _point2Ds = new List<Point2D>();
        bool flag = false;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;

        public override void OnLoad(GMapControl gMapControl)
        {
            _gMapControl = gMapControl;
            _gMapControl.Overlays.Add(_gMapOverlay);

            _points = new List<PointLatLng>();
            if (!_gMapControl.Overlays.Contains(_gMapOverlay))
                _gMapControl.Overlays.Add(_gMapOverlay);
            if (!_gMapControl.Overlays.Contains(_highLightOverlay))
                _gMapControl.Overlays.Add(_highLightOverlay);
            _start = false;
            this._mapUrl = ((SuperMapProvider)gMapControl.MapProvider).ServiceUrl;
            this._mapName = ((SuperMapProvider)gMapControl.MapProvider).MapName;
        }

        public override void OnMapMouseDown(object sender, MouseEventArgs e)
        {
            if (!_start)
            {
                //_highLightOverlay.Markers.Clear();
                //_highLightOverlay.Routes.Clear();
                //_highLightOverlay.Polygons.Clear();
            }
            _start = true;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);
            Point2D point2D = new Point2D(mercatorX, mercatorY);
            _point2Ds.Add(point2D);
            _points.Add(currentPoint);
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
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryParams = new QueryParameter[QuerySetting.LayerNames.Count];
            for (int i = 0; i < QuerySetting.LayerNames.Count; i++)
            {
                queryParameterSet.QueryParams[i] = new QueryParameter();
                queryParameterSet.QueryParams[i].Name = QuerySetting.LayerNames[i];
            }

            Geometry geo = new Geometry();
            geo.Parts = new int[1] { _point2Ds.Count };
            geo.Points = _point2Ds.ToArray();
            geo.Type = GeometryType.REGION;
            QueryResult queryResult = null;
            try
            {
                queryResult = map.QueryByGeometry(_mapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
            }
            catch (ServiceException serviceException)
            {
                MessageBox.Show(serviceException.Message);
            }

            //高亮显示查询结果。
            if (queryResult != null && queryResult.Recordsets != null && queryResult.Recordsets.Length > 0)
            {
                for (int i = 0; i < queryResult.Recordsets.Length; i++)
                {
                    if (queryResult.Recordsets[i] != null && queryResult.Recordsets[i].Features != null &&
                        queryResult.Recordsets[i].Features.Length > 0)
                    {
                        for (int j = 0; j < queryResult.Recordsets[i].Features.Length; j++)
                        {
                            if (queryResult.Recordsets[i].Features[j].Geometry != null && (
                                queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.POINT
                            || queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.TEXT))
                            {
                                double lat, lng;
                                Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[0].X, queryResult.Recordsets[i].Features[j].Geometry.Points[0].Y, out lng, out lat);
                                PointLatLng pointLatLng = new PointLatLng(lat, lng);
                                GMapMarkerGoogleRed marker = new GMapMarkerGoogleRed(pointLatLng);
                                _highLightOverlay.Markers.Add(marker);
                            }
                            else if (queryResult.Recordsets[i].Features[j].Geometry != null &&
                                (queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.REGION
                            || queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.RECTANGLE))
                            {
                                if (queryResult.Recordsets[i].Features[j].Geometry.Parts != null)
                                //queryResult.Recordsets[i].Features[j].Geometry.Parts.Length > 1)
                                {
                                    int startIndex = 0;
                                    for (int k = 0; k < queryResult.Recordsets[i].Features[j].Geometry.Parts.Length; k++)
                                    {
                                        List<PointLatLng> regionClient = new List<PointLatLng>();
                                        for (int n = startIndex; n < queryResult.Recordsets[i].Features[j].Geometry.Parts[k]; n++)
                                        {
                                            double lat, lng;
                                            Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[n].X, queryResult.Recordsets[i].Features[j].Geometry.Points[n].Y, out lng, out lat);
                                            regionClient.Add(new PointLatLng(lat, lng));
                                        }
                                        GMapPolygonExtension hight = new GMapPolygonExtension("", regionClient, 2.0F,
               System.Drawing.Color.FromArgb(125, 255, 0, 0), System.Drawing.Color.FromArgb(50, 255, 0, 0));
                                        _highLightOverlay.Polygons.Add(hight);
                                        startIndex += queryResult.Recordsets[i].Features[j].Geometry.Parts[k];

                                    }
                                }
                            }
                            else if (queryResult.Recordsets[i].Features[j].Geometry != null &&
                                (queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.LINE))
                            {
                                int startIndex = 0;
                                for (int k = 0; k < queryResult.Recordsets[i].Features[j].Geometry.Parts.Length; k++)
                                {
                                    List<PointLatLng> regionClient = new List<PointLatLng>();
                                    for (int n = startIndex; n < startIndex + queryResult.Recordsets[i].Features[j].Geometry.Parts[k]; n++)
                                    {
                                        double lat, lng;
                                        Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[n].X, queryResult.Recordsets[i].Features[j].Geometry.Points[n].Y, out lng, out lat);
                                        regionClient.Add(new PointLatLng(lat, lng));
                                    }
                                    GMapRouteExtension hight = new GMapRouteExtension("", regionClient,
           System.Drawing.Color.FromArgb(125, 255, 0, 0), 5.0F, false);
                                    _highLightOverlay.Routes.Add(hight);
                                    startIndex += queryResult.Recordsets[i].Features[j].Geometry.Parts[k];

                                }
                            }
                        }
                    }
                }
            }

            _gMapOverlay.Polygons.Clear();
            _points.Clear();
            _point2Ds.Clear();
            flag = false;
            _start = false;
            base.OnMapMouseDoubleClick(sender, e);
        }
    }

    public class QueryByPointAction : Action
    {
        private GMapControl _gMapControl = null;
        private GMapOverlay _gMapOverlay = new GMapOverlay("queryByPoint");
        private GMapOverlay _highLightOverlay = new GMapOverlay("highlight_point");
        List<Point2D> _point2Ds = new List<Point2D>();
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;

        public override void OnLoad(GMapControl gMapControl)
        {
            _gMapControl = gMapControl;
            _gMapControl.Overlays.Add(_gMapOverlay);

            if (!_gMapControl.Overlays.Contains(_gMapOverlay))
                _gMapControl.Overlays.Add(_gMapOverlay);
            if (!_gMapControl.Overlays.Contains(_highLightOverlay))
                _gMapControl.Overlays.Add(_highLightOverlay);
            this._mapUrl = ((SuperMapProvider)gMapControl.MapProvider).ServiceUrl;
            this._mapName = ((SuperMapProvider)gMapControl.MapProvider).MapName;
            this._map = new Map(this._mapUrl);
        }

        public override void OnMapMouseDown(object sender, MouseEventArgs e)
        {
            //this._highLightOverlay.Routes.Clear();
            //this._highLightOverlay.Polygons.Clear();
            //this._highLightOverlay.Markers.Clear();

            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mercatorX, mercatorY;
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mercatorX, out mercatorY);

            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ReturnContent = true;
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryParams = new QueryParameter[QuerySetting.LayerNames.Count];
            for (int i = 0; i < QuerySetting.LayerNames.Count; i++)
            {
                queryParameterSet.QueryParams[i] = new QueryParameter();
                queryParameterSet.QueryParams[i].Name = QuerySetting.LayerNames[i];
            }

            Geometry geo = new Geometry();
            geo.Type = GeometryType.POINT;
            geo.Parts = new int[] { 1 };
            geo.Points = new Point2D[1];
            geo.Points[0] = new Point2D(mercatorX, mercatorY);
            geo.Type = GeometryType.POINT;
            QueryResult queryResult = null;
            try
            {
                queryResult = _map.QueryByDistance(_mapName, geo, 10000, queryParameterSet);
            }
            catch (ServiceException serviceException)
            {
                MessageBox.Show(serviceException.Message);
            }

            if (queryResult != null && queryResult.Recordsets != null && queryResult.Recordsets.Length > 0)
            {
                for (int i = 0; i < queryResult.Recordsets.Length; i++)
                {
                    if (queryResult.Recordsets[i] != null && queryResult.Recordsets[i].Features != null &&
                        queryResult.Recordsets[i].Features.Length > 0)
                    {
                        for (int j = 0; j < queryResult.Recordsets[i].Features.Length; j++)
                        {
                            if (queryResult.Recordsets[i].Features[j].Geometry != null && (
                                queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.POINT
                            || queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.TEXT))
                            {
                                double lat, lng;
                                Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[0].X, queryResult.Recordsets[i].Features[j].Geometry.Points[0].Y, out lng, out lat);
                                PointLatLng pointLatLng = new PointLatLng(lat, lng);
                                GMapMarkerGoogleRed marker = new GMapMarkerGoogleRed(pointLatLng);
                                _highLightOverlay.Markers.Add(marker);
                            }
                            else if (queryResult.Recordsets[i].Features[j].Geometry != null &&
                                (queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.REGION
                            || queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.RECTANGLE))
                            {
                                if (queryResult.Recordsets[i].Features[j].Geometry.Parts != null)
                                //queryResult.Recordsets[i].Features[j].Geometry.Parts.Length > 1)
                                {
                                    int startIndex = 0;
                                    for (int k = 0; k < queryResult.Recordsets[i].Features[j].Geometry.Parts.Length; k++)
                                    {
                                        List<PointLatLng> regionClient = new List<PointLatLng>();
                                        for (int n = startIndex; n < startIndex + queryResult.Recordsets[i].Features[j].Geometry.Parts[k]; n++)
                                        {
                                            double lat, lng;
                                            Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[n].X, queryResult.Recordsets[i].Features[j].Geometry.Points[n].Y, out lng, out lat);
                                            regionClient.Add(new PointLatLng(lat, lng));
                                        }
                                        GMapPolygonExtension hight = new GMapPolygonExtension("", regionClient, 2.0F,
               System.Drawing.Color.FromArgb(125, 255, 0, 0), System.Drawing.Color.FromArgb(50, 255, 0, 0));
                                        _highLightOverlay.Polygons.Add(hight);
                                        startIndex += queryResult.Recordsets[i].Features[j].Geometry.Parts[k];

                                    }
                                }
                            }
                            else if (queryResult.Recordsets[i].Features[j].Geometry != null &&
                                (queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.LINE))
                            {
                                int startIndex = 0;
                                for (int k = 0; k < queryResult.Recordsets[i].Features[j].Geometry.Parts.Length; k++)
                                {
                                    List<PointLatLng> regionClient = new List<PointLatLng>();
                                    for (int n = startIndex; n < queryResult.Recordsets[i].Features[j].Geometry.Parts[k]; n++)
                                    {
                                        double lat, lng;
                                        Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[n].X, queryResult.Recordsets[i].Features[j].Geometry.Points[n].Y, out lng, out lat);
                                        regionClient.Add(new PointLatLng(lat, lng));
                                    }
                                    GMapRouteExtension hight = new GMapRouteExtension("", regionClient,
           System.Drawing.Color.FromArgb(125, 255, 0, 0), 5.0F, false);
                                    _highLightOverlay.Routes.Add(hight);
                                    startIndex += queryResult.Recordsets[i].Features[j].Geometry.Parts[k];

                                }
                            }
                        }
                    }
                }
            }

            base.OnMapMouseDown(sender, e);
        }
    }

    public class QueryByRectAction : Action
    {
        private GMapControl _gMapControl = null;
        private GMapOverlay _gMapOverlay = new GMapOverlay("queryByRect");
        private GMapOverlay _highLightOverlay = new GMapOverlay("highlight_rect");
        private bool _start = false;
        GMapPolygon _polygon = null;
        private string _mapUrl = string.Empty;
        private string _mapName = string.Empty;
        private Map _map = null;
        private PointLatLng _startPoint;

        public override void OnLoad(GMapControl gMapControl)
        {
            _gMapControl = gMapControl;
            _gMapControl.Overlays.Add(_gMapOverlay);

            if (!_gMapControl.Overlays.Contains(_gMapOverlay))
                _gMapControl.Overlays.Add(_gMapOverlay);
            if (!_gMapControl.Overlays.Contains(_highLightOverlay))
                _gMapControl.Overlays.Add(_highLightOverlay);
            this._mapUrl = ((SuperMapProvider)gMapControl.MapProvider).ServiceUrl;
            this._mapName = ((SuperMapProvider)gMapControl.MapProvider).MapName;
            this._map = new Map(this._mapUrl);
        }

        public override void OnMapMouseDown(object sender, MouseEventArgs e)
        {
            _start = true;
            _startPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);

            base.OnMapMouseDown(sender, e);
        }

        public override void OnMapMouseMove(object sender, MouseEventArgs e)
        {
            if (!_start) return;
            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            PointLatLng point1 = new PointLatLng(currentPoint.Lat, _startPoint.Lng);
            PointLatLng point2 = new PointLatLng(_startPoint.Lat, currentPoint.Lng);
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(_startPoint);
            points.Add(point1);
            points.Add(currentPoint);
            points.Add(point2);
            _polygon = new GMapPolygonExtension("", points, 2.0F,
                System.Drawing.Color.FromArgb(100, 0, 0, 255), System.Drawing.Color.FromArgb(50, 0, 0, 255));
            this._gMapOverlay.Polygons.Clear();
            this._gMapOverlay.Polygons.Add(_polygon);

            base.OnMapMouseMove(sender, e);
        }

        public override void OnMapMouseUp(object sender, MouseEventArgs e)
        {
            if (!_start) return;
            this._gMapOverlay.Polygons.Clear();

            PointLatLng currentPoint = this._gMapControl.FromLocalToLatLng(e.X, e.Y);
            double mecatorStartX = 0, mecatorStartY = 0;
            double mecatorEndX = 0, mecatorEndY = 0;
            Helper.LonLat2Mercator(_startPoint.Lng, _startPoint.Lat, out mecatorStartX, out  mecatorStartY);
            Helper.LonLat2Mercator(currentPoint.Lng, currentPoint.Lat, out mecatorEndX, out  mecatorEndY);
            double left = mecatorStartX > mecatorEndX ? mecatorEndX : mecatorStartX;
            double bottom = mecatorStartY > mecatorEndY ? mecatorEndY : mecatorStartY;
            double right = mecatorStartX > mecatorEndX ? mecatorStartX : mecatorEndX;
            double top = mecatorStartY > mecatorEndY ? mecatorStartY : mecatorEndY;
            Rectangle2D rect = new Rectangle2D(left, bottom, right, top);
            Geometry geo = new Geometry(rect);
            geo.Type = GeometryType.REGION;

            //MessageBox.Show(string.Format("left:{0};bottom:{1};right:{2};top{3}", left, bottom, right, top));
            //List<PointLatLng> test = new List<PointLatLng>();
            //double lat1, lng1;
            //Helper.Mercator2LonLat(rect.LeftBottom.X, rect.LeftBottom.Y, out lng1, out lat1);
            //test.Add(new PointLatLng(lat1, lng1));
            //Helper.Mercator2LonLat(rect.LeftBottom.X, rect.RightTop.Y, out lng1, out lat1);
            //test.Add(new PointLatLng(lat1, lng1));
            //Helper.Mercator2LonLat(rect.RightTop.X, rect.RightTop.Y, out lng1, out lat1);
            //test.Add(new PointLatLng(lat1, lng1));
            //Helper.Mercator2LonLat(rect.RightTop.X, rect.LeftBottom.Y, out lng1, out lat1);
            //test.Add(new PointLatLng(lat1, lng1));
            //GMapPolygonExtension testgp = new GMapPolygonExtension("", test, 2.0F,
            //    System.Drawing.Color.FromArgb(100, 0, 0, 255), System.Drawing.Color.FromArgb(255, 255, 0, 0));
            //this._gMapOverlay.Polygons.Add(testgp);

            QueryParameterSet queryParameterSet = new QueryParameterSet();

            queryParameterSet.ReturnContent = true;
            queryParameterSet.QueryOption = QuerySetting.QueryOption;
            queryParameterSet.ExpectCount = QuerySetting.ExceptionCount;
            queryParameterSet.QueryParams = new QueryParameter[QuerySetting.LayerNames.Count];
            for (int i = 0; i < QuerySetting.LayerNames.Count; i++)
            {
                queryParameterSet.QueryParams[i] = new QueryParameter();

                queryParameterSet.QueryParams[i].Name = QuerySetting.LayerNames[i];
            }

            QueryResult queryResult = null;
            try
            {
                queryResult = _map.QueryByGeometry(_mapName, geo, SpatialQueryMode.INTERSECT, queryParameterSet);
            }
            catch (ServiceException serviceException)
            {
                MessageBox.Show(serviceException.Message);
            }

            if (queryResult != null && queryResult.Recordsets != null && queryResult.Recordsets.Length > 0)
            {
                for (int i = 0; i < queryResult.Recordsets.Length; i++)
                {
                    if (queryResult.Recordsets[i] != null && queryResult.Recordsets[i].Features != null &&
                        queryResult.Recordsets[i].Features.Length > 0)
                    {
                        for (int j = 0; j < queryResult.Recordsets[i].Features.Length; j++)
                        {
                            if (queryResult.Recordsets[i].Features[j].Geometry != null && (
                                queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.POINT
                            || queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.TEXT))
                            {
                                double lat, lng;
                                Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[0].X, queryResult.Recordsets[i].Features[j].Geometry.Points[0].Y, out lng, out lat);
                                PointLatLng pointLatLng = new PointLatLng(lat, lng);
                                GMapMarkerGoogleRed marker = new GMapMarkerGoogleRed(pointLatLng);
                                _highLightOverlay.Markers.Add(marker);
                            }
                            else if (queryResult.Recordsets[i].Features[j].Geometry != null &&
                                (queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.REGION
                            || queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.RECTANGLE))
                            {
                                if (queryResult.Recordsets[i].Features[j].Geometry.Parts != null)
                                //queryResult.Recordsets[i].Features[j].Geometry.Parts.Length > 1)
                                {
                                    int startIndex = 0;
                                    for (int k = 0; k < queryResult.Recordsets[i].Features[j].Geometry.Parts.Length; k++)
                                    {
                                        List<PointLatLng> regionClient = new List<PointLatLng>();
                                        for (int n = startIndex; n < startIndex + queryResult.Recordsets[i].Features[j].Geometry.Parts[k]; n++)
                                        {
                                            double lat, lng;
                                            Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[n].X, queryResult.Recordsets[i].Features[j].Geometry.Points[n].Y, out lng, out lat);
                                            regionClient.Add(new PointLatLng(lat, lng));
                                        }
                                        GMapPolygonExtension hight = new GMapPolygonExtension("", regionClient, 2.0F,
               System.Drawing.Color.FromArgb(125, 255, 0, 0), System.Drawing.Color.FromArgb(50, 255, 0, 0));
                                        _highLightOverlay.Polygons.Add(hight);
                                        startIndex += queryResult.Recordsets[i].Features[j].Geometry.Parts[k];

                                    }
                                }
                            }
                            else if (queryResult.Recordsets[i].Features[j].Geometry != null &&
                                (queryResult.Recordsets[i].Features[j].Geometry.Type == GeometryType.LINE))
                            {
                                int startIndex = 0;
                                for (int k = 0; k < queryResult.Recordsets[i].Features[j].Geometry.Parts.Length; k++)
                                {
                                    List<PointLatLng> regionClient = new List<PointLatLng>();
                                    for (int n = startIndex; n < queryResult.Recordsets[i].Features[j].Geometry.Parts[k]; n++)
                                    {
                                        double lat, lng;
                                        Helper.Mercator2LonLat(queryResult.Recordsets[i].Features[j].Geometry.Points[n].X, queryResult.Recordsets[i].Features[j].Geometry.Points[n].Y, out lng, out lat);
                                        regionClient.Add(new PointLatLng(lat, lng));
                                    }
                                    GMapRouteExtension hight = new GMapRouteExtension("", regionClient,
           System.Drawing.Color.FromArgb(125, 255, 0, 0), 5.0F, false);
                                    _highLightOverlay.Routes.Add(hight);
                                    startIndex += queryResult.Recordsets[i].Features[j].Geometry.Parts[k];

                                }
                            }
                        }
                    }
                }
            }

            _start = false;
            base.OnMapMouseUp(sender, e);
        }
    }
}
