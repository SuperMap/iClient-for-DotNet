using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 查询参数集合类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class QueryParameterSet
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public QueryParameterSet()
        {
        }
        ///// <summary>
        ///// 拷贝构造函数。
        ///// </summary>
        ///// <param name="queryParam">查询参数集合对象。</param>
        ///// <exception cref="ArgumentNullException">当查询参数集合对象为 Null 时抛出异常。</exception>
        //public QueryParameterSet(QueryParameterSet queryParam)
        //{
        //    if (queryParam == null) throw new ArgumentNullException();
        //    this.CustomParams = queryParam.CustomParams;
        //    this.ExpectCount = queryParam.ExpectCount;
        //    this.NetworkType = queryParam.NetworkType;
        //    this.QueryOption = queryParam.QueryOption;
        //    this.QueryParams = queryParam.QueryParams;
        //    this.ReturnContent = queryParam.ReturnContent;
        //    this.ReturnCustomResult = queryParam.ReturnCustomResult;
        //    this.StartRecord = queryParam.StartRecord;
        //}
        /// <summary>
        /// 自定义参数，供扩展使用。
        /// </summary>
        [JsonProperty("customParams")]
        public String CustomParams { get; set; }

        private int _expectCount = 100000;
        /// <summary>
        /// 查询记录期望返回结果记录，默认为100000条，如果实际不足100000条记录则返回实际记录数目。
        /// </summary>
        [JsonProperty("expectCount")]
        public int ExpectCount
        {
            get { return this._expectCount; }
            set { this._expectCount = value; }
        }

        private GeometryType _networkType = GeometryType.LINE;
        /// <summary>
        /// 网络数据集对应的查询类型，分为点和线两种类型，默认为线几何对象类型，即GeometryType.LINE。
        /// </summary>
        [JsonProperty("networkType")]
        public GeometryType NetworkType
        {
            get { return this._networkType; }
            set { this._networkType = value; }
        }
        private QueryOption _queryOption = QueryOption.ATTRIBUTEANDGEOMETRY;
        /// <summary>
        /// 查询结果选项对象，用于指定查询结果中包含的内容,默认为返回属性和几何实体。
        /// </summary>
        [JsonProperty("queryOption")]
        public QueryOption QueryOption {
            get { return this._queryOption; }
            set { this._queryOption = value; }
        }

        /// <summary>
        /// 查询参数数组。
        /// </summary>
        [JsonProperty("queryParams")]
        public QueryParameter[] QueryParams { get; set; }

        private int _startRecord = 0;
        /// <summary>
        /// 查询起始记录位置，默认为0。
        /// </summary>
        [JsonProperty("startRecord")]
        public int StartRecord
        {
            get { return this._startRecord; }
            set { this._startRecord = value; }
        }

        private bool _returnContent = false;
        /// <summary>
        /// 获取或设置是返回查询结果记录集 Recordsets，还是返回查询结果的资源 ResourceInfo，默认为false。
        /// </summary>
        [JsonProperty("returnContent")]
        public bool ReturnContent
        {
            get { return this._returnContent; }
            set { this._returnContent = value; }
        }

        private bool _returnCustomResult = false;
        /// <summary>
        /// 是否返回查询结果的 Bounds 信息，当 returnContent=false 时有效，默认为false。 
        /// </summary>
        [JsonProperty("returnCustomResult")]
        public bool ReturnCustomResult {
            get { return this._returnCustomResult; }
            set { this._returnCustomResult = value; }
        }
    }
}
