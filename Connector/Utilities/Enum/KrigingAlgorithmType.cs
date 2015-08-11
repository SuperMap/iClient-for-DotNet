using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>该枚举定义了克吕金插值方法的类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KrigingAlgorithmType
    {
        /// <summary>
        /// <para>普通克吕金插值法。</para>
        /// <para>最常用的克吕金插值方法之一。该方法假定用于插值的字段值的期望（平均值）未知且恒定。它利用一定的数学函数，
        /// 通过对给定的空间点进行拟合来估算单元格的值，生成格网数据集。它不仅可以生成一个表面，还可以给出预测结果的精度或者确定性的度量。因此，此方法计算精度较高，常用于社会科学及地质学。</para>
        /// </summary>
        KRIGING,

        /// <summary>
        /// <para>简单克吕金插值法。</para>
        /// <para>简单克吕金是常用的克吕金插值方法之一，该方法假定用于插值的字段值的期望（平均值）已知的某一常数。</para>
        /// </summary>
        SimpleKriging,

        /// <summary>
        /// <para>泛克吕金插值法。</para>
        /// <para>泛克吕金也是常用的克吕金插值方法之一，该方法假定用于插值的字段值的期望（平均值）未知的变量。在样点数据中
        /// 存在某种主导趋势，并且该趋势可以通过某一个确定的函数或者多项式进行拟合的情况下适用泛克吕金插值法。</para>
        /// </summary>
        UniversalKriging
    }
}
