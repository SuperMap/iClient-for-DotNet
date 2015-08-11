using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 资源图片类。
    /// </summary>
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ResourceImage
    {
        /// <summary>
        /// 资源图片二进制流。
        /// </summary>
        public byte[] ImageData { get; set; }
       
        ///<summary>
        /// 资源图片的 URL 地址。
        ///</summary>
        public string ImageUrl { get; set; }
    }
}
