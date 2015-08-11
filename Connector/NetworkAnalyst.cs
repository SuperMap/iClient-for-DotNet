using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    /// <summary>
    /// NetworkAnalyst 组件接口，用以访问 SuperMap iServer 网络分析服务组件中的REST服务，封装了与网络分析相关的一系列功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>只能对 SuperMap REST 接口类型服务的访问。</description></item>
    /// <item><description>实例化NetworkAnalyst对象时需要使用明确的网络分析服务组件地址(例如：http://localhost:8090/iserver/services/transportationanalyst-sample/rest") </description></item>
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
    ///         //根据服务组件地址初始化一个NetworkAnalyst对象。
    ///         NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
    ///     }
    /// }
    /// </code>
    /// </example>
    public class NetworkAnalyst
    {
        #region 成员变量

        private string _serviceUrl;
        private NetworkAnalystProvider _netWorkAnalystProvider;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">SuperMap iServer 网络分析服务组件的URL地址(例如：http://localhost:8090/iserver/services/transportationanalyst-sample/rest")。 </param>
        /// <exception cref="ArgumentNullException">参数 serviceUrl 为空时抛出异常。</exception>
        public NetworkAnalyst(string serviceUrl)
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
            this._netWorkAnalystProvider = new NetworkAnalystProvider(this._serviceUrl);
        }

        #endregion

        /// <summary>
        /// SuperMap iServer 网络分析服务组件地址。
        /// </summary>
        public string ServiceUrl
        {
            get { return this._serviceUrl; }
        }

        /// <summary>
        /// 最佳路径分析，根据网络结点的 ID 进行分析。
        /// </summary>
        /// <remarks>
        /// <para>最佳路径分析解决的问题是，在网络数据集中，给定 N 个点（N 大于等于2），找出按照给定点的次序依次经过这 N 个点的阻抗最小的路径。 “阻抗最小”有多种理解，如时间最短、费用最低、风景最好、路况最佳、过桥最少、收费站最少、经过乡村最多等。</para>
        /// <para>调用该方法实现路径查找，查找的结果就是依次经过 N 个点（N 大于等于2）的最佳路径。</para>
        /// <para>例子：如果要顺序访问1、2、3、4四个结点并查找经过这四个结点的最佳路径， 则需要分别找到1、2结点间的最佳路径 R1_2，2、3间的最佳路径 R2_3和3、4结点间的最佳路径 R3_4，结果顺序访问1、2、3、4四个结点的最佳路径为 R= R1_2 + R2_3 + R3_4。</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// 以下为根据网络结点ID数组进行最佳路径分析的示范程序。
        /// 
        /// int[] nodeIDs = new int[2] { 3554, 3755 };
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;Path&gt; actualResult = netAnalyst.FindPath("RoadNet@Changchun", nodeIDs, false, param);
        /// </code>
        /// </example>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodeIDs">需要经过的网络结点 ID 数组，必设参数，ID必须大于0。</param>
        /// <param name="hasLeastEdgeCount">是否按弧段数最少的模式查询。可选参数，默认为false， 代表不按照弧段最少进行查询。 </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>最佳路径分析结果集合，目前实际上其中只包含一个元素。</returns>
        public List<Path> FindPath(string networkDatasetName, int[] nodeIDs, bool hasLeastEdgeCount, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindPath(networkDatasetName, nodeIDs, hasLeastEdgeCount, parameter);
        }

        /// <summary>
        /// 使用异步方式进行最佳路径分析，根据网络结点的 ID 进行分析。此方法不会阻止调用线程。
        /// </summary>
        /// <remarks>
        /// <para>最佳路径分析解决的问题是，在网络数据集中，给定 N 个点（N 大于等于2），找出按照给定点的次序依次经过这 N 个点的阻抗最小的路径。 “阻抗最小”有多种理解，如时间最短、费用最低、风景最好、路况最佳、过桥最少、收费站最少、经过乡村最多等。</para>
        /// <para>调用该方法实现路径查找，查找的结果就是依次经过 N 个点（N 大于等于2）的最佳路径。</para>
        /// <para>例子：如果要顺序访问1、2、3、4四个结点并查找经过这四个结点的最佳路径， 则需要分别找到1、2结点间的最佳路径 R1_2，2、3间的最佳路径 R2_3和3、4结点间的最佳路径 R3_4，结果顺序访问1、2、3、4四个结点的最佳路径为 R= R1_2 + R2_3 + R3_4。</para>
        /// </remarks>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodeIDs">需要经过的网络结点 ID 数组，必设参数，ID必须大于0。</param>
        /// <param name="hasLeastEdgeCount">是否按弧段数最少的模式查询。可选参数，默认为false， 代表不按照弧段最少进行查询。 </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <param name="completed">完成后时执行的方法。</param>
        /// <param name="failed">失败时执行的方法。</param>
        public void FindPath(string networkDatasetName, int[] nodeIDs, bool hasLeastEdgeCount, TransportationAnalystParameter parameter,
            EventHandler<FindPathEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            EventHandler<FindPathEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _netWorkAnalystProvider.FindPath(networkDatasetName, nodeIDs, hasLeastEdgeCount, parameter, callback, failed);
        }

        /// <summary>
        /// 最佳路径分析,根据坐标点进行分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="points">需要经过的坐标点数组，必设参数。</param>
        /// <param name="hasLeastEdgeCount">是否按弧段数最少的模式查询。可选参数，默认为false， 代表不按照弧段最少进行查询。 </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>最佳路径分析结果集合，目前实际上其中只包含一个元素。</returns>
        /// <remarks>
        /// <para>最佳路径分析解决的问题是，在网络数据集中，给定 N 个点（N 大于等于2），找出按照给定点的次序依次经过这 N 个点的阻抗最小的路径。 “阻抗最小”有多种理解，如时间最短、费用最低、风景最好、路况最佳、过桥最少、收费站最少、经过乡村最多等。</para>
        /// <para>调用该方法实现路径查找，查找的结果就是依次经过 N 个点（N 大于等于2）的最佳路径。</para>
        /// <para>例子：如果要顺序访问1、2、3、4四个结点并查找经过这四个结点的最佳路径， 则需要分别找到1、2结点间的最佳路径 R1_2，2、3间的最佳路径 R2_3和3、4结点间的最佳路径 R3_4，结果顺序访问1、2、3、4四个结点的最佳路径为 R= R1_2 + R2_3 + R3_4。</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// 以下为根据坐标点数组进行最佳路径分析的示范程序。
        /// 
        /// Point2D[] points = new Point2D[2];
        /// points[0] = new Point2D(5750.89, -3793.98);
        /// points[1] = new Point2D(5700.79, -3878.43);
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;Path&gt; actualResult = netAnalyst.FindPath("RoadNet@Changchun", points, false, param);
        /// </code>
        /// </example>
        public List<Path> FindPath(string networkDatasetName, Point2D[] points, bool hasLeastEdgeCount, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindPath(networkDatasetName, points, hasLeastEdgeCount, parameter);
        }

        /// <summary>
        /// 使用异步方式进行最佳路径分析,根据坐标点进行分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="points">需要经过的坐标点数组，必设参数。</param>
        /// <param name="hasLeastEdgeCount">是否按弧段数最少的模式查询。可选参数，默认为false， 代表不按照弧段最少进行查询。 </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <param name="completed">完成后时执行的方法。</param>
        /// <param name="failed">失败时执行的方法。</param>
        /// <returns>最佳路径分析结果集合，目前实际上其中只包含一个元素。</returns>
        /// <remarks>
        /// <para>最佳路径分析解决的问题是，在网络数据集中，给定 N 个点（N 大于等于2），找出按照给定点的次序依次经过这 N 个点的阻抗最小的路径。 “阻抗最小”有多种理解，如时间最短、费用最低、风景最好、路况最佳、过桥最少、收费站最少、经过乡村最多等。</para>
        /// <para>调用该方法实现路径查找，查找的结果就是依次经过 N 个点（N 大于等于2）的最佳路径。</para>
        /// <para>例子：如果要顺序访问1、2、3、4四个结点并查找经过这四个结点的最佳路径， 则需要分别找到1、2结点间的最佳路径 R1_2，2、3间的最佳路径 R2_3和3、4结点间的最佳路径 R3_4，结果顺序访问1、2、3、4四个结点的最佳路径为 R= R1_2 + R2_3 + R3_4。</para>
        /// </remarks>
        public void FindPath(string networkDatasetName, Point2D[] points, bool hasLeastEdgeCount, TransportationAnalystParameter parameter,
             EventHandler<FindPathEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(networkDatasetName))
            {
                if (failed != null)
                {
                    failed(this, new FailedEventArgs(new ArgumentNullException("networkDatasetName", Resources.ArgumentIsNotNull)));
                }
                return;
            }
            EventHandler<FindPathEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _netWorkAnalystProvider.FindPath(networkDatasetName, points, hasLeastEdgeCount, parameter, callback, failed);
        }

        /// <summary>
        /// 最近设施查找分析，事件点以点坐标表示。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="facilityPoints">表示设施点的坐标点数组，必设参数。</param>
        /// <param name="eventPoint">表示事件点的坐标点，必设参数。</param>
        /// <param name="expectFacilityCount">要查找的设施点数量，可选参数，默认值为1。</param>
        /// <param name="fromEvent">是否从事件点到设施点进行查找，可选参数，默认为false。</param>
        /// <param name="maxWeight">查找半径，必设参数。单位同 parameter（交通网络分析通用参数）中设置的权值字段一致，如果要查找整个网络，该值设为 0。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>最近设施分析结果路径集合。</returns>
        /// <remarks>
        /// <para>最近设施分析是指在网络上给定一个事件点和一组设施点，为事件点查找以最小耗费能到达的一个或几个设施点，结果为从事件点到设施点(或从设施点到事件点)的最佳路径。</para>
        /// <list type="bullet">
        /// <item><description>设施点：最近设施分析的基本要素，也就是学校、超市、加油站等服务设施。</description></item>
        /// <item><description>事件点：为最近设施分析的基本要素，就是需要服务设施的事件位置。</description></item>
        /// </list>
        /// <para>使用场景一：例如事件发生点是一起交通事故，要求查找在10分钟内能到达的最近医院，超过10分钟能到达的都不予考虑。此例中，事故发生地即是一个事件点，周边的医院则是设施点。最近设施查找实际上也是一种路径分析，
        /// 因此，同样可以应用障碍边和障碍点的设置，在行驶路途上这些障碍将不能被穿越，在路径分析中会予以考虑。</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// Point2D eventPoint = new Point2D(5701.74, -3881.73);
        /// Point2D[] facilityPoints = new Point2D[3];
        /// facilityPoints[0] = new Point2D(5753.97, -3794.36);
        /// facilityPoints[1] = new Point2D(5643.59, -3830.26);
        /// facilityPoints[2] = new Point2D(5817.94, -3957.25);
        /// string networkDatasetName = "RoadNet@Changchun";
        /// int expectFacilityCount = 3;
        /// bool fromEvent = true;
        /// double maxWeight = 1000;
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;ClosestFacilityPath&lt;Point2D&gt;&gt; actualResult = netAnalyst.FindClosestFacility(networkDatasetName, facilityPoints, eventPoint, expectFacilityCount, fromEvent, maxWeight, param);
        /// </code>
        /// </example>
        public List<ClosestFacilityPath<Point2D>> FindClosestFacility(string networkDatasetName, Point2D[] facilityPoints, Point2D eventPoint, int expectFacilityCount,
            bool fromEvent, double maxWeight, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindClosestFacility(networkDatasetName, facilityPoints, eventPoint, expectFacilityCount,
            fromEvent, maxWeight, parameter);
        }

        /// <summary>
        /// 最近设施查找分析，事件点以网络结点 ID 表示。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="facilityIDs">表示设施点的结点 ID 数组，必设参数，ID必须大于0。</param>
        /// <param name="eventID">表示事件点的结点 ID，必设参数，ID必须大于0。</param>
        /// <param name="expectFacilityCount">要查找的设施点数量，可选参数，默认值为1。</param>
        /// <param name="fromEvent">是否从事件点到设施点进行查找，可选参数，默认为false。</param>
        /// <param name="maxWeight">查找半径，必设参数。单位同 parameter（交通网络分析通用参数）中设置的权值字段一致，如果要查找整个网络，该值设为 0。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>最近设施分析结果路径集合。</returns>
        /// <remarks>
        /// <para>最近设施分析是指在网络上给定一个事件点和一组设施点，为事件点查找以最小耗费能到达的一个或几个设施点，结果为从事件点到设施点(或从设施点到事件点)的最佳路径。</para>
        /// <list type="bullet">
        /// <item><description>设施点：最近设施分析的基本要素，也就是学校、超市、加油站等服务设施。</description></item>
        /// <item><description>事件点：为最近设施分析的基本要素，就是需要服务设施的事件位置。</description></item>
        /// </list>
        /// <para>使用场景一：例如事件发生点是一起交通事故，要求查找在10分钟内能到达的最近医院，超过10分钟能到达的都不予考虑。此例中，事故发生地即是一个事件点，周边的医院则是设施点。最近设施查找实际上也是一种路径分析，
        /// 因此，同样可以应用障碍边和障碍点的设置，在行驶路途上这些障碍将不能被穿越，在路径分析中会予以考虑。</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// int[] facilityIDs = new int[3] { 3309, 3429, 3556 };
        /// string networkDatasetName = "RoadNet@Changchun";
        /// int eventID = 3434;
        /// int expectFacilityCount = 3;
        /// bool fromEvent = true;
        /// double maxWeight = 1000;
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;ClosestFacilityPath&lt;int&gt;&gt; actualResult = netAnalyst.FindClosestFacility(networkDatasetName, facilityIDs, eventID, expectFacilityCount, fromEvent, maxWeight, param);
        /// </code>
        /// </example>
        public List<ClosestFacilityPath<int>> FindClosestFacility(string networkDatasetName, int[] facilityIDs, int eventID, int expectFacilityCount,
            bool fromEvent, double maxWeight, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindClosestFacility(networkDatasetName, facilityIDs, eventID, expectFacilityCount, fromEvent, maxWeight, parameter);
        }

        /// <summary>
        /// 旅行商分析,根据网络结点的 ID 进行分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="nodeIDsToVisit">需要途经的网络结点的 ID 数组，数组中的第一个点为旅行商的出发点，必设参数。</param>
        /// <param name="endNodeAssigned">是否指定终止点。可选参数，默认为False，如果设置为true ，则表示指定终止点，则旅行商必须最后一个访问终止点，即途经的最后一个点。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>旅行商分析结果集合，目前实际上其中只包含一个元素。</returns>
        /// <remarks>
        /// <para>旅行商分析是查找经过指定一系列点的路径，旅行商分析是无序的路径分析。旅行商可以自己决定访问结点的顺序，目标是旅行路线阻抗总和最小（或接近最小）。</para>
        /// <para>在旅行商分析中，如果指定了终止点，则旅行商必须最后一个访问终止点，而其他经过点的访问次序由旅行商自己决定。</para>
        /// <para>在旅行商分析中，需要途经的点是在 nodeIDsToVisit 参数中指定的，其中点序列中的第一个点为旅行商的出发点。</para>
        /// <para>最佳路径分析与旅行商分析的异同：</para>
        /// <list type="bullet">
        /// <item><description>相同点：都是在网络中寻找遍历所有经过点的花费最少的路径。</description></item>
        /// <item><description>不同点：在遍历所有经过点的过程，对访问经过点的顺序处理有所不同。 最佳路径分析必须按照指定的顺序访问所有经过点，而旅行商分析需要确定最优次序来访问所有点，
        /// 而并不一定按照指定的经过点的次序。有关最佳路径分析的详细内容，请参见最佳路径分析<see cref="FindPath(string,int[],bool,SuperMap.Connector.Utility.TransportationAnalystParameter)"/>方法。</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// string networkDatasetName = "RoadNet@Changchun";
        /// int[] nodeIDsToVisit = new int[4] { 3310, 3434, 3745, 3560 };
        /// bool endNodeAssigned = false;
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;TSPPath&gt; actualResult = netAnalyst.FindTSPPath(networkDatasetName, nodeIDsToVisit, endNodeAssigned, param);
        /// </code>
        /// </example>
        public List<TSPPath> FindTSPPath(string networkDatasetName, int[] nodeIDsToVisit, bool endNodeAssigned, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindTSPPath(networkDatasetName, nodeIDsToVisit, endNodeAssigned, parameter);
        }
        /// <summary>
        /// 旅行商分析,根据坐标点进行分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="pointsToVisit">需要途经的坐标点数组，数组中的第一个点为旅行商的出发点，必设参数。</param>
        /// <param name="endNodeAssigned">是否指定终止点。可选参数，默认为False，如果设置为true ，则表示指定终止点，则旅行商必须最后一个访问终止点，即途经的最后一个点。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>旅行商分析结果集合，目前实际上其中只包含一个元素。</returns>
        /// <remarks>
        /// <para>旅行商分析是查找经过指定一系列点的路径，旅行商分析是无序的路径分析。旅行商可以自己决定访问结点的顺序，目标是旅行路线阻抗总和最小（或接近最小）。</para>
        /// <para>在旅行商分析中，如果指定了终止点，则旅行商必须最后一个访问终止点，而其他经过点的访问次序由旅行商自己决定。</para>
        /// <para>在旅行商分析中，需要途经的点是在 pointsToVisit 参数中指定的，其中点序列中的第一个点为旅行商的出发点。</para>
        /// <para>最佳路径分析与旅行商分析的异同：</para>
        /// <list type="bullet">
        /// <item>
        ///    <description>相同点：都是在网络中寻找遍历所有经过点的花费最少的路径。</description>
        /// </item>
        /// <item><description>不同点：在遍历所有经过点的过程，对访问经过点的顺序处理有所不同。 最佳路径分析必须按照指定的顺序访问所有经过点，而旅行商分析需要确定最优次序来访问所有点，
        /// 而并不一定按照指定的经过点的次序。有关最佳路径分析的详细内容，请参见<see cref="FindPath(string, SuperMap.Connector.Utility.Point2D[],bool,SuperMap.Connector.Utility.TransportationAnalystParameter)"/>方法。</description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// string networkDatasetName = "RoadNet@Changchun";
        /// Point2D[] pointsToVisit = new Point2D[4];
        /// pointsToVisit[0] = new Point2D(5744.88, -3768.94);
        /// pointsToVisit[1] = new Point2D(5700.86, -3885.46);
        /// pointsToVisit[2] = new Point2D(5840.1, -4088.35);
        /// pointsToVisit[3] = new Point2D(5874.72, -3918.83);
        /// bool endNodeAssigned = false;
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;TSPPath&gt; actualResult = netAnalyst.FindTSPPath(networkDatasetName, pointsToVisit, endNodeAssigned, param);
        /// </code>
        /// </example>
        public List<TSPPath> FindTSPPath(string networkDatasetName, Point2D[] pointsToVisit, bool endNodeAssigned, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindTSPPath(networkDatasetName, pointsToVisit, endNodeAssigned, parameter);
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
        /// <remarks>
        /// <para>多旅行商分析也称为物流配送，是指在网络数据集中，给定 M 个配送中心点和 N 个配送目的地（M，N 为大于零的整数），查找经济有效的配送路径，并给出相应的行走路线。</para>
        /// <para>物流配送功能就是解决如何合理分配配送次序和送货路线，使配送总花费达到最小或每个配送中心的花费达到最小。</para>
        /// <para>多旅行商分析的结果将给出每个配送中心所负责的配送目的地，和每个配送中心向其负责的配送目的地配送货物时，经过各个配送目的地的顺序和相应的行走路线。 从而使各个配送中心
        /// 的配送花费相对平均，或者使所有的配送中心的总花费最小。</para>
        /// <para>例子：现在有50个报刊零售地（配送目的地），和4个报刊供应地（配送中心）， 现寻求这4个供应地向报刊零售地发送报纸的最优路线， 属物流配送问题。</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// string networkDatasetName = "RoadNet@Changchun";
        /// int[] nodeIDs = new int[3] { 4345, 4443, 4820 };
        /// int[] centerIDs = new int[3] { 3315, 3556, 3650 };
        /// bool hasLeastTotalCost = false;
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;MTSPPath&lt;int&gt;&gt; actualResult = netAnalyst.FindMTSPPath(networkDatasetName, nodeIDs, centerIDs, hasLeastTotalCost, param);
        /// </code>
        /// </example>
        public List<MTSPPath<int>> FindMTSPPath(string networkDatasetName, int[] nodeIDs, int[] centerIDs, bool hasLeastTotalCost, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindMTSPPath(networkDatasetName, nodeIDs, centerIDs, hasLeastTotalCost, parameter);
        }

        /// <summary>
        /// 多旅行商（物流配送）分析，配送中心以点坐标串表示。
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
        /// <remarks>
        /// <para>多旅行商分析也称为物流配送，是指在网络数据集中，给定 M 个配送中心点和 N 个配送目的地（M，N 为大于零的整数），查找经济有效的配送路径，并给出相应的行走路线。</para>
        /// <para>物流配送功能就是解决如何合理分配配送次序和送货路线，使配送总花费达到最小或每个配送中心的花费达到最小。</para>
        /// <para>多旅行商分析的结果将给出每个配送中心所负责的配送目的地，和每个配送中心向其负责的配送目的地配送货物时，经过各个配送目的地的顺序和相应的行走路线。 从而使各个配送中心
        /// 的配送花费相对平均，或者使所有的配送中心的总花费最小。</para>
        /// <para>例子：现在有50个报刊零售地（配送目的地），和4个报刊供应地（配送中心）， 现寻求这4个供应地向报刊零售地发送报纸的最优路线， 属物流配送问题。下面的示意图展示了这个例子的情况以及进行多旅行商分析后的简图。</para>
        /// <para> 如下图所示，左图中粉色大圆点代表4个报刊供应地（配送中心），而其他小圆点代表报刊零售地（配送目的地），共有50个；每一类颜色代表一个配送中心的配送方案，包括它所负责的配送目的地、配送次序以及配送线路。</para>
        /// <para>右图为左图中矩形框圈出的第2号配送中心的配送方案：蓝色的标有数字的小圆点是2号配送中心所负责的配送目的地（共有18个），2号配送中心将按照配送目的地上标有数字的顺序依次发送报纸，即先送1号报刊零售地，再送2号报刊零售地，依次类推，并且沿着分析得出的蓝色线路完成配送，回到配送中心。</para>
        /// <para>
        /// <img src="../../../../CHM/interfacesimges/NetworkAnalyst/FindMTSPPaths/FindMTSP1.png"></img>        
        /// <img src="../../../../CHM/interfacesimges/NetworkAnalyst/FindMTSPPaths/FindMTSP2.png"></img>
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// string networkDatasetName = "RoadNet@Changchun";
        /// Point2D[] centerPoints = new Point2D[3];
        /// centerPoints[0] = new Point2D(5864.76, -3770.43);
        /// centerPoints[1] = new Point2D(5814.46, -3954.47);
        /// centerPoints[2] = new Point2D(5585.9, -4012.3);
        /// Point2D[] points = new Point2D[3];
        /// points[0] = new Point2D(5655.9, -4508.85);
        /// points[1] = new Point2D(5548, -4626.36);
        /// points[2] = new Point2D(5700.8, -4873.9);
        /// bool hasLeastTotalCost = false;
        /// TransportationAnalystParameter param = new TransportationAnalystParameter();
        /// param.ResultSetting = new TransportationAnalystResultSetting();
        /// param.ResultSetting.ReturnEdgeFeatures = true;
        /// param.ResultSetting.ReturnEdgeGeometry = true;
        /// param.ResultSetting.ReturnEdgeIDs = true;
        /// param.ResultSetting.ReturnNodeFeatures = true;
        /// param.ResultSetting.ReturnNodeGeometry = true;
        /// param.ResultSetting.ReturnNodeIDs = true;
        /// param.ResultSetting.ReturnPathGuides = true;
        /// param.ResultSetting.ReturnRoutes = true;
        /// NetworkAnalyst netAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        /// List&lt;MTSPPath&lt;Point2D&gt;&gt; actualResult = netAnalyst.FindMTSPPath(networkDatasetName, points, centerPoints, hasLeastTotalCost, param);
        /// </code>
        /// </example>
        public List<MTSPPath<Point2D>> FindMTSPPath(string networkDatasetName, Point2D[] points, Point2D[] centerPoints, bool hasLeastTotalCost, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindMTSPPath(networkDatasetName, points, centerPoints, hasLeastTotalCost, parameter);
        }

        /// <summary>
        /// 获取交通网络分析服务中使用的所有网络数据集的名称。
        /// </summary>
        /// <returns>网络数据集名称列表。</returns>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 下面的代码示例演示如何获取网络数据集名称列表。
        /// <code>
        ///using System;
        ///using System.Collections.Generic;
        ///using System.Text;
        ///using SuperMap.Connector;
        ///
        ///class Program
        ///{
        ///     static void Main(string[] args)
        ///     {
        ///         // 使用 iServer REST 中一个网络分析服务地址实例初始化一个NetworkAnalyst对象
        ///         NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        ///    
        ///         // 使用GetNetworkDatasetNames获取所有的网络数据集名称列表。
        ///         List&lt;string&gt; networkDatasetNames = networkAnalyst.GetNetworkDatasetNames();
        ///
        ///         if (networkAnalyst != null)
        ///         {
        ///             for (int i = 0; i &lt; networkDatasetNames.Count; i++)
        ///             {
        ///                 // 打印所有的网络数据集名。
        ///                 Console.WriteLine(string.Format("网络数据集名：{0}", networkDatasetNames[i]));
        ///             }
        ///         }
        ///     }
        ///}
        /// </code>
        /// </example>
        public List<string> GetNetworkDatasetNames()
        {
            return _netWorkAnalystProvider.GetNetworkDatasetNames();
        }

        /// <summary>
        /// 获取指定网络数据集的转向权值字段名称列表。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>指定网路数据集对应的转向权值字段列表。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public List<string> GetTurnWeightNames(string networkDatasetName)
        {
            return _netWorkAnalystProvider.GetTurnWeightNames(networkDatasetName);
        }

        /// <summary>
        /// 获取指定网络数据集的权值字段名称列表。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>指定网络数据集对应的权值字段列表。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public List<string> GetWeightNames(string networkDatasetName)
        {
            return _netWorkAnalystProvider.GetWeightNames(networkDatasetName);
        }

        /// <summary>
        /// 获取指定网络数据集投影信息。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/>的返回列表的元素之一。</param>
        /// <returns>指定网络数据集对应的投影信息。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public PrjCoordSys GetNetworkDatasetPrj(string networkDatasetName)
        {
            return _netWorkAnalystProvider.GetNetworkDatasetPrj(networkDatasetName);
        }

        /// <summary>
        /// 重新加载网络模型。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。<see cref="GetNetworkDatasetNames()"/> 的返回列表的元素之一。</param>
        /// <returns>重新加载是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool ReloadModel(string networkDatasetName)
        {
            return _netWorkAnalystProvider.ReloadModel(networkDatasetName);
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
        /// <returns>更新是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool UpdateEdgeWeight(string networkDatasetName, int edgeID, int fromNodeID, int toNodeID, string weightField, double weight)
        {
            return _netWorkAnalystProvider.UpdateEdgeWeight(networkDatasetName, edgeID, fromNodeID, toNodeID, weightField, weight);
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
        /// <returns>更新是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool UpdateTurnNodeWeight(string networkDatasetName, int nodeID, int fromEdgeID, int toEdgeID, string turnWeightField, double weight)
        {
            return _netWorkAnalystProvider.UpdateTurnNodeWeight(networkDatasetName, nodeID, fromEdgeID, toEdgeID, turnWeightField, weight);
        }

        /// <summary>
        /// 根据指定的结点ID集合和交通网络分析参数，得出一个耗费矩阵。该矩阵是一个二维 double 数组，用来存储任意两点间的资源消耗。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设字段。</param>
        /// <param name="nodeIDs">计算耗费矩阵的结点 ID 的数组。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>存储任意两点间耗费的二维矩阵。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 下面的代码示例演示如何根据网络节点ID计算耗费矩阵。
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
        ///         //初始化
        ///         NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        ///         int[] nodeIDs = new int[]{2, 6, 9 };
        ///
        ///         //计算耗费矩阵
        ///         double[][] weightMatrix = networkAnalyst.ComputeWeightMatrix("RoadNet@Changchun", nodeIDs);
        ///
        ///         //显示结果。
        ///         if (weightMatrix != null)
        ///         {
        ///             for (int i = 0; i &lt; weightMatrix.Length; i++)
        ///             {
        ///                 if (weightMatrix[i] != null)
        ///                 {
        ///                     for (int j = 0; j &lt; weightMatrix[i].Length; j++)
        ///                     {
        ///                         Console.Write(string.Format("{0}", weightMatrix[i][j]));
        ///                     }
        ///                     Console.WriteLine();
        ///                 }
        ///             }
        ///         }
        ///     }
        /// }
        /// //计算结果如下：
        /// // 0    454     434
        /// //454   0       62 
        /// //434   62      0
        /// </code>
        /// </example>
        public double[][] ComputeWeightMatrix(string networkDatasetName, int[] nodeIDs, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.ComputeWeightMatrix<int>(networkDatasetName, new List<int>(nodeIDs), parameter);
        }

        /// <summary>
        /// 根据指定的点集合和交通网络分析参数，得出一个耗费矩阵。该矩阵是一个二维 double 数组，用来存储任意两点间的资源消耗。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设字段。</param>
        /// <param name="points">需要计算耗费矩阵的点集合。</param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>存储任意两点间耗费的二维矩阵。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 下面的代码示例演示如何根据坐标点计算耗费矩阵。
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
        ///         //初始化
        ///         NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        ///         Point2D[] points = new Point2D[2];
        ///         points[0] = new Point2D() { X = 32.754, Y = 23.205 };
        ///         points[1] = new Point2D() { X = 415.55, Y = 87.66 };
        ///
        ///         //计算耗费矩阵
        ///         double[][] weightMatrix = networkAnalyst.ComputeWeightMatrix("RoadNet@Changchun", points);
        ///
        ///         //显示结果。
        ///         if (weightMatrix != null)
        ///         {
        ///             for (int i = 0; i &lt; weightMatrix.Length; i++)
        ///             {
        ///                 if (weightMatrix[i] != null)
        ///                 {
        ///                     for (int j = 0; j &lt; weightMatrix[i].Length; j++)
        ///                     {
        ///                         Console.Write(string.Format("{0}", weightMatrix[i][j]));
        ///                     }
        ///                     Console.WriteLine();
        ///                 }
        ///             }
        ///         }
        ///     }
        /// }
        /// //计算结果如下：
        /// // 0               446.2672385857
        /// // 446.2672385857  0
        /// </code>
        /// </example>
        public double[][] ComputeWeightMatrix(string networkDatasetName, Point2D[] points, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.ComputeWeightMatrix<Point2D>(networkDatasetName, new List<Point2D>(points), parameter);
        }

        /// <summary>
        /// 根据节点ID数组，得出一个耗费矩阵。该矩阵是一个二维 double 数组，用来存储任意两点间的资源消耗。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设字段。</param>
        /// <param name="nodeIDs">计算耗费矩阵的结点 ID 的集合。</param>
        /// <returns>存储任意两点间耗费的二维矩阵。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// <see cref="ComputeWeightMatrix(string, int[], SuperMap.Connector.Utility.TransportationAnalystParameter)"/>
        /// </example>
        public double[][] ComputeWeightMatrix(string networkDatasetName, int[] nodeIDs)
        {
            return _netWorkAnalystProvider.ComputeWeightMatrix<int>(networkDatasetName, new List<int>(nodeIDs), null);
        }

        /// <summary>
        /// 根据坐标点数组，得出一个耗费矩阵。该矩阵是一个二维 double 数组，用来存储任意两点间的资源消耗。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设字段。</param>
        /// <param name="points">需要计算耗费矩阵的点集合。</param>
        /// <returns>存储任意两点间耗费的二维矩阵。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 请参见:
        /// <see cref="ComputeWeightMatrix(string, SuperMap.Connector.Utility.Point2D[], SuperMap.Connector.Utility.TransportationAnalystParameter)"/>
        /// </example>
        public double[][] ComputeWeightMatrix(string networkDatasetName, Point2D[] points)
        {
            return _netWorkAnalystProvider.ComputeWeightMatrix<Point2D>(networkDatasetName, new List<Point2D>(points), null);
        }

        /// <summary>
        /// 选址分区分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设字段。</param>
        /// <param name="parameter">选址分析参数。</param>
        /// <returns>选址分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName、parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <remarks>
        /// <para>选址分区分析是为了确定一个或多个待建设施的最佳或最优位置， 使得设施可以用一种最经济有效的方式为需求方提供服务或者商品。 选址分区不仅仅是一个选址过程，还要将需求点的需求分配到相应的新建设施的服务区中，因此称之为选址与分区。</para>
        /// <para>在选址分区分析过程中，资源供给中心以及分析模式的设定是在 LocationAnalystParameter 类型的参数 parameter 中实现的，具体细节参见 <see cref="SuperMap.Connector.Utility.LocationAnalystParameter"/> 类。</para>
        /// <para>在分析过程中使用的需求点都为网络结点，即除了各种类型的中心点所对应的网络结点， 所有网络结点都作为资源需求点参与选址分区分析，如果要排除某部分结点，可以将其设置为障碍点。</para>  
        /// <para>以下例子说明了选址分区的应用：某个区域还没有邮局，现要在这个区域内建立邮局，有15个待选地点（如左图所示，蓝色方框代表15个候选地点），将在这些待选点中选择7个最佳地点建立邮局。最佳选址要满足，居民点中的居民步行去邮局办理业务
        /// 的步行时间要在30分钟以内，同时每个邮局能够服务的居民总人数有限，在同时满足这两个条件的基础上，选址分区分析会给出以个最佳的选址位置，并且圈出每个邮局的服务区域（如右图所示，红色点表示最后选出的7个建立邮局的最佳位置）。备注：下面
        /// 两幅中的网络数据集的所有网络结点被看做是该区域的居民点全部参与选址分区分析，居民点中的居民数目即为该居民点所需服务的数量。</para>
        /// <para>
        /// <img src="../../../../CHM/interfacesimges/NetworkAnalyst/findlocation/findlocation1.png"></img>
        /// <img src="../../../../CHM/interfacesimges/NetworkAnalyst/findlocation/findlocation2.png"></img>
        /// </para>
        /// </remarks>
        /// <example>
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
        ///        //初始化。
        ///        NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        ///        //设置选址区分析参数。
        ///        LocationAnalystParameter parameter = new LocationAnalystParameter()
        ///         {
        ///             NodeDemandField = "Demand",
        ///             WeightName = "length",
        ///             TurnWeightField = "TurnCost",
        ///             ReturnEdgeFeatures = true,
        ///             ReturnEdgeGeometry = true,
        ///             ReturnNodeFeatures = true,
        ///             IsFromCenter = true,
        ///             SupplyCenters = new List&lt;SupplyCenter&gt;()
        ///             {
        ///                 new SupplyCenter() { NodeID = 11, MaxWeight = 100, ResourceValue = 500, Type = SupplyCenterType.FIXEDCENTER },
        ///                 new SupplyCenter() { NodeID = 12, MaxWeight = 100, ResourceValue = 500, Type = SupplyCenterType.OPTIONALCENTER }
        ///             },
        ///             ExpectedSupplyCenterCount = 2
        ///         };
        ///        //执行选址区分析。
        ///        LocationAnalystResult result = networkAnalyst.FindLocation("RoadNet@Changchun", parameter);
        ///        //需求结果个数为：13
        ///        //资源供给中心点结果个数为：2
        ///    }
        ///}
        /// </code>
        /// </example>
        public LocationAnalystResult FindLocation(string networkDatasetName, LocationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindLocation(networkDatasetName, parameter);
        }

        /// <summary>
        /// 根据网络节点ID进行服务区分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="centerIDs">服务中心结点 ID 数组，必设参数。</param>
        /// <param name="weights">服务半径集合，必设参数。该集合的大小跟服务中心个数一致， 标识了在对每个服务中心进行服务区分析时，所用的范围值。例如设置 weights[0] 为 300.0，parameter.WeightFieldName 为 Length ，可表明在第一个服务中心的结果服务区内， 任意点出发到该服务中心的耗费都不应超过300米。</param>
        /// <param name="isFromCenter">
        /// <para>是否从中心点开始分析，false 表示不从中心点开始分析。</para>
        /// <para>从中心点开始分析和不从中心点开始分析，体现了服务中心和需要该服务的需求地的关系模式。 从中心点开始分析，是一个服务中心向服务需求地提供服务；而不从中心点开始分析， 是一个服务需求地主动到服务中心获得服务。</para>
        /// <para>
        /// 例如：某个奶站向各个居民点送牛奶，如果要对这个奶站进行服务区分析，看这个奶站在允许的条件下所能服务的范围，那么在实际分析过程中就应当使用从中心点开始分析的模式；另一个例子，如果想分析一个区域的某个学校在允许的条件下所能服务的区域时，在现实中，都是学生主动来到学校学习，接受学校提供的服务，那么在实际分析过程中就应当使用不从中心点开始分析的模式。
        /// </para>
        /// </param>
        /// <param name="isCenterMutuallyExclusive">是否对分析结果服务区进行互斥处理，false 表示不进行互斥处理， 若设置为 true， 表示如果分析出的服务区有重叠的部分，则进行互斥处理。如图所示左图未进行互斥处理，右图进行了互斥处理。
        /// <para>
        /// <img src="../../../../CHM/interfacesimges/NetworkAnalyst/FindServiceArea/isCenterExclusive.png"></img>
        /// </para>
        /// </param>
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>服务区分析结果。为一个数组，数组的大小跟服务中心的个数一致，数组中每一个元素对应了每一个服务中心的服务区信息。 </returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName、centerIDs 为空时抛出异常。</exception>
        /// <exception cref="ArgumentException">当参数 centerIDs 的长度不等于 weights 的长度时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 下面代码的代码示例演示了执行服务区分析。
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
        ///         //初始化
        ///         NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://localhost:8090/iserver/services/transportationanalyst-sample/rest");
        ///         int[] centerIDs = new int[] { 2, 4, 6 };
        ///         double[] weights = new double[] { 500, 1000, 500 };
        ///        
        ///         //执行服务区分析操作，
        ///         List&lt;ServiceAreaResult&gt;result = networkAnalyst.FindServiceArea("RoadNet@Changchun", centerIDs, weights, true, false, null);
        ///         
        ///         //
        ///         //服务区分析区域：3
        ///         //
        ///     }
        /// }
        /// </code>
        /// </example>
        public List<ServiceAreaResult> FindServiceArea(string networkDatasetName, int[] centerIDs, double[] weights, bool isFromCenter, bool isCenterMutuallyExclusive, TransportationAnalystParameter parameter)
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
            if (centerIDs == null || centerIDs.Length == 0)
            {
                throw new ArgumentNullException("centers", Resources.ArgumentIsNotNull);
            }
            if (weights == null || weights.Length == 0)
            {
                throw new ArgumentNullException("weights", Resources.ArgumentIsNotNull);
            }
            if (weights.Length != centerIDs.Length)
            {
                throw new ArgumentException(string.Format(Resources.LengthEqualError, "centerIDs", "weights"));
            }
            return _netWorkAnalystProvider.FindServiceArea<int>(networkDatasetName, new List<int>(centerIDs), new List<double>(weights), isFromCenter, isCenterMutuallyExclusive, parameter);
        }

        /// <summary>
        /// 根据坐标点进行服务区分析。
        /// </summary>
        /// <param name="networkDatasetName">用于唯一标识一个网络数据集的字符串，必设参数。</param>
        /// <param name="centerPoints">服务中心坐标点数组，必设参数。</param>
        /// <param name="weights">服务半径集合，必设参数。该集合的大小跟服务中心个数一致， 标识了在对每个服务中心进行服务区分析时，所用的范围值。例如设置 weights[0] 为 300.0，parameter.WeightFieldName 为 Length ，可表明在第一个服务中心的结果服务区内， 任意点出发到该服务中心的耗费都不应超过300米。</param>
        /// <param name="isFromCenter">
        /// <para>是否从中心点开始分析，false 表示不从中心点开始分析。</para>
        /// <para>从中心点开始分析和不从中心点开始分析，体现了服务中心和需要该服务的需求地的关系模式。 从中心点开始分析，是一个服务中心向服务需求地提供服务；而不从中心点开始分析， 是一个服务需求地主动到服务中心获得服务。</para>
        /// <para>
        /// 例如：某个奶站向各个居民点送牛奶，如果要对这个奶站进行服务区分析，看这个奶站在允许的条件下所能服务的范围，那么在实际分析过程中就应当使用从中心点开始分析的模式；另一个例子，如果想分析一个区域的某个学校在允许的条件下所能服务的区域时，在现实中，都是学生主动来到学校学习，接受学校提供的服务，那么在实际分析过程中就应当使用不从中心点开始分析的模式。
        /// </para>
        /// </param>
        /// <param name="isCenterMutuallyExclusive">是否对分析结果服务区进行互斥处理，false 表示不进行互斥处理， 若设置为 true， 表示如果分析出的服务区有重叠的部分，则进行互斥处理。如图所示左图未进行互斥处理，右图进行了互斥处理。
        /// <para>
        /// <img src="../../../../CHM/interfacesimges/NetworkAnalyst/FindServiceArea/isCenterExclusive.png"></img>        
        /// </para>
        /// </param>      
        /// <param name="parameter">交通网络分析通用参数。可选参数，默认返回EdgeIDs、NodeIDs、Routes信息。</param>
        /// <returns>服务区分析结果。为一个数组，数组的大小跟服务中心的个数一致，数组中每一个元素对应了每一个服务中心的服务区信息。 </returns>
        /// <exception cref="ArgumentNullException">参数 networkDatasetName、centerPoints 为空时抛出异常。</exception>
        /// <exception cref="ArgumentException">当参数 centerPoints 的长度不等于 weights 的长度时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 请参见：
        /// <see cref="FindServiceArea(string, int[], double[], bool, bool, SuperMap.Connector.Utility.TransportationAnalystParameter)"/>
        /// </example>
        public List<ServiceAreaResult> FindServiceArea(string networkDatasetName, Point2D[] centerPoints, double[] weights, bool isFromCenter, bool isCenterMutuallyExclusive, TransportationAnalystParameter parameter)
        {
            return _netWorkAnalystProvider.FindServiceArea<Point2D>(networkDatasetName, new List<Point2D>(centerPoints), new List<double>(weights), isFromCenter, isCenterMutuallyExclusive, parameter);
        }
    }
}
