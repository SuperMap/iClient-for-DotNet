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
    internal class SpatialAnalystProvider
    {
        private string _serviceUrl = string.Empty;

        public SpatialAnalystProvider(string serviceUrl)
        {
            this._serviceUrl = serviceUrl;
        }

        #region 获取服务发布的信息
        public List<string> GetDatasourceNames()
        {
            List<SpatialAnalystDatasetInfoResult> datasetInfos = GetSpatialAnalystDatasetInfoInternal();
            List<string> datasourceNames = null;
            Dictionary<string, string> tempNames = new Dictionary<string, string>();
            if (datasetInfos != null && datasetInfos.Count > 0)
            {
                datasourceNames = new List<string>();
                for (int i = 0; i < datasetInfos.Count; i++)
                {
                    if (datasetInfos[i] != null && datasetInfos[i].DatasetInfo != null
                        && !tempNames.ContainsKey(datasetInfos[i].DatasetInfo.DataSourceName))
                    {
                        tempNames.Add(datasetInfos[i].DatasetInfo.DataSourceName, datasetInfos[i].DatasetInfo.DataSourceName);
                        datasourceNames.Add(datasetInfos[i].DatasetInfo.DataSourceName);
                    }
                }
            }
            return datasourceNames;
        }

        public List<DatasetInfo> GetDatasetInfos(string datasourceName)
        {
            List<SpatialAnalystDatasetInfoResult> datasetInfoResults = GetSpatialAnalystDatasetInfoInternal();
            List<DatasetInfo> datasetInfos = null;
            if (datasetInfoResults != null && datasetInfoResults.Count > 0)
            {
                datasetInfos = new List<DatasetInfo>();
                for (int i = 0; i < datasetInfoResults.Count; i++)
                {
                    if (datasetInfoResults[i] != null && datasetInfoResults[i].DatasetInfo != null
                        && datasourceName == datasetInfoResults[i].DatasetInfo.DataSourceName)
                    {
                        datasetInfos.Add(datasetInfoResults[i].DatasetInfo);
                    }
                }
            }
            return datasetInfos;
        }

        public DatasetInfo GetDatasetInfo(string datasourceName, string datasetName)
        {
            List<SpatialAnalystDatasetInfoResult> datasetInfoResults = GetSpatialAnalystDatasetInfoInternal();
            DatasetInfo datasetInfo = null;
            if (datasetInfoResults != null && datasetInfoResults.Count > 0)
            {
                for (int i = 0; i < datasetInfoResults.Count; i++)
                {
                    if (datasetInfoResults[i] != null && datasetInfoResults[i].DatasetInfo != null
                        && datasourceName == datasetInfoResults[i].DatasetInfo.DataSourceName &&
                        datasetName == datasetInfoResults[i].DatasetInfo.Name)
                    {
                        datasetInfo = datasetInfoResults[i].DatasetInfo;
                        break;
                    }
                }
            }
            return datasetInfo;
        }

        private List<SpatialAnalystDatasetInfoResult> GetSpatialAnalystDatasetInfoInternal()
        {
            string baseUrl = string.Format("{0}/spatialanalyst/datasets.rjson", this._serviceUrl);
            string requestResult = SynchHttpRequest.GetRequestString(baseUrl);
            return JsonConvert.DeserializeObject<List<SpatialAnalystDatasetInfoResult>>(requestResult);
        }
        #endregion

        #region Buffer
        public DatasetSpatialAnalystResult Buffer(string datasetName, BufferAnalystParameter bufferAnalystParameter, QueryParameter filterQueryParameter, BufferResultSetting bufferResultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/datasets/{1}/buffer.json?returnContent=true", this._serviceUrl,
                HttpUtility.UrlEncode(datasetName));
            DatasetBufferRequestParameter parameter = new DatasetBufferRequestParameter(bufferAnalystParameter, filterQueryParameter, bufferResultSetting);
            string strBufferResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(parameter));
            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strBufferResult);
        }

        public GeometrySpatialAnalystResult Buffer(Geometry geometry, BufferAnalystParameter bufferAnalystParameter)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/geometry/buffer.json?returnContent=true", this._serviceUrl);
            GeometryBufferRequestParameter parameter = new GeometryBufferRequestParameter(geometry, bufferAnalystParameter);
            string strBufferResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(parameter));
            return JsonConvert.DeserializeObject<GeometrySpatialAnalystResult>(strBufferResult);
        }
        #endregion

        #region Overlay

        public DatasetSpatialAnalystResult Overlay(string sourceDataset, QueryParameter sourceDatasetFilter, string operateDataset, QueryParameter operateDatasetFilter, OverlayOperationType operation, DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/datasets/{1}/overlay.json?returnContent=true", this._serviceUrl, HttpUtility.UrlEncode(sourceDataset));
            DatasetOverlayRequestParameter parameter = new DatasetOverlayRequestParameter(sourceDatasetFilter, operateDataset, operateDatasetFilter, operation, null, datasetOverlayResultSetting);
            string strOverlayResul = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(parameter));

            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strOverlayResul);
        }

        public DatasetSpatialAnalystResult Overlay(string sourceDataset, QueryParameter sourceDatasetFilter, Geometry[] operateRegions, OverlayOperationType operation, DatasetOverlayResultSetting datasetOverlayResultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/datasets/{1}/overlay.json?returnContent=true", this._serviceUrl, HttpUtility.UrlEncode(sourceDataset));
            DatasetOverlayRequestParameter parameter = new DatasetOverlayRequestParameter(sourceDatasetFilter, null, null, operation, operateRegions, datasetOverlayResultSetting);
            string strOverlayResul = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(parameter));

            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strOverlayResul);
        }

        public GeometrySpatialAnalystResult Overlay(Geometry sourceGeometry, Geometry operateGeometry, OverlayOperationType operation)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/geometry/overlay.json?returnContent=true", this._serviceUrl);
            GeometryOverlayRequestParameter parameter = new GeometryOverlayRequestParameter(sourceGeometry, operateGeometry, operation);
            string strOverlayResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(parameter));

            return JsonConvert.DeserializeObject<GeometrySpatialAnalystResult>(strOverlayResult);
        }
        #endregion

        #region isoregion
        public DatasetSpatialAnalystResult IsoRegion(string pointDataset, QueryParameter filterQueryParameter, string zValueField, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            return IsoRegionInternal(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
        }

        public DatasetSpatialAnalystResult IsoRegion(string gridDataset, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            return IsoRegionInternal(gridDataset, null, null, null, parameter, resultSetting);
        }

        public DatasetSpatialAnalystResult IsoRegionInternal(string DatasetName, QueryParameter filterQueryParameter, string zValueField, double? resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/datasets/{1}/isoregion.json?returnContent=true", this._serviceUrl, DatasetName);
            ExtractRequestParameter isoRegionParameter = new ExtractRequestParameter(filterQueryParameter, zValueField, resolution, parameter, resultSetting);
            string strIsoRegionResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(isoRegionParameter));

            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strIsoRegionResult);
        }

        public DatasetSpatialAnalystResult IsoRegion(Point2D[] points, double[] zValues, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/geometry/isoregion.json?returnContent=true", this._serviceUrl);
            ExtractRequestParameter isoRegionParameter = new ExtractRequestParameter(points, zValues, resolution, parameter, resultSetting);
            string strIsoRegionResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(isoRegionParameter));

            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strIsoRegionResult);
        }

        #endregion


        #region interpolate
        public DatasetSpatialAnalystResult Interpolate(string pointDataset, InterpolationParameter parameter)
        {
            string baseUrl = "";
            string resourceType = "";
            System.Type parameterType = parameter.GetType();
            switch (parameterType.Name)
            {
                case "InterpolationDensityParameter":
                    resourceType = "density";
                    break;
                case "InterpolationIDWParameter":
                    resourceType = "idw";
                    break;
                case "InterpolationRBFParameter":
                    resourceType = "rbf";
                    break;
                case "InterpolationKrigingParameter":
                    resourceType = "kriging";
                    break;
                default:
                    break;
            }
            baseUrl = string.Format("{0}/spatialanalyst/datasets/{1}/interpolation/{2}.json?returnContent=true", this._serviceUrl, HttpUtility.HtmlEncode(pointDataset), resourceType);
            string json = string.Empty;
            json = JsonConvert.SerializeObject(parameter);

            string interpolateResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, json);

            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(interpolateResult);
        }
        #endregion


        #region isoline
        public DatasetSpatialAnalystResult IsoLine(string pointDataset, QueryParameter filterQueryParameter, string zValueField, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            return IsoLineInternal(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
        }

        public DatasetSpatialAnalystResult IsoLine(string gridDataset, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            return IsoLineInternal(gridDataset, null, null, null, parameter, resultSetting);
        }

        public DatasetSpatialAnalystResult IsoLineInternal(string DatasetName, QueryParameter filterQueryParameter, string zValueField, double? resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/datasets/{1}/isoline.json?returnContent=true", this._serviceUrl, DatasetName);
            ExtractRequestParameter isoLineParameter = new ExtractRequestParameter(filterQueryParameter, zValueField, resolution, parameter, resultSetting);
            string strIsoLineResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(isoLineParameter));
            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strIsoLineResult);
        }

        public DatasetSpatialAnalystResult IsoLine(Point2D[] points, double[] zValues, double resolution, ExtractParameter parameter, DataReturnOption resultSetting)
        {
            string baseUrl = string.Format("{0}/spatialanalyst/geometry/isoline.json?returnContent=true", this._serviceUrl);
            ExtractRequestParameter isoLineParameter = new ExtractRequestParameter(points, zValues, resolution, parameter, resultSetting);
            string strIsoLineResult = SynchHttpRequest.GetRequestString(baseUrl, HttpRequestMethod.POST, JsonConvert.SerializeObject(isoLineParameter));

            return JsonConvert.DeserializeObject<DatasetSpatialAnalystResult>(strIsoLineResult);
        }

        #endregion

    }
}
