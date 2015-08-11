using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>地图图片。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class MapImage
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MapImage()
        { }

        /// <summary>
        /// 地图图片的二进制流。
        /// </summary>
        [JsonProperty("imageData")]
        public byte[] ImageData { get; set; }
        
        ///<summary>
        /// 地图图片的 URL 地址。
        ///</summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 地图参数。
        /// </summary>
        [JsonProperty("mapParameter")]
        public MapParameter MapParameter { get; set; }
    }
}
