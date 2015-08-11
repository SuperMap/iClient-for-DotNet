using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.Control.Utility
{
    internal class Helper
    {
        public static Point2D PointLatLng2Point2D(PointLatLng pointLatlng)
        {
            if (pointLatlng == null) return null;
            Point2D point2D = new Point2D(pointLatlng.Lng, pointLatlng.Lat);
            return point2D;
        }

        public static List<Point2D> PointLatLngs2Point2Ds(List<PointLatLng> pointLatlngs)
        {
            if (pointLatlngs == null) return null;
            List<Point2D> point2Ds = new List<Point2D>(pointLatlngs.Count);
            for (int i = 0; i < pointLatlngs.Count; i++)
            { 
                point2Ds.Add(Helper.PointLatLng2Point2D(pointLatlngs[i]));
            }
            return point2Ds;
        }

        public static PointLatLng Point2D2PointLatLng(Point2D point2D)
        {
            if (point2D == null) return PointLatLng.Empty;
            PointLatLng pointLatLng = new PointLatLng(point2D.Y, point2D.X);
            return pointLatLng;
        }

        public static List<PointLatLng> Point2Ds2PointLatLngs(List<Point2D> point2Ds)
        {
            if (point2Ds == null) return null;
            List<PointLatLng> pointLatLngs = new List<PointLatLng>(point2Ds.Count);
            for (int i = 0; i < point2Ds.Count; i++)
            {
                pointLatLngs.Add(Helper.Point2D2PointLatLng(point2Ds[i]));
            }
            return pointLatLngs;
        }

        public static double GetNearestScale(List<double> scales, double scale)
        {
            if (scales == null && scales.Count == 0)
            {
                throw new ArgumentException();
            }
            double result = double.MaxValue;
            double resultDistance = double.MaxValue;
            for (int i = 0; i < scales.Count; i++)
            {
                double distance = Math.Abs(scales[i] - scale);
                if (distance < resultDistance)
                {
                    result = scales[i];
                    resultDistance = distance;
                }
            }
            return result;
        }

        public static int GetNearestIndex(List<double> scales, double scale)
        {
            if (scales == null && scales.Count == 0)
            {
                throw new ArgumentException();
            }
            int index = 0;
            double resultDistance = double.MaxValue;
            for (int i = 0; i < scales.Count; i++)
            {
                double distance = Math.Abs(scales[i] - scale);
                if (distance < resultDistance)
                {
                    index = i;
                    resultDistance = distance;
                }
            }
            return index;
        }

    }
}
