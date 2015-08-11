using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>图片输出格式。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImageOutputFormat
    {
        ///// <summary>
        /////  BINARY 格式。 
        ///// </summary>
        ////BINARY,

        /// <summary>
        /// BMP 格式。
        /// </summary>
        BMP,

        ///// <summary>
        /////  默认的图片输出格式，即 PNG 格式。 
        ///// </summary>
        ////DEFAULT,
        ///// <summary>
        ///// EMF 格式，该格式暂不支持。 
        ///// </summary>
        ////EMF,
        ///// <summary>
        /////  EPS 格式，该格式暂不支持。 
        ///// </summary>
        ////EPS,

        /// <summary>
        ///   GIF 格式。 
        /// </summary>
        GIF,

        /// <summary>
        ///  JPG 格式。 
        /// </summary>
        JPG,

        ///// <summary>
        /////   PDF 格式，该格式暂不支持。 
        ///// </summary>
        ////PDF,

        /// <summary>
        ///   PNG格式
        /// </summary>
        PNG
    }
}
