using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMap.iClient.WPF
{
    public class MapControl : GMap.NET.WindowsPresentation.GMapControl
    {
        public MapControl()
        {
            this.DragButton = System.Windows.Input.MouseButton.Left;
        }
    }
}
