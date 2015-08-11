using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;
using Newtonsoft.Json;
using System.IO;

namespace SuperMap.Connector
{
    /// <summary>
    /// Map 组件接口，用以访问 SuperMap iServer 地图服务组件中的REST服务，封装了与地图相关的一系列功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>只能对 SuperMap REST 接口类型服务的访问。</description></item>
    /// <item><description>实例化Map对象时需要使用明确的地图服务组件地址(例如：http://localhost:8090/iserver/services/map-world/rest/") </description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// using System;
    /// using System.Collections.Generic;
    /// using System.Text;
    /// using SuperMap.Connector;
    /// using SuperMap.Connector.Utility;
    ///
    /// class Program
    /// {
    ///     static void Main(string[] args)
    ///     {
    ///         //根据服务组件地址初始化一个Map对象。
    ///         Map map = new Map("http://localhost:8090/iserver/services/map-world/rest/");
    ///
    ///        //获取指定服务组件中所有的地图名。
    ///        List&lt;string&gt; mapNames = map.GetMapNames();
    ///     }
    /// }
    /// 
    /// //地图名称列表：
    /// //World; 世界地图_Day; 世界地图; 世界地图_Night; World Map
    /// </code>
    /// </example>
    public class Map
    {
        #region 成员变量

        private string _serviceUrl;
        private MapProvider _mapProvider;

        #endregion

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">SuperMap iServer 地图服务组件的URL地址。</param>
        /// <exception cref="ArgumentNullException">参数 serviceUrl 为空时抛出异常。</exception>
        public Map(string serviceUrl)
        {
            if (string.IsNullOrEmpty(serviceUrl))
            {
                throw new ArgumentNullException("serviceUrl", "serivceUrl is null");
            }
            if (serviceUrl.Trim().EndsWith("/"))
            {
                int lastLocation = serviceUrl.LastIndexOf("/");
                if (lastLocation >= 0)
                {
                    serviceUrl = serviceUrl.Substring(0, lastLocation);
                }
            }
            this._serviceUrl = serviceUrl;
            this._mapProvider = new MapProvider(this._serviceUrl);
        }

        /// <summary>
        /// SuperMap iServer 地图服务组件地址。
        /// </summary>
        public string ServiceUrl
        {
            get { return this._serviceUrl; }
        }

        // <summary>
        // 使用异步的方式获取指定服务中的所有的地图名称。
        // </summary>
        // <param name="onCompleted">获取成功的回调函数。</param>
        // <param name="onError">获取失败的回调函数。</param>
        //public void GetMapNames(EventHandler<GetMapNamesEventArgs> onCompleted, EventHandler<ServiceErrorEventArgs> onError)
        //{
        //    _mapProvider.GetMapNames(onCompleted, onError);
        //}

        /// <summary>
        /// 获取指定服务中的所有的地图名称。
        /// </summary>
        /// <returns>地图名称列表。</returns>
        public List<string> GetMapNames()
        {
            return _mapProvider.GetMapNames();
        }

        /// <summary>
        /// 使用异步的方式，获取指定服务中的所有的地图名称。
        /// </summary>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        public void GetMapNames(EventHandler<GetMapNamesEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            EventHandler<GetMapNamesEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _mapProvider.GetMapNames(callback, failed);
        }

        /// <summary>
        /// 获取指定地图名称的默认的地图参数。
        /// </summary>
        /// <param name="mapName">地图名称。【必设参数】</param>
        /// <returns>返回的地图参数对象。</returns>
        public MapParameter GetDefaultMapParameter(string mapName)
        {
            return this.GetDefaultMapParameter(mapName, true);
        }

        /// <summary>
        /// 获取指定地图名称的默认的地图参数，可指定是否返回图层信息。
        /// </summary>
        /// <param name="mapName">地图名称。【必设参数】</param>
        /// <param name="returnLayers">是否返回图层信息。</param>
        /// <returns>返回的地图参数对象。</returns>
        public MapParameter GetDefaultMapParameter(string mapName, bool returnLayers)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                throw new ArgumentNullException("mapName", "mapName is null");
            }
            return _mapProvider.GetDefaultMapParameter(mapName, returnLayers);
        }

        /// <summary>
        /// 使用异步的方式，获取指定地图名称的默认的地图参数。
        /// </summary>
        /// <param name="mapName">地图名称。【必设参数】</param>
        /// <param name="completed">获取默认的地图参数完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        public void GetDefaultMapParameter(string mapName, EventHandler<MapParameterEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            GetDefaultMapParameter(mapName, true, completed, failed);
        }

        /// <summary>
        /// 使用异步的方式，获取指定地图名称的默认的地图参数，可指定是否返回图层信息。
        /// </summary>
        /// <param name="mapName">地图名称。【必设参数】</param>
        /// <param name="returnLayers">是否返回图层信息。</param>
        /// <param name="completed">获取默认的地图参数完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        public void GetDefaultMapParameter(string mapName, bool returnLayers, EventHandler<MapParameterEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("mapName", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            EventHandler<MapParameterEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _mapProvider.GetDefaultMapParameter(mapName, returnLayers, callback, failed);
        }

        /// <summary>
        /// 根据地图名称、二维地理坐标点、量算单位进行面积量算。
        /// </summary>
        /// <param name="mapName">地图名称。【必设参数】</param>
        /// <param name="point2Ds">二维地理坐标点数组。【必设参数】</param>
        /// <param name="unit">返回结果的单位。</param>
        /// <returns>量算结果对象。</returns>
        public MeasureAreaResult MeasureArea(string mapName, List<Point2D> point2Ds, Unit unit)
        {
            return _mapProvider.MeasureArea(mapName, point2Ds, unit);
        }

        /// <summary>
        /// 根据地图名称、二维地理坐标点、量算单位进行距离量算。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="point2Ds">二维地理坐标点数组。</param>
        /// <param name="unit">返回结果的单位。</param>
        /// <returns>量算结果对象。</returns>
        public MeasureDistanceResult MeasureDistance(string mapName, List<Point2D> point2Ds, Unit unit)
        {
            return _mapProvider.MeasureDistance(mapName, point2Ds, unit);
        }

        /// <summary>
        /// 根据地图分块信息，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="tileInfo">地图分块信息。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的格网图片信息。</returns>
        public MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetTile(mapName, tileInfo, imageOutputOption);
        }

        /// <summary>
        /// 根据地图分块信息和地图参数设置，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="tileInfo">地图分块信息。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <returns>所获取的格网图片信息。</returns>
        public MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption, MapParameter mapParameter)
        {
            return _mapProvider.GetTile(mapName, tileInfo, imageOutputOption, mapParameter);
        }

        /// <summary>
        /// 根据地图参数、图片输出设置获取地图图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的地图图片对象。</returns>
        /// <example>
        /// <code>
        /// Map map = new Map("http://localhost:8090/iserver/services/map-world/rest");
        /// MapParameter mapParameter = map.GetDefaultMapParameter("世界地图");
        /// ImageOutputOption imageOutputOption = new ImageOutputOption();
        /// imageOutputOption.ImageOutputFormat = ImageOutputFormat.PNG;
        /// imageOutputOption.ImageReturnType = ImageReturnType.URL;
        /// MapImage mapImageResult = map.GetMapImage("世界地图", mapParameter, imageOutputOption);
        /// </code>
        /// </example>
        public MapImage GetMapImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetMapImage(mapName, mapParameter, imageOutputOption, false);
        }

        /// <summary>
        /// 根据地图参数、图片输出设置获取地图图片，可设置是否返回当前图片参数信息。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <param name="returnMapParameter">是否返回图片参数信息。</param>
        /// <returns>所获取的地图图片对象。</returns>
        public MapImage GetMapImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption, bool returnMapParameter)
        {
            return _mapProvider.GetMapImage(mapName, mapParameter, imageOutputOption, returnMapParameter);
        }

        /// <summary>
        /// 根据资源图片参数获取资源图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="resourceParameter">资源图片参数，如生成的图片的高度、宽度、类型，资源的类型、风格等。</param>
        /// <param name="imageOutputOption">资源图片输出设置。</param>
        /// <returns>资源图片对象。</returns>
        public ResourceImage GetResource(string mapName, ResourceParameter resourceParameter, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetResource(mapName, resourceParameter, imageOutputOption);
        }

        /// <summary>
        /// 在指定的地图上，查询与指定的矩形范围以及符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="bounds">矩形范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        public QueryResult QueryByBounds(string mapName, Rectangle2D bounds, QueryParameterSet queryParameterSet)
        {
            return _mapProvider.QueryByBounds(mapName, bounds, queryParameterSet);
        }

        /// <summary>
        /// 使用异步的方式，在指定的地图上，查询与指定的矩形范围以及符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="bounds">矩形范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 </param>
        /// <param name="completed"><see cref="EventHandler&lt;QueryEventArgs&gt;"/>委托，它表示在服务端查询完成后执行的方法。</param>
        /// <param name="failed"><see cref="EventHandler&lt;FailedEventArgs&gt;"/>类型委托，它表示在进行查询时发生异常后执行的方法。</param>
        public void QueryByBounds(string mapName, Rectangle2D bounds, QueryParameterSet queryParameterSet,
             EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentNullException("mapName", Resources.ArgumentIsNotNull)));
                return;
            }
            if (queryParameterSet == null)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            if (bounds == null)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("bounds", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            _mapProvider.QueryByBounds(mapName, bounds, queryParameterSet, completed, failed);
        }

        /// <summary>
        /// 在指定的地图上，查询距离指定几何对象一定范围内的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="distance">查询的距离范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 
        /// </param>
        /// <returns>查询结果集。</returns>
        /// <remarks>到指定几何对象的一定距离范围，实际是以指定几何对象为中心的一个圆，在这个圆内以及与圆相交的几何对象都能够被查询出来。
        /// </remarks>
        public QueryResult QueryByDistance(string mapName, Geometry geometry, double distance, QueryParameterSet queryParameterSet)
        {
            return _mapProvider.QueryByDistance(mapName, geometry, distance, queryParameterSet);
        }

        /// <summary>
        /// 使用异步的方式查询一定范围内的几何对象。此方法不会阻止调用线程。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象</param>
        /// <param name="distance">查询的距离范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。</param>
        /// <param name="completed">在服务端查询完成后时执行的方法。</param>
        /// <param name="failed">在进行查询时发生异常后执行的方法。</param>
        public void QueryByDistance(string mapName, Geometry geometry, double distance, QueryParameterSet queryParameterSet, EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentNullException("mapName", Resources.ArgumentIsNotNull)));
                return;
            }
            if (queryParameterSet == null)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            if (geometry == null)
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentNullException("geometry", Resources.ArgumentIsNotNull)));
                return;
            }
            if (distance <= 0.0)
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentOutOfRangeException("distance", Resources.ArgumentMoreThanZero)));
                return;
            }
            _mapProvider.QueryByDistance(mapName, geometry, distance, queryParameterSet, completed, failed);
        }

        /// <summary>
        /// 在指定的地图上，查询与指定的几何对象符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间几何对象间的查询模式
        /// <para>空间几何对象间的查询模式定义了一些几何对象之间的空间位置关系，根据这些空间关系来构建过滤条件执行查询。
        /// 例如：查询可被包含在面对象中的空间对象，与面有相离或者相邻关系的空间对象等。</para>
        /// </param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        public QueryResult QueryByGeometry(string mapName, Geometry geometry, SpatialQueryMode spatialQueryMode, QueryParameterSet queryParameterSet)
        {
            return _mapProvider.QueryByGeometry(mapName, geometry, spatialQueryMode, queryParameterSet);
        }

        /// <summary>
        /// 使用异步的方式，在指定的地图上，查询与指定的几何对象符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间几何对象间的查询模式
        /// <para>空间几何对象间的查询模式定义了一些几何对象之间的空间位置关系，根据这些空间关系来构建过滤条件执行查询。
        /// 例如：查询可被包含在面对象中的空间对象，与面有相离或者相邻关系的空间对象等。</para>
        /// </param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <param name="completed">在服务端查询完成后时执行的方法。</param>
        /// <param name="failed">在进行查询时发生异常后执行的方法。</param>
        public void QueryByGeometry(string mapName, Geometry geometry, SpatialQueryMode spatialQueryMode, QueryParameterSet queryParameterSet,
            EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentNullException("mapName", Resources.ArgumentIsNotNull)));
                return;
            }
            if (queryParameterSet == null)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            if (geometry == null)
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentNullException("geometry", Resources.ArgumentIsNotNull)));
                return;
            }
            EventHandler<QueryEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _mapProvider.QueryByGeometry(mapName, geometry, spatialQueryMode, queryParameterSet, callback, failed);
        }

        /// <summary>
        ///  在指定的地图上，执行 SQL 查询。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        public QueryResult QueryBySQL(string mapName, QueryParameterSet queryParameterSet)
        {
            return _mapProvider.QueryBySQL(mapName, queryParameterSet);
        }

        /// <summary>
        ///  使用异步的方式，在指定的地图上，执行 SQL 查询。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <param name="completed">在服务端查询完成后时执行的方法。</param>
        /// <param name="failed">在进行查询时发生异常后执行的方法。</param>
        public void QueryBySQL(string mapName, QueryParameterSet queryParameterSet,
             EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                if (failed != null)
                    failed(this, new FailedEventArgs(new ArgumentNullException("mapName", Resources.ArgumentIsNotNull)));
                return;
            }
            if (queryParameterSet == null)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            EventHandler<QueryEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _mapProvider.QueryBySQL(mapName, queryParameterSet, callback, failed);
        }

        /// <summary>
        /// 在指定的地图上，查找距离指定几何对象一定距离容限内最近的对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="maxDistance">容限距离。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。当查询类型为最近地物查询时，查询起始记录位置QueryParameterSet.StartRecord参数不支持。 </param>
        /// <returns>查询结果对象。</returns>
        public QueryResult FindNearest(string mapName, Geometry geometry, double maxDistance, QueryParameterSet queryParameterSet)
        {
            return _mapProvider.FindNearest(mapName, geometry, maxDistance, queryParameterSet);
        }

        /// <summary>
        /// 使用异步的方式，在指定的地图上，查找距离指定几何对象一定距离容限内最近的对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="maxDistance">容限距离。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。当查询类型为最近地物查询时，查询起始记录位置QueryParameterSet.StartRecord参数不支持。 </param>
        /// <param name="completed">在服务端查询完成后时执行的方法。</param>
        /// <param name="failed">在进行查询时发生异常后执行的方法。</param>
        public void FindNearest(string mapName, Geometry geometry, double maxDistance, QueryParameterSet queryParameterSet,
            EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("mapName", Resources.ArgumentIsNotNull)));
                }
                return;
            }

            if (queryParameterSet == null || queryParameterSet.QueryParams == null)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            if (maxDistance <= 0)
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("maxDistance", Resources.ArgumentMoreThanZero)));
                }
                return;
            }
            EventHandler<QueryEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _mapProvider.FindNearest(mapName, geometry, maxDistance, queryParameterSet, callback, failed);
        }

        /// <summary>
        /// 根据查询结果资源ID，获取查询结果高亮图片，图片只支持PNG格式。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="queryResultID">查询结果资源ID。</param>
        /// <param name="style">高亮风格设置。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>高亮图片对象。</returns>
        /// <example>
        /// <code>
        /// ImageOutputOption imageOutputOption = new ImageOutputOption();
        /// imageOutputOption.ImageOutputFormat = ImageOutputFormat.PNG;
        /// imageOutputOption.ImageReturnType = ImageReturnType.URL;
        /// MapParameter mapParameter = map1.GetDefaultMapParameter("世界地图");
        /// mapParameter.ViewBounds = new Rectangle2D(-180, -90, 180, 90);
        /// mapParameter.RectifyType = RectifyType.BYVIEWBOUNDS;
        /// Style style = new Style();
        /// style.FillForeColor = new SuperMap.Connector.Utility.Color(0, 255, 0);
        /// Map map1 = new Map("http://localhost:8090/iserver/services/map-world/rest");
        /// //需要获取某次查询结果的queryResultID值
        /// MapImage actualResult = map1.GetHighlightImage("世界地图", queryResultID, style, mapParameter, imageOutputOption);
        /// </code>
        /// </example>
        public MapImage GetHighlightImage(string mapName, string queryResultID, Style style, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetHighlightImage(mapName, queryResultID, style, mapParameter, imageOutputOption);
        }

        //public MapImage GetHighlightImage(string mapName, string highlightTargetSetID, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        //{
        //    return _mapProvider.GetHighlightImage(mapName, highlightTargetSetID, mapParameter, imageOutputOption);
        //}

        /// <summary>
        /// 获取地图的鹰眼图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>鹰眼对象。</returns>
        /// <example>
        /// <code>
        /// Map map1 = new Map("http://localhost:8090/iserver/services/map-world/rest");
        /// ImageOutputOption imageOutputOption = new ImageOutputOption();
        /// imageOutputOption.ImageOutputFormat = ImageOutputFormat.PNG;
        /// imageOutputOption.ImageReturnType = ImageReturnType.URL;
        /// imageOutputOption.Transparent = false;
        /// MapParameter mapParameter = map1.GetDefaultMapParameter("世界地图");
        /// Overview actualResult = map1.GetOverview("世界地图", mapParameter, imageOutputOption);
        /// </code>
        /// </example>
        public Overview GetOverview(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetOverview(mapName, mapParameter, imageOutputOption);
        }

        /// <summary>
        /// 获取地图的全幅显示图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>全幅显示图片对象。</returns>
        /// <example>
        /// <code>
        /// Map map1 = new Map("http://localhost:8090/iserver/services/map-world/rest");
        /// ImageOutputOption imageOutputOption = new ImageOutputOption();
        /// imageOutputOption.ImageOutputFormat = ImageOutputFormat.PNG;
        /// imageOutputOption.ImageReturnType = ImageReturnType.URL;
        /// MapParameter mapParameter = map1.GetDefaultMapParameter("世界地图");
        /// MapImage imageResult = map1.GetEntireImage("世界地图", mapParameter, imageOutputOption);
        /// </code>
        /// </example>
        public MapImage GetEntireImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetEntireImage(mapName, mapParameter, imageOutputOption);
        }


        /// <summary>
        /// 根据指定的图层范围获取地图的全幅显示图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="layerName">指定图层，以该图层内容的最小外接矩形作为全幅显示的地理范围。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>全幅显示图片对象。</returns>
        public MapImage GetEntireImage(string mapName, string layerName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            return _mapProvider.GetEntireImage(mapName, layerName, mapParameter, imageOutputOption);
        }

        /// <summary>
        /// 清除指定地图范围的缓存。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="bounds">地图范围。</param>
        /// <returns>清除缓存是否成功。</returns>
        public bool ClearCache(string mapName, Rectangle2D bounds)
        {
            return _mapProvider.ClearCache(mapName, bounds);
        }
    }
}
