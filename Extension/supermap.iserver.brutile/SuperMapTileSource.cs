using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BruTile;
using SuperMap.Connector;
using Utility = SuperMap.Connector.Utility;

namespace Brutile.SuperMapProvider
{
    public class SuperMapTileSource : ITileSource
    {
        private ITileProvider _tileProvider = null;
        private ITileSchema _tileSchema = null;

        public SuperMapTileSource(string serviceUrl, string mapName, uint tileSize, string format, double[] scales)
        {
            _tileProvider = new iServerProvider(serviceUrl, mapName, tileSize, format, scales);
            _tileSchema = new iServerSchema(serviceUrl, mapName, tileSize, format, scales);
        }

        public SuperMapTileSource(string serviceUrl, string mapName, uint tileSize, string format, double[] scales, Utility.MapParameter mapParameter)
        {
            _tileProvider = new iServerProvider(serviceUrl, mapName, tileSize, format, scales ,mapParameter);
            _tileSchema = new iServerSchema(serviceUrl, mapName, tileSize, format, scales);
        }

        public ITileProvider Provider
        {
            get { return _tileProvider; }
        }

        public ITileSchema Schema
        {
            get { return _tileSchema; }
        }
    }

    public class iServerProvider : ITileProvider
    {
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        private uint _tileSize;
        private string _format = "png";
        private double[] _scales;
        private Utility.MapParameter mapParameter;

        public iServerProvider(string serviceUrl, string mapName, uint tileSize, string format, double[] scales)
        {
            this._serviceUrl = serviceUrl;
            this._mapName = mapName;
            this._format = format;
            this._scales = scales;
            this._tileSize = tileSize;
        }

        public iServerProvider(string serviceUrl, string mapName, uint tileSize, string format, double[] scales, Utility.MapParameter mapParameter)
        {
            this._serviceUrl = serviceUrl;
            this._mapName = mapName;
            this._format = format;
            this._scales = scales;
            this._tileSize = tileSize;
            this.mapParameter = mapParameter;
        }

        public byte[] GetTile(TileInfo tileInfo)
        {
            int iLevel = 0;
            if (!int.TryParse(tileInfo.Index.LevelId, out iLevel)) return null;
            double scale = _scales[iLevel];

            SuperMap.Connector.Utility.TileInfo iserverTileInfo = new SuperMap.Connector.Utility.TileInfo();
            iserverTileInfo.Height = this._tileSize;
            iserverTileInfo.Width = this._tileSize;
            iserverTileInfo.TileIndex = new SuperMap.Connector.Utility.TileIndex();
            iserverTileInfo.TileIndex.ColIndex = tileInfo.Index.Col;
            iserverTileInfo.TileIndex.RowIndex = tileInfo.Index.Row;
            iserverTileInfo.Scale = scale;

            SuperMap.Connector.Utility.ImageOutputOption option = new Utility.ImageOutputOption();
            option.Transparent = false;
            if (mapParameter != null)
            {
                option.Transparent = true;
            }

            Map map = new Map(this._serviceUrl);
            return map.GetTile(this._mapName, iserverTileInfo, option, this.mapParameter).ImageData;
        }
    }

    public class iServerSchema : TileSchema
    {
        public iServerSchema(string serviceUrl, string mapName, uint tileSize, string format, double[] scales)
        {
            Name = "iServer";
            Format = format;
            Srs = "EPSG:4326";

            Map map = new Map(serviceUrl);
            SuperMap.Connector.Utility.MapParameter mapParameter = map.GetDefaultMapParameter(mapName);

            this.Extent = new Extent(mapParameter.Bounds.LeftBottom.X, mapParameter.Bounds.LeftBottom.Y,
                mapParameter.Bounds.RightTop.X, mapParameter.Bounds.RightTop.Y);
            this.Width = (int)tileSize;
            this.Height = (int)tileSize;
            this.Format = format;
            this.OriginX = mapParameter.Bounds.LeftBottom.X;
            this.OriginY = mapParameter.Bounds.RightTop.Y;
            this.Axis = AxisDirection.InvertedY;

            for (int i = 0; i < scales.Length; i++)
            {
                double referViewBoudnsWidth = mapParameter.ViewBounds.RightTop.X - mapParameter.ViewBounds.LeftBottom.X;
                double referViewBoundsHeight = mapParameter.ViewBounds.RightTop.Y - mapParameter.ViewBounds.LeftBottom.X;
                double referViewerWidth = mapParameter.Viewer.RightBottom.X - mapParameter.Viewer.LeftTop.X;
                double referViewerHeight = mapParameter.Viewer.RightBottom.Y - mapParameter.Viewer.LeftTop.Y;
                double resolutionX = (mapParameter.Scale * referViewBoudnsWidth) / (scales[i] * referViewerWidth);
                double resolutionY = (mapParameter.Scale * referViewBoundsHeight) / (scales[i] * referViewerHeight);

                this.Resolutions.Add(new Resolution() { Id = i.ToString(), UnitsPerPixel = resolutionX });
            }
        }
    }
}
