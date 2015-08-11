using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// PDF 格式图片输出选项。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class PDFOption
    {  
        ///<summary>
        ///是否输出完整地图范围。
        /// </summary>
        [JsonProperty("entire")]
        public bool Entire { get; set; }
       
        /// <summary>
        /// 输出的 PDF 文件是否拥有地图中的线样式。
        /// </summary>
        [JsonProperty("lineStyleRetained")]
        public bool LineStyleRetained { get; set; }
        
        /// <summary>
        /// 输出的 PDF 文件是否拥有地图中的点样式。
        /// </summary>
        [JsonProperty("pointStyleRetained")]
        public bool PointStyleRetained { get; set; }
       
        /// <summary>
        /// 输出的 PDF 文件是否拥有地图中的面样式。
        /// </summary>
        [JsonProperty("regionStyleRetained")]
        public bool RegionStyleRetained { get; set; }
        
        /// <summary>
        /// 是否以矢量的方式输出地图。
        /// </summary>
        [JsonProperty("vector")]
        public bool Vector { get; set; }
    }
}
