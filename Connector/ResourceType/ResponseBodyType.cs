using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class Error
#else
    public class Error
#endif
    {
        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class ErrorResource
#else
    public class ErrorResource
#endif
    {
        [JsonProperty("succeed")]
        public bool Succeed { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class TempLayersSetResourceResult
#else
    public class TempLayersSetResourceResult
#endif
    {
        /// <summary>
        ///   创建临时图层集是否成功。如果不成功会有错误信息。 
        /// </summary>
        [JsonProperty("succeed")]
        public bool Succeed { get; set; }
        /// <summary>
        /// 查询结果资源的 ID。
        /// </summary>
        [JsonProperty("newResourceID")]
        public string NewResourceID { get; set; }
        /// <summary>
        /// 创建的临时图层集的 URI，标识一个 tempLayers 资源。 
        /// </summary>
        [JsonProperty("newResourceLocation")]
        public string NewResourceLocation { get; set; }
        /// <summary>
        ///  出错信息，如果创建成功，则没有本字段。 
        /// </summary>
        //[JsonProperty("error")]
        public object Error { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal sealed class MapsResourceResult
#else
    public sealed class MapsResourceResult
#endif
    {
        [JsonProperty("resourceConfigID")]
        public string ResourceConfigID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supportedMediaTypes")]
        public List<string> SupportedMediaTypes { get; set; }

        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class NetworkAnalystRootResourceResult
#else
    public class NetworkAnalystRootResourceResult
#endif
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("resourceConfigID")]
        public string ResourceConfigID { get; set; }

        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("SupportedMediaTypes")]
        public string[] SupportedMediaTypes { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class FeaturesResourceResult
#else
    public class FeaturesResourceResult
#endif
    {
        [JsonProperty("featureUriList")]
        public List<string> FeatureUriList { get; set; }

        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class DatesetResourceResult
#else
    public class DatesetResourceResult
#endif
    {
        [JsonProperty("childUriList")]
        public List<string> ChildUriList { get; set; }

        [JsonProperty("datasetInfo")]
        public DatasetInfo DatasetInfo { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class Succeed
#else
    public class Succeed
#endif
    {
        [JsonProperty("succeed")]
        public bool succeed { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class SpatialAnalystDatasetInfoResult
#else
    public class SpatialAnalystDatasetInfoResult
#endif
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("datasetInfo")]
        public DatasetInfo DatasetInfo { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    internal class TransferResourceResult
#else
    public class TransferResourceResult
#endif
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("resourceConfigID")]
        public string ResourceConfigID { get; set; }

        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        [JsonProperty("supportedMediaTypes")]
        public string SupportedMediaTypes { get; set; }

        [JsonProperty("visible")]
        public string Visible { get; set; }
    }
}
