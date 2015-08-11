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
using SuperMap.Web.Core;

namespace SuperMap.Demo.WindowsPhone
{
    public class MyInfoWindow : MarkerStyle
    {
        public static readonly DependencyProperty InfoProperty = DependencyProperty.Register("Info", typeof(string), typeof(MyInfoWindow), null);

        public string Info
        {
            get { return GetValue(InfoProperty).ToString(); }
            set { SetValue(InfoProperty, value); }
        }

        public MyInfoWindow(string message)
        {
            this.ControlTemplate = Application.Current.Resources["MyInfoWindow"] as ControlTemplate;
            Info = message;
            this.OffsetX = 75;
            this.OffsetY = 50;
        }

    }
}
