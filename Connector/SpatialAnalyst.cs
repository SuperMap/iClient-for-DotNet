using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    /// <summary>
    /// SpatialAnalyst 组件接口，用以访问 SuperMap iServer 空间分析服务组件中的REST服务，封装了与空间分析相关的一系列功能。
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>只能针对 SuperMap iServer REST 接口类型服务的访问。</description></item>
    /// <item><description>实例化SpatialAnalyst对象时需要使用明确的空间分析服务组件地址(例如：http://localhost:8090/iserver/services/spatialanalyst-sample/restjsr") </description></item>
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
    ///         //根据服务组件地址初始化一个SpatialAnalyst对象。
    ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-sample/restjsr");
    ///     }
    /// }
    /// </code>
    /// </example>
    public class SpatialAnalyst
    {
        private string _serviceUrl = string.Empty;
        private SpatialAnalystProvider _spatialAnalystProvier = null;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">SuperMap iServer 空间分析服务组件的URL地址(例如：http://localhost:8090/iserver/services/transportationanalyst-sample/restjsr")。 </param>
        /// <exception cref="ArgumentNullException">参数 serviceUrl 为空时抛出异常。</exception>
        public SpatialAnalyst(string serviceUrl)
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
            this._spatialAnalystProvier = new SpatialAnalystProvider(this._serviceUrl);
        }

        /// <summary>
        /// 获取数据源名称列表。
        /// </summary>
        /// <returns>数据源名称列表。</returns>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public List<string> GetDatasourceNames()
        {
            return _spatialAnalystProvier.GetDatasourceNames();
        }

        /// <summary>
        /// 获取指定数据源名称下数据集列表。
        /// </summary>
        /// <param name="datasourceName">数据源名。</param>
        /// <returns>数据集列表。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public List<DatasetInfo> GetDatasetInfos(string datasourceName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
#endif
            return _spatialAnalystProvier.GetDatasetInfos(datasourceName);
        }

        /// <summary>
        /// 获取指定数据集名的数据集信息。
        /// </summary>
        /// <param name="datasourceName">数据源名。</param>
        /// <param name="datasetName">数据集名。</param>
        /// <returns>数据集信息。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName, datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        public DatasetInfo GetDatasetInfo(string datasourceName, string datasetName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrWhiteSpace(datasetName))
            {
                throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            }

#else
            if (string.IsNullOrEmpty(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrEmpty(datasetName))
            {
                throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            }
#endif
            return _spatialAnalystProvier.GetDatasetInfo(datasourceName, datasetName);
        }

        /// <summary>
        /// 根据数据集创建缓冲区。
        /// </summary>
        /// <param name="datasetName">数据集标识。</param>
        /// <param name="filterQueryParameter">过滤参数，可选。设置了过滤参数后，只对数据集中满足此过滤条件的对象创建缓冲区。</param>
        /// <param name="bufferAnalystParameter">缓冲区分析参数，必设参数。指定缓冲距离、缓冲区端点类型等缓冲区分析需要的信息，请参见 <see cref="BufferAnalystParameter"/> 类。</param>
        /// <param name="bufferResultSetting">数据集缓冲区分析结果设置参数。</param>
        /// <returns>数据集缓冲区分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 datasetName 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示例代码演示如何根据数据集进行缓冲区分析。
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
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象。
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-changchun/restjsr");
        /// 
        ///         //初始化一个Buffer分析参数。
        ///          BufferAnalystParameter bufferparameter = new BufferAnalystParameter()
        ///         {
        ///             EndType = BufferEndType.ROUND,
        ///             LeftDistance = new BufferDistance() { Value = 100 },   //左侧缓冲距离100米。
        ///             RightDistance = new BufferDistance() { Value = 100 },
        ///             SemicircleLineSegment = 12
        ///         };
        ///
        ///         //分析完成后结果返回参数。
        ///          BufferResultSetting bufferResultSetting = new BufferResultSetting()
        ///         {
        ///             DataReturnOption = new DataReturnOption()
        ///             {
        ///                 DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,  //返回数据集名称和结果集。
        ///                 Dataset = "bufferResult",                               //缓冲区分析结果数据集名称。
        ///                 DeleteExistResultDataset = true,                        //存在同名结果数据集则覆盖。
        ///                 ExpectCount = 20
        ///             },
        ///             IsUnion = false,             //不合并结果数据集中相交的面。
        ///             IsAttributeRetained = true   //保留原有数据集中字段。
        ///         };
        /// 
        ///         //用来对数据集中的几何对象进行过滤的查询条件。
        ///          QueryParameter filterQueryParameter = new QueryParameter()
        ///         {
        ///             Ids = new int[] { 1, 2, 3, 4, 5 }  //只对数据集中SmID为1,2,3,4,5的几何对象进行缓冲区分析。
        ///         };
        /// 
        ///         string datasetName = "Vegetable@Changchun";   //用来进行缓冲区分析的数据集，@符号前为数据集名称，@符号后为数据源名称。
        /// 
        ///         //执行缓冲区分析。
        ///          DatasetSpatialAnalystResult bufferResult = spatialAnalyst.Buffer(datasetName, bufferparameter, filterQueryParameter, bufferResultSetting);
        /// 
        ///         Console.WriteLine(string.Format("缓冲区分析结果数据集名称为:{0}", bufferResult.Dataset));
        ///         Console.ReadLine();
        ///     }
        /// }
        /// 
        /// //分析输出如下结果：
        /// //缓冲区分析结果数据集名称为:bufferResult@Changchun
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult Buffer(string datasetName, BufferAnalystParameter bufferAnalystParameter, QueryParameter filterQueryParameter, BufferResultSetting bufferResultSetting)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(datasetName))
            {
                throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(datasetName))
            {
                throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            }
#endif
            return _spatialAnalystProvier.Buffer(datasetName, bufferAnalystParameter, filterQueryParameter, bufferResultSetting);
        }

        /// <summary>
        /// 根据几何对象创建缓冲区，成功则返回一个面对象，失败则返回空值。
        /// </summary>
        /// <param name="geometry">需要创建缓冲区的几何对象。</param>
        /// <param name="bufferAnalystParameter">缓冲区分析参数，必设参数。指定缓冲距离、缓冲区端点类型等缓冲区分析需要的信息，请参见 <see cref="BufferAnalystParameter"/> 类。</param>
        /// <returns>几何对象缓冲区分析结果。</returns>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示例代码演示如何根据几何对象进行缓冲区分析。
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
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象。
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-changchun/restjsr");
        ///
        ///         //初始化一个Buffer分析参数。
        ///          BufferAnalystParameter bufferparameter = new BufferAnalystParameter()
        ///         {
        ///             EndType = BufferEndType.ROUND,
        ///             LeftDistance = new BufferDistance() { Value = 100 },   //左侧缓冲距离100米。
        ///             RightDistance = new BufferDistance() { Value = 100 },
        ///             SemicircleLineSegment = 12
        ///         };
        ///
        ///         //缓冲几何对象。
        ///          Point2D point1 = new Point2D(23, 23);
        ///         Point2D point2 = new Point2D(33, 37);
        ///         Point2D point3 = new Point2D(33, 38);
        ///         Point2D point4 = new Point2D(23, 23);
        ///         Geometry bufferSourceGeometry = new Geometry()
        ///         {
        ///             Type = GeometryType.REGION,
        ///             Parts = new int[] { 4 },
        ///             Points = new Point2D[] { point1, point2, point3, point4 },
        ///         };
        /// 
        ///         //执行缓冲区分析。
        ///          GeometrySpatialAnalystResult bufferResult = spatialAnalyst.Buffer(bufferSourceGeometry, bufferparameter);
        ///         Console.ReadLine();
        ///     }
        /// }
        /// </code>
        /// </example>
        public GeometrySpatialAnalystResult Buffer(Geometry geometry, BufferAnalystParameter bufferAnalystParameter)
        {
            return _spatialAnalystProvier.Buffer(geometry, bufferAnalystParameter);
        }

        #region Overlay
        /// <summary>
        /// 对两个数据集进行叠加分析操作。
        /// </summary>
        /// <param name="sourceDataset">源数据集名，也即被操作数据集名，例如：region1@changchun。</param>
        /// <param name="operateDataset">操作数据集名，例如:region2@changchun。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <returns>矢量数据集叠加分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 sourceDataset, operateDataset 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="Overlay(string, QueryParameter, string, QueryParameter, OverlayOperationType, DatasetOverlayResultSetting)"/></example>
        public DatasetSpatialAnalystResult Overlay(string sourceDataset, string operateDataset, OverlayOperationType operation)
        {
            return Overlay(sourceDataset, null, operateDataset, null, operation, null);
        }

        /// <summary>
        /// 根据指定的分析返回结果设置对两个数据集进行叠加分析操作。
        /// </summary>
        /// <param name="sourceDataset">源数据集名，也即被操作数据集名，例如：region1@changchun。</param>
        /// <param name="operateDataset">操作数据集名，例如:region2@changchun。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <param name="datasetOverlayResultSetting">数据集叠加分析结果设置。</param>
        /// <returns>矢量数据集叠加分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 sourceDataset, operateDataset 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="Overlay(string, QueryParameter, string, QueryParameter, OverlayOperationType, DatasetOverlayResultSetting)"/></example>
        public DatasetSpatialAnalystResult Overlay(string sourceDataset, string operateDataset, OverlayOperationType operation, DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
            return Overlay(sourceDataset, null, operateDataset, null, operation, datasetOverlayResultSetting);
        }

        /// <summary>
        /// 根据指定的过滤条件以及分析返回结果设置对两个数据集进行叠加分析操作。
        /// </summary>
        /// <param name="sourceDataset">源数据集名，也即被操作数据集名，例如：region1@changchun。</param>
        /// <param name="sourceDatasetFilter">源数据集中空间对象过滤条件。设置完过滤条件后，源数据集中仅有满足条件的对象才参与叠加分析。</param>
        /// <param name="operateDataset">操作数据集名，例如:region2@changchun。</param>
        /// <param name="operateDatasetFilter">操作数据集中空间对象过滤条件。设置完过滤条件后，操作数据集中仅有满足条件的对象才参与叠加分析。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <param name="datasetOverlayResultSetting">数据集叠加分析结果设置。</param>
        /// <returns>矢量数据集叠加分析结果。</returns>
        /// <remarks>在矢量数据集叠加分析中至少涉及到三个数据集，其中一个数据集被称作源数据集，即被操作的数据集（在 SuperMap GIS 中称作第一数据集）；
        /// 另一个数据集被称作叠加数据集，即操作数据集（operateDataset）；还有一个数据集就是叠加结果数据集，
        /// 包含叠加后数据的几何信息和属性信息。叠加结果数据集中的属性信息来自于第一数据集和第二数据集的属性表，
        /// 在进行叠加分析的时候，用户可以根据自己的需要在这两个数据集的属性表中选择需要保留的属性字段。
        /// </remarks>
        /// <exception cref="ArgumentNullException">参数 sourceDataset, operateDataset 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示范代码演示如何根据数据集进行叠加分析操作。
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
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象。
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-changchun/restjsr");
        ///         string sourceDataset = "AreaPoly@Changchun";  //源数据集名称。
        ///         string operateDataset = "Frame_R@Changchun";  //操作数据集名称。
        ///         string returnDatasetName = "overlayresult";   //结果数据集名称。
        /// 
        ///         //设置叠加分析返回结果设置。
        ///          DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
        ///         {
        ///             DataReturnOption = new DataReturnOption()
        ///             {
        ///                 Dataset = returnDatasetName,
        ///                 DeleteExistResultDataset = true,
        ///                 DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET  //返回数据集名称和记录集。
        ///             },
        ///             Tolerance = 5,
        ///         };
        /// 
        ///         //设置源数据集的过滤条件。
        ///          QueryParameter sourceDatasetFilter = new QueryParameter()
        ///         {
        ///             AttributeFilter = "smid=19 or smid=656",
        ///         };
        /// 
        ///         //设置操作数据集的过滤条件。
        ///          QueryParameter operateDatasetFilter = new QueryParameter()
        ///         {
        ///             AttributeFilter = "smid=1",
        ///         };
        /// 
        ///         //执行叠加分析操作。
        ///          DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, sourceDatasetFilter, operateDataset, operateDatasetFilter, OverlayOperationType.INTERSECT, resultSetting);
        ///         
        ///         Console.ReadLine();
        ///     }
        /// }
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult Overlay(string sourceDataset, QueryParameter sourceDatasetFilter, string operateDataset, QueryParameter operateDatasetFilter, OverlayOperationType operation, DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(sourceDataset))
            {
                throw new ArgumentNullException("sourceDataset", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrWhiteSpace(operateDataset))
            {
                throw new ArgumentNullException("operateDataset", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(sourceDataset))
            {
                throw new ArgumentNullException("sourceDataset", Resources.ArgumentIsNotNull);
            }
            if (string.IsNullOrEmpty(operateDataset))
            {
                throw new ArgumentNullException("operateDataset", Resources.ArgumentIsNotNull);
            }
#endif
            return _spatialAnalystProvier.Overlay(sourceDataset, sourceDatasetFilter, operateDataset, operateDatasetFilter, operation, datasetOverlayResultSetting);
        }

        /// <summary>
        /// 使用指定的区域对数据集进行叠加分析操作。
        /// </summary>
        /// <param name="sourceDataset">源数据集名，也即被操作数据集名，例如：region1@changchun。</param>
        /// <param name="operateRegions">操作区域。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <returns>矢量数据集叠加分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 sourceDataset, operateRegions 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="Overlay(string, QueryParameter, Geometry[], OverlayOperationType, DatasetOverlayResultSetting)"/></example>
        public DatasetSpatialAnalystResult Overlay(string sourceDataset, Geometry[] operateRegions, OverlayOperationType operation)
        {
            return Overlay(sourceDataset, null, operateRegions, operation, null);
        }

        /// <summary>
        /// 根据指定的分析返回结果设置使用指定的区域对数据集进行叠加分析操作。
        /// </summary>
        /// <param name="sourceDataset">源数据集名，也即被操作数据集名，例如：region1@changchun。</param>
        /// <param name="operateRegions">操作区域。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <param name="datasetOverlayResultSetting">数据集叠加分析结果设置。</param>
        /// <returns>矢量数据集叠加分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 sourceDataset, operateRegions 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="Overlay(string, QueryParameter, Geometry[], OverlayOperationType, DatasetOverlayResultSetting)"/></example>
        public DatasetSpatialAnalystResult Overlay(string sourceDataset, Geometry[] operateRegions, OverlayOperationType operation, DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
            return Overlay(sourceDataset, null, operateRegions, operation, datasetOverlayResultSetting);
        }

        /// <summary>
        /// 根据指定的过滤条件以及返回结果设置使用指定的区域对数据集进行叠加分析操作。
        /// </summary>
        /// <param name="sourceDataset">源数据集名，也即被操作数据集名，例如：region1@changchun。</param>
        /// <param name="sourceDatasetFilter">源数据集中空间对象过滤条件。设置完过滤条件后，源数据集中仅有满足条件的对象才参与叠加分析。</param>
        /// <param name="operateRegions">操作区域。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <param name="datasetOverlayResultSetting">数据集叠加分析结果设置。</param>
        /// <returns>矢量数据集叠加分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 sourceDataset, operateRegions 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示范代码演示如何使用一个面对象和数据集进行叠加分析操作。
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
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象。
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-changchun/restjsr");
        ///         string sourceDataset = "School@Changchun";  //源数据集名称。
        ///         string returnDatasetName = "result";        //结果数据集名称。
        /// 
        ///         //初始化一个操作区域。
        ///          Point2D leftBottom = new Point2D(3577.31919947043, -5449.94178803891);
        ///         Point2D rightBottom = new Point2D(7546.48057648152, -5449.94178803891);
        ///         Point2D rightTop = new Point2D(7546.48057648152, -3822.87747356561);
        ///         Point2D leftTop = new Point2D(3577.31919947043, -3822.87747356561);
        ///         Geometry region = new Geometry()
        ///         {
        ///             Type = GeometryType.RECTANGLE,
        ///             Parts = new int[] { 4 },
        ///             Points = new Point2D[] { leftBottom, rightBottom, rightTop, leftTop }
        ///         };
        ///         Geometry[] operateRegions = new Geometry[] { region };
        /// 
        ///         //叠加分析返回结果设置。
        ///          DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
        ///         {
        ///             DataReturnOption = new DataReturnOption()
        ///             {
        ///                 Dataset = returnDatasetName,
        ///                 DeleteExistResultDataset = true,
        ///                 DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
        ///             },
        ///             Tolerance = 5,
        ///             SourceDatasetFields = new string[] { "NAME" }  //设置源数据集中保留字段列表。
        ///         };
        /// 
        ///         //源数据集过滤对象。
        ///          QueryParameter sourceDatasetFilter = new QueryParameter()
        ///         {
        ///             AttributeFilter = "smid &gt; 100 and smid &lt; 200"
        ///         };
        /// 
        ///         //执行叠加分析操作。
        ///          DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, sourceDatasetFilter, operateRegions, OverlayOperationType.INTERSECT, resultSetting);
        /// 
        ///         Console.ReadLine();
        ///     }
        /// }
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult Overlay(string sourceDataset, QueryParameter sourceDatasetFilter, Geometry[] operateRegions, OverlayOperationType operation, DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(sourceDataset))
            {
                throw new ArgumentNullException("sourceDataset", Resources.ArgumentIsNotNull);
            }
#else
            if (string.IsNullOrEmpty(sourceDataset))
            {
                throw new ArgumentNullException("sourceDataset", Resources.ArgumentIsNotNull);
            }
#endif
            if (operateRegions == null)
            {
                throw new ArgumentNullException("operateRegions", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.Overlay(sourceDataset, sourceDatasetFilter, operateRegions, operation, datasetOverlayResultSetting);
        }

        /// <summary>
        /// 使用几何对象进行叠加分析操作。
        /// </summary>
        /// <param name="sourceGeometry">被操作的几何对象。</param>
        /// <param name="operateGeometry">操作几何对象。</param>
        /// <param name="operation">叠加分析类型，叠加操作有：裁剪（CLIP）、擦除（ERASE）、合并（UNION）、相交（INTERSECT）、同一（IDENTITY）、对称差（XOR）和更新（UPDATE）。</param>
        /// <returns>几何对象叠加分析结果。</returns>
        /// <exception cref="ArgumentNullException">参数 sourceGeometry, operateGeometry为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示范代码演示如何使用两个面对象进行叠加分析操作。
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
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象。
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-changchun/restjsr");
        /// 
        ///         //构造一个源几何对象。
        ///          Point2D point1 = new Point2D(143.95848843850121, 340.94821798126338);
        ///         Point2D point2 = new Point2D(126.82919567639334, 318.2994864402541);
        ///         Point2D point3 = new Point2D(140.08853711076571, 298.50563702626283);
        ///         Point2D point4 = new Point2D(182.53111806576629, 309.73484005920017);
        ///         Point2D point5 = new Point2D(177.70953936235816, 329.02115487283277);
        ///         Point2D point6 = new Point2D(143.95848843850121, 340.94821798126338);
        ///         Geometry sourceGeometry = new Geometry()
        ///         {
        ///             Type = GeometryType.REGION,
        ///             Parts = new int[] { 6 },
        ///             Points = new Point2D[] { point1, point2, point3, point4, point5, point6 }
        ///         };
        /// 
        ///         //构造一个操作几何对象。
        ///          Point2D point11 = new Point2D(181.79816017595482, 356.16963002561636);
        ///         Point2D point21 = new Point2D(158.46194538218725, 319.17740805623669);
        ///         Point2D point31 = new Point2D(196.43985247981379, 287.15681971902217);
        ///         Point2D point41 = new Point2D(224.78694726220056, 322.27670720950834);
        ///         Point2D point51 = new Point2D(181.79816017595482, 356.16963002561636);
        ///         Geometry operateGeometry = new Geometry()
        ///         {
        ///             Type = GeometryType.REGION,
        ///             Parts = new int[] { 5 },
        ///             Points = new Point2D[] { point11, point21, point31, point41, point51 }
        ///         };
        /// 
        ///         //执行叠加分析操作。
        ///          GeometrySpatialAnalystResult result = spatialAnalyst.Overlay(sourceGeometry, operateGeometry, OverlayOperationType.INTERSECT);
        ///         Console.ReadLine();
        ///     }
        /// }
        /// </code>
        /// </example>
        public GeometrySpatialAnalystResult Overlay(Geometry sourceGeometry, Geometry operateGeometry, OverlayOperationType operation)
        {
            if (sourceGeometry == null)
            {
                throw new ArgumentNullException("sourceGeometry", Resources.ArgumentIsNotNull);
            }
            if (operateGeometry == null)
            {
                throw new ArgumentNullException("operateGeometry", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.Overlay(sourceGeometry, operateGeometry, operation);
        }
        #endregion

        #region isoregion
        /// <summary>
        /// 用于从点数据集中提取等值面，该方法的实现原理是先对点数据集进行插值分析， 得到栅格数据集（方法实现的中间结果），接着从栅格数据集提取等值面。
        /// </summary>
        /// <param name="pointDataset">进行分析的点数据集标识(datasetName@datasourceName)。</param>
        /// <param name="filterQueryParameter">对点数据集中的点对象进行过滤的 属性过滤条件。只有满足过滤条件的点才参与分析。</param>
        /// <param name="zValueField">高程字段名。</param>
        /// <param name="resolution">中间结果（栅格数据集）的分辨率。</param>
        /// <param name="parameter">提取等值面的参数，必设参数。设置光滑度、重采样距离等，请参见 <see cref="ExtractParameter"/> 类。</param>
        /// <param name="resultSetting">返回值设置参数，设置是否返回记录、是否创建结果数据集等。</param>
        /// <returns>根据返回值设置参数返回相应的信息。</returns>
        /// <exception cref="ArgumentNullException">参数 pointDataset,parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示范代码演示如何对一个点数据集进行提取等值面操作。 
        /// <code>
        /// class Program
        /// {
        ///     static void Main(string[] args)
        ///     {
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象
        ///         SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-sample/restjsr");
        ///         
        ///         string pointDataset = "SamplesP@Interpolation";   //进行分析的点数据集标识
        ///         string zValueField = "AVG_WTR";  //高程字段名
        ///         double resolution = 3000;   //中间结果（栅格数据集）的分辨率
        ///         
        ///         //对点数据集中的点对象进行过滤的过滤条件
        ///         QueryParameter filterQueryParameter = new QueryParameter()
        ///         {
        ///             AttributeFilter = "SmID>0"
        ///          };
        ///          
        ///          //等值面的提取参数设置类
        ///          ExtractParameter parameter = new ExtractParameter()
        ///          {
        ///             DatumValue = 0,
        ///             Interval = 500,
        ///             Smoothness = 3
        ///           };
        ///           
        ///           //返回值设置参数
        ///           DataReturnOption resultSetting = new DataReturnOption()
        ///           {
        ///             DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
        ///             DeleteExistResultDataset = true,
        ///             Dataset = "isoregion@Interpolation"
        ///            };
        ///            
        ///            //执行提取等值面操作
        ///            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
        ///            Console.WriteLine("提取的等值面个数为：{0}", actualResult.Recordset.Features.Length);
        ///            Console.ReadLine();
        ///       }
        /// }
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult IsoRegion(string pointDataset, QueryParameter filterQueryParameter, string zValueField, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            if (string.IsNullOrEmpty(pointDataset))
            {
                throw new ArgumentNullException("pointDataset", Resources.ArgumentIsNotNull);
            }
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.IsoRegion(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
        }

        /// <summary>
        /// 用于从栅格数据集中提取等值面。
        /// </summary>
        /// <param name="gridDataset">需分析的栅格数据集标识。</param>
        /// <param name="parameter">提取等值面的参数，必设参数。设置光滑度、重采样距离等，请参见 <see cref="ExtractParameter"/> 类。</param>
        /// <param name="resultSetting">返回值设置参数，设置是否返回记录、是否创建结果数据集等。</param>
        /// <returns>根据返回值设置参数返回相应的信息。</returns>
        /// <exception cref="ArgumentNullException">参数 gridDataset,parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="IsoRegion(string, QueryParameter, string, double, ExtractParameter, DataReturnOption)"/></example>
        public DatasetSpatialAnalystResult IsoRegion(string gridDataset, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            if (string.IsNullOrEmpty(gridDataset))
            {
                throw new ArgumentNullException("gridDataset", Resources.ArgumentIsNotNull);
            }
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.IsoRegion(gridDataset, parameter, resultSetting);
        }

        /// <summary>
        /// <para>用于从一个点集合中提取等值面，方法的实现原理是先利用点集合中存储的第三维信息（高程或者温度等），也就是除了点的坐标信息的数据，对点数据进行插值分析，得到栅格数据集（中间结果数据集），接着从栅格数据集中提取等值面。</para>
        /// </summary>
        /// <param name="points">进行分析的点数组。</param>
        /// <param name="zValues">各点的高程值数组，该数组长度必须与points相同。</param>
        /// <param name="resolution">中间结果（栅格数据集）的分辨率。</param>
        /// <param name="parameter">提取等值面的参数，必设参数。设置光滑度、重采样距离等，请参见 <see cref="ExtractParameter"/> 类。</param>
        /// <param name="resultSetting">返回值设置参数，设置是否返回记录、是否创建结果数据集等。</param>
        /// <returns>根据返回值设置参数返回相应的信息。</returns>
        /// <exception cref="ArgumentNullException">参数 parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示范代码演示如何从一个点集合进行提取等值面操作。
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
        ///          //根据服务组件地址初始化一个SpatialAnalyst对象
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-sample/restjsr");
        ///          //设置进行分析的点数组
        ///          Point2D[] points = new Point2D[10];
        ///          points[0] = new Point2D() { X = 603598.5, Y = 4479242.9 };
        ///          points[1] = new Point2D() { X = 604604.9, Y = 4475916.8 };
        ///          points[2] = new Point2D() { X = 605069.2, Y = 4473869.0 };
        ///          points[3] = new Point2D() { X = 597849.2, Y = 4473651.4 };
        ///          points[4] = new Point2D() { X = 603468.4, Y = 4470350.5 };
        ///          points[5] = new Point2D() { X = 602541.3, Y = 4469362.1 };
        ///          points[6] = new Point2D() { X = 596899.8, Y = 4468956.9 };
        ///          points[7] = new Point2D() { X = 611758.7, Y = 4476101.0 };
        ///          points[8] = new Point2D() { X = 617993.0, Y = 4476567.4 };
        ///          points[9] = new Point2D() { X = 613072.9, Y = 4472425.6 };
        ///          //设置各点的高程值数组
        ///          double[] zValues = new double[10] { 52.98, 25.74, 62.94, 50.82, 41.36, 41.66, 64.66, 23.7, 40.74, 3.12 };
        ///          //中间结果（栅格数据集）的分辨率
        ///          double resolution = 3000;
        ///          //提取等值面的参数
        ///          ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
        ///          
        ///          //执行提取等值面操作
        ///          DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(points, zValues, resolution, parameter, null);
        ///          Console.WriteLine("返回的数据集名称为：{0}", actualResult.Dataset);
        ///          Console.ReadLine();
        ///     }
        /// }
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult IsoRegion(Point2D[] points, double[] zValues, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.IsoRegion(points, zValues, resolution, parameter, resultSetting);
        }

        #endregion


        #region interpolate
        /// <summary>
        /// <para>用于对离散的点数据进行插值得到栅格数据集。插值分析可以将有限的采样点数据，通过插值对采样点周围的数值情况进行预测，
        /// 从而掌握研究区域内数据的总体分布状况，而使采样的离散点不仅仅反映其所在位置的数值情况，而且可以反映区域的数值分布。</para>
        /// </summary>
        /// <param name="pointDataset">进行插值分析的点数据集名称，如SamplesP@Interpolation。</param>
        /// <param name="parameter">插值参数对象。</param>
        /// <returns>返回插值分析得到的栅格数据集。</returns>
        /// <remarks>
        /// <para>插值分析支持的算法类型：点密度、径向基函数、距离反比权值、普通克吕金、简单克吕金、泛克吕金共6种插值法。</para>
        /// <para>(1)点密度（Density）插值法。插值分析时只需要将parameter参数定义为<see cref="InterpolationDensityParameter"/>类型，即可进行点密度插值法。</para>
        /// <para>(2)径向基函数（Radial Basis Function）插值法。该方法假设变化是平滑的，它有两个特点：表面必须精确通过数据点；表面必须有最小曲率。该插值在创建有视觉要求的曲线和等高线方面有优势。插值分析时只需要将parameter参数定义为<see cref="InterpolationRBFParameter"/>类型，即可进行径向基函数插值法。</para>
        /// <para>(3)距离反比权值（Inverse Distance Weighted）插值法。该方法通过计算附近区域离散点群的平均值来估算单元格的值，生成格网数据集。
        /// 这是一种简单有效的数据内插方法，运算速度相对较快。距离离散中心越近的点，其估算值越受影响。插值分析时只需要将parameter参数定义为<see cref="InterpolationIDWParameter"/>类型，即可进行距离反比权值插值法。</para>
        /// <para>(4)克吕金插值法。克吕金插值法又分成3种类型（参考<see cref="KrigingAlgorithmType"/>）：普通克吕金插值法；简单克吕金插值法；泛克吕金插值法。插值分析时需要将parameter参数定义为<see cref="InterpolationKrigingParameter"/>类型，并且在InterpolationKrigingParameter.Type参数中设置克吕金插值法的类型，即可进行克吕金插值法。</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">参数 parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>
        /// 以下示范代码演示如何进行插值分析操作。
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
        ///          //根据服务组件地址初始化一个SpatialAnalyst对象
        ///          SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-sample/restjsr");
        ///          //设置插值参数
        ///          InterpolationKrigingParameter param = new InterpolationKrigingParameter()
        ///          {
        ///              PixelFormat = PixelFormat.BIT16,
        ///              ZValueFieldName = "AVG_TMP",
        ///              ZValueScale = 1,
        ///              Resolution = 3000,
        ///              OutputDatasetName = "interpolateKriging",
        ///              OutputDatasourceName = "Interpolation",
        ///              VariogramMode = VariogramMode.SPHERICAL,
        ///              SearchMode = SearchMode.KDTREE_FIXED_RADIUS,
        ///              SearchRadius = 0
        ///           };
        ///           //进行插值分析
        ///           DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate("SamplesP@Interpolation",param);
        ///           Console.WriteLine("返回的数据集名称是：{0}", actualResult.Dataset);
        ///           Console.ReadLine();
        ///      }
        /// }
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult Interpolate(string pointDataset, InterpolationParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            if (pointDataset == null)
            {
                throw new ArgumentNullException("pointDataset", Resources.ArgumentIsNotNull);
            }

            return _spatialAnalystProvier.Interpolate(pointDataset, parameter);
        }

        #endregion


        #region isoLine
        /// <summary>
        /// 用于从点数据集中提取等值线，该方法的实现原理是先对点数据集进行插值分析， 得到栅格数据集（方法实现的中间结果），接着从栅格数据集中提取等值线。
        /// </summary>
        /// <param name="pointDataset">进行分析的点数据集标识(datasetName@datasourceName)。</param>
        /// <param name="filterQueryParameter">对点数据集中的点对象进行过滤的 属性过滤条件。只有满足过滤条件的点才参与分析。</param>
        /// <param name="zValueField">高程字段名。</param>
        /// <param name="resolution">中间结果（栅格数据集）的分辨率。</param>
        /// <param name="parameter">提取等值线的参数，必设参数。设置光滑度、重采样距离等，请参见 <see cref="ExtractParameter"/> 类。</param>
        /// <param name="resultSetting">返回值设置参数，设置是否返回记录、是否创建结果数据集等。</param>
        /// <returns>根据返回值设置参数返回相应的信息。</returns>
        /// <exception cref="ArgumentNullException">参数 pointDataset,parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// 以下示范代码演示如何对一个点数据集进行提取等值线操作。 
        /// <example>
        /// <code>
        /// class Program
        /// {
        ///     static void Main(string[] args)
        ///     {
        ///         //根据服务组件地址初始化一个SpatialAnalyst对象
        ///         SpatialAnalyst spatialAnalyst = new SpatialAnalyst("http://localhost:8090/iserver/services/spatialanalyst-sample/restjsr");
        ///         
        ///         string pointDataset = "SamplesP@Interpolation";   //进行分析的点数据集标识
        ///         string zValueField = "AVG_WTR";  //高程字段名
        ///         double resolution = 3000;   //中间结果（栅格数据集）的分辨率
        ///         
        ///         //对点数据集中的点对象进行过滤的过滤条件
        ///         QueryParameter filterQueryParameter = new QueryParameter()
        ///         {
        ///             AttributeFilter = "SmID>0"
        ///          };
        ///          
        ///          //等值线的提取参数设置类
        ///          ExtractParameter parameter = new ExtractParameter()
        ///          {
        ///             DatumValue = 0,
        ///             Interval = 500,
        ///             Smoothness = 3
        ///           };
        ///           
        ///           //返回值设置参数
        ///           DataReturnOption resultSetting = new DataReturnOption()
        ///           {
        ///             DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
        ///             DeleteExistResultDataset = true,
        ///             Dataset = "isoLine@Interpolation"
        ///           };
        ///            
        ///            //执行提取等值线操作
        ///            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
        ///            Console.WriteLine("提取的等值线个数为：{0}", actualResult.Recordset.Features.Length);
        ///            Console.ReadLine();
        ///       }
        /// }
        /// </code>
        /// </example>
        public DatasetSpatialAnalystResult IsoLine(string pointDataset, QueryParameter filterQueryParameter, string zValueField, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            if (string.IsNullOrEmpty(pointDataset))
            {
                throw new ArgumentNullException("pointDataset", Resources.ArgumentIsNotNull);
            }
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.IsoLine(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
        }

        /// <summary>
        /// 用于从栅格数据集中提取等值线。
        /// </summary>
        /// <param name="gridDataset">需分析的栅格数据集标识。</param>
        /// <param name="parameter">提取等值线的参数，必设参数。设置光滑度、重采样距离等，请参见 <see cref="ExtractParameter"/> 类。</param>
        /// <param name="resultSetting">返回值设置参数，设置是否返回记录、是否创建结果数据集等。</param>
        /// <returns>根据返回值设置参数返回相应的信息。</returns>
        /// <exception cref="ArgumentNullException">参数 gridDataset,parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="IsoLine(string, QueryParameter, string, double, ExtractParameter, DataReturnOption)"/></example>
        public DatasetSpatialAnalystResult IsoLine(string gridDataset, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            if (string.IsNullOrEmpty(gridDataset))
            {
                throw new ArgumentNullException("gridDataset", Resources.ArgumentIsNotNull);
            }
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.IsoLine(gridDataset, parameter, resultSetting);
        }

        /// <summary>
        /// <para>用于从一个点集合中提取等值线，方法的实现原理是先利用点集合中存储的第三维信息（高程或者温度等），也就是除了点的坐标信息的数据，对点数据进行插值分析，得到栅格数据集（中间结果数据集），接着从栅格数据集中提取等值线。</para>
        /// </summary>
        /// <param name="points">进行分析的点数组。</param>
        /// <param name="zValues">各点的高程值数组，该数组长度必须与points相同。</param>
        /// <param name="resolution">中间结果（栅格数据集）的分辨率。</param>
        /// <param name="parameter">提取等值线的参数，必设参数。设置光滑度、重采样距离等，请参见 <see cref="ExtractParameter"/> 类。</param>
        /// <param name="resultSetting">返回值设置参数，设置是否返回记录、是否创建结果数据集等。</param>
        /// <returns>根据返回值设置参数返回相应的信息。</returns>
        /// <exception cref="ArgumentNullException">参数 parameter 为空时抛出异常。</exception>
        /// <exception cref="SuperMap.Connector.Utility.ServiceException">服务端处理错误时抛出异常。</exception>
        /// <example>请参见 <see cref="IsoLine(string, QueryParameter, string, double, ExtractParameter, DataReturnOption)"/></example>
        public DatasetSpatialAnalystResult IsoLine(Point2D[] points, double[] zValues, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", Resources.ArgumentIsNotNull);
            }
            return _spatialAnalystProvier.IsoLine(points, zValues, resolution, parameter, resultSetting);
        }

        #endregion
    }
}