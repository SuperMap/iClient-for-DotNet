using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gmap.demo.winform
{
    public static class Helper
    {
        public static void Mercator2LonLat(double mercatorX, double mercatorY, out double lng, out double lat)
        {
            lng = mercatorX;// / 20037508.34 * 180;
            lat = mercatorY; // 20037508.34 * 180; ;
            //lat = 180 / Math.PI * (2 * Math.Atan(Math.Exp(lat * Math.PI / 180)) - Math.PI / 2);
        }

        public static void LonLat2Mercator(double lng, double lat, out double mercatorX, out double mercatorY)
        {
            mercatorX = lng;//lng * 20037508.342789 / 180;
            mercatorY = lat;//Math.Log(Math.Tan((90 + lat) * Math.PI / 360)) / (Math.PI / 180);
            //mercatorY = mercatorY * 20037508.342789 / 180;
        }
    }
}
