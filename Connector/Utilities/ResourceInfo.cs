using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 资源信息。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class ResourceInfo
    {
        /// <summary>
        /// 获取资源的 ID。
        /// </summary>
        [JsonProperty("newResourceID")]
        public string NewResourceID { get; set; }
        /// <summary>
        /// 获取资源的 URL。
        /// </summary>
        [JsonProperty("newResourceLocation")]
        public string NewResourceLocation { get; set; }
        /// <summary>
        /// 返回查询结果的 Bounds 信息，当原查询对象的坐标系统为带投影的坐标系统时，返回的 Bounds 。信息用经纬度表示
        /// </summary>
        [JsonProperty("customResult")]
        public Rectangle2D Bounds { get; set; }
        /// <summary>
        /// 获取资源创建是否成功。
        /// </summary>
        [JsonProperty("succeed")]
        public bool Succeed { get; set; }
    }
}
