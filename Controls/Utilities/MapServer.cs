using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET;
using SuperMap.Connector.Utility;

namespace SuperMap.iClient.Utility
{
    /// <summary>
    /// 地图初始化信息
    /// </summary>
    public abstract class MapServer
    {
        #region Fields
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;
        #endregion

        #region Property
        /// <summary>
        /// 地图的Url
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
        }

        /// <summary>
        /// 地图名称
        /// </summary>
        public string MapName
        {
            get { return _mapName; }
        }

        #endregion

        /// <summary>
        /// 初始化MapServer类的新实例
        /// </summary>
        /// <param name="serviceUrl">地图的Url</param>
        /// <param name="mapName">地图名称</param>
        public MapServer(string serviceUrl, string mapName)
        {
            if (string.IsNullOrEmpty(serviceUrl) && string.IsNullOrEmpty(mapName))
                throw new ArgumentNullException();
            this._serviceUrl = serviceUrl;
            this._mapName = mapName;
        }
    }

    /// <summary>
    /// 地图初始化信息，由调用者指定支持的比例尺
    /// </summary>
    public class MapServerByScales : MapServer
    {
        private double[] _scales = null;
        /// <summary>
        /// 获取当前地图提供的比例尺
        /// </summary>
        public double[] Scales
        {
            get { return _scales; }
        }

        /// <summary>
        /// MapServerByScales构造函数
        /// </summary>
        /// <param name="serviceUrl">地图的Url</param>
        /// <param name="mapName">地图名称</param>
        /// <param name="scales">支持的比例尺</param>
        /// <param name="defaultScaleIndex">默认呈现级别，该参数可选</param>
        public MapServerByScales(string serviceUrl, string mapName, double[] scales, int defaultScaleIndex = 0)
            : base(serviceUrl, mapName)
        {
            if (string.IsNullOrEmpty(serviceUrl) && string.IsNullOrEmpty(mapName) && scales == null)
                throw new ArgumentNullException();
            this._scales = scales;
        }
    }

    /// <summary>
    /// 地图初始化信息，由调用者指定支持的缩放级别数，由程序生成指定数量的比例尺，每一级为前一级的1/2
    /// </summary>
    public class MapServerByZoomCount : MapServer
    {
        private int _zoomCount = 0;
        /// <summary>
        /// 获取当前地图提供的缩放级别数量
        /// </summary>
        public int ZoomCount
        {
            get { return _zoomCount; }
        }

        private int _defaultScaleIndex = 0;
        /// <summary>
        /// 获取默认的地图缩放级别
        /// </summary>
        public int DefaultScaleIndex
        {
            get { return _defaultScaleIndex; }
        }

        /// <summary>
        /// MapServerByZoomCount构造函数
        /// </summary>
        /// <param name="serviceUrl">地图的Url</param>
        /// <param name="mapName">地图名称</param>
        /// <param name="zoomCount">支持的缩放级别数</param>
        /// <param name="defaultScaleIndex">默认初始缩放级别</param>
        public MapServerByZoomCount(string serviceUrl, string mapName, int zoomCount, int defaultScaleIndex = 0)
            : base(serviceUrl, mapName)
        {
            this._zoomCount = zoomCount;
            this._defaultScaleIndex = defaultScaleIndex;
        }
    }
}
