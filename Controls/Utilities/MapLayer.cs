using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET;

namespace SuperMap.Connector.Control.Utility
{
    /// <summary>
    /// 地图图层。
    /// </summary>
    public class MapLayer : Layer
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">图层id。</param>
        /// <param name="layerName">图层名称。</param>
        public MapLayer(string id, string layerName)
            : base(id, layerName)
        {

        }

    }

    /// <summary>
    /// 超图云地图服务图层。
    /// </summary>
    public class CloudLayer : MapLayer
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public CloudLayer() :
            base("SuperMapCloud", "SuperMapCloudLayer")
        { }
    }

    /// <summary>
    /// 地图图层，由调用者指定支持的比例尺。
    /// </summary>
    public class MapByScalesLayer : MapLayer
    {
        private double[] _scales = null;
        /// <summary>
        /// 获取当前地图提供的比例尺。
        /// </summary>
        public double[] Scales
        {
            get { return _scales; }
        }

        /// <summary>
        /// 地图的Url。
        /// </summary>
        public string ServiceUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// 地图名字。
        /// </summary>
        public string MapName
        {
            get;
            private set;
        }

        /// <summary>
        /// MapServerByScales构造函数。
        /// </summary>
        /// <param name="id">图层ID。</param>
        /// <param name="layerName">图层名字。</param>
        /// <param name="serviceUrl">地图的Url。</param>
        /// <param name="mapName">地图名称。</param>
        /// <param name="scales">支持的比例尺。</param>
        /// <param name="defaultScaleIndex">默认呈现级别，该参数可选。</param>
        public MapByScalesLayer(string id, string layerName, string serviceUrl, string mapName, double[] scales, int defaultScaleIndex = 0)
            : base(id, layerName)
        {
            if (string.IsNullOrEmpty(serviceUrl) && string.IsNullOrEmpty(mapName) && scales == null)
                throw new ArgumentNullException();
            this._scales = scales;
            this.ServiceUrl = serviceUrl;
            this.MapName = mapName;
        }
    }

    /// <summary>
    /// 地图图层，由调用者指定支持的缩放级别数，由程序生成指定数量的比例尺，每一级为前一级的1/2。
    /// </summary>
    public class MapByZoomCountLayer : MapLayer
    {
        /// <summary>
        /// 地图的Url。
        /// </summary>
        public string ServiceUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// 地图名字。
        /// </summary>
        public string MapName
        {
            get;
            private set;
        }

        private int _zoomCount = 0;
        /// <summary>
        /// 获取当前地图提供的缩放级别数量。
        /// </summary>
        public int ZoomCount
        {
            get { return _zoomCount; }
        }

        private int _defaultScaleIndex = 0;
        /// <summary>
        /// 获取默认的地图缩放级别。
        /// </summary>
        public int DefaultScaleIndex
        {
            get { return _defaultScaleIndex; }
        }

        /// <summary>
        /// MapServerByZoomCount构造函数。
        /// </summary>
        /// <param name="id">图层ID。</param>
        /// <param name="layerName">图层名字。</param>
        /// <param name="serviceUrl">地图的Url。</param>
        /// <param name="mapName">地图名称。</param>
        /// <param name="zoomCount">支持的缩放级别数。</param>
        /// <param name="defaultScaleIndex">默认初始缩放级别。</param>
        public MapByZoomCountLayer(string id, string layerName, string serviceUrl, string mapName, int zoomCount, int defaultScaleIndex = 0)
            : base(id, layerName)
        {
            this._zoomCount = zoomCount;
            this._defaultScaleIndex = defaultScaleIndex;
            this.ServiceUrl = serviceUrl;
            this.MapName = mapName;
        }
    }
}
