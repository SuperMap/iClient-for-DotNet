using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 鹰眼对象。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class Overview
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Overview()
        { }

        /// <summary>
        /// 地图图片的二进制流。
        /// </summary>
        public byte[] ImageData { get; set; }

        ///<summary>
        /// 地图图片的 URL 地址。
        ///</summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 地图的名称。
        /// </summary>
        [JsonProperty("mapName")]
        public string MapName { get; set; }

        /// <summary>
        /// 鹰眼图中显示的地图的可视范围。
        /// </summary>
        [JsonProperty("viewBounds")]
        public Rectangle2D ViewBounds { get; set; }

        /// <summary>
        /// 鹰眼图片的大小。
        /// </summary>
        [JsonProperty("viewer")]
        public Rectangle Viewer { get; set; }

        /// <summary>
        /// 图片上次修改时间。
        /// </summary>
        [JsonProperty("lastModified")]
        public long LastModified { get; set; }
    }
}
