using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    /// <summary>
    /// Data 组件接口，用以访问 SuperMap iServer 数据服务组件中的REST服务，封装了与空间数据相关的一系列功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>只能对 SuperMap REST 接口类型服务的访问。</description></item>
    /// <item><description>实例化Data对象时需要使用明确的数据服务组件地址(例如：http://localhost:8090/iserver/services/data-world/rest") </description></item>
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
    ///         //根据服务组件地址初始化一个Data对象。
    ///         Data data = new Data("http://localhost:8090/iserver/services/data-world/rest");
    ///
    ///        //获取指定空间数据服务组件中所有的数据源信息。
    ///        List&lt;DatasourceInfo&gt; datasourceInfos = data.GetDatasourceInfos();
    ///     }
    /// }
    /// 
    /// //数据源名称：
    /// //World
    /// </code>
    /// </example>
    public class Data
    {
        #region 成员变量

        private string _serviceUrl;
        private DataProvider _dataProvider;

        #endregion

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">SuperMap iServer 空间数据服务组件的URL地址。</param>
        /// <exception cref="ArgumentNullException">参数 serviceUrl 为空时抛出异常。</exception>
        public Data(string serviceUrl)
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
            this._dataProvider = new DataProvider(this._serviceUrl);
        }

        /// <summary>
        /// SuperMap iServer 空间数据服务组件地址。
        /// </summary>
        public string ServiceUrl
        {
            get { return this._serviceUrl; }
        }

        /// <summary>
        /// 在指定数据集中增加一组同类型的要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="targetFeatures">待添加的要素列表，列表中的要素必须是同一种类型，必设参数。</param>
        /// <returns>编辑结果。</returns>
        public EditResult AddFeatures(string datasourceName, String datasetName, List<Feature> targetFeatures)
        {
            return _dataProvider.AddFeatures(datasourceName, datasetName, targetFeatures);
        }

        /// <summary>
        /// 在指定的数据集中删除一组要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="ids">待删除要素的 ID 数组，必设参数。</param>
        /// <returns>编辑结果。</returns>
        public EditResult DeleteFeatures(string datasourceName, string datasetName, int[] ids)
        {
            return _dataProvider.DeleteFeatures(datasourceName, datasetName, ids);
        }

        /// <summary>
        /// 在指定的数据集中，更新一组要素。
        /// 参数 targetFeatures 是新要素列表，其要素 ID 与数据集中待更新的要素 ID 相同，根据 ID 查找到待更新的要素， 然后将原要素更新到新的要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据源名称，必设参数。</param>
        /// <param name="targetFeatures">新要素列表。其 ID 与要更新的要素 ID 相同，必设参数。</param>
        /// <returns>编辑结果。</returns>
        public EditResult UpdateFeatures(string datasourceName, string datasetName, List<Feature> targetFeatures)
        {
            return _dataProvider.UpdateFeatures(datasourceName, datasetName, targetFeatures);
        }

        /// <summary>
        /// 通过 SQL 查询条件获取要素。
        /// </summary>
        /// <param name="datasetNames">
        /// <para>数据集名称数组(datasourceName:datasetName),必选参数。 </para>
        /// <para>数据集名称由数据源名和数据集名构成，例如 World 数据源下的 Ocean 数据集，这里的数据集名称就是“World:Ocean”。</para>
        /// </param>
        /// <param name="queryParam">查询参数。</param>
        /// <returns>要素集合。</returns>
        /// <exception cref="ArgumentNullException">参数 datasetNames 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// <code>
        /// using System;
        /// using System.Collections.Generic;
        /// using System.Text;
        /// using SuperMap.Connector;
        /// using SuperMap.Connector.Utility;
        ///
        /// namespace ConsoleApplication1
        /// {
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            Data data = new Data("http://localhost:8090/iserver/services/data-world/rest");
        ///           string[] datasetNames = { "World:Capitals", "World:Ocean" };
        ///            List&lt;Feature&gt; result = data.GetFeature(datasetNames, new QueryParameter());
        ///            Console.WriteLine("获得要素个数为：{0}", result.Count);    //获得结果集个数为：235
        ///        }
        ///    }
        /// }
        /// </code>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, QueryParameter queryParam)
        {
            return _dataProvider.GetFeature(datasetNames, queryParam);
        }

        /// <summary>
        /// 通过 SQL 查询条件获取要素。
        /// </summary>
        /// <param name="datasetNames">
        /// <para>数据集名称数组(datasourceName:datasetName),必选参数。 </para>
        /// <para>数据集名称由数据源名和数据集名构成，例如 World 数据源下的 Ocean 数据集，这里的数据集名称就是“World:Ocean”。</para>
        /// </param>
        /// <param name="maxFeatures">最多可返回的要素数量。</param>
        /// <param name="queryParam">查询参数。</param>
        /// <returns>要素集合。</returns>
        /// <exception cref="ArgumentNullException">参数 datasetNames 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 请参见：<see cref="GetFeature(string[], SuperMap.Connector.Utility.QueryParameter)"/>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, QueryParameter queryParam, int maxFeatures)
        {
            return _dataProvider.GetFeature(datasetNames, queryParam, maxFeatures);
        }

        /// <summary>
        /// 获取落在指定几何对象的缓冲区内的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="bufferDistance">缓冲区的半径，单位同当前数据集坐标单位（coordUnit）。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        /// <exception cref="ArgumentNullException">参数 datasetNames、geometry 为空时抛出异常。</exception>
        /// <exception cref="ArgumentException">参数 bufferDistance 小于等于0时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// <code>
        /// using System;
        /// using System.Collections.Generic;
        /// using System.Text;
        /// using SuperMap.Connector;
        /// using SuperMap.Connector.Utility;
        /// 
        /// namespace ConsoleApplication1
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             Data data = new Data("http://localhost:8090/iserver/services/data-world/rest");
        /// 
        ///             //查询的数据集数组
        ///             string[] datasetNames = { "World:Capitals", "World:Ocean" };
        /// 
        ///             //缓冲区域
        ///             Geometry geometry = new Geometry();
        ///             geometry.Parts = new int[1] { 5 };
        ///             geometry.Points = new Point2D[5];
        ///             geometry.Points[0] = new Point2D(-45, -90);
        ///             geometry.Points[1] = new Point2D(-45, 90);
        ///             geometry.Points[2] = new Point2D(45, 90);
        ///             geometry.Points[3] = new Point2D(45, -90);
        ///             geometry.Points[4] = new Point2D(-45, -90);
        /// 
        ///             //缓冲区的半径
        ///             double bufferDistance = 1;
        /// 
        ///             List&lt;Feature&gt; result = data.GetFeature(datasetNames, geometry, bufferDistance, null);
        /// 
        ///             Console.WriteLine("获得要素的个数为：{0}", result.Count);    //获得结果集个数为：119
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, double bufferDistance, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, geometry, bufferDistance, fields);
        }

        /// <summary>
        /// 获取落在指定空间对象的缓冲区内，并满足一定属性过滤条件的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="bufferDistance">缓冲区的半径，单位同当前数据集坐标单位（coordUnit）。</param>
        /// <param name="attributeFilter">属性查询过滤条件。如 fieldValue &lt; 100，name like '%酒店%'。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>        
        /// <exception cref="ArgumentNullException">参数 datasetNames、geometry 为空时抛出异常。</exception>
        /// <exception cref="ArgumentException">参数 bufferDistance 小于等于0时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 请参见：<see cref="GetFeature(string[], SuperMap.Connector.Utility.Geometry, double, string[])"/>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, double bufferDistance, string attributeFilter, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, geometry, bufferDistance, attributeFilter, fields);
        }

        /// <summary>
        /// 获取与指定几何对象具有特定空间查询模式的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间查询模式。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>        
        /// <exception cref="ArgumentNullException">参数 datasetNames、geometry 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// <code>
        /// using System;
        /// using System.Collections.Generic;
        /// using System.Text;
        /// using SuperMap.Connector;
        /// using SuperMap.Connector.Utility;
        /// 
        /// namespace ConsoleApplication1
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             Data data = new Data("http://localhost:8090/iserver/services/data-world/rest");
        /// 
        ///             //查询的数据集数组
        ///             string[] datasetNames = { "World:Capitals", "World:Ocean" };
        /// 
        ///             //几何对象
        ///             Geometry geometry = new Geometry();
        ///             geometry.Parts = new int[1] { 5 };
        ///             geometry.Points = new Point2D[5];
        ///             geometry.Points[0] = new Point2D(-45, -90);
        ///             geometry.Points[1] = new Point2D(-45, 90);
        ///             geometry.Points[2] = new Point2D(45, 90);
        ///             geometry.Points[3] = new Point2D(45, -90);
        ///             geometry.Points[4] = new Point2D(-45, -90);
        /// 
        ///             List&lt;Feature&gt; result = data.GetFeature(datasetNames, geometry, SpatialQueryMode.CONTAIN, null);
        /// 
        ///             Console.WriteLine("获得要素个数为：{0}", result.Count);    //获得结果集个数为：106
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, SpatialQueryMode spatialQueryMode, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, geometry, spatialQueryMode, fields);
        }

        /// <summary>
        /// 获取与指定几何对象具有特定空间查询模式的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间查询模式。</param>
        /// <param name="attributeFilter">属性过滤条件。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>        
        /// <exception cref="ArgumentNullException">参数 datasetNames、geometry 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 请参见：<see cref="GetFeature(string[], SuperMap.Connector.Utility.Geometry, SuperMap.Connector.Utility.SpatialQueryMode, string[])"/>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, SpatialQueryMode spatialQueryMode, string attributeFilter, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, geometry, spatialQueryMode, attributeFilter, fields);
        }

        /// <summary>
        /// 根据指定要素 ID 获取指定数据集中的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="ids">要素 ID。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        /// <exception cref="ArgumentNullException">参数 datasetNames、ids 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// <code>
        /// using System;
        /// using System.Collections.Generic;
        /// using System.Text;
        /// using SuperMap.Connector;
        /// using SuperMap.Connector.Utility;
        /// 
        /// namespace ConsoleApplication1
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             Data data = new Data("http://localhost:8090/iserver/services/data-world/rest");
        /// 
        ///             //查询的数据集数组
        ///             string[] datasetNames = { "World:Capitals", "World:Ocean" };
        /// 
        ///             //要素 ID 的集合
        ///             int[] ids = { 1, 2, 3, 5, 9 };
        /// 
        ///             List&lt;Feature&gt; result = data.GetFeature(datasetNames, ids, null);
        /// 
        ///             Console.WriteLine("获得要素个数为：{0}", result.Count);    //获得结果集个数为：10
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, int[] ids, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, ids, fields);
        }

        /// <summary>
        /// 获取在指定空间范围内的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="bounds">指定的查询范围。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>        
        /// <exception cref="ArgumentNullException">参数 datasetNames、bounds 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// <code>
        /// using System;
        /// using System.Collections.Generic;
        /// using System.Text;
        /// using SuperMap.Connector;
        /// using SuperMap.Connector.Utility;
        /// 
        /// namespace ConsoleApplication1
        /// {
        ///     class Program
        ///     {
        ///         static void Main(string[] args)
        ///         {
        ///             Data data = new Data("http://localhost:8090/iserver/services/data-world/rest");
        /// 
        ///             //查询的数据集数组
        ///             string[] datasetNames = { "World:Capitals", "World:Ocean" };
        /// 
        ///             //指定的查询范围。
        ///             Rectangle2D bound = new Rectangle2D(new Point2D(-45, -45), new Point2D(45, 45));
        /// 
        ///             List&lt;Feature&gt; result = data.GetFeature(datasetNames, bound, null);
        /// 
        ///             Console.WriteLine("获得要素个数为：{0}", result.Count);    //获得结果集个数为：83
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, Rectangle2D bounds, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, bounds, fields);
        }

        /// <summary>
        /// 获取在指定空间范围内，并满足一定属性过滤条件的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="bounds">指定的查询范围。</param>
        /// <param name="attributeFilter">属性过滤条件。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        /// <exception cref="ArgumentNullException">参数 datasetNames、bounds 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 请参见：<see cref="GetFeature(string[], SuperMap.Connector.Utility.Rectangle2D, string[])"/>
        /// </example>
        public List<Feature> GetFeature(string[] datasetNames, Rectangle2D bounds, string attributeFilter, string[] fields)
        {
            return _dataProvider.GetFeature(datasetNames, bounds, attributeFilter, fields);
        }

        /// <summary>
        /// 获取指定数据源的指定数据集信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必选参数。</param>
        /// <param name="datasetName">数据集名称，必选参数。</param>
        /// <returns>数据集信息。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public DatasetInfo GetDatasetInfo(string datasourceName, string datasetName)
        {
            return _dataProvider.GetDatasetInfo(datasourceName, datasetName);
        }

        /// <summary>
        /// 在指定的数据源中，根据指定的数据集信息创建一个新的数据集。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必选参数。</param>
        /// <param name="datasetName">数据集名称，必选参数。</param>
        /// <param name="datasetType"> 数据集类型。目前支持六种枚举值：POINT、LINE、REGION、TEXT、CAD、TABULAR。</param>
        /// <returns>数据集创建成功返回 true， 否则返回 false。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool CreateDataset(string datasourceName, string datasetName, DatasetType datasetType)
        {
            return _dataProvider.CreateDataset(datasourceName, datasetName, datasetType);
        }

        /// <summary>
        /// 在指定的数据源中，根据指定的数据集信息删除一个数据集。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据集名称。</param>
        /// <returns>数据集删除成功返回 true，否则返回 false。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool DeleteDataset(string datasourceName, string datasetName)
        {
            return _dataProvider.DeleteDataset(datasourceName, datasetName);
        }

        /// <summary>
        /// 在指定的数据源中，更新指定数据集的信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">待更新的数据集的名称。</param>
        /// <param name="newDatasetInfo">新的数据集信息。</param>
        /// <returns>数据集创建成功返回 true， 否则返回 false。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <remarks>现支持更新IsFileCache，Description，PrjCoordSys，Charset，Palette，NoValue 属性。</remarks>
        public bool UpdateDatasetInfo(string datasourceName, string datasetName, DatasetInfo newDatasetInfo)
        {
            return _dataProvider.UpdateDatasetInfo(datasourceName, datasetName, newDatasetInfo);
        }

        /// <summary>
        /// <para>复制数据集。</para>
        /// <para>从指定的源数据源中，复制指定的源数据集到指定的目标数据源中的目标数据集。</para>
        /// </summary>
        /// <param name="srcDatasourceName">源数据源名称，必设参数。</param>
        /// <param name="srcDatasetName">源数据集名称，必设参数。</param>
        /// <param name="destDatasourceName">目标数据源名称，必设参数。</param>
        /// <param name="destDatasetName">目标数据集名称，必设参数。</param>
        /// <returns>数据集复制成功返回 true，否则返回 false。</returns>
        /// <exception cref="ArgumentNullException">参数 srcDatasourceName、srcDatasetName、destDatasourceName、destDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool CopyDataset(string srcDatasourceName, string srcDatasetName, string destDatasourceName, string destDatasetName)
        {
            return _dataProvider.CopyDataset(srcDatasourceName, srcDatasetName, destDatasourceName, destDatasetName);
        }

        /// <summary>
        /// <para>复制数据集。</para>
        /// <para>在指定的源数据源中，复制指定的源数据集。</para>
        /// </summary>
        /// <param name="srcDatasourceName">源数据源名称，必设参数。</param>
        /// <param name="srcDatasetName">源数据集名称，必设参数。</param>
        /// <param name="destDatasetName">目标数据集名称，必设参数。</param>
        /// <returns>数据集复制成功返回 true，否则返回 false。</returns>
        /// <exception cref="ArgumentNullException">参数 srcDatasourceName、srcDatasetName、destDatasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public bool CopyDataset(string srcDatasourceName, string srcDatasetName, string destDatasetName)
        {
            return _dataProvider.CopyDataset(srcDatasourceName, srcDatasetName, srcDatasourceName, destDatasetName);
        }

        /// <summary>
        /// 获取所有数据源的信息。
        /// </summary>
        /// <returns>数据源信息列表。</returns>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public List<DatasourceInfo> GetDatasourceInfos()
        {
            return _dataProvider.GetDatasourceInfos();
        }

        /// <summary>
        /// 获取指定的某个数据源的信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <returns>数据源信息。 </returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public DatasourceInfo GetDatasourceInfo(string datasourceName)
        {
            return _dataProvider.GetDatasourceInfo(datasourceName);
        }

        /// <summary>
        /// 用新的数据源信息更新原来的数据源信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="newDatasourceInfo">新的数据源信息。</param>
        /// <returns>数据源信息更新是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <remarks>
        /// 只能对数据源信息中的 CoordUnit、Description、DistanceUnit" 进行更新。
        /// </remarks>
        public bool UpdateDatasourceInfo(string datasourceName, DatasourceInfo newDatasourceInfo)
        {
            return _dataProvider.UpdateDatasourceInfo(datasourceName, newDatasourceInfo);
        }

        /// <summary>
        /// 获取指定数据集的所有字段信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <returns>字段信息列表。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public List<FieldInfo> GetFieldInfos(string datasourceName, string datasetName)
        {
            return _dataProvider.GetFieldInfos(datasourceName, datasetName);
        }

        /// <summary>
        /// 获取指定数据集下字段的字段信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="fieldName">字段名称，必设参数。</param>
        /// <returns>字段信息。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName、fieldName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public FieldInfo GetFieldInfo(string datasourceName, string datasetName, string fieldName)
        {
            return _dataProvider.GetFieldInfo(datasourceName, datasetName, fieldName);
        }

        /// <summary>
        /// 更新指定数据集的字段信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="fieldName">字段名称，必设参数。</param>
        /// <param name="newFiledInfo">新的字段信息，必设参数。</param>
        /// <returns>更新字段信息是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName、fieldName、newFiledInfo 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <remarks>
        /// <para>只能在空数据集中进行更新字段的操作。</para>
        /// <para>只能对字段的别名 Caption 进行更新。</para>
        /// </remarks>
        public bool UpdateField(string datasourceName, string datasetName, string fieldName, FieldInfo newFiledInfo)
        {
            return _dataProvider.UpdateField(datasourceName, datasetName, fieldName, newFiledInfo);
        }

        /// <summary>
        /// 删除指定数据集下的字段。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="fieldName">字段名称，必设参数。</param>
        /// <returns>删除字段是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName、fieldName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <remarks>
        /// 只能在空数据集中进行删除字段的操作。
        /// </remarks>
        public bool DeleteField(string datasourceName, string datasetName, string fieldName)
        {
            return _dataProvider.DeleteField(datasourceName, datasetName, fieldName);
        }

        /// <summary>
        /// 在指定的数据集下创建新的字段。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="fieldInfo">字段信息。</param>
        /// <returns>创建字段是否成功。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <remarks>只能在空数据集中进行创建字段的操作。</remarks>
        public bool CreateField(string datasourceName, string datasetName, FieldInfo fieldInfo)
        {
            return _dataProvider.CreateField(datasourceName, datasetName, fieldInfo);
        }

        /// <summary>
        /// 在指定的数据集中，根据指定的统计方法对指定字段进行统计计算。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必设参数。</param>
        /// <param name="datasetName">数据集名称，必设参数。</param>
        /// <param name="fieldName">字段名称，必设参数。</param>
        /// <param name="statisticMode">统计方法。</param>
        /// <returns>统计结果。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName、fieldName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public double Statistic(string datasourceName, string datasetName, string fieldName, StatisticMode statisticMode)
        {
            return _dataProvider.Statistic(datasourceName, datasetName, fieldName, statisticMode);
        }
    }
}
