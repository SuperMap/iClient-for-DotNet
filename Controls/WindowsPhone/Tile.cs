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
    internal class Tile
    {
        public Image Image { get; set; }

        public string Key { get; set; }
        public double Resolution { get; set; }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public int Level { get; set; }

        public string Url { get; set; }
        public byte[] ImageData { get; set; }
    }
}
