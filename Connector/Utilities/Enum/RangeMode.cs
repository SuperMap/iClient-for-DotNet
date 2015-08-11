using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   

    /// <summary>
    /// <para>分段专题图的分段方式枚举。</para>
    /// <para>在分段专题图中，作为专题变量的字段或表达式的值按照某种分段方式被分成多个范围段，要素或记录根据其所对应的
    /// 字段值或表达式值被分配到其中一个分段中，在同一个范围段中要素或记录使用相同的风格进行显示。分段专题图一般
    /// 用来表现连续分布现象的数量或程度特征，如降水量的分布，土壤侵蚀强度的分布等，从而反映现象在各区域的集中程
    /// 度或发展水平的分布差异。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RangeMode
    {   
        /// <summary>
        /// 自定义分段。
        /// </summary>
        CUSTOMINTERVAL,

        /// <summary>
        /// 等距离分段，
        /// </summary>
        EQUALINTERVAL,

        /// <summary>
        /// 对数分段。
        /// </summary>
        LOGARITHM,

        /// <summary>
        /// 等计数分段。
        /// </summary>
        QUANTILE,

        /// <summary>
        /// 平方根分段。
        /// </summary>
        SQUAREROOT,

        /// <summary>
        /// 标准差分段。
        /// </summary>
        STDDEVIATION
    }
}
