using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    internal class CloudMapProvider
    {
        private string _serviceUrl = string.Empty;
        public CloudMapProvider(string serviceUrl)
        {
            _serviceUrl = serviceUrl;
        }

        public MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption)
        {
            int scale = (int)Math.Floor(1 / tileInfo.Scale);
            string url = string.Format("{0}/output/cache/{1}_{2}x{3}/{4}/{5}/{6}.png",
                this._serviceUrl, mapName, tileInfo.Width, tileInfo.Height, scale, tileInfo.TileIndex.RowIndex, tileInfo.TileIndex.ColIndex);
            MapImage mapImage = null;
            if (imageOutputOption == null || (imageOutputOption != null && imageOutputOption.ImageReturnType == ImageReturnType.URL))
            {
                mapImage = new MapImage()
                {
                    ImageUrl = url
                };
            }
            else
            {
                byte[] imageData = SynchHttpRequest.GetRequestBytes(url);
                mapImage = new MapImage()
                {
                    ImageData = imageData
                };
            }
            return mapImage;
        }
    }
}
