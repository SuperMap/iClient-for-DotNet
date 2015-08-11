using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SuperMap.Connector.Utility;
using System.Diagnostics;
#if WINDOWS_PHONE
using System.Net;
#else
using System.Web;
#endif


namespace SuperMap.Connector
{
    /// <summary>
    /// Map服务提供者。
    /// </summary>
    internal class MapProvider
    {
        private static object _lockTarget = new object();

        private string _serviceUrl;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">服务地址。</param>
        public MapProvider(string serviceUrl)
        {
            this._serviceUrl = serviceUrl;
        }

        //#if !WINDOWS_PHONE
        //        public void GetMapNames(EventHandler<GetMapNamesEventArgs> onCompleted, EventHandler<ServiceErrorEventArgs> onError)
        //        {
        //            AsyncHttpRequestHandler<GetMapNamesEventArgs> callback = new AsyncHttpRequestHandler<GetMapNamesEventArgs>(GetMapNamsCallback);
        //            AsyncHttpRequest asynHttpRequest = new AsyncHttpRequest();
        //            string uri = string.Format("{0}/maps.json?", this._serviceUrl);
        //            asynHttpRequest.GetRequestString<GetMapNamesEventArgs>(uri, HttpRequestMethod.GET, null, callback, onCompleted, onError);
        //        }
        //#endif

        //private void GetMapNamsCallback(string response, EventHandler<EventArgs> onCompleted, EventHandler<EventArgs> onError)
        //{
        //    List<MapsResourceResult> mapsResourceResults = JsonConvert.DeserializeObject<List<MapsResourceResult>>(response);
        //    List<string> mapNames = new List<string>();
        //    if (mapsResourceResults != null && mapsResourceResults.Count > 0)
        //    {
        //        for (int i = 0; i < mapsResourceResults.Count; i++)
        //        {
        //            mapNames.Add(mapsResourceResults[i].Name);
        //        }
        //    }
        //    if (onCompleted != null)
        //    {
        //        //T xxx = null;
        //        GetMapNamesEventArgs e = new GetMapNamesEventArgs(mapNames);
        //        //xxx = e as T;
        //        EventArgs xg = new EventArgs();
        //        onCompleted(this, e);
        //        //onCompleted(this, xxx);
        //        //onCompleted(null, xg);
        //    }
        //    Debug.WriteLine(response);
        //}

        //private void GetMapNamsCallback<T>(bool succeed, string response, EventHandler<T> onCompleted, EventHandler<ServiceErrorEventArgs> onError) where T : GetMapNamesEventArgs
        //{
        //    List<MapsResourceResult> mapsResourceResults = JsonConvert.DeserializeObject<List<MapsResourceResult>>(response);
        //    List<string> mapNames = new List<string>();
        //    if (mapsResourceResults != null && mapsResourceResults.Count > 0)
        //    {
        //        for (int i = 0; i < mapsResourceResults.Count; i++)
        //        {
        //            mapNames.Add(mapsResourceResults[i].Name);
        //        }
        //    }
        //    if (succeed && onCompleted != null)
        //    {
        //        GetMapNamesEventArgs e = new GetMapNamesEventArgs(mapNames);
        //        onCompleted(this, (T)e);
        //    }
        //    else
        //    {

        //    }
        //    Debug.WriteLine(response);
        //}

        /// <summary>
        /// 获取地图列表。
        /// </summary>
        /// <returns></returns>
        public List<string> GetMapNames()
        {
            string uri = string.Format("{0}/maps.json?", this._serviceUrl);
            string requestResultJson = SynchHttpRequest.GetRequestString(uri);
            List<MapsResourceResult> mapsResourceResults = JsonConvert.DeserializeObject<List<MapsResourceResult>>(requestResultJson);
            List<string> mapNames = new List<string>();
            if (mapsResourceResults != null && mapsResourceResults.Count > 0)
            {
                for (int i = 0; i < mapsResourceResults.Count; i++)
                {
                    mapNames.Add(mapsResourceResults[i].Name);
                }
            }
            return mapNames;
        }

        public void GetMapNames(EventHandler<GetMapNamesEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/maps.json?_method=GET", this._serviceUrl);
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    List<MapsResourceResult> mapsResourceResults = JsonConvert.DeserializeObject<List<MapsResourceResult>>(e.Result);
                    List<string> mapNames = new List<string>();
                    if (mapsResourceResults != null && mapsResourceResults.Count > 0)
                    {
                        for (int i = 0; i < mapsResourceResults.Count; i++)
                        {
                            mapNames.Add(mapsResourceResults[i].Name);
                        }
                    }
                    if (completed != null)
                    {
                        completed(this, new GetMapNamesEventArgs(mapNames));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        /// <summary>
        /// 根据地图名获取默认的地图参数。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <returns>地图参数。</returns>
        public MapParameter GetDefaultMapParameter(string mapName, bool returnLayers)
        {
            string uri = string.Format("{0}/maps/{1}.json?", this._serviceUrl, HttpUtility.UrlEncode(mapName));
            string requestResultJson = SynchHttpRequest.GetRequestString(uri);
            MapParameter mapParameter = JsonConvert.DeserializeObject<MapParameter>(requestResultJson);

            if (returnLayers)
            {
                string layersUri = string.Format("{0}/maps/{1}/layers.rjson?", this._serviceUrl, mapName);
                string requestJson = SynchHttpRequest.GetRequestString(layersUri);

                //是否需要用Layer进行解析呢
                //暂全部认为是UGC图层，后续可以将json的转换提升到LayerConverter中。
                List<UGCMapLayer> ugcMapLayers = JsonConvert.DeserializeObject<List<UGCMapLayer>>(requestJson);

                //MapParameter中对外公开的图层为具体的图层（UGCVectorLayer等,不会公开UGCMapLayer,后续的WMS图层另作处理）即如下转换下：
                if (mapParameter != null && ugcMapLayers != null && ugcMapLayers.Count > 0)
                {
                    mapParameter.Layers = new List<Layer>();
                    for (int i = 0; i < ugcMapLayers.Count; i++)
                    {
                        if (ugcMapLayers[i].SubLayers != null && ugcMapLayers[i].SubLayers.Count > 0)
                        {
                            for (int j = 0; j < ugcMapLayers[i].SubLayers.Count; j++)
                            {
                                mapParameter.Layers.Add(ugcMapLayers[i].SubLayers[j]);
                            }
                        }
                    }
                }
            }

            return mapParameter;
        }

        public void GetDefaultMapParameter(string mapName, bool returnLayers, EventHandler<MapParameterEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/maps/{1}.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(mapName));
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    MapParameter mapParameter = JsonConvert.DeserializeObject<MapParameter>(e.Result);
                    if (returnLayers)
                    {
                        string layersUri = string.Format("{0}/maps/{1}/layers.json?_method=GET", this._serviceUrl, mapName);
                        EventHandler<AsyncEventArgs<string>> callbackLayers = (sender1, e1) =>
                        {
                            if (e1 != null)
                            {
                                //是否需要用Layer进行解析呢
                                //暂全部认为是UGC图层，后续可以将json的转换提升到LayerConverter中。
                                List<UGCMapLayer> ugcMapLayers = JsonConvert.DeserializeObject<List<UGCMapLayer>>(e1.Result);

                                //MapParameter中对外公开的图层为具体的图层（UGCVectorLayer等,不会公开UGCMapLayer,后续的WMS图层另作处理）即如下转换下：
                                if (mapParameter != null && ugcMapLayers != null && ugcMapLayers.Count > 0)
                                {
                                    mapParameter.Layers = new List<Layer>();
                                    for (int i = 0; i < ugcMapLayers.Count; i++)
                                    {
                                        if (ugcMapLayers[i].SubLayers != null && ugcMapLayers[i].SubLayers.Count > 0)
                                        {
                                            for (int j = 0; j < ugcMapLayers[i].SubLayers.Count; j++)
                                            {
                                                mapParameter.Layers.Add(ugcMapLayers[i].SubLayers[j]);
                                            }
                                        }
                                    }
                                }
                                if (completed != null)
                                {
                                    completed(this, new MapParameterEventArgs(mapParameter));
                                }
                            }
                        };
                        AsyncHttpRequest.DownloadStringAsync(layersUri, null, callbackLayers, failed);
                    }
                    else
                    {
                        if (completed != null)
                        {
                            completed(this, new MapParameterEventArgs(mapParameter));
                        }
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        /// <summary>
        /// 根据地图分块信息，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名。【必设参数】</param>
        /// <param name="tileInfo">地图分块信息。【必设参数】</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的格网图片信息。</returns>
        public MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption)
        {
            return this.GetTile(mapName, tileInfo, imageOutputOption, null);
        }

        /// <summary>
        /// 根据地图分块信息和地图参数设置，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名。【必设参数】</param>
        /// <param name="tileInfo">地图分块信息。【必设参数】</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <returns>所获取的格网图片信息。</returns>
        public MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption, MapParameter mapParameter)
        {
            string strImageFormat = "png";
            bool returnUrl = false;
            if (imageOutputOption != null)
            {
                strImageFormat = imageOutputOption.ImageOutputFormat.ToString().ToLower();
                if (imageOutputOption.ImageReturnType == ImageReturnType.URL)
                {
                    returnUrl = true;
                }
            }
            if (tileInfo == null || tileInfo.TileIndex == null)
            {
                return null;
            }
            string url = string.Format("{0}/maps/{1}/tileImage.{2}?", this._serviceUrl, HttpUtility.UrlEncode(mapName), strImageFormat);
            StringBuilder requestParamBuilder = new StringBuilder();
            requestParamBuilder.Append(string.Format("scale={0}&x={1}&y={2}&width={3}&height={4}", tileInfo.Scale,
                tileInfo.TileIndex.ColIndex, tileInfo.TileIndex.RowIndex, tileInfo.Width, tileInfo.Height));
            if (imageOutputOption != null)
            {
                requestParamBuilder.Append(string.Format("&transparent={0}&", imageOutputOption.Transparent));
            }
            if (mapParameter != null)
            {
                requestParamBuilder.Append(this.GetMapRequestByMapParameter(mapName, mapParameter, false, true, true, true));
            }
            //进行重定向
            MapImage mapImage = new MapImage();
            url = url + requestParamBuilder.ToString();
            if (returnUrl)
            {
                mapImage.ImageUrl = url;
            }
            else
            {
                mapImage.ImageData = SynchHttpRequest.GetRequestBytes(url);
            }

            return mapImage;
        }

        /// <summary>
        /// 根据地图参数、图片输出设置获取地图图片。
        /// </summary>
        /// <param name="mapName">地图名。【必设参数】</param>
        /// <param name="mapParameter">地图参数。【必设参数】</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的地图图片对象。</returns>
        public MapImage GetMapImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption, bool returnMapParameter)
        {
            string strImageFormat = "png";
            bool returnUrl = false;
            if (imageOutputOption != null)
            {
                strImageFormat = imageOutputOption.ImageOutputFormat.ToString().ToLower();
                if (returnMapParameter)
                {
                    strImageFormat = "json";
                }
                if (imageOutputOption.ImageReturnType == ImageReturnType.URL)
                {
                    returnUrl = true;
                }
            }
            string url = string.Format("{0}/maps/{1}/image.{2}?", this._serviceUrl, HttpUtility.UrlEncode(mapName), strImageFormat);
            StringBuilder requestParamBuilder = new StringBuilder();

            if (imageOutputOption != null)
            {
                requestParamBuilder.Append(string.Format("transparent={0}&", imageOutputOption.Transparent));
            }
            if (mapParameter != null)
            {
                requestParamBuilder.Append(this.GetMapRequestByMapParameter(mapName, mapParameter, false, false, false, false));
            }
            MapImage mapImage = new MapImage();
            url = url + requestParamBuilder.ToString(); //用GET请求发送。
            if (returnMapParameter)
            {
                string requetResponse = SynchHttpRequest.GetRequestString(url, HttpRequestMethod.GET, "");
                Dictionary<string, object> jsonItems = JsonConvert.DeserializeObject<Dictionary<string, object>>(requetResponse);
                mapImage.ImageUrl = jsonItems["imageUrl"].ToString();
                mapImage.MapParameter = JsonConvert.DeserializeObject<MapParameter>(JsonConvert.SerializeObject(jsonItems["mapParam"]));
                return mapImage;
            }
            else if (returnUrl)
            {
                mapImage.ImageUrl = url;
            }
            else
            {
                mapImage.ImageData = SynchHttpRequest.GetRequestBytes(url);
            }

            return mapImage;
        }

        /// <summary>
        /// 获取地图的鹰眼图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>鹰眼对象。</returns>
        public Overview GetOverview(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            string strImageFormat = "png";
            bool returnUrl = false;
            if (imageOutputOption != null)
            {
                strImageFormat = imageOutputOption.ImageOutputFormat.ToString().ToLower();
                if (imageOutputOption.ImageReturnType == ImageReturnType.URL)
                {
                    returnUrl = true;
                    strImageFormat = "json";
                }
            }
            string url = string.Format("{0}/maps/{1}/overview.{2}?", this._serviceUrl, HttpUtility.UrlEncode(mapName), strImageFormat);
            StringBuilder requestParamBuilder = new StringBuilder();
            if (imageOutputOption != null)
            {
                requestParamBuilder.Append(string.Format("transparent={0}&", imageOutputOption.Transparent));
            }
            if (mapParameter != null)
            {
                requestParamBuilder.Append(GetMapRequestByMapParameter(mapName, mapParameter, true, false, false, false));
            }
            //进行重定向
            //requestParamBuilder.Append(string.Format("redirect={0}&", "true"));
            url = url + requestParamBuilder.ToString();
            Overview overview = new Overview();
            if (returnUrl)
            {
                string requetResponse = SynchHttpRequest.GetRequestString(url);
                Dictionary<string, object> jsonItems = JsonConvert.DeserializeObject<Dictionary<string, object>>(requetResponse);
                overview.ImageUrl = jsonItems["imageUrl"].ToString();
                overview.MapName = JsonConvert.DeserializeObject<string>(JsonConvert.SerializeObject(jsonItems["mapName"]));
                overview.LastModified = JsonConvert.DeserializeObject<long>(JsonConvert.SerializeObject(jsonItems["lastModified"]));
                overview.ViewBounds = JsonConvert.DeserializeObject<Rectangle2D>(JsonConvert.SerializeObject(jsonItems["viewBounds"]));
                overview.Viewer = JsonConvert.DeserializeObject<Rectangle>(JsonConvert.SerializeObject(jsonItems["viewer"]));
            }
            else
            {
                overview.ImageData = SynchHttpRequest.GetRequestBytes(url);
            }

            return overview;
        }

        /// <summary>
        /// 获取地图的全幅显示图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>全幅显示图片对象。</returns>
        public MapImage GetEntireImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            return GetEntireImage(mapName, null, mapParameter, imageOutputOption);
        }

        /// <summary>
        /// 获取地图的全幅显示图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="layerName">指定图层，以该图层内容的最小外接矩形作为全幅显示的地理范围，为空时，表示地图的最小外接矩形。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>全幅显示图片对象。</returns>
        public MapImage GetEntireImage(string mapName, string layerName, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            string strImageFormat = "png";
            bool returnUrl = false;
            if (imageOutputOption != null)
            {
                strImageFormat = imageOutputOption.ImageOutputFormat.ToString().ToLower();
                if (imageOutputOption.ImageReturnType == ImageReturnType.URL)
                {
                    returnUrl = true;
                }
            }
            string url = string.Format("{0}/maps/{1}/entireimage.{2}?", this._serviceUrl, HttpUtility.UrlEncode(mapName), strImageFormat);
            StringBuilder requestParamBuilder = new StringBuilder();
            requestParamBuilder.Append(string.Format("layerName={0}&", layerName));
            requestParamBuilder.Append(string.Format("redirect={0}&", "true"));
            if (imageOutputOption != null)
            {
                requestParamBuilder.Append(string.Format("transparent={0}&", imageOutputOption.Transparent));
            }
            if (mapParameter != null)
            {
                requestParamBuilder.Append(GetMapRequestByMapParameter(mapName, mapParameter, true, false, false, false));
            }
            url = url + requestParamBuilder.ToString();
            MapImage mapImage = new MapImage();
            if (returnUrl)
            {
                mapImage.ImageUrl = url;
            }
            else
            {
                mapImage.ImageData = SynchHttpRequest.GetRequestBytes(url);
            }

            return mapImage;
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
        public MapImage GetHighlightImage(string mapName, string queryResultID, Style style, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(queryResultID)) throw new ArgumentNullException("queryResultID", Resources.ArgumentIsNotNull);
            string strImageFormat = "png";
            bool returnUrl = false;
            if (imageOutputOption != null)
            {
                strImageFormat = imageOutputOption.ImageOutputFormat.ToString().ToLower();
                if (imageOutputOption.ImageReturnType == ImageReturnType.URL)
                {
                    returnUrl = true;
                }
            }
            string url = string.Format("{0}/maps/{1}/highlightImage.{2}?", this._serviceUrl, HttpUtility.UrlEncode(mapName), strImageFormat);
            StringBuilder requestParamBuilder = new StringBuilder();
            requestParamBuilder.Append(string.Format("queryResultID={0}&", queryResultID));
            requestParamBuilder.Append(string.Format("style={0}&", JsonConvert.SerializeObject(style)));
            if (imageOutputOption != null)
            {
                requestParamBuilder.Append(string.Format("transparent={0}&", imageOutputOption.Transparent));
            }
            if (mapParameter != null)
            {
                requestParamBuilder.Append(GetMapRequestByMapParameter(mapName, mapParameter, true, false, false, false));
            }
            url = url + requestParamBuilder.ToString();
            MapImage mapImage = new MapImage();
            if (returnUrl)
            {
                mapImage.ImageUrl = url;
            }
            else
            {
                mapImage.ImageData = SynchHttpRequest.GetRequestBytes(url);
            }

            return mapImage;
        }

        //public MapImage GetHighlightImage(string mapName, string highlightTargetSetID, MapParameter mapParameter, ImageOutputOption imageOutputOption)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 根据地图参数中的图层列表获取临时图层ID
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <returns>临时图层ID。</returns>
        private string GetTempLayersSetID(string mapName, MapParameter mapParameter)
        {
            if (mapParameter.Layers == null) return "0";

            string tempLayersKey = HashKeyHelper.GetHashKey<List<Layer>>(mapParameter.Layers);
            object layersID = CacheManager.Instance.GetCache(tempLayersKey);
            if (layersID == null)
            {
                lock (MapProvider._lockTarget)
                {
                    layersID = CacheManager.Instance.GetCache(tempLayersKey);
                    if (layersID == null)
                    {
                        //和GetMapParameter中相似，反向处理时，解析为UGCMapLayer对象中。
                        List<Layer> layers = new List<Layer>();
                        UGCMapLayer ugcMapLayer = new UGCMapLayer();
                        ugcMapLayer.SubLayers = new LayerCollection();
                        if (mapParameter.Layers != null && mapParameter.Layers.Count > 0)
                        {
                            for (int i = 0; i < mapParameter.Layers.Count; i++)
                            {
                                ugcMapLayer.SubLayers.Add(mapParameter.Layers[i]);
                            }
                        }
                        ugcMapLayer.Name = mapParameter.Name;
                        ugcMapLayer.Caption = mapParameter.Name;
                        ugcMapLayer.Visible = true;
                        ugcMapLayer.Type = LayerType.UGC;
                        ugcMapLayer.Description = mapParameter.Description;
                        ugcMapLayer.Bounds = mapParameter.Bounds;
                        layers.Add(ugcMapLayer);

                        string tempLayersSetUrl = string.Format("{0}/maps/{1}/tempLayersSet.json?", this._serviceUrl, HttpUtility.UrlEncode(mapName));
                        string tempLayersSetJson = JsonConvert.SerializeObject(layers);

                        string tempLayersSetResourceResult = SynchHttpRequest.GetRequestString(tempLayersSetUrl, tempLayersSetJson);
                        TempLayersSetResourceResult tempLayersSet = JsonConvert.DeserializeObject<TempLayersSetResourceResult>(tempLayersSetResourceResult);
                        if (tempLayersSet != null)
                        {
                            layersID = tempLayersSet.NewResourceID;
                            CacheManager.Instance.AddCache(tempLayersKey, layersID);
                        }
                    }
                }
            }

            return layersID as string;
        }

        /// <summary>
        /// 获取MapParameter对象的请求字符串(用来出图时用。)。
        /// </summary>
        /// <param name="mapName">地图名</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="filterCenter"></param>
        /// <param name="filterLayers"></param>
        /// <param name="filterVierBounds"></param>
        /// <param name="filterViewer"></param>
        /// <returns>地图请求参数字符串。</returns>
        private string GetMapRequestByMapParameter(string mapName, MapParameter mapParameter, bool filterLayers,
            bool filterViewer, bool filterVierBounds, bool filterCenter)
        {
            if (mapParameter == null) return string.Empty;
            StringBuilder mapParameterBuilder = new StringBuilder();

            if (!filterLayers)
            {
                string layersID = GetTempLayersSetID(mapName, mapParameter);
                if (layersID != "0")
                    mapParameterBuilder.Append(string.Format("&{0}={1}&", "layersID", layersID));
            }
            if (!filterViewer && mapParameter.Viewer != null)
            {
                mapParameterBuilder.Append(string.Format("viewer={0}&", JsonConvert.SerializeObject(mapParameter.Viewer)));
            }
            if (!filterVierBounds && mapParameter.ViewBounds != null)
            {
                mapParameterBuilder.Append(string.Format("viewBounds={0}&", JsonConvert.SerializeObject(mapParameter.ViewBounds)));
            }
            if (!filterCenter && mapParameter.Center != null)
            {
                mapParameterBuilder.Append(string.Format("center={0}&", JsonConvert.SerializeObject(mapParameter.Center)));
                mapParameterBuilder.Append(string.Format("scale={0}&", mapParameter.Scale));
            }

            if (mapParameter.DynamicProjection && mapParameter.PrjCoordSys != null)
            {
                mapParameterBuilder.Append(string.Format("{0}={1}&", "dynamicProjection", mapParameter.DynamicProjection.ToString()));
                mapParameterBuilder.Append(string.Format("{0}={1}", "prjCoordSys", JsonConvert.SerializeObject(mapParameter.PrjCoordSys)));
                mapParameterBuilder.Append("&");
            }

            mapParameterBuilder.Append(string.Format("{0}={1}&", "cacheEnabled", mapParameter.CacheEnabled));
            if (mapParameter.CustomParams != null)
            {
                mapParameterBuilder.Append(string.Format("customParams={0}&", mapParameter.CustomParams));
            }
            mapParameterBuilder.Append(string.Format("rectifyType={0}&", mapParameter.RectifyType));
            if (mapParameter.ClipRegionEnabled && mapParameter.ClipRegion != null)
            {
                mapParameterBuilder.Append(string.Format("clipRegionEnabled={0}&", mapParameter.ClipRegionEnabled));
                mapParameterBuilder.Append(string.Format("clipRegion={0}&", JsonConvert.SerializeObject(mapParameter.ClipRegion)));
            }
            if (mapParameter.CustomEntireBoundsEnabled && mapParameter.CustomEntireBounds != null)
            {
                mapParameterBuilder.Append(string.Format("customEntireBoundsEnabled={0}&", mapParameter.CustomEntireBoundsEnabled));
                mapParameterBuilder.Append(string.Format("customEntireBounds={0}&", JsonConvert.SerializeObject(mapParameter.CustomEntireBounds)));
            }
            mapParameterBuilder.Append(string.Format("angle={0}&", mapParameter.Angle));
            mapParameterBuilder.Append(string.Format("antialias={0}&", mapParameter.Antialias));
            mapParameterBuilder.Append(string.Format("backgroundStyle={0}&", JsonConvert.SerializeObject(mapParameter.BackgroundStyle)));
            mapParameterBuilder.Append(string.Format("colorMode={0}&", mapParameter.ColorMode));
            mapParameterBuilder.Append(string.Format("markerAngleFixed={0}&", mapParameter.MarkerAngleFixed));
            mapParameterBuilder.Append(string.Format("maxVisibleTextSize={0}&", mapParameter.MaxVisibleTextSize));
            mapParameterBuilder.Append(string.Format("maxVisibleVertex={0}&", mapParameter.MaxVisibleVertex));
            mapParameterBuilder.Append(string.Format("minVisibleTextSize={0}&", mapParameter.MinVisibleTextSize));
            mapParameterBuilder.Append(string.Format("overlapDisplayed={0}&", mapParameter.OverlapDisplayed));
            mapParameterBuilder.Append(string.Format("paintBackground={0}&", mapParameter.PaintBackground));
            mapParameterBuilder.Append(string.Format("textAngleFixed={0}&", mapParameter.TextAngleFixed));
            mapParameterBuilder.Append(string.Format("textOrientationFixed={0}&", mapParameter.TextOrientationFixed));

            return mapParameterBuilder.ToString();
        }

        /// <summary>
        /// 获取MapParameter对象的请求字符串(用来出图时用。)。
        /// </summary>
        /// <param name="mapName">地图名</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <returns>地图请求参数字符串。</returns>
        private string GetMapRequestByMapParameter(string mapName, MapParameter mapParameter)
        {
            StringBuilder mapParameterBuilder = new StringBuilder();

            string layersID = GetTempLayersSetID(mapName, mapParameter);
            if (layersID != "0")
                mapParameterBuilder.Append(string.Format("&{0}={1}&", "layersID", layersID));
            if (mapParameter.DynamicProjection && mapParameter.PrjCoordSys != null)
            {
                mapParameterBuilder.Append(string.Format("{0}={1}&", "dynamicProjection", mapParameter.DynamicProjection.ToString()));
                mapParameterBuilder.Append(string.Format("{0}={1}", "prjCoordSys", JsonConvert.SerializeObject(mapParameter.PrjCoordSys)));
                mapParameterBuilder.Append("&");
            }

            mapParameterBuilder.Append(string.Format("{0}={1}&", "cacheEnabled", mapParameter.CacheEnabled));
            if (mapParameter.CustomParams != null)
            {
                mapParameterBuilder.Append(string.Format("customParams={0}&", mapParameter.CustomParams));
            }
            mapParameterBuilder.Append(string.Format("rectifyType={0}&", mapParameter.RectifyType));
            if (mapParameter.ClipRegionEnabled && mapParameter.ClipRegion != null)
            {
                mapParameterBuilder.Append(string.Format("clipRegionEnabled={0}&", mapParameter.ClipRegionEnabled));
                mapParameterBuilder.Append(string.Format("clipRegion={0}&", JsonConvert.SerializeObject(mapParameter.ClipRegion)));
            }
            if (mapParameter.CustomEntireBoundsEnabled && mapParameter.CustomEntireBounds != null)
            {
                mapParameterBuilder.Append(string.Format("customEntireBoundsEnabled={0}&", mapParameter.CustomEntireBoundsEnabled));
                mapParameterBuilder.Append(string.Format("customEntireBounds={0}&", JsonConvert.SerializeObject(mapParameter.CustomEntireBounds)));
            }
            mapParameterBuilder.Append(string.Format("angle={0}&", mapParameter.Angle));
            mapParameterBuilder.Append(string.Format("antialias={0}&", mapParameter.Antialias));
            mapParameterBuilder.Append(string.Format("backgroundStyle={0}&", JsonConvert.SerializeObject(mapParameter.BackgroundStyle)));
            mapParameterBuilder.Append(string.Format("colorMode={0}&", mapParameter.ColorMode));
            mapParameterBuilder.Append(string.Format("markerAngleFixed={0}&", mapParameter.MarkerAngleFixed));
            mapParameterBuilder.Append(string.Format("maxVisibleTextSize={0}&", mapParameter.MaxVisibleTextSize));
            mapParameterBuilder.Append(string.Format("maxVisibleVertex={0}&", mapParameter.MaxVisibleVertex));
            mapParameterBuilder.Append(string.Format("minVisibleTextSize={0}&", mapParameter.MinVisibleTextSize));
            mapParameterBuilder.Append(string.Format("overlapDisplayed={0}&", mapParameter.OverlapDisplayed));
            mapParameterBuilder.Append(string.Format("paintBackground={0}&", mapParameter.PaintBackground));
            mapParameterBuilder.Append(string.Format("textAngleFixed={0}&", mapParameter.TextAngleFixed));
            mapParameterBuilder.Append(string.Format("textOrientationFixed={0}&", mapParameter.TextOrientationFixed));

            return mapParameterBuilder.ToString();
        }

        /// <summary>
        /// 根据资源图片参数获取资源图片。
        /// </summary>
        /// <param name="mapName">地图名称。【比设参数】</param>
        /// <param name="resourceParameter">资源图片参数，如生成的图片的高度、宽度、类型，资源的类型、风格等。【比设参数】</param>
        /// <param name="imageOutputOption">资源图片输出设置。</param>
        /// <returns>资源图片对象。</returns>
        public ResourceImage GetResource(string mapName, ResourceParameter resourceParameter, ImageOutputOption imageOutputOption)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            if (resourceParameter == null) throw new ArgumentNullException("resourceParameter", Resources.ArgumentIsNotNull);
            string strImageFormat = "png";
            bool returnUrl = false;
            if (imageOutputOption != null)
            {
                strImageFormat = imageOutputOption.ImageOutputFormat.ToString().ToLower();
                if (imageOutputOption.ImageReturnType == ImageReturnType.URL)
                {
                    returnUrl = true;
                    strImageFormat = "json";
                }
            }
            string baseUrl = string.Format("{0}/maps/{1}/symbol.{2}?", this._serviceUrl, HttpUtility.UrlEncode(mapName), strImageFormat);
            StringBuilder requestParamBuilder = new StringBuilder();
            requestParamBuilder.Append(baseUrl);
            requestParamBuilder.Append(string.Format("resourceType={0}&", resourceParameter.Type.ToString()));
            if (resourceParameter.Style != null)
            {
                requestParamBuilder.Append(string.Format("style={0}&", JsonConvert.SerializeObject(resourceParameter.Style)));
            }
            requestParamBuilder.Append(string.Format("picWidth={0}&", resourceParameter.Width));
            requestParamBuilder.Append(string.Format("picHeight={0}&", resourceParameter.Height));
            if (imageOutputOption != null)
            {
                requestParamBuilder.Append(string.Format("transparent={0}&", imageOutputOption.Transparent));
            }
            //if (resourceParameter.ForeColor != null)
            //{
            //    requestParamBuilder.Append(string.Format("foreColor={0}&", JsonConvert.SerializeObject(resourceParameter.ForeColor)));
            //}
            //if (resourceParameter.BackColor != null)
            //{
            //    requestParamBuilder.Append(string.Format("backColor={0}&", JsonConvert.SerializeObject(resourceParameter.BackColor)));
            //}
            //进行重定向
            requestParamBuilder.Append(string.Format("redirect={0}&", "true"));
            ResourceImage resourceImage = new ResourceImage();
            if (returnUrl)
            {
                string symbolResult = SynchHttpRequest.GetRequestString(requestParamBuilder.ToString());
                resourceImage.ImageUrl = JsonConvert.DeserializeObject<Dictionary<string, object>>(symbolResult)["resourceImageUrl"].ToString();
            }
            else
            {
                resourceImage.ImageData = SynchHttpRequest.GetRequestBytes(requestParamBuilder.ToString());
            }

            return resourceImage;
        }

        /// <summary>
        ///  在指定的地图上，执行 SQL 查询。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        public QueryResult QueryBySQL(string mapName, QueryParameterSet queryParameterSet)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            QueryResource qrResource = new QueryResource();
            if (queryParameterSet != null && queryParameterSet.QueryParams != null)
            {
                qrResource.QueryParameters = queryParameterSet;
            }
            else
            {
                throw new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull);
            }
            qrResource.QueryMode = "SqlQuery";

            return QueryInternal(mapName, qrResource);
        }

        public void QueryBySQL(string mapName, QueryParameterSet queryParameterSet,
            EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            QueryResource qr = BuildQueryResource(null, null, queryParameterSet, "SqlQuery", null, null);
            QueryInternal(mapName, qr, completed, failed);
        }

        /// <summary>
        /// 在指定的地图上，查询与指定的矩形范围以及符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="bounds">矩形范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        public QueryResult QueryByBounds(string mapName, Rectangle2D bounds, QueryParameterSet queryParameterSet)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            QueryResource qrResource = new QueryResource();
            if (queryParameterSet != null && queryParameterSet.QueryParams != null)
            {
                qrResource.QueryParameters = queryParameterSet;
            }
            else
            {
                throw new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull);
            }
            qrResource.QueryMode = "BoundsQuery";
            if (bounds != null)
            {
                qrResource.Bounds = bounds;
            }
            else
            {
                throw new ArgumentNullException("bounds", Resources.ArgumentIsNotNull);
            }
            return QueryInternal(mapName, qrResource);
        }

        public void QueryByBounds(string mapName, Rectangle2D bounds, QueryParameterSet queryParameterSet,
            EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            QueryResource qr = BuildQueryResource(null, null, queryParameterSet, "BoundsQuery", null, bounds);
            QueryInternal(mapName, qr, completed, failed);
        }

        /// <summary>
        /// 在指定的地图上，查询距离指定几何对象一定范围内的几何对象。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="distance">查询的距离范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 
        /// </param>
        /// <returns>查询结果集。</returns>
        /// <remarks>到指定几何对象的一定距离范围，实际是以指定几何对象为中心的一个圆，在这个圆内以及与圆相交的几何对象都能够被查询出来。
        /// </remarks>
        public QueryResult QueryByDistance(string mapName, Geometry geometry, double distance, QueryParameterSet queryParameterSet)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            QueryResource qrResource = new QueryResource();
            if (geometry != null)
            {
                qrResource.Geometry = geometry;
            }
            else
            {
                throw new ArgumentNullException("geometry", Resources.ArgumentIsNotNull);
            }
            if (distance > 0)
            {
                qrResource.Distance = distance;
            }
            else
            {
                throw new ArgumentOutOfRangeException("distance", Resources.ArgumentMoreThanZero);
            }
            if (queryParameterSet != null && queryParameterSet.QueryParams != null)
            {
                qrResource.QueryParameters = queryParameterSet;
            }
            else
            {
                throw new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull);
            }
            qrResource.QueryMode = "DistanceQuery";

            return QueryInternal(mapName, qrResource);
        }

        public void QueryByDistance(string mapName, Geometry geometry, double distance, QueryParameterSet queryParameterSet,
            EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            QueryResource qr = BuildQueryResource(geometry, distance, queryParameterSet, "DistanceQuery", null, null);
            QueryInternal(mapName, qr, completed, failed);
        }

        private QueryResource BuildQueryResource(Geometry geometry, double? distance, QueryParameterSet queryParameterSet,
            string queryMode, string spatialQueryMode, Rectangle2D bounds)
        {
            QueryResource qrResource = new QueryResource();
            qrResource.Geometry = geometry;
            if (distance != null && distance > 0.0)
            {
                qrResource.Distance = distance;
            }
            qrResource.QueryParameters = queryParameterSet;
            qrResource.SpatialQueryMode = spatialQueryMode;
            qrResource.Bounds = bounds;
            qrResource.QueryMode = queryMode;
            return qrResource;
        }

        /// <summary>
        /// 在指定的地图上，查询与指定的几何对象符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间几何对象间的查询模式
        /// <para>空间几何对象间的查询模式定义了一些几何对象之间的空间位置关系，根据这些空间关系来构建过滤条件执行查询。</para>
        /// <example>查询可被包含在面对象中的空间对象，与面有相离或者相邻关系的空间对象等。</example>
        /// </param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        public QueryResult QueryByGeometry(string mapName, Geometry geometry, SpatialQueryMode spatialQueryMode, QueryParameterSet queryParameterSet)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            QueryResource qrResource = new QueryResource();
            if (geometry != null)
            {
                qrResource.Geometry = geometry;
            }
            else
            {
                throw new ArgumentNullException("geometry", Resources.ArgumentIsNotNull);
            }
            if (queryParameterSet != null && queryParameterSet.QueryParams != null)
            {
                qrResource.QueryParameters = queryParameterSet;
            }
            else
            {
                throw new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull);
            }
            qrResource.QueryMode = "SpatialQuery";
            qrResource.SpatialQueryMode = spatialQueryMode.ToString();
            return QueryInternal(mapName, qrResource);
        }

        public void QueryByGeometry(string mapName, Geometry geometry, SpatialQueryMode spatialQueryMode, QueryParameterSet queryParameterSet, EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            QueryResource qr = BuildQueryResource(geometry, null, queryParameterSet, "SpatialQuery", spatialQueryMode.ToString(), null);
            QueryInternal(mapName, qr, completed, failed);
        }

        /// <summary>
        /// 在指定的地图上，查找距离指定几何对象一定距离容限内最近的对象。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="maxDistance">容限距离。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果对象。</returns>
        public QueryResult FindNearest(string mapName, Geometry geometry, double maxDistance, QueryParameterSet queryParameterSet)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            QueryResource qrResource = new QueryResource();
            if (queryParameterSet != null && queryParameterSet.QueryParams != null)
            {
                qrResource.QueryParameters = queryParameterSet;
            }
            else
            {
                throw new ArgumentNullException("queryParameterSet", Resources.ArgumentIsNotNull);
            }
            if (maxDistance > 0)
            {
                qrResource.Distance = maxDistance;
            }
            else
            {
                throw new ArgumentNullException("maxDistance", Resources.ArgumentMoreThanZero);
            }
            qrResource.QueryMode = "FindNearest";
            qrResource.Geometry = geometry;
            return QueryInternal(mapName, qrResource);
        }

        public void FindNearest(string mapName, Geometry geometry, double maxDistance, QueryParameterSet queryParameterSet,
            EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            QueryResource qr = BuildQueryResource(geometry, maxDistance, queryParameterSet, "FindNearest", null, null);
            QueryInternal(mapName, qr, completed, failed);
        }

        /// <summary>
        /// 查询。
        /// </summary>
        /// <param name="mapName">地图名。</param>
        /// <param name="queryResource">查询参数。</param>
        /// <returns>查询结果。</returns>
        internal QueryResult QueryInternal(string mapName, QueryResource queryResource)
        {
            string uri = string.Format("{0}/maps/{1}/queryResults.json?returnContent={2}&returnCustomResult={3}", this._serviceUrl,
                HttpUtility.UrlEncode(mapName), queryResource.QueryParameters.ReturnContent, queryResource.QueryParameters.ReturnCustomResult);
            string connect = JsonConvert.SerializeObject(queryResource);
            string requestResultJson = SynchHttpRequest.GetRequestString(uri, connect);
            QueryResult queryResult = null;
            if (queryResource.QueryParameters.ReturnContent)
            {
                queryResult = JsonConvert.DeserializeObject<QueryResult>(requestResultJson);
            }
            else
            {
                queryResult = new QueryResult();
                queryResult.ResourceInfo = JsonConvert.DeserializeObject<ResourceInfo>(requestResultJson);
            }
            return queryResult;
        }

        private void QueryInternal(string mapName, QueryResource queryResource, EventHandler<QueryEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/maps/{1}/queryResults.json?returnContent={2}&returnCustomResult={3}", this._serviceUrl,
                HttpUtility.UrlEncode(mapName), queryResource.QueryParameters.ReturnContent, queryResource.QueryParameters.ReturnCustomResult);
            string queryJson = JsonConvert.SerializeObject(queryResource);
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    QueryResult queryResult = null;
                    queryResult = JsonConvert.DeserializeObject<QueryResult>(e.Result);
                    completed(this, new QueryEventArgs(queryResult));
                }
            };
            AsyncHttpRequest.UpLoadStringAsync(uri, HttpRequestMethod.POST, queryJson, null, callback, failed);
        }

        /// <summary>
        /// 根据地图名称、二维地理坐标点、量算参数进行面积量算。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="point2Ds">二维地理坐标点数组。 </param>
        /// <param name="unit">返回结果的单位。</param>
        /// <returns>量算结果对象。</returns>
        public MeasureAreaResult MeasureArea(string mapName, List<Point2D> point2Ds, Unit unit)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            if (point2Ds == null) throw new ArgumentNullException("point2Ds", Resources.ArgumentIsNotNull);
            if (point2Ds.Count <= 2) throw new ArgumentException(string.Format(Resources.Point2DsLessThreePoint, "point2Ds"));
            string uri = string.Format("{0}/maps/{1}/area.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(mapName));
            MeasureRequestParameter measureParameter = new MeasureRequestParameter(point2Ds, unit);
            string measureAreaJsonString = SynchHttpRequest.GetRequestString(uri, JsonConvert.SerializeObject(measureParameter));
            MeasureAreaResult measureAreaJsonResult = JsonConvert.DeserializeObject<MeasureAreaResult>(measureAreaJsonString);
            return measureAreaJsonResult;
        }

        /// <summary>
        /// 根据地图名称、二维地理坐标点、量算参数进行距离量算。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="point2Ds">二维地理坐标点数组。</param>
        /// <param name="unit">返回结果的单位。</param>
        /// <returns>量算结果对象。</returns>
        public MeasureDistanceResult MeasureDistance(string mapName, List<Point2D> point2Ds, Unit unit)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            if (point2Ds == null) throw new ArgumentNullException("point2Ds", Resources.ArgumentIsNotNull);
            if (point2Ds.Count < 2) throw new ArgumentException(string.Format(Resources.Point2DsLessTwoPoint, "point2Ds"));
            string uri = string.Format("{0}/maps/{1}/distance.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(mapName));
            MeasureRequestParameter measureParameter = new MeasureRequestParameter(point2Ds, unit);
            string measureDistanceString = SynchHttpRequest.GetRequestString(uri, JsonConvert.SerializeObject(measureParameter));
            return JsonConvert.DeserializeObject<MeasureDistanceResult>(measureDistanceString);
        }

        /// <summary>
        /// 清除指定地图范围的缓存。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="bounds">地图范围。</param>
        /// <returns>清除缓存是否成功。</returns>
        public bool ClearCache(string mapName, Rectangle2D bounds)
        {
            if (string.IsNullOrEmpty(mapName)) throw new ArgumentNullException("mapName", Resources.ArgumentIsNotNull);
            if (bounds == null)
            {
                throw new ArgumentNullException("bounds", Resources.ArgumentIsNotNull);
            }
            string uri = string.Format("{0}/maps/{1}/clearcache.json?bounds={2}", this._serviceUrl, HttpUtility.UrlEncode(mapName),
                JsonConvert.SerializeObject(bounds));
            string result = SynchHttpRequest.GetRequestString(uri);
            bool clearCacheResult = false;
            if (bool.TryParse(result, out clearCacheResult))
            {
                return clearCacheResult;
            }
            else
            {
                return false;
            }
        }
    }
}
