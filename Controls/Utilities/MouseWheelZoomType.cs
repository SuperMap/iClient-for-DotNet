using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Connector.Control.Utility
{
    public enum MouseWheelZoomType
    {
        /// <summary>
        /// 以鼠标指针点为请求的中心点缩放地图，并将该点作为缩放完成后的中心点。
        /// </summary>
        MousePositionAndCenter = GMap.NET.MouseWheelZoomType.MousePositionAndCenter,

        /// <summary>
        /// 以鼠标指针点为请求的中心点缩放地图，但是当前地图中心点不变。
        /// </summary>
        MousePositionWithoutCenter = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter,

        /// <summary>
        /// 以当前地图中心点为请求的中心点缩放地图。
        /// </summary>
        ViewCenter = GMap.NET.MouseWheelZoomType.ViewCenter, 
    }
}
