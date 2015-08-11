using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 	<para>克吕金（Kriging）插值时的半变函数类型枚举。 包括指数型、球型和高斯型。用户所选择的半变函数类型会影响未知点的预测，特别是曲线在原点处的不同形状有重要意义。曲线在原点处越陡，则较近领域对该预测值的影响就越大。因此输出表面就会越不光滑。每种类型都有各自适用的情况。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VariogramMode
    {
        /// <summary>
        /// 指数函数（Exponential Variogram Mode）。
        /// </summary>
        EXPONENTIAL,

        /// <summary>
        /// 高斯函数（Gaussian Variogram Mode）。 
        /// </summary>
        GAUSSIAN,

        /// <summary>
        /// 球型函数（Spherical Variogram Mode）。 
        /// </summary>
        SPHERICAL
    }
}
