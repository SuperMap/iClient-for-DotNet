using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace SuperMap.Connector.Control.Utility
{
    /// <summary>
    /// 地图图层。
    /// </summary>
    public abstract class Layer
    {
        #region 字段
        private string _id = string.Empty;
        private string _name = string.Empty;
        #endregion

        /// <summary>
        /// 初始化Layer的新实例
        /// </summary>
        public Layer()
        {

        }

        /// <summary>
        /// 根据图层ID和名字初始化Layer的新实例
        /// </summary>
        /// <param name="id">图层ID</param>
        /// <param name="name">图层名字</param>
        public Layer(string id, string name)
        {
            this._id = id;
            this._name = name;
        }

        /// <summary>
        /// 图层ID。
        /// </summary>
        public string ID
        {
            get { return this._id; }
        }

        /// <summary>
        /// 图层名字。
        /// </summary>
        public string Name
        {
            get { return this._name; }
        }

    }


    /// <summary>
    /// 地图图层。
    /// </summary>
    public class MapLayer : Layer
    {
        private string _serviceUrl = string.Empty;
        private string _mapName = string.Empty;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">图层id。</param>
        /// <param name="layerName">图层名称。</param>
        public MapLayer(string id, string layerName, string serviceUrl, string mapName)
            : base(id, layerName)
        {
            this._serviceUrl = serviceUrl;
            this._mapName = mapName;
        }

        /// <summary>
        /// 地图的Url。
        /// </summary>
        public string ServiceUrl
        {
            get { return this._serviceUrl; }
        }

        /// <summary>
        /// 地图名字。
        /// </summary>
        public string MapName
        {
            get { return this._mapName; }
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
        public CloudLayer(string serviceUrl, string mapName) :
            base("SuperMapCloud", "SuperMapCloudLayer", serviceUrl, mapName)
        {

        }
    }

    /// <summary>
    /// 地图图层，由调用者指定支持的比例尺。
    /// </summary>
    public class MapByScalesLayer : MapLayer
    {
        private double[] _scales = null;


        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">图层ID。</param>
        /// <param name="layerName">图层名字。</param>
        /// <param name="serviceUrl">地图的Url。</param>
        /// <param name="mapName">地图名称。</param>
        /// <param name="scales">支持的比例尺。</param>
        /// <param name="defaultScaleIndex">默认呈现级别，该参数可选。</param>
        public MapByScalesLayer(string id, string layerName, string serviceUrl, string mapName, double[] scales, int defaultScaleIndex = 0)
            : base(id, layerName, serviceUrl, mapName)
        {
            if (string.IsNullOrEmpty(serviceUrl) && string.IsNullOrEmpty(mapName) && scales == null)
                throw new ArgumentNullException();
            this._scales = scales;

        }

        /// <summary>
        /// 获取当前地图提供的比例尺。
        /// </summary>
        public double[] Scales
        {
            get { return _scales; }
        }

    }

    /// <summary>
    /// 地图图层，由调用者指定支持的缩放级别数，根据iServer发布地图默认比例尺生成指定数量的比例尺级别，每一级为前一级的1/2。
    /// </summary>
    public class MapByZoomCountLayer : MapLayer
    {
        #region 字段
        private int _zoomCount = 0;
        private int _defaultScaleIndex = 0;
        #endregion

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="id">图层ID。</param>
        /// <param name="layerName">图层名字。</param>
        /// <param name="serviceUrl">地图的Url。</param>
        /// <param name="mapName">地图名称。</param>
        /// <param name="zoomCount">支持的缩放级别数。</param>
        /// <param name="defaultScaleIndex">默认初始缩放级别。</param>
        public MapByZoomCountLayer(string id, string layerName, string serviceUrl, string mapName, int zoomCount, int defaultScaleIndex = 0)
            : base(id, layerName, serviceUrl, mapName)
        {
            this._zoomCount = zoomCount;
            this._defaultScaleIndex = defaultScaleIndex;
        }

        /// <summary>
        /// 获取当前地图提供的缩放级别数量。
        /// </summary>
        public int ZoomCount
        {
            get { return _zoomCount; }
        }

        /// <summary>
        /// 获取默认的地图缩放级别。
        /// </summary>
        public int DefaultScaleIndex
        {
            get { return _defaultScaleIndex; }
        }
    }
}
