using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Utility;
using Newtonsoft.Json;
#region Copyright 2011-2012 Supermap GIS Technologies, Inc.
//////////////////////////////////////////////////////////////////////////
//============================================================
//软件产品：		SuperMap Connector for .NET
//版本信息：		V1.0
//作  者：			胡本权
//单  位：			北京超图地理信息技术有限公司，SuperMap GIS Technologies, Inc.
//最后修改时间：	以文件日期为准
//-------------------------------------------------------------------------------------
//版权声明：		SuperMap IS Class，版权所有(c) 北京超图地理信息技术有限公司，1998-2012。
//					http://www.supermap.com， 未经许可不得擅自传播。
//警告：			本计算机程序受著作权法和国际公约的保护，未经授权擅自复制或者传播本程序的部分或全部，
//					将受到严厉的民事及刑事制裁，并将在法律许可的范围内受到最大可能的起诉。
//
//版本信息：		
//作    者：		
//完成日期：		
//更新说明：

//////////////////////////////////////////////////////////////////////////
#endregion

namespace SuperMap.Connector
{
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class QueryResource
#else
    public class QueryResource
#endif
    {
        /// <summary>
        /// 使用POST请求模拟GET请求时，查询协助类。
        /// </summary>
        [JsonProperty("queryMode", NullValueHandling = NullValueHandling.Ignore)]
        public string QueryMode;
        [JsonProperty("queryParameters", NullValueHandling = NullValueHandling.Ignore)]
        public QueryParameterSet QueryParameters;
        [JsonProperty("geometry", NullValueHandling = NullValueHandling.Ignore)]
        public Geometry Geometry;
        [JsonProperty("bounds", NullValueHandling = NullValueHandling.Ignore)]
        public Rectangle2D Bounds;
        [JsonProperty("spatialQueryMode", NullValueHandling = NullValueHandling.Ignore)]
        public string SpatialQueryMode;
        [JsonProperty("distance", NullValueHandling = NullValueHandling.Ignore)]
        public double? Distance;
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class GetFeatureResource
#else
    public class GetFeatureResource
#endif
    {
        /// <summary>
        /// 使用POST请求时，GetFeature协助类。
        /// </summary>

        [JsonProperty("getFeatureMode")]
        public GetFeatureMode GetFeatureMode;

        [JsonProperty("datasetNames")]
        public string[] DatasetNames;

        [JsonProperty("ids")]
        public int[] Ids;

        [JsonProperty("bounds")]
        public Rectangle2D Bounds;

        [JsonProperty("geometry")]
        public Geometry Geometry;

        [JsonProperty("bufferDistance")]
        public double Distance;

        [JsonProperty("attributeFilter")]
        public string AttributeFilter;

        [JsonProperty("queryParameter")]
        public QueryParameter QueryParameter;

        [JsonProperty("spatialQueryMode")]
        public SpatialQueryMode SpatialQueryMode;

    }

    /// <summary>
    /// 使用POST请求模拟GET请求时，面积量算，距离量算协助类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class MeasureRequestParameter
#else
    public class MeasureRequestParameter
#endif
    {
        public MeasureRequestParameter(List<Point2D> points, Unit unit)
        {
            this._point2Ds = points;
            this._unit = unit;
        }

        private List<Point2D> _point2Ds;
        [JsonProperty("point2Ds")]
        public List<Point2D> Point2Ds
        {
            get
            {
                return this._point2Ds;
            }
            set
            {
                this._point2Ds = value;
            }
        }

        private Unit _unit = Unit.METER;
        [JsonProperty("unit")]
        public Unit Unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                this._unit = value;
            }
        }
    }
    /// <summary>
    /// 使用POST请求模拟GET请求时，Findpath协助类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class FindPathRequestParameter
#else
    public class FindPathRequestParameter
#endif
    {

        public FindPathRequestParameter(Object nodes, bool hasLeastEdgeCount, TransportationAnalystParameter parameter)
        {
            this.Nodes = nodes;
            this.Parameter = parameter;
            this.HasLeastEdgeCount = hasLeastEdgeCount;
        }

        [JsonProperty("nodes")]
        public Object Nodes;

        [JsonProperty("hasLeastEdgeCount")]
        public bool HasLeastEdgeCount;

        [JsonProperty("parameter")]
        public TransportationAnalystParameter Parameter;
    }

    /// <summary>
    /// 使用POST请求模拟GET请求时，ClosestFacilityPath协助类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class ClosestFacilityRequestParameter
#else
    public class ClosestFacilityRequestParameter
#endif
    {

        public ClosestFacilityRequestParameter(Object facilities, Object eventObject, int expectFacilityCount,
            bool fromEvent, double maxWeight, TransportationAnalystParameter parameter)
        {
            this.Facilities = facilities;
            this.Parameter = parameter;
            this.Event = eventObject;
            if (expectFacilityCount < 1)
            {
                expectFacilityCount = 1;
            }
            this.ExpectFacilityCount = expectFacilityCount;
            this.FromEvent = fromEvent;
            if (maxWeight < 0)
            {
                maxWeight = 0;
            }
            this.MaxWeight = maxWeight;
        }

        [JsonProperty("facilities")]
        public Object Facilities;

        [JsonProperty("event")]
        public Object Event;

        [JsonProperty("expectFacilityCount")]
        public int ExpectFacilityCount;

        [JsonProperty("fromEvent")]
        public bool FromEvent;

        [JsonProperty("maxWeight")]
        public double MaxWeight;

        [JsonProperty("parameter")]
        public TransportationAnalystParameter Parameter;
    }

    /// <summary>
    /// 使用POST请求模拟GET请求时，TSPPath协助类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class TSPPathRequestParameter
#else
    public class TSPPathRequestParameter
#endif
    {
        public TSPPathRequestParameter(Object nodes, bool endNodeAssigned, TransportationAnalystParameter parameter)
        {
            this.Nodes = nodes;
            this.Parameter = parameter;
            this.EndNodeAssigned = endNodeAssigned;
        }

        [JsonProperty("nodes")]
        public Object Nodes;

        [JsonProperty("endNodeAssigned")]
        public bool EndNodeAssigned;

        [JsonProperty("parameter")]
        public TransportationAnalystParameter Parameter;
    }

    /// <summary>
    /// 使用POST请求模拟GET请求时，MTSPPath协助类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class MTSPPathRequestParameter
#else
    public class MTSPPathRequestParameter
#endif
    {
        public MTSPPathRequestParameter(Object nodes, Object centers, bool hasLeastTotalCost, TransportationAnalystParameter parameter)
        {
            this.Nodes = nodes;
            this.Parameter = parameter;
            this.Centers = centers;
            this.HasLeastTotalCost = hasLeastTotalCost;
        }

        [JsonProperty("nodes")]
        public Object Nodes;

        [JsonProperty("centers")]
        public Object Centers;

        [JsonProperty("hasLeastTotalCost")]
        public bool HasLeastTotalCost;

        [JsonProperty("parameter")]
        public TransportationAnalystParameter Parameter;
    }

    /// <summary>
    /// 使用POST请求模拟GET请求时，weightMatrix协助类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class WeightMatrixRequestParameter<T>
#else
    public class WeightMatrixRequestParameter<T>
#endif
    {
        public WeightMatrixRequestParameter(List<T> nodes, TransportationAnalystParameter parameter)
        {
            this.Nodes = nodes;
            this.Parameter = parameter;
        }

        [JsonProperty("nodes")]
        public List<T> Nodes { get; set; }

        [JsonProperty("parameter")]
        public TransportationAnalystParameter Parameter { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class ServiceAreaRequestParameter<T>
#else
    public class ServiceAreaRequestParameter<T>
#endif
    {
        public ServiceAreaRequestParameter(List<T> centers, List<double> weights, bool isFromCenter, bool isCenterMutuallyExclusive, TransportationAnalystParameter parameter)
        {
            this.Centers = centers;
            this.Weights = weights;
            this.IsFromCenter = isFromCenter;
            this.IsCenterMutuallyExclusive = isCenterMutuallyExclusive;
            this.Parameter = parameter;
        }

        [JsonProperty("centers")]
        public List<T> Centers { get; set; }

        [JsonProperty("weights")]
        public List<double> Weights { get; set; }

        [JsonProperty("isFromCenter")]
        public bool IsFromCenter { get; set; }

        [JsonProperty("isCenterMutuallyExclusive")]
        public bool IsCenterMutuallyExclusive { get; set; }

        [JsonProperty("parameter")]
        public TransportationAnalystParameter Parameter { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class DatasetInfoRequestParameter
#else
    public class DatasetInfoRequestParameter
#endif
    {
        public DatasetInfoRequestParameter(string datasetName, DatasetType datasetType)
        {
            this.DatasetName = datasetName;
            this.DatasetType = datasetType;
        }

        [JsonProperty("datasetName")]
        public string DatasetName { get; set; }

        [JsonProperty("datasetType")]
        public DatasetType DatasetType { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class CopyDatasetRequestParameter
#else
    public class CopyDatasetRequestParameter
#endif
    {
        public CopyDatasetRequestParameter(string srcDatasourceName, string srcDatasetName, string destDatasetName)
        {
            this.SrcDatasourceName = srcDatasourceName;
            this.SrcDatasetName = srcDatasetName;
            this.DestDatasetName = destDatasetName;
        }

        [JsonProperty("srcDatasourceName")]
        public string SrcDatasourceName { get; set; }

        [JsonProperty("srcDatasetName")]
        public string SrcDatasetName { get; set; }

        [JsonProperty("destDatasetName")]
        public string DestDatasetName { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class DatasetBufferRequestParameter
#else
    public class DatasetBufferRequestParameter
#endif
    {
        public DatasetBufferRequestParameter(BufferAnalystParameter bufferQueryParameter,
            QueryParameter queryParameter, BufferResultSetting bufferResultSetting)
        {
            this.BufferAnalystParameter = bufferQueryParameter;
            if (bufferResultSetting != null)
            {
                this.DataReturnOption = bufferResultSetting.DataReturnOption;
                this.IsAttributeRetained = bufferResultSetting.IsAttributeRetained;
                this.IsUnion = bufferResultSetting.IsUnion;
            }
            this.FilterQueryParameter = queryParameter;
        }

        [JsonProperty("dataReturnOption")]
        public DataReturnOption DataReturnOption { get; set; }

        [JsonProperty("isAttributeRetained")]
        public bool IsAttributeRetained { get; set; }

        [JsonProperty("isUnion")]
        public bool IsUnion { get; set; }

        [JsonProperty("bufferAnalystParameter")]
        public BufferAnalystParameter BufferAnalystParameter { get; set; }

        [JsonProperty("filterQueryParameter")]
        public QueryParameter FilterQueryParameter { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class GeometryBufferRequestParameter
#else
    public class GeometryBufferRequestParameter
#endif
    {
        public GeometryBufferRequestParameter(Geometry sourceGeometry, BufferAnalystParameter bufferAnalystParameter)
        {
            this.SourceGeometry = sourceGeometry;
            this.AnalystParameter = bufferAnalystParameter;
        }

        [JsonProperty("sourceGeometry")]
        public Geometry SourceGeometry { get; set; }

        [JsonProperty("analystParameter")]
        public BufferAnalystParameter AnalystParameter { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class DatasetOverlayRequestParameter
#else
    public class DatasetOverlayRequestParameter
#endif
    {
        public DatasetOverlayRequestParameter(QueryParameter sourceDatasetFilter, string operateDataset, QueryParameter operateDatasetFilter, OverlayOperationType operation, Geometry[] operateRegions,
            DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
            this.SourceDatasetFilter = sourceDatasetFilter;
            this.OperateDataset = operateDataset;
            this.OperateDatasetFilter = operateDatasetFilter;
            this.Operation = operation;
            if (datasetOverlayResultSetting != null)
            {
                this.Tolerance = datasetOverlayResultSetting.Tolerance;
                this.DataReturnOption = datasetOverlayResultSetting.DataReturnOption;
                this.SourceDatasetFields = datasetOverlayResultSetting.SourceDatasetFields;
                this.OperateDatasetFields = datasetOverlayResultSetting.OperateDatasetFields;
                this.Tolerance = datasetOverlayResultSetting.Tolerance;
            }
            this.OperateRegions = operateRegions;
        }

        [JsonProperty("sourceDatasetFilter", NullValueHandling = NullValueHandling.Ignore)]
        public QueryParameter SourceDatasetFilter { get; set; }

        [JsonProperty("operateDataset", NullValueHandling = NullValueHandling.Ignore)]
        public string OperateDataset { get; set; }

        [JsonProperty("operateDatasetFilter", NullValueHandling = NullValueHandling.Ignore)]
        public QueryParameter OperateDatasetFilter { get; set; }

        [JsonProperty("operation", NullValueHandling = NullValueHandling.Ignore)]
        public OverlayOperationType Operation { get; set; }

        [JsonProperty("tolerance", NullValueHandling = NullValueHandling.Ignore)]
        public double Tolerance { get; set; }

        [JsonProperty("dataReturnOption", NullValueHandling = NullValueHandling.Ignore)]
        public DataReturnOption DataReturnOption { get; set; }

        [JsonProperty("operateRegions", NullValueHandling = NullValueHandling.Ignore)]
        public Geometry[] OperateRegions { get; set; }

        [JsonProperty("sourceDatasetFields", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SourceDatasetFields { get; set; }

        [JsonProperty("operateDatasetFields", NullValueHandling = NullValueHandling.Ignore)]
        public string[] OperateDatasetFields { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class GeometryOverlayRequestParameter
#else
    public class GeometryOverlayRequestParameter
#endif
    {
        public GeometryOverlayRequestParameter(Geometry sourceGeometry, Geometry operateGeometry, OverlayOperationType operation)
        {
            this.SourceGeometry = sourceGeometry;
            this.OperateGeometry = operateGeometry;
            this.Operation = operation;
        }

        [JsonProperty("sourceGeometry")]
        public Geometry SourceGeometry { get; set; }

        [JsonProperty("operateGeometry")]
        public Geometry OperateGeometry { get; set; }

        [JsonProperty("operation")]
        public OverlayOperationType Operation { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class ExtractRequestParameter
#else
    public class ExtractRequestParameter
#endif
    {
        public ExtractRequestParameter(QueryParameter filterQueryParameter, string zValueFieldName, double? resolution, ExtractParameter extractParameter, DataReturnOption resultSetting)
        {
            this.FilterQueryParameter = filterQueryParameter;
            this.ZValueFieldName = zValueFieldName;
            this.Resolution = resolution;
            this.ExtractParameter = extractParameter;
            this.ResultSetting = resultSetting;
        }

        public ExtractRequestParameter(Point2D[] points, double[] zValues, double resolution, ExtractParameter extractParameter, DataReturnOption resultSetting)
        {
            this.Points = points;
            this.ZValues = zValues;
            this.Resolution = resolution;
            this.ExtractParameter = extractParameter;
            this.ResultSetting = resultSetting;
        }

        [JsonProperty("filterQueryParameter", NullValueHandling = NullValueHandling.Ignore)]
        public QueryParameter FilterQueryParameter { get; set; }

        [JsonProperty("zValueFieldName", NullValueHandling = NullValueHandling.Ignore)]
        public string ZValueFieldName { get; set; }

        [JsonProperty("resolution", NullValueHandling = NullValueHandling.Ignore)]
        public double? Resolution { get; set; }

        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public Point2D[] Points { get; set; }

        [JsonProperty("zValues", NullValueHandling = NullValueHandling.Ignore)]
        public double[] ZValues { get; set; }

        [JsonProperty("extractParameter", NullValueHandling = NullValueHandling.Ignore)]
        public ExtractParameter ExtractParameter { get; set; }

        [JsonProperty("resultSetting", NullValueHandling = NullValueHandling.Ignore)]
        public DataReturnOption ResultSetting { get; set; }
    }

}
