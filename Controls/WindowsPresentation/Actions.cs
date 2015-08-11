using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Utility;
using System.Windows.Input;

namespace SuperMap.Connector.Control.WPF
{
    /// <summary>
    /// 拖动操作。
    /// </summary>
    public class PanAction : MapAction
    {
        private bool _isDown;
        private System.Windows.Point _oldPoint;

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

            System.Windows.Point newPoint = e.GetPosition(Map);
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
        protected override void MouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.MouseLeftButtonUp(e);

            _isDown = false;
            Map.Cursor = Cursors.Arrow;
        }


        /// <summary>
        /// 每当鼠标键按下后，都将调用此方法。继承自MapAction。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected override void MouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.MouseLeftButtonDown(e);

            _isDown = true;
            _oldPoint = e.GetPosition(Map);
            Map.Cursor = Cursors.Hand;
        }


        /// <summary>
        /// 每当鼠标双击后，都将调用此方法。继承自MapAction。
        /// </summary>
        /// <param name="e"></param>
        protected override void MouseDoubleClick(MouseButtonEventArgs e)
        {
            base.MouseDoubleClick(e);
            Map.Zoom = Map.Zoom + 1;
        }


    }
}
