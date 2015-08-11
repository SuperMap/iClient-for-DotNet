using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>资源供给中心类型枚举。</para>
    /// <para>该枚举类定义了网络分析中资源中心点的类型，主要用于资源分配和选址分区。</para>
    /// <para>资源供给中心点的类型包括非中心，固定中心和可选中心。固定中心用于资源分配分析；
    /// 固定中心和可选中心用于选址分析；非中心在两种网络分析时都不予考虑。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SupplyCenterType
    {
        /// <summary>
        /// 固定中心点，用于资源分配和选址分区。
        /// </summary>
        FIXEDCENTER,

        /// <summary>
        ///非中心点，在资源分配和选址分区时都不予考虑。 
        /// </summary>
        NULL,

        /// <summary>
        ///可选中心点，用于选址分区。 
        /// </summary>
        OPTIONALCENTER
    }
}
