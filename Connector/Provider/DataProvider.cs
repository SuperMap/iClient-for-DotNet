using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SuperMap.Connector.Utility;
using SuperMap.Connector;
#if WINDOWS_PHONE
using System.Net;
#else
using System.Web;
#endif

namespace SuperMap.Connector
{
    /// <summary>
    /// Data服务提供者。
    /// </summary>
    internal class DataProvider
    {
        private string _serviceUrl;
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">服务地址。</param>
        public DataProvider(string serviceUrl)
        {
            this._serviceUrl = serviceUrl;
        }

        #region Feature
        /// <summary>
        /// 在指定数据集中增加一组同类型的要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据集名称。</param>
        /// <param name="targetFeatures">待添加的要素列表，列表中的要素必须是同一种类型。</param>
        /// <returns></returns>
        public EditResult AddFeatures(string datasourceName, string datasetName, List<Feature> targetFeatures)
        {
            EditResult editResult = new EditResult();
            if (string.IsNullOrEmpty(datasourceName))
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "datasourceName");
                return editResult;
            }
            if (string.IsNullOrEmpty(datasetName))
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "datasetName");
                return editResult;
            }
            if (targetFeatures == null || targetFeatures.Count <= 0)
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "targetFeatures");
                return editResult;
            }

            int featureCount = targetFeatures.Count;
            for (int i = 0; i < featureCount; i++)
            {
                if (targetFeatures[i].FieldNames == null)
                {
                    targetFeatures[i].FieldNames = new string[] { };
                }
                if (targetFeatures[i].FieldValues == null)
                {
                    targetFeatures[i].FieldValues = new string[] { };
                }
            }
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/features.json?returnContent=true", this._serviceUrl,
                datasourceName, datasetName);
            string postData = JsonConvert.SerializeObject(targetFeatures);
            string requestResultJson = string.Empty;

            try
            {
                requestResultJson = SynchHttpRequest.GetRequestString(uri, postData);
            }
            catch (ServiceException e)
            {
                editResult.Succeed = false;
                editResult.Message = e.Message;
                return editResult;
            }
            //处理返回的ids ,[167,168] 
            string[] idsStr = requestResultJson.Replace("[", "").Replace("]", "").Trim().Split(',');
            int idsNum = idsStr.Length;
            editResult.Ids = new int[idsNum];
            for (int i = 0; i < idsNum; i++)
            {
                int.TryParse(idsStr[i].Trim(), out editResult.Ids[i]);
            }
            //判断ids的个数，小于等于0,即判定为添加要素错误
            if (idsNum > 0)
            {
                editResult.Succeed = true;
            }
            else
            {
                editResult.Succeed = false;
            }
            return editResult;
        }

        /// <summary>
        /// 在指定的数据集中删除一组要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据集名称。</param>
        /// <param name="ids">待删除要素的 ID 数组。</param>
        /// <returns>编辑结果。</returns>
        public EditResult DeleteFeatures(string datasourceName, string datasetName, int[] ids)
        {
            EditResult editResult = new EditResult();
            if (string.IsNullOrEmpty(datasourceName))
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "datasourceName");
                return editResult;
            }
            if (string.IsNullOrEmpty(datasetName))
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "datasetName");
                return editResult;
            }
            if (ids == null || ids.Length <= 0)
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "ids");
                return editResult;
            }
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/features.json?_method=DELETE", this._serviceUrl,
                datasourceName, datasetName);
            string postData = JsonConvert.SerializeObject(ids);
            string requestResultJson = string.Empty;

            try
            {
                requestResultJson = SynchHttpRequest.GetRequestString(uri, postData);
                editResult = JsonConvert.DeserializeObject<EditResult>(requestResultJson);
            }
            catch (ServiceException e)
            {
                editResult.Succeed = false;
                editResult.Message = e.Message;
                return editResult;
            }
            return editResult;
        }

        /// <summary>
        /// 在指定的数据集中，更新一组要素。
        /// 参数 targetFeatures 是新要素列表，其要素 ID 与数据集中待更新的要素 ID 相同，根据 ID 查找到待更新的要素， 然后将原要素更新到新的要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据源名称。</param>
        /// <param name="targetFeatures">新要素列表。其 ID 与要更新的要素 ID 相同。</param>
        /// <returns></returns>
        public EditResult UpdateFeatures(string datasourceName, string datasetName, List<Feature> targetFeatures)
        {
            EditResult editResult = new EditResult();
            if (string.IsNullOrEmpty(datasourceName))
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "datasourceName");
                return editResult;
            }
            if (string.IsNullOrEmpty(datasetName))
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "datasetName");
                return editResult;
            }
            if (targetFeatures == null || targetFeatures.Count <= 0)
            {
                editResult.Succeed = false;
                editResult.Message = string.Format(Resources.ParamIsNotNull, "targetFeatures");
                return editResult;
            }
            else
            {
                int featureCount = targetFeatures.Count;
                for (int i = 0; i < featureCount; i++)
                {
                    if (targetFeatures[i].Id <= 0)
                    {
                        editResult.Succeed = false;
                        editResult.Message = string.Format(Resources.ParamIsInvalid, "Feature.Id");
                        return editResult;
                    }
                    else if (targetFeatures[i].Geometry != null)
                    {
                        targetFeatures[i].Geometry.Id = targetFeatures[i].Id;
                    }
                    if (targetFeatures[i].FieldNames == null)
                    {
                        targetFeatures[i].FieldNames = new string[] { };
                    }
                    if (targetFeatures[i].FieldValues == null)
                    {
                        targetFeatures[i].FieldValues = new string[] { };
                    }
                }
            }
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/features.json?_method=PUT", this._serviceUrl,
                datasourceName, datasetName);
            string postData = JsonConvert.SerializeObject(targetFeatures);
            string requestResultJson = string.Empty;
            try
            {
                requestResultJson = SynchHttpRequest.GetRequestString(uri, postData);
                editResult = JsonConvert.DeserializeObject<EditResult>(requestResultJson);
            }
            catch (ServiceException e)
            {
                editResult.Succeed = false;
                editResult.Message = e.Message;
                return editResult;
            }
            return editResult;
        }

        ////根据Point2D计算最小外接矩形
        //private Rectangle2D CalcBounds(Point2D[] point2Ds)
        //{
        //    if (point2Ds == null)
        //    {
        //        throw new InvalidOperationException("The \"Points\" field is null, can't calculate bounds.");
        //    }
        //    Rectangle2D bounds = new Rectangle2D();
        //    int maxX, minX, maxY, minY;
        //    maxX = minX = maxY = minY = 0;

        //    for (int i = 1; i < point2Ds.Length; i++)	//从第二个点开始遍历比较。
        //    {
        //        if (point2Ds[i] == null)
        //        {
        //            continue;
        //        }

        //        if (point2Ds[i].X < point2Ds[minX].X)
        //        {
        //            minX = i;
        //        }
        //        else if (point2Ds[i].X > point2Ds[maxX].X)
        //        {
        //            maxX = i;
        //        }

        //        if (point2Ds[i].Y < point2Ds[minY].Y)
        //        {
        //            minY = i;
        //        }
        //        else if (point2Ds[i].Y > point2Ds[maxY].Y)
        //        {
        //            maxY = i;
        //        }
        //    }

        //    bounds.LeftBottom.X = point2Ds[minX].X;
        //    bounds.LeftBottom.Y = point2Ds[minY].Y;
        //    bounds.RightTop.X = point2Ds[maxX].X;
        //    bounds.RightTop.Y = point2Ds[maxY].Y;
        //    return bounds;
        //}

        /// <summary>
        /// 通过 SQL 查询条件获取要素。
        /// </summary>
        /// <param name="datasetNames">
        /// <para>数据集名称数组(datasourceName:datasetName),必选参数。 </para>
        /// <para>数据集名称由数据源名和数据集名构成，例如 World 数据源下的 Ocean 数据集，这里的数据集名称就是“World:Ocean”。</para>
        /// </param>
        /// <param name="queryParam">查询参数。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, QueryParameter queryParam)
        {
            return GetFeature(datasetNames, queryParam, 0);
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
        public List<Feature> GetFeature(string[] datasetNames, QueryParameter queryParam, int maxFeatures)
        {
            if (datasetNames == null || datasetNames.Length <= 0 || string.IsNullOrEmpty(datasetNames[0]))
            {
                throw new ArgumentNullException("datasetNames", Resources.ArgumentIsNotNull);
            }
            if (queryParam == null)
            {
                queryParam = new QueryParameter();
            }
            GetFeatureResource featureResource = new GetFeatureResource();

            featureResource.DatasetNames = datasetNames;
            featureResource.QueryParameter = queryParam;

            featureResource.GetFeatureMode = GetFeatureMode.SQL;

            return GetFeatureInternal(featureResource, maxFeatures);
        }

        /// <summary>
        /// 获取落在指定几何对象的缓冲区内的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName),必选参数。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="bufferDistance">缓冲区的半径，单位同当前数据集坐标单位（coordUnit）。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, double bufferDistance, string[] fields)
        {
            return GetFeature(datasetNames, geometry, bufferDistance, string.Empty, fields);
        }

        /// <summary>
        /// 获取落在指定几何对象的缓冲区内的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName),必选参数。</param>
        /// <param name="geometry">几何对象,必选参数。</param>
        /// <param name="bufferDistance">缓冲区的半径，单位同当前数据集坐标单位（coordUnit）。</param>
        /// <param name="attributeFilter">属性查询过滤条件。如 fieldValue &lt; 100，name like '%酒店%'。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, double bufferDistance, string attributeFilter, string[] fields)
        {
            if (datasetNames == null || datasetNames.Length <= 0 || string.IsNullOrEmpty(datasetNames[0]))
            {
                throw new ArgumentNullException("datasetNames", Resources.ArgumentIsNotNull);
            }
            if (geometry == null)
            {
                throw new ArgumentNullException("geometry", Resources.ArgumentIsNotNull);
            }
            if (bufferDistance <= 0)
            {
                throw new ArgumentException(string.Format(Resources.ArgumentMoreThanZero, "bufferDistance"));
            }
            GetFeatureResource featureResource = new GetFeatureResource();
            featureResource.DatasetNames = datasetNames;
            featureResource.Distance = bufferDistance;
            featureResource.Geometry = geometry;
            if (fields != null)
            {
                featureResource.QueryParameter = new QueryParameter();
                featureResource.QueryParameter.Fields = fields;
            }
            featureResource.AttributeFilter = attributeFilter;
            if (string.IsNullOrEmpty(attributeFilter))
            {
                featureResource.GetFeatureMode = GetFeatureMode.BUFFER;
            }
            else
            {
                featureResource.GetFeatureMode = GetFeatureMode.BUFFER_ATTRIBUTEFILTER;
            }
            return GetFeatureInternal(featureResource, 0);
        }

        /// <summary>
        /// 获取与指定几何对象具有特定空间查询模式的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间查询模式。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, SpatialQueryMode spatialQueryMode, string[] fields)
        {
            return GetFeature(datasetNames, geometry, spatialQueryMode, string.Empty, fields);
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
        public List<Feature> GetFeature(string[] datasetNames, Geometry geometry, SpatialQueryMode spatialQueryMode, string attributeFilter, string[] fields)
        {
            if (datasetNames == null || datasetNames.Length <= 0 || string.IsNullOrEmpty(datasetNames[0]))
            {
                throw new ArgumentNullException("datasetNames", Resources.ArgumentIsNotNull);
            }
            if (geometry == null)
            {
                throw new ArgumentNullException("geometry", Resources.ArgumentIsNotNull);
            }
            GetFeatureResource featureResource = new GetFeatureResource();
            featureResource.DatasetNames = datasetNames;
            featureResource.Geometry = geometry;
            featureResource.SpatialQueryMode = spatialQueryMode;
            featureResource.AttributeFilter = attributeFilter;
            if (fields != null)
            {
                featureResource.QueryParameter = new QueryParameter();
                featureResource.QueryParameter.Fields = fields;
            }
            if (string.IsNullOrEmpty(attributeFilter))
            {
                featureResource.GetFeatureMode = GetFeatureMode.SPATIAL;
            }
            else
            {
                featureResource.GetFeatureMode = GetFeatureMode.SPATIAL_ATTRIBUTEFILTER;
            }
            return GetFeatureInternal(featureResource, 0);
        }

        /// <summary>
        /// 根据指定要素 ID 获取指定数据集中的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="ids">要素 ID。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, int[] ids, string[] fields)
        {
            if (datasetNames == null || datasetNames.Length <= 0 || string.IsNullOrEmpty(datasetNames[0]))
            {
                throw new ArgumentNullException("datasetNames", Resources.ArgumentIsNotNull);
            }

            if (ids == null || ids.Length <= 0)
            {
                throw new ArgumentNullException("ids", Resources.ArgumentIsNotNull);
            }
            GetFeatureResource featureResource = new GetFeatureResource();
            featureResource.DatasetNames = datasetNames;
            featureResource.Ids = ids;
            if (fields != null)
            {
                featureResource.QueryParameter = new QueryParameter();
                featureResource.QueryParameter.Fields = fields;
            }
            featureResource.GetFeatureMode = GetFeatureMode.ID;
            return GetFeatureInternal(featureResource, 0);
        }

        /// <summary>
        /// 获取在指定空间范围内的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="bounds">指定的查询范围。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, Rectangle2D bounds, string[] fields)
        {
            return GetFeature(datasetNames, bounds, string.Empty, fields);
        }

        /// <summary>
        /// 获取在指定空间范围内，并满足一定属性过滤条件的要素。
        /// </summary>
        /// <param name="datasetNames">数据集名称数组(datasourceName:datasetName)，如 World:Capitals，必选参数。</param>
        /// <param name="bounds">指定的查询范围。</param>
        /// <param name="attributeFilter">属性过滤条件。</param>
        /// <param name="fields">待返回的字段数组。当该参数为 null 时，返回全部字段。</param>
        /// <returns>要素集合。</returns>
        public List<Feature> GetFeature(string[] datasetNames, Rectangle2D bounds, string attributeFilter, string[] fields)
        {
            if (datasetNames == null || datasetNames.Length <= 0 || string.IsNullOrEmpty(datasetNames[0]))
            {
                throw new ArgumentNullException("datasetNames", Resources.ArgumentIsNotNull);
            }
            if (bounds == null)
            {
                throw new ArgumentNullException("bounds", Resources.ArgumentIsNotNull);
            }
            GetFeatureResource featureResource = new GetFeatureResource();
            featureResource.DatasetNames = datasetNames;
            featureResource.Bounds = bounds;
            featureResource.AttributeFilter = attributeFilter;
            if (fields != null)
            {
                featureResource.QueryParameter = new QueryParameter();
                featureResource.QueryParameter.Fields = fields;
            }
            //attributeFilter存在属性过滤条件的，使用 BOUNDS_ATTRIBUTEFILTER 方式
            if (string.IsNullOrEmpty(attributeFilter))
            {
                featureResource.GetFeatureMode = GetFeatureMode.BOUNDS;
            }
            else
            {
                featureResource.GetFeatureMode = GetFeatureMode.BOUNDS_ATTRIBUTEFILTER;
            }
            return GetFeatureInternal(featureResource, 0);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureResource"></param>
        /// <param name="maxFeatures"></param>
        /// <returns></returns>
        private List<Feature> GetFeatureInternal(GetFeatureResource featureResource, int maxFeatures)
        {
            string maxFeaturesStr = "";
            if (maxFeatures > 0)
            {
                maxFeaturesStr = string.Format("&fromIndex=0&toIndex={0}", maxFeatures - 1);
            }

            string uri = string.Format("{0}/data/featureResults.json?returnContent=true{1}", this._serviceUrl, maxFeaturesStr);

            string postData = JsonConvert.SerializeObject(featureResource);
            string requestResultJson = SynchHttpRequest.GetRequestString(uri, postData);

            FeaturesResourceResult featuresResult = JsonConvert.DeserializeObject<FeaturesResourceResult>(requestResultJson);

            return featuresResult.Features;
        }

        #endregion

        #region DataSource
        public List<DatasourceInfo> GetDatasourceInfos()
        {
            string uri = string.Format("{0}/data/datasources.json", this._serviceUrl);
            string result = SynchHttpRequest.GetRequestString(uri);
            Dictionary<string, object> resultHash = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            if (resultHash != null && resultHash.ContainsKey("datasourceNames") && resultHash["datasourceNames"] != null)
            {
                List<string> dataSourceNames = JsonConvert.DeserializeObject<List<string>>(resultHash["datasourceNames"].ToString());
                if (dataSourceNames != null && dataSourceNames.Count > 0)
                {
                    List<DatasourceInfo> dataSourceInfos = new List<DatasourceInfo>();
                    for (int i = 0; i < dataSourceNames.Count; i++)
                    {
                        dataSourceInfos.Add(this.GetDatasourceInfo(dataSourceNames[i]));
                    }
                    return dataSourceInfos;
                }
            }
            return null;
        }

        public DatasourceInfo GetDatasourceInfo(string datasourceName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
#else
            if(string.IsNullOrEmpty(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
#endif
            string uri = string.Format("{0}/data/datasources/{1}.json", this._serviceUrl, HttpUtility.UrlEncode(datasourceName));
            string result = SynchHttpRequest.GetRequestString(uri);
            Dictionary<string, object> hashResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            if (hashResult != null && hashResult.ContainsKey("datasourceInfo") && hashResult["datasourceInfo"] != null)
            {
                return JsonConvert.DeserializeObject<DatasourceInfo>(hashResult["datasourceInfo"].ToString());
            }
            return null;
        }

        public bool UpdateDatasourceInfo(string datasourceName, DatasourceInfo newDatasourceInfo)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
#else
            if(string.IsNullOrEmpty(datasourceName))
            {
                throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            }
#endif
            if (newDatasourceInfo == null)
            {
                throw new ArgumentNullException("newDataSourceInfo", Resources.ArgumentIsNotNull);
            }
            string baseUri = string.Format("{0}/data/datasources/{1}.json?",
                this._serviceUrl, HttpUtility.UrlEncode(datasourceName));
            string result = SynchHttpRequest.GetRequestString(baseUri, HttpRequestMethod.PUT, JsonConvert.SerializeObject(newDatasourceInfo));
            Succeed succeed = JsonConvert.DeserializeObject<Succeed>(result);
            return succeed.succeed;
        }
        #endregion

        #region FieldInfo
        public List<FieldInfo> GetFieldInfos(string datasourceName, string datasetName)
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
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/fields.json",
                this._serviceUrl, HttpUtility.UrlEncode(datasourceName), HttpUtility.UrlEncode(datasetName));
            string result = SynchHttpRequest.GetRequestString(uri);
            Dictionary<string, object> hashResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            if (hashResult != null && hashResult.ContainsKey("fieldNames") && hashResult["fieldNames"] != null)
            {
                string[] fieldNames = JsonConvert.DeserializeObject<string[]>(hashResult["fieldNames"].ToString());
                if (fieldNames != null && fieldNames.Length > 0)
                {
                    List<FieldInfo> fieldInfos = new List<FieldInfo>();
                    for (int i = 0; i < fieldNames.Length; i++)
                    {
                        fieldInfos.Add(GetFieldInfo(datasourceName, datasetName, fieldNames[i]));
                    }
                    return fieldInfos;
                }
            }
            return null;
        }

        public FieldInfo GetFieldInfo(string datasourceName, string datasetName, string fieldName)
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
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
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
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
            }
#endif
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/fields/{3}.json?",
               this._serviceUrl, HttpUtility.UrlEncode(datasourceName), HttpUtility.UrlEncode(datasetName), HttpUtility.UrlEncode(fieldName));
            string result = SynchHttpRequest.GetRequestString(uri);
            Dictionary<string, object> hashFieldInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            if (hashFieldInfo != null && hashFieldInfo.ContainsKey("fieldInfo") && hashFieldInfo["fieldInfo"] != null)
            {
                return JsonConvert.DeserializeObject<FieldInfo>(hashFieldInfo["fieldInfo"].ToString());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新指定数据集的字段信息。
        /// </summary>
        /// <param name="datasourceName"></param>
        /// <param name="datasetName"></param>
        /// <param name="fieldName"></param>
        /// <param name="newFiledInfo"></param>
        /// <returns></returns>
        public bool UpdateField(string datasourceName, string datasetName, string fieldName, FieldInfo newFiledInfo)
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
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
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
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
            }
#endif
            if (newFiledInfo == null)
            {
                throw new ArgumentNullException("newFiledInfo", Resources.ArgumentIsNotNull);
            }
            FieldInfo currentFieldInfo = GetFieldInfo(datasourceName, datasetName, fieldName);
            currentFieldInfo.Caption = newFiledInfo.Caption;
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/fields/{3}.json?_method=PUT",
                this._serviceUrl, HttpUtility.UrlEncode(datasourceName), HttpUtility.UrlEncode(datasetName),
                HttpUtility.UrlEncode(fieldName));
            string result = SynchHttpRequest.GetRequestString(uri, JsonConvert.SerializeObject(currentFieldInfo));
            return JsonConvert.DeserializeObject<Succeed>(result).succeed;
        }

        public bool CreateField(string datasourceName, string datasetName, FieldInfo filedInfo)
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
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/fields.json?",
                this._serviceUrl, HttpUtility.UrlEncode(datasourceName), HttpUtility.UrlEncode(datasetName));
            string result = SynchHttpRequest.GetRequestString(uri, JsonConvert.SerializeObject(filedInfo));
            return JsonConvert.DeserializeObject<Succeed>(result).succeed;
        }

        public bool DeleteField(string datasourceName, string datasetName, string fieldName)
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
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
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
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
            }
#endif
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/fields/{3}.json?_method=DELETE",
               this._serviceUrl, HttpUtility.UrlEncode(datasourceName),
               HttpUtility.UrlEncode(datasetName), HttpUtility.UrlEncode(fieldName));
            string result = SynchHttpRequest.GetRequestString(uri);
            return JsonConvert.DeserializeObject<Succeed>(result).succeed;
        }
        #endregion

        #region Dataset

        /// <summary>
        /// 获取指定数据源的指定数据集信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必选参数。</param>
        /// <param name="datasetName">数据集名称，必选参数。</param>
        /// <returns>数据集信息。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        public DatasetInfo GetDatasetInfo(string datasourceName, string datasetName)
        {
            if (string.IsNullOrEmpty(datasourceName)) throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(datasetName)) throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            string uri = string.Format("{0}/data/datasources/name/{1}/datasets/name/{2}.json ", this._serviceUrl, datasourceName, datasetName);
            string result = SynchHttpRequest.GetRequestString(uri);
            DatesetResourceResult datasetResult = JsonConvert.DeserializeObject<DatesetResourceResult>(result);
            return datasetResult.DatasetInfo;
        }

        /// <summary>
        /// 在指定的数据源中，根据指定的数据集信息创建一个新的数据集。
        /// </summary>
        /// <param name="datasourceName">数据源名称，必选参数。</param>
        /// <param name="datasetName">数据集名称，必选参数。</param>
        /// <param name="datasetType"> 数据集类型，必选参数。</param>
        /// <returns>数据集创建成功返回 true， 否则返回 false。</returns>
        /// <exception cref="ArgumentNullException">参数 datasourceName、datasetName 为空时抛出异常。</exception>
        public bool CreateDataset(string datasourceName, string datasetName, DatasetType datasetType)
        {
            if (string.IsNullOrEmpty(datasourceName)) throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(datasetName)) throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            string uri = string.Format("{0}/data/datasources/{1}/datasets.json", this._serviceUrl, datasourceName);
            DatasetInfoRequestParameter datasetInfo = new DatasetInfoRequestParameter(datasetName, datasetType);
            string result = SynchHttpRequest.GetRequestString(uri, JsonConvert.SerializeObject(datasetInfo));
            EditResult datasetResult = JsonConvert.DeserializeObject<EditResult>(result);
            return datasetResult.Succeed;
        }

        /// <summary>
        /// 在指定的数据源中，根据指定的数据集信息删除一个数据集。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据集名称。</param>
        /// <returns>数据集删除成功返回 true，否则返回 false。</returns>
        public bool DeleteDataset(string datasourceName, string datasetName)
        {
            if (string.IsNullOrEmpty(datasourceName)) throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(datasetName)) throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}.json?_method=DELETE", this._serviceUrl, datasourceName, datasetName);
            string result = SynchHttpRequest.GetRequestString(uri);
            EditResult datasetResult = JsonConvert.DeserializeObject<EditResult>(result);
            return datasetResult.Succeed;
        }

        /// <summary>
        /// 在指定的数据源中，更新指定数据集的信息。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">待更新的数据集的名称。</param>
        /// <param name="newDatasetInfo">新的数据集信息。</param>
        /// <returns>数据集创建成功返回 true， 否则返回 false。</returns>
        public bool UpdateDatasetInfo(string datasourceName, string datasetName, DatasetInfo newDatasetInfo)
        {
            if (string.IsNullOrEmpty(datasourceName)) throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(datasetName)) throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}.json", this._serviceUrl, datasourceName, datasetName);
            string result = SynchHttpRequest.GetRequestString(uri, HttpRequestMethod.PUT, JsonConvert.SerializeObject(newDatasetInfo));

            EditResult datasetResult = JsonConvert.DeserializeObject<EditResult>(result);
            return datasetResult.Succeed;
        }

        /// <summary>
        /// <para>复制数据集。</para>
        /// <para>从指定的源数据源中，复制指定的源数据集到指定的目标数据源中的目标数据集。</para>
        /// </summary>
        /// <param name="srcDatasourceName">源数据源名称。</param>
        /// <param name="srcDatasetName">源数据集名称。</param>
        /// <param name="destDatasourceName">目标数据源名称。</param>
        /// <param name="destDatasetName">目标数据集名称。</param>
        /// <returns>数据集复制成功返回 true，否则返回 false。</returns>
        public bool CopyDataset(string srcDatasourceName, string srcDatasetName, string destDatasourceName, string destDatasetName)
        {
            if (string.IsNullOrEmpty(srcDatasourceName)) throw new ArgumentNullException("srcDatasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(srcDatasetName)) throw new ArgumentNullException("srcDatasetName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(destDatasourceName)) throw new ArgumentNullException("destDatasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(destDatasetName)) throw new ArgumentNullException("destDatasetName", Resources.ArgumentIsNotNull);
            string uri = string.Format("{0}/data/datasources/{1}/datasets.json", this._serviceUrl, destDatasourceName);
            CopyDatasetRequestParameter datasetInfo = new CopyDatasetRequestParameter(srcDatasourceName, srcDatasetName, destDatasetName);
            string result = SynchHttpRequest.GetRequestString(uri, JsonConvert.SerializeObject(datasetInfo));
            EditResult datasetResult = JsonConvert.DeserializeObject<EditResult>(result);
            return datasetResult.Succeed;
        }

        #endregion

        #region statistic
        public double Statistic(string datasourceName, string datasetName, string fieldName, StatisticMode statisticMode)
        {
            if (string.IsNullOrEmpty(datasourceName)) throw new ArgumentNullException("datasourceName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(datasetName)) throw new ArgumentNullException("datasetName", Resources.ArgumentIsNotNull);
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException("fieldName", Resources.ArgumentIsNotNull);
            string uri = string.Format("{0}/data/datasources/{1}/datasets/{2}/fields/{3}/{4}.json?", this._serviceUrl,
                HttpUtility.UrlEncode(datasourceName), HttpUtility.UrlEncode(datasetName), HttpUtility.UrlEncode(fieldName), statisticMode.ToString());
            string result = SynchHttpRequest.GetRequestString(uri);
            Dictionary<string, object> hasResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            double statisticResult = -9999;
            if (hasResult != null && hasResult.ContainsKey("result") && hasResult["result"] != null)
            {
                double.TryParse(hasResult["result"].ToString(), out statisticResult);
            }
            return statisticResult;
        }

        #endregion
    }
}
