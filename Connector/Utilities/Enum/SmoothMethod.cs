using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 光滑方法枚举类。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SmoothMethod
    {
        /// <summary>
        /// B 样条法。
        /// 等值线会以每四个控制点为单位进行光滑，经过第一个和第四个控制点，在第二和第三个控制点附近拟合。
        /// </summary>
        BSPLINE,
        /// <summary>
        /// 磨角法。
        /// 等值线会经过每一个控制点。
        /// </summary>
        POLISH
    }
}
