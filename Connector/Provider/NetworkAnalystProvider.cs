using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;
using Newtonsoft.Json;
#if WINDOWS_PHONE
using System.Net;
#else
using System.Web;
#endif


namespace SuperMap.Connector
{
    /// <summary>
    /// 交通网络分析提供者
    /// </summary>
    internal class NetworkAnalystProvider
    {
        private string _serviceUrl;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceUrl"></param>
        public NetworkAnalystProvider(string serviceUrl)
        {
            // TODO: Complete member initialization
            this._serviceUrl = serviceUrl;
        }

        /// <summary>
        /// 最佳路径分析。
        /// </summary>
        /// <param name="networkDatasetName">必设参数，用于唯一标识一个网络数据集的字符串。</param>
        /// <param name="nodeIDs">需要经过的网络结点 ID 数组，必设参数，ID必须大于0。</param>
        /// <param name="hasLeastEdgeCount">是否按弧段数最少的模式查询。可选参数，默认为false， 代表不按照弧段最少进行查询。 </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数。</param>
        /// <returns>最佳路径分析结果集合，目前实际上其中只包含一个元素。</returns>
        public List<Path> FindPath(string networkDatasetName, int[] nodeIDs, bool hasLeastEdgeCount, TransportationAnalystParameter parameter)
        {
            if (nodeIDs == null || nodeIDs.Length <= 0)
            {
                throw new ArgumentNullException("nodeIDs", Resources.ArgumentIsNotNull);
            }
            //int length = nodeIDs.Length;
            //for (int i = 0; i < length; i++)
            //{
            //    if (nodeIDs[i] < 1) throw new ArgumentException("nodeIDs", Resources.ArgumentMoreThanZero);
            //}
            if (nodeIDs.Length < 2) throw new ArgumentException(string.Format(Resources.Point2DsLessTwoPoint, "nodeIDs"));
            return FindPathInternal(networkDatasetName, nodeIDs, null, hasLeastEdgeCount, parameter);
        }

        public void FindPath(string networkDatasetName, int[] nodeIDs, bool hasLeastEdgeCount, TransportationAnalystParameter parameter,
            EventHandler<FindPathEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            FindPathInternal(networkDatasetName, nodeIDs, null, hasLeastEdgeCount, parameter, completed, failed);
        }

        /// <summary>
        /// 最佳路径分析。
        /// </summary>
        /// <param name="networkDatasetName">必设参数，用于唯一标识一个网络数据集的字符串。</param>
        /// <param name="points">需要经过的坐标点数组，必设参数。</param>
        /// <param name="hasLeastEdgeCount">是否按弧段数最少的模式查询。 </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认使用TransportationAnalystSetting中的设置。</param>
        /// <returns>最佳路径分析结果集合，目前实际上其中只包含一个元素。</returns>
        public List<Path> FindPath(string networkDatasetName, Point2D[] points, bool hasLeastEdgeCount, TransportationAnalystParameter parameter)
        {
            if (points == null) throw new ArgumentNullException("points", Resources.ArgumentIsNotNull);
            if (points.Length < 2) throw new ArgumentException(string.Format(Resources.Point2DsLessTwoPoint, "points"));

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == null) throw new ArgumentNullException("point", Resources.ArgumentIsNotNull);
            }
            return FindPathInternal(networkDatasetName, null, points, hasLeastEdgeCount, parameter);
        }


        public void FindPath(string networkDatasetName, Point2D[] points, bool hasLeastEdgeCount, TransportationAnalystParameter parameter,
            EventHandler<FindPathEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            FindPathInternal(networkDatasetName, null, points, hasLeastEdgeCount, parameter, completed, failed);
        }


        private void FindPathInternal(string networkDatasetName, int[] nodeIDs, Point2D[] points, bool hasLeastEdgeCount, TransportationAnalystParameter parameter,
          EventHandler<FindPathEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            FindPathRequestParameter findPathParamter = null;
            if (nodeIDs == null)
            {
                findPathParamter = new FindPathRequestParameter(points, hasLeastEdgeCount, parameter);
            }
            else
            {
                findPathParamter = new FindPathRequestParameter(nodeIDs, hasLeastEdgeCount, parameter);
            }
            string baseUrl = string.Format("{0}/networkanalyst/{1}/path.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    List<Path> findPathResult = null;
                    if (e != null && e.Result != null)
                    {
                        string result = e.Result.Replace("{\"pathList\":", "");
                        result = result.Substring(0, result.Length - 1);
                        findPathResult = JsonConvert.DeserializeObject<List<Path>>(result);
                    }
                    completed(this, new FindPathEventArgs(findPathResult));
                }
            };
            AsyncHttpRequest.UpLoadStringAsync(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(findPathParamter), null, callback, failed);
        }

        internal List<Path> FindPathInternal(string networkDatasetName, int[] nodeIDs, Point2D[] points, bool hasLeastEdgeCount, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            FindPathRequestParameter findPathParamter = null;
            if (nodeIDs == null)
            {
                findPathParamter = new FindPathRequestParameter(points, hasLeastEdgeCount, parameter);
            }
            else
            {
                findPathParamter = new FindPathRequestParameter(nodeIDs, hasLeastEdgeCount, parameter);
            }
            string baseUrl = string.Format("{0}/networkanalyst/{1}/path.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(findPathParamter));
            result = result.Replace("{\"pathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<Path>>(result);
        }

        /// <summary>
        /// 最近设施查找分析，事件点以点坐标表示。
        /// <para>最近设施分析是指在网络上给定一个事件点和一组设施点，为事件点查找以最小耗费能到达的一个或几个设施点，结果为从事件点到设施点(或从设施点到事件点)的最佳路径。</para>
        /// </summary>
        /// <param name="networkDatasetName">必设参数，用于唯一标识一个网络数据集的字符串。</param>
        /// <param name="facilityPoints">表示设施点的坐标点数组，必设参数。</param>
        /// <param name="eventPoint">表示事件点的坐标点，必设参数。</param>
        /// <param name="expectFacilityCount">要查找的设施点数量，可选参数，默认值为1。</param>
        /// <param name="fromEvent">是否从事件点到设施点进行查找，可选参数，默认为false。</param>
        /// <param name="maxWeight">查找半径，必设参数。单位同 parameter（交通网络分析通用参数）中设置的权值字段一致，如果要查找整个网络，该值设为 0。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数。</param>
        /// <returns></returns>
        public List<ClosestFacilityPath<Point2D>> FindClosestFacility(string networkDatasetName, Point2D[] facilityPoints, Point2D eventPoint, int expectFacilityCount,
            bool fromEvent, double maxWeight, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (facilityPoints == null) throw new ArgumentNullException("facilityPoints", Resources.ArgumentIsNotNull);
            if (eventPoint == null) throw new ArgumentNullException("eventPoint", Resources.ArgumentIsNotNull);

            string baseUrl = string.Format("{0}/networkanalyst/{1}/closestfacility.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            ClosestFacilityRequestParameter pointParameter = new ClosestFacilityRequestParameter(facilityPoints, eventPoint, expectFacilityCount, fromEvent, maxWeight, parameter);

            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(pointParameter));
            result = result.Replace("{\"facilityPathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<ClosestFacilityPath<Point2D>>>(result);
        }

        /// <summary>
        /// 最近设施查找分析，事件点以网络结点 ID 表示。
        /// </summary>
        /// <param name="networkDatasetName">必设参数，用于唯一标识一个网络数据集的字符串。</param>
        /// <param name="facilityIDs">表示设施点的结点 ID 数组，必设参数，ID必须大于0。</param>
        /// <param name="eventID">表示事件点的结点 ID，必设参数，ID必须大于0。</param>
        /// <param name="expectFacilityCount">要查找的设施点数量，可选参数，默认值为1。</param>
        /// <param name="fromEvent">是否从事件点到设施点进行查找，可选参数，默认为false。</param>
        /// <param name="maxWeight">查找半径，必设参数。单位同 parameter（交通网络分析通用参数）中设置的权值字段一致，如果要查找整个网络，该值设为 0。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认使用TransportationAnalystSetting中的设置。</param>
        /// <returns>最近设施分析结果路径集合。</returns>
        public List<ClosestFacilityPath<int>> FindClosestFacility(string networkDatasetName, int[] facilityIDs, int eventID, int expectFacilityCount, bool fromEvent, double maxWeight, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (eventID < 1) throw new ArgumentException("eventID", Resources.ArgumentMoreThanZero);
            if (facilityIDs == null || facilityIDs.Length <= 0)
            {
                throw new ArgumentNullException("facilityIDs", Resources.ArgumentIsNotNull);
            }
            string baseUrl = string.Format("{0}/networkanalyst/{1}/closestfacility.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            ClosestFacilityRequestParameter nodeIDParameter = new ClosestFacilityRequestParameter(facilityIDs, eventID, expectFacilityCount, fromEvent, maxWeight, parameter);

            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(nodeIDParameter));

            result = result.Replace("{\"facilityPathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<ClosestFacilityPath<int>>>(result);
        }

        /// <summary>
        /// 旅行商分析,根据网络结点的 ID 进行分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodeIDsToVisit">需要途经的网络结点的 ID 数组，必设参数。</param>
        /// <param name="endNodeAssigned">是否指定终止点。可选参数，默认为False，如果设置为true ，则表示指定终止点，则旅行商必须最后一个访问终止点，即途经的最后一个点。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>旅行商分析结果集合，目前实际上其中只包含一个元素。</returns>
        public List<TSPPath> FindTSPPath(string networkDatasetName, int[] nodeIDsToVisit, bool endNodeAssigned, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }

            if (nodeIDsToVisit.Length < 2) throw new ArgumentException(string.Format(Resources.Point2DsLessTwoPoint, "nodeIDsToVisit"));

            string baseUrl = string.Format("{0}/networkanalyst/{1}/tsppath.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));

            TSPPathRequestParameter tspParameter = new TSPPathRequestParameter(nodeIDsToVisit, endNodeAssigned, parameter);
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(tspParameter));
            result = result.Replace("{\"tspPathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<TSPPath>>(result);
        }

        /// <summary>
        /// 旅行商分析,根据坐标点进行分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="pointsToVisit">需要途经的坐标点数组，必设参数。</param>
        /// <param name="endNodeAssigned">是否指定终止点。可选参数，默认为False，如果设置为true ，则表示指定终止点，则旅行商必须最后一个访问终止点，即途经的最后一个点。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>旅行商分析结果集合，目前实际上其中只包含一个元素。</returns>
        public List<TSPPath> FindTSPPath(string networkDatasetName, Point2D[] pointsToVisit, bool endNodeAssigned, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (pointsToVisit == null || pointsToVisit.Length < 2) throw new ArgumentException(string.Format(Resources.Point2DsLessTwoPoint, "pointsToVisit"));
            string baseUrl = string.Format("{0}/networkanalyst/{1}/tsppath.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));

            TSPPathRequestParameter tspParameter = new TSPPathRequestParameter(pointsToVisit, endNodeAssigned, parameter);
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(tspParameter));
            result = result.Replace("{\"tspPathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<TSPPath>>(result);
        }

        /// <summary>
        /// 多旅行商（物流配送）分析，配送中心以网络结点 ID 数组表示。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodeIDs">配送目标结点 ID 数组，必设参数。</param>
        /// <param name="centerIDs">配送中心结点 ID 数组，必设参数。</param>
        /// <param name="hasLeastTotalCost">
        /// <para>配送模式是否为总花费最小方案。可选参数，默认值为false， 表示采用局部最优方案；设置为true 表示采用总花费最小方案。</para>
        /// <para>总花费最小方案中，可能会出现某些配送中心点配送的花费较多，而其他的配送中心点的花费较少的情况。 局部最优方案中，会控制每个配送中心点的花费，使各个中心点花费相对平均，此时总花费不一定最小。</para>
        /// </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>多旅行商分析结果集。</returns>
        public List<MTSPPath<int>> FindMTSPPath(string networkDatasetName, int[] nodeIDs, int[] centerIDs, bool hasLeastTotalCost, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (nodeIDs == null) throw new ArgumentNullException("nodeIDs", Resources.ArgumentIsNotNull);
            if (centerIDs == null) throw new ArgumentNullException("centerIDs", Resources.ArgumentIsNotNull);
            string baseUrl = string.Format("{0}/networkanalyst/{1}/mtsppath.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));


            MTSPPathRequestParameter mtspParameter = new MTSPPathRequestParameter(nodeIDs, centerIDs, hasLeastTotalCost, parameter);
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(mtspParameter));
            result = result.Replace("{\"pathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<MTSPPath<int>>>(result);
        }

        /// <summary>
        /// 多旅行商（物流配送）分析，配送中心以网络结点 ID 数组表示。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="points">配送目标坐标点数组，必设参数。</param>
        /// <param name="centerPoints">配送中心坐标点数组，必设参数。</param>
        /// <param name="hasLeastTotalCost">
        /// <para>配送模式是否为总花费最小方案。可选参数，默认值为false， 表示采用局部最优方案；设置为true 表示采用总花费最小方案。</para>
        /// <para>总花费最小方案中，可能会出现某些配送中心点配送的花费较多，而其他的配送中心点的花费较少的情况。 局部最优方案中，会控制每个配送中心点的花费，使各个中心点花费相对平均，此时总花费不一定最小。</para>
        /// </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>多旅行商分析结果集。</returns>
        public List<MTSPPath<Point2D>> FindMTSPPath(string networkDatasetName, Point2D[] points, Point2D[] centerPoints, bool hasLeastTotalCost, TransportationAnalystParameter parameter)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (points == null) throw new ArgumentNullException("points", Resources.ArgumentIsNotNull);
            if (centerPoints == null) throw new ArgumentNullException("centerPoints", Resources.ArgumentIsNotNull);
            string baseUrl = string.Format("{0}/networkanalyst/{1}/mtsppath.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));


            MTSPPathRequestParameter mtspParameter = new MTSPPathRequestParameter(points, centerPoints, hasLeastTotalCost, parameter);
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(mtspParameter));
            result = result.Replace("{\"pathList\":", "");
            result = result.Substring(0, result.Length - 1);
            return JsonConvert.DeserializeObject<List<MTSPPath<Point2D>>>(result);
        }

        /// <summary>
        /// 获取交通网络分析服务中使用的所有网络数据集的名称。
        /// </summary>
        /// <returns>网络数据名称数组。</returns>
        public List<string> GetNetworkDatasetNames()
        {
            string baseUrl = string.Format("{0}/networkanalyst.json?", this._serviceUrl);
            string result = SynchHttpRequest.GetRequestString(baseUrl);
            List<NetworkAnalystRootResourceResult> resourceResult = JsonConvert.DeserializeObject<List<NetworkAnalystRootResourceResult>>(result);
            if (resourceResult != null)
            {
                List<string> networkDatasetNames = new List<string>();
                for (int i = 0; i < resourceResult.Count; i++)
                {
                    networkDatasetNames.Add(resourceResult[i].Name);
                }
                return networkDatasetNames;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定网络数据集的转向权值字段名称列表。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>指定网路数据对应的转向权值字段列表。</returns>
        public List<string> GetTurnWeightNames(string networkDatasetName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#endif
            string baseUrl = string.Format("{0}/networkanalyst/{1}/turnnodeweightfieldnames.json?", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl);
            return JsonConvert.DeserializeObject<List<string>>(result);
        }

        /// <summary>
        /// 获取指定网络数据的权值字段名称列表。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>指定网路数据集对应的权值字段列表。</returns>
        public List<string> GetWeightNames(string networkDatasetName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#endif
            string baseUrl = string.Format("{0}/networkanalyst/{1}/edgeweightnames.json?", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl);
            return JsonConvert.DeserializeObject<List<string>>(result);
        }

        /// <summary>
        /// 获取指定网络数据的投影信息。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>指定网络数据对应的投影信息。</returns>
        public PrjCoordSys GetNetworkDatasetPrj(string networkDatasetName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#endif
            string baseUrl = string.Format("{0}/networkanalyst/{1}/networkdataprj.json?", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl);
            return JsonConvert.DeserializeObject<PrjCoordSys>(result);
        }

        /// <summary>
        /// 重新加载网络模型。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>重新加载是否成功。</returns>
        public bool ReloadModel(string networkDatasetName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#endif
            string baseUrl = string.Format("{0}/networkanalyst/{1}/model.json?_method=PUT", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl, "");
            Dictionary<string, object> resultHash = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            if (resultHash != null && resultHash.ContainsKey("succeed") && resultHash["succeed"] != null)
            {
                bool succeed = false;
                bool.TryParse(resultHash["succeed"].ToString(), out succeed);
                return succeed;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新弧段的权值。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="edgeID">目标弧段 ID。</param>
        /// <param name="fromNodeID">目标弧段的起始结点 ID。</param>
        /// <param name="toNodeID">目标弧段的终止结点 ID。</param>
        /// <param name="weightField">目标弧段对应的权值信息的名称，fromNodeID 和 toNodeID 参数决定了更新其中的正向字段还是反向字段。</param>
        /// <param name="weight">新的权值。</param>
        /// <returns>更新成功返回更新前的权值，失败返回 double 类型数据的最小值。</returns>
        public bool UpdateEdgeWeight(string networkDatasetName, int edgeID, int fromNodeID, int toNodeID, string weightField, double weight)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrWhiteSpace(weightField))
            {
                throw new ArgumentNullException("weightField", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrEmpty(weightField))
            {
                throw new ArgumentNullException("weightField", Resources.ArgumentIsNotNull);
            }
#endif
            string baseUrl = string.Format("{0}/networkanalyst/{1}/edgeweight/{2}/fromnode/{3}/tonode/{4}/weightfield/{5}.json?_method=PUT",
              this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName), edgeID, fromNodeID, toNodeID, weightField);
            string result = SynchHttpRequest.GetRequestString(baseUrl, weight.ToString());
            bool succeed = false;
            try
            {
                Dictionary<string, object> resultHash = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                if (resultHash != null && resultHash.ContainsKey("succeed") && resultHash["succeed"] != null)
                {
                    bool.TryParse(resultHash["succeed"].ToString(), out succeed);
                }
            }
            catch
            {

            }
            return succeed;
        }

        /// <summary>
        /// 更新转向结点的权值。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodeID">目标转向结点 ID。</param>
        /// <param name="fromEdgeID">目标转向结点的起始弧段 ID。</param>
        /// <param name="toEdgeID">目标转向结点的终止弧段 ID。</param>
        /// <param name="turnWeightField">转向权值字段的名称。</param>
        /// <param name="weight">新的权值。</param>
        /// <returns>成功返回更新前的权值，失败返回 double 类型数据的最小值。</returns>
        public bool UpdateTurnNodeWeight(string networkDatasetName, int nodeID, int fromEdgeID, int toEdgeID, string turnWeightField, double weight)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrWhiteSpace(turnWeightField))
            {
                throw new ArgumentNullException("weightField", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrEmpty(turnWeightField))
            {
                throw new ArgumentNullException("weightField", Resources.ArgumentIsNotNull);
            }
#endif
            string baseUrl = string.Format("{0}/networkanalyst/{1}/turnnodeweight/{2}/fromedge/{3}/toedge/{4}/weightfield/{5}.json?_method=PUT",
               this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName), nodeID, fromEdgeID, toEdgeID, turnWeightField);
            string result = SynchHttpRequest.GetRequestString(baseUrl, weight.ToString());
            bool succeed = false;
            try
            {
                Dictionary<string, object> resultHash = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                if (resultHash != null && resultHash.ContainsKey("succeed") && resultHash["succeed"] != null)
                {
                    bool.TryParse(resultHash["succeed"].ToString(), out succeed);
                }
            }
            catch
            {

            }
            return succeed;
        }

        /// <summary>
        /// 通过交通网络分析参数，得出一个耗费矩阵。该矩阵是一个二维 double 数组，用来存储任意两点间的资源消耗。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodes">计算耗费矩阵的结点 ID 的集合。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>存储任意两点间耗费的二维矩阵列表。</returns>
        public double[][] ComputeWeightMatrix<T>(string networkDatasetName, List<T> nodes, TransportationAnalystParameter parameter)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#endif
            if (!(typeof(T) == typeof(int) || typeof(T) == typeof(Point2D)))
            {
                throw new ArgumentException("", "");
            }

            WeightMatrixRequestParameter<T> requestParameter = new WeightMatrixRequestParameter<T>(nodes, parameter);
            string baseUrl = string.Format("{0}/networkanalyst/{1}/weightmatrix.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(requestParameter));
            return JsonConvert.DeserializeObject<double[][]>(result);
        }

        public List<ServiceAreaResult> FindServiceArea<T>(string networkDatasetName, List<T> centers, List<double> weights, bool isFromCenter, bool isCenterMutuallyExclusive, TransportationAnalystParameter parameter)
        {
            //string baseUrl = string.Format("{0}/networkanalyst/{1}/serviceareas/{2}/{3}.json?_method=GET", this._serviceUrl, 
            //    HttpUtility.UrlEncode(networkDatasetName),JsonConvert.SerializeObject(centers), JsonConvert.SerializeObject(weights));
            string baseUrl = string.Format("{0}/networkanalyst/{1}/servicearea.json?_method=GET", this._serviceUrl,
                   HttpUtility.UrlEncode(networkDatasetName));
            ServiceAreaRequestParameter<T> requestParameter = new ServiceAreaRequestParameter<T>(centers, weights, isFromCenter, isCenterMutuallyExclusive, parameter);
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(requestParameter));
            Dictionary<string, object> resultHash = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            if (resultHash != null && resultHash.ContainsKey("serviceAreaList") && resultHash["serviceAreaList"] != null)
            {
                return JsonConvert.DeserializeObject<List<ServiceAreaResult>>(resultHash["serviceAreaList"].ToString());
            }
            else
            {
                return null;
            }
        }

        public LocationAnalystResult FindLocation(string networkDatasetName, LocationAnalystParameter parameter)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                throw new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull);
            }
#endif
            if (parameter == null) throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            string baseUrl = string.Format("{0}/networkanalyst/{1}/location.json?_method=GET", this._serviceUrl, HttpUtility.UrlEncode(networkDatasetName));
            string result = SynchHttpRequest.GetRequestString(baseUrl, JsonConvert.SerializeObject(parameter));
            return JsonConvert.DeserializeObject<LocationAnalystResult>(result);
        }
    }
}
