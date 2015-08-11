using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.Control.WindowsPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewBoundsChanedEventArgs : EventArgs
    {
        public ViewBoundsChanedEventArgs(Rectangle2D oldViewBounds, Rectangle2D newViewBounds)
        {
            if (oldViewBounds != null)
            {
                _oldViewBounds = new Rectangle2D(oldViewBounds);
            }
            if (_newViewBounds != null)
            {
                _newViewBounds = new Rectangle2D(newViewBounds);
            }
        }

        private Rectangle2D _newViewBounds = null;
        public Rectangle2D NewViewBounds { get { return _newViewBounds; } }

        private Rectangle2D _oldViewBounds = null;
        public Rectangle2D OldViewBounds { get { return _oldViewBounds; } }
    }
}
