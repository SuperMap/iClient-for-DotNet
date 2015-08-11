using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    /// <summary>
    /// 访问SuperMapCloud 类。
    /// </summary>
    public class CloudMap
    {
        private CloudMapProvider _provider = null;
        private string _serviceUrl;

        /// <summary>
        /// 通过SuperMapCloud服务地址初始化一个实例。
        /// </summary>
        /// <param name="serviceUrl">云地图服务地址，默认使用 http://wwww.supermapcloud.com</param>
        public CloudMap(string serviceUrl = "http://wwww.supermapcloud.com")
        {
            _serviceUrl = serviceUrl;
            _provider = new CloudMapProvider(_serviceUrl);
        }

        /// <summary>
        /// 根据指定地图名及地图分块信息，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="tileInfo">地图分块信息。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的格网图片信息。</returns>
        /// <example>
        /// 以下代码演示了如何访问SuperMap Cloud云地图服务。
        /// <code>
        ///using System;
        ///using System.Collections.Generic;
        ///using System.Text;
        ///using SuperMap.Connector;
        ///using SuperMap.Connector.Utility;
        ///
        ///class Program
        ///{
        ///    static void Main(string[] args)
        ///    {
        ///        CloudMap cloudMap = new CloudMap("http://www.supermapcloud.com"); //初始化地图对象
        ///        TileInfo tileInfo = new TileInfo() //分块索引信息
        ///        {
        ///            Height = 256,
        ///            Width = 256,
        ///            Scale = 1 / 470000000,
        ///            TileIndex = new TileIndex()
        ///            {
        ///                ColIndex = 0,
        ///                RowIndex = 0
        ///            }
        ///        };
        ///        ImageOutputOption option = new ImageOutputOption()
        ///        {
        ///            ImageOutputFormat = ImageOutputFormat.PNG,
        ///            ImageReturnType = ImageReturnType.URL,
        ///        };
        ///        MapImage mapImage = cloudMap.GetTile(tileInfo, option); //获取地图。
        ///    }
        ///}
        /// </code>
        /// </example>
        public MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption)
        {
            return _provider.GetTile(mapName, tileInfo, imageOutputOption);
        }

        /// <summary>
        /// 获取SuperMapCloud上默认"quanguo"的格网图片。
        /// </summary>
        /// <param name="tileInfo">地图分块信息。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的格网图片信息。</returns>
        public MapImage GetTile(TileInfo tileInfo, ImageOutputOption imageOutputOption)
        {
            return this.GetTile("quanguo", tileInfo, imageOutputOption);
        }
    }
}
