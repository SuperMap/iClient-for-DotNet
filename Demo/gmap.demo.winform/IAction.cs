using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Windows.Forms;

namespace gmap.demo.winform
{
    public interface IAction
    {
        string ActionName { get; set; }
        string ActionDescription { get; set; }

        void OnLoad(GMapControl gmapControl);
        //void Dispose();

        #region 地图中的事件
        EmptyTileError EmptyTileError { get; }
        MapTypeChanged MapTypeChanged { get; }
        MapZoomChanged MapZoomChanged { get; }
        MapDrag MapDrag { get; }
        TileLoadStart TileLoadStart { get; }
        TileLoadComplete TileLoadComplete { get; }
        PositionChanged PositionChanged { get; }
        MarkerClick MarkerClick { get; }
        MarkerEnter MarkerEnter { get; }
        MarkerLeave MarkerLeave { get; }
        #endregion

        #region 地图上鼠标事件
        MouseEventHandler MapMouseDown { get; }
        MouseEventHandler MapMouseMove { get; }
        MouseEventHandler MapMouseUp { get; }
        //MouseEventHandler MouseEnter { get; }
        //MouseEventHandler MouseLeave { get; }
        MouseEventHandler MapMouseClick { get; }
        MouseEventHandler MapMouseDoubleClick { get; }
        #endregion
    }
}
