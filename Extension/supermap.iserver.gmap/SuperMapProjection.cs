using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET;
using SuperMap.Connector.Utility;

namespace GMap.SuperMapProvider
{
    public class SuperMapProjection : PureProjection
    {
        #region fields
        private double[] _mapScales;
        private double[] _resolutions;
        private double _minX;
        private double _minY;
        private double _maxX;
        private double _maxY;
        private double _axis;
        private double _flattening;
        private GSize _tileSize = new GSize(256, 256);

        #endregion

        public SuperMapProjection(double[] mapScales, MapParameter defaultMapParameter)
        {
            if (mapScales == null)
                throw new ArgumentNullException();
            if (defaultMapParameter == null)
            {
                throw new ArgumentNullException();
            }

            _mapScales = mapScales;

            if (defaultMapParameter.Bounds == null)
                throw new ArgumentNullException();
            _minX = defaultMapParameter.Bounds.LeftBottom.X;
            _minY = defaultMapParameter.Bounds.LeftBottom.Y;
            _maxX = defaultMapParameter.Bounds.RightTop.X;
            _maxY = defaultMapParameter.Bounds.RightTop.Y;

            if (defaultMapParameter.PrjCoordSys != null &&
                defaultMapParameter.PrjCoordSys.CoordSystem != null &&
                defaultMapParameter.PrjCoordSys.CoordSystem.Datum != null &&
                defaultMapParameter.PrjCoordSys.CoordSystem.Datum.Spheroid != null)
            {
                _axis = defaultMapParameter.PrjCoordSys.CoordSystem.Datum.Spheroid.Axis;
                _flattening = defaultMapParameter.PrjCoordSys.CoordSystem.Datum.Spheroid.Flatten;
            }

            double refMapScale = defaultMapParameter.Scale;
            double refResolution = (defaultMapParameter.ViewBounds.RightTop.X - defaultMapParameter.ViewBounds.LeftBottom.X) /
                (defaultMapParameter.Viewer.Width);

            double refResolutionY = (defaultMapParameter.ViewBounds.RightTop.Y - defaultMapParameter.ViewBounds.LeftBottom.Y) /
                (defaultMapParameter.Viewer.Height);

            _resolutions = new double[_mapScales.Length];
            for (int i = 0; i < _mapScales.Length; i++)
            {
                _resolutions[i] = refResolution * refMapScale / mapScales[i];
            }
        }

        #region Override

        public override GSize GetTileMatrixSizeXY(int zoom)
        {
            return base.GetTileMatrixSizeXY(zoom);
        }

        public override GPoint FromPixelToTileXY(GPoint p)
        {
            return base.FromPixelToTileXY(p);
        }

        public override GPoint FromTileXYToPixel(GPoint p)
        {
            return base.FromTileXYToPixel(p);
        }

        public override double GetGroundResolution(int zoom, double latitude)
        {
            if (zoom < 0)
            {
                zoom = 0;
            }
            return _resolutions[zoom];
        }

        public override GSize GetTileMatrixSizePixel(int zoom)
        {
            return base.GetTileMatrixSizePixel(zoom);
        }
        #endregion

        #region abstract

        public override GSize TileSize
        {
            get { return _tileSize; }
        }

        public override double Axis
        {
            get { return _axis; }
        }

        public override double Flattening
        {
            get { return _flattening; }
        }

        public override GPoint FromLatLngToPixel(double lat, double lng, int zoom)
        {
            GPoint ret = GPoint.Empty;

            lat = Clip(lat, _minY, _maxY);
            lng = Clip(lng, _minX, _maxX);
            double res = _resolutions[zoom];

            ret.X = (int)Math.Floor((lng - _minX) / res);
            ret.Y = (int)Math.Floor((_maxY - lat) / res);

            return ret;
        }

        public override PointLatLng FromPixelToLatLng(int x, int y, int zoom)
        {
            PointLatLng ret = new PointLatLng();

            double res = _resolutions[zoom];

            ret.Lat = _maxY - (y * res);
            ret.Lng = (x * res) + _minX;

            return ret;
        }

        public override GSize GetTileMatrixMinXY(int zoom)
        {
            return new GSize(0, 0);
        }

        public override GSize GetTileMatrixMaxXY(int zoom)
        {
            if (zoom < 0)
                zoom = 0;
            double resolution = _resolutions[zoom];
            double dWidth = _maxX - _minX;
            double dHeight = _maxY - _minY;
            int widht = (int)Math.Floor(dWidth / (_tileSize.Width * resolution));
            int height = (int)Math.Floor(dHeight / (_tileSize.Height * resolution));
            return new GSize(widht, height);
        }
        #endregion
    }
}
