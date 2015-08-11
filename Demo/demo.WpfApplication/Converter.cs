using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using SuperMap.Connector.Utility;

namespace demo.WpfApplication
{
    public class Point2DToStringConverter:IValueConverter
    {

        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Point2D point = (Point2D)value;
            if (point == null)
            {
                return string.Empty;
            }
            else
            {
                return point.X.ToString() + "\r\n" + point.Y.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value.ToString();
            string[] array = s.Split(',');
            double x, y;
            double.TryParse(array[0], out x);
            double.TryParse(array[1], out y);
            return new Point2D(x,y);
        }

        #endregion
    }
}
