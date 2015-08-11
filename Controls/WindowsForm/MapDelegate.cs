using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Utility;
using System.Windows.Forms;

namespace SuperMap.Connector.Control.Forms
{
    /// <summary>
    /// 表示将处理地图控件上的CenterChanged事件的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的<see cref="CenterChangeEventArgs"/>。</param>
    public delegate void CenterChangeHandler(object sender, CenterChangeEventArgs e);

    /// <summary>
    /// 表示将处理地图控件上的ZoomChanged事件的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的<see cref="ZoomChangeEventArgs"/>。</param>
    public delegate void ZoomChangeHandler(object sender, ZoomChangeEventArgs e);

    /// <summary>
    /// 表示将处理MapControl上的ViewBoundsChanged事件的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的<see cref="ViewBoundsChangeEventArgs"/>。</param>
    public delegate void ViewBoundsChangeHandler(object sender, ViewBoundsChangeEventArgs e);

    /// <summary>
    /// 表示将处理重写的鼠标事件（MouseMove，MouseUp，MouseDown，MouseWheel，MouseClick，MouseDoubleClick）的方法。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的<see cref="MapMouseEventArgs"/>。</param>
    public delegate void MapMouseHandler(object sender, MapMouseEventArgs e);

    /// <summary>
    /// 为CenterChanged事件提供数据。
    /// </summary>
    public class CenterChangeEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化CenterChangeEventArgs类的新实例。
        /// </summary>
        /// <param name="oldCenter">地图原来的中心点坐标。</param>
        /// <param name="newCenter">地图新的中心点坐标。</param>
        public CenterChangeEventArgs(Point2D oldCenter, Point2D newCenter)
        {
            OldCenter = oldCenter;
            NewCenter = newCenter;
        }

        /// <summary>
        /// 获取地图原来的中心点坐标。
        /// </summary>
        public Point2D OldCenter
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取地图新的中心点坐标。
        /// </summary>
        public Point2D NewCenter
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// 为ZoomChanged事件提供数据。
    /// </summary>
    public class ZoomChangeEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化ZoomChangeEventArgs的新实例。
        /// </summary>
        /// <param name="oldZoom">地图原来的缩放级别。</param>
        /// <param name="newZoom">地图新的缩放级别。</param>
        public ZoomChangeEventArgs(int oldZoom, int newZoom)
        {
            OldZoom = oldZoom;
            NewZoom = newZoom;
        }

        /// <summary>
        /// 获取地图原来的缩放级别。
        /// </summary>
        public int OldZoom
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取地图新的缩放级别。
        /// </summary>
        public int NewZoom
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// 为ViewBoundsChanged事件提供数据。
    /// </summary>
    public class ViewBoundsChangeEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化ViewBoundsChangeEventArgs类的新实例。
        /// </summary>
        /// <param name="oldViewBounds">地图原来的范围。</param>
        /// <param name="newViewBounds">地图新的范围。</param>
        public ViewBoundsChangeEventArgs(Rectangle2D oldViewBounds, Rectangle2D newViewBounds)
        {
            this.OldViewBounds = oldViewBounds;
            this.NewViewBounds = newViewBounds;
        }

        /// <summary>
        /// 获取地图原来的范围。
        /// </summary>
        public Rectangle2D OldViewBounds
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取地图新的范围。
        /// </summary>
        public Rectangle2D NewViewBounds
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// 为重写的鼠标事件（MouseMove，MouseUp，MouseDown，MouseWheel，MouseClick，MouseDoubleClick）提供数据。
    /// </summary>
    public class MapMouseEventArgs : MouseEventArgs
    {
        /// <summary>
        /// 初始化MapMouseEventArgs类的新实例。
        /// </summary>
        /// <param name="e">鼠标的当前屏幕坐标。</param>
        /// <param name="point2D">鼠标的当前地理坐标。</param>
        public MapMouseEventArgs(MouseEventArgs e, Point2D point2D)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            this.Point2D = point2D;
        }

        /// <summary>
        /// 鼠标当前地理坐标。
        /// </summary>
        public Point2D Point2D
        {
            get;
            private set;
        }
    }
}
