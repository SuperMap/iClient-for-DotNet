using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace gmap.demo.winform
{
    public partial class MapControl : GMapControl
    {
        public MapControl()
        {
            InitializeComponent();

            #region 注册事件。
            this.MouseDown += new MouseEventHandler(MapControl_MouseDown);
            this.MouseMove += new MouseEventHandler(MapControl_MouseMove);
            this.MouseUp += new MouseEventHandler(MapControl_MouseUp);
            this.MouseClick += new MouseEventHandler(MapControl_MouseClick);
            this.MouseDoubleClick += new MouseEventHandler(MapControl_MouseDoubleClick);

            this.OnMapDrag += new GMap.NET.MapDrag(MapControl_OnMapDrag);
            this.OnMapTypeChanged += new GMap.NET.MapTypeChanged(MapControl_OnMapTypeChanged);
            this.OnMapZoomChanged += new GMap.NET.MapZoomChanged(MapControl_OnMapZoomChanged);
            this.OnMarkerClick += new MarkerClick(MapControl_OnMarkerClick);
            this.OnMarkerEnter += new MarkerEnter(MapControl_OnMarkerEnter);
            this.OnMarkerLeave += new MarkerLeave(MapControl_OnMarkerLeave);
            this.OnPositionChanged += new GMap.NET.PositionChanged(MapControl_OnPositionChanged);
            this.OnTileLoadComplete += new GMap.NET.TileLoadComplete(MapControl_OnTileLoadComplete);
            this.OnTileLoadStart += new GMap.NET.TileLoadStart(MapControl_OnTileLoadStart);
            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// 第一次加载时需要调用。
        /// </summary>
        public void Init()
        {
            this.OnLoad(null);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //base.OnMouseEnter(e);
        }

        #region 事件响应函数。

        void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentAction != null && this._currentAction.MapMouseDown != null)
            {
                this._currentAction.MapMouseDown(sender, e);
            }
        }

        void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentAction != null && this._currentAction.MapMouseMove != null)
            {
                this._currentAction.MapMouseMove(sender, e);
            }
        }

        void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (this._currentAction != null && this._currentAction.MapMouseUp != null)
            {
                this._currentAction.MapMouseUp(sender, e);
            }
        }

        void MapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (this._currentAction != null && this._currentAction.MapMouseClick != null)
            {
                this._currentAction.MapMouseClick(sender, e);
            }
        }

        void MapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._currentAction != null && this._currentAction.MapMouseDoubleClick != null)
            {
                this._currentAction.MapMouseDoubleClick(sender, e);
            }
        }
        #endregion

        #region GMap事件响应函数。

        void MapControl_OnMapDrag()
        {
            if (this._currentAction != null && this._currentAction.MapDrag != null)
            {
                this._currentAction.MapDrag();
            }
        }

        void MapControl_OnTileLoadStart()
        {
            if (this._currentAction != null && this._currentAction.TileLoadStart != null)
            {
                this._currentAction.TileLoadStart();
            }
        }

        void MapControl_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            if (this._currentAction != null && this._currentAction.TileLoadComplete != null)
            {
                this._currentAction.TileLoadComplete(ElapsedMilliseconds);
            }
        }

        void MapControl_OnPositionChanged(GMap.NET.PointLatLng point)
        {
            if (this._currentAction != null && this._currentAction.PositionChanged != null)
            {
                this._currentAction.PositionChanged(point);
            }
        }

        void MapControl_OnMarkerLeave(GMapMarker item)
        {
            if (this._currentAction != null && this._currentAction.MarkerLeave != null)
            {
                this._currentAction.MarkerLeave(item);
            }
        }

        void MapControl_OnMarkerEnter(GMapMarker item)
        {
            if (this._currentAction != null && this._currentAction.MarkerEnter != null)
            {
                this._currentAction.MarkerEnter(item);
            }
        }

        void MapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (this._currentAction != null && this._currentAction.MarkerClick != null)
            {
                this._currentAction.MarkerClick(item, e);
            }
        }

        void MapControl_OnMapZoomChanged()
        {
            if (this._currentAction != null && this._currentAction.MapZoomChanged != null)
            {
                this._currentAction.MapZoomChanged();
            }
        }

        void MapControl_OnMapTypeChanged(GMap.NET.MapProviders.GMapProvider type)
        {
            if (this._currentAction != null && this._currentAction.MapTypeChanged != null)
            {
                this._currentAction.MapTypeChanged(type);
            }
        }
        #endregion

        #region 属性。
        private IAction _currentAction = null;
        public IAction CurrentAction
        {
            get
            {
                return _currentAction;
            }
            set
            {
                if (_currentAction != value)
                {
                    this.CanDragMap = false; //还原为不是平移状态。
                    _currentAction = value;
                    if (_currentAction != null)
                    {
                        _currentAction.OnLoad(this);
                    }
                }
            }
        }
        #endregion
    }
}
