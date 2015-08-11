using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>转弯方向枚举。</para>
    /// <para>用在行驶引导子项类中，表示转弯的方向。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TurnType
    {
        /// <summary>
        /// 向前直行。
        /// </summary>
        AHEAD,

        /// <summary>
        /// 掉头。 
        /// </summary>
        BACK,

        /// <summary>
        /// 终点，不转弯。 
        /// </summary>
        END,

        /// <summary>
        /// 左转。 
        /// </summary>
        LEFT,

        /// <summary>
        /// 无效值。 
        /// </summary>
        NONE,

        /// <summary>
        /// 右转。 
        /// </summary>
        RIGHT

    }
}
