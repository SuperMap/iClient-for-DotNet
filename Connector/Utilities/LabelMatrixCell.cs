using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 矩阵标签元素类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LabelMatrixCellConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class LabelMatrixCell
    {
        /// <summary>
        /// 矩阵标签类型。
        /// </summary>
        [JsonProperty("type")]
        public LabelMatrixCellType Type { get; set; }
    }

    /// <summary>
    /// 图片类型的矩阵标签元素类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LabelMatrixCellConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class LabelImageCell : LabelMatrixCell
    {   
        ///<summary>
        ///图片的高度，单位为毫米。
        ///</summary>
        [JsonProperty("height")]
        public double Height { get; set; }
       
        /// <summary>
        /// 记录了图片类型的矩阵标签元素所使用图片的路径的字段名称。
        /// </summary>
        [JsonProperty("pathField")]
        public string PathField { get; set; }
        
        /// <summary>
        /// 图片的旋转角度。
        /// </summary>
        [JsonProperty("rotation")]
        public double Rotation { get; set; }
      
        /// <summary>
        /// 图片的大小是否固定。
        /// </summary>
        [JsonProperty("sizeFixed")]
        public bool SizeFixed { get; set; }
       
        /// <summary>
        /// 返回图片的宽度，单位为毫米。
        /// </summary>
        [JsonProperty("width")]
        public double Width { get; set; }
    }

    
    /// <summary>
    /// 符号类型的矩阵标签元素类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LabelMatrixCellConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class LabelSymbolCell : LabelMatrixCell
    {
        /// <summary>
        /// 所使用符号的样式。
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }

        /// <summary>
        /// 记录所使用符号 ID 的字段名称。
        /// </summary>
        [JsonProperty("symbolIDField")]
        public string SymbolIDField { get; set; }
    }

    /// <summary>
    /// 专题图类型的矩阵标签元素类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LabelMatrixCellConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class LabelThemeCell : LabelMatrixCell
    {
        
        /// <summary>
        /// 标签专题图对象。
        /// </summary>
        [JsonProperty("themeLabel")]
        public ThemeLabel ThemeLabel { get; set; }
    }
}
