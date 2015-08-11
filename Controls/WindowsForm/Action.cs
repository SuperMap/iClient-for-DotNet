using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Utility;
using SuperMap.Connector.Control.Utility;
using SuperMap.Connector.Control.Forms;
using System.Windows.Forms;

namespace SuperMap.Connector.Control.Forms
{
    /// <summary>
    /// 拖动操作。
    /// </summary>
    public class PanAction : MapAction
    {
        private bool _isDown;
        private System.Drawing.Point _oldPoint;

        /// <summary>
        /// 加载对应的地图控件。
        /// </summary>
        /// <param name="mapControl">需要加载的地图控件。</param>
        public override void OnLoad(MapControl mapControl)
        {
            base.OnLoad(mapControl);
            ActionDescription = "拖动地图";
        }
        /// <summary>
        /// 每当鼠标移动后，都将调用此方法。继承自MapAction。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs。</param>
        protected override void MouseMove(MouseEventArgs e)
        {
            if (!_isDown)
            {
                return;
            }

            System.Drawing.Point newPoint = e.Location;
            if (_oldPoint == null)
            {
                _oldPoint = newPoint;
            }
            else
            {
                double xoffet = (newPoint.X - _oldPoint.X) * Map.Resolution;
                double yoffset = (newPoint.Y - _oldPoint.Y) * Map.Resolution;
                _oldPoint = newPoint;

                Point2D newCenter = new Point2D(Map.Center.X - xoffet, Map.Center.Y + yoffset);
                Map.Center = newCenter;

            }
        }

        /// <summary>
        /// 每当鼠标键放开后，都将调用此方法。继承自MapAction。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected override void MouseUp(MouseEventArgs e)
        {
            _isDown = false;
            Map.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 每当鼠标键按下后，都将调用此方法。继承自MapAction。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected override void MouseDown(MouseEventArgs e)
        {
            _isDown = true;
            _oldPoint = e.Location;
            Map.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// 每当鼠标双击后，都将调用此方法。继承自MapAction。
        /// </summary>
        /// <param name="e"></param>
        protected override void MouseDoubleClick(MouseEventArgs e)
        {
            Map.Zoom = Map.Zoom + 1;
        }

    }
}
