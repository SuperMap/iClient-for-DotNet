using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>中央经线类型枚举。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrimeMeridianType
    {
        /// <summary>
        /// 23°42'58".815 E。
        /// </summary>
        PRIMEMERIDIAN_ATHENS,

        /// <summary>
        ///  7°26'22".5 E。
        /// </summary>
        PRIMEMERIDIAN_BERN,

        /// <summary>
        /// 74°04'51".3 W。
        /// </summary>
        PRIMEMERIDIAN_BOGOTA,

        /// <summary>
        /// 4°22'04".71 E 。
        /// </summary>
        PRIMEMERIDIAN_BRUSSELS,

        /// <summary>
        /// 17°40'00" W。
        /// </summary>
        PRIMEMERIDIAN_FERRO,

        /// <summary>
        /// 格林威治本初子午线，即0°经线。
        /// </summary>
        PRIMEMERIDIAN_GREENWICH,

        /// <summary>
        /// 106°48'27".79 E。
        /// </summary>
        PRIMEMERIDIAN_JAKARTA,

        /// <summary>
        /// 9°07'54".862 W。
        /// </summary>
        PRIMEMERIDIAN_LISBON,

        /// <summary>
        /// 3°41'16".58 W。
        /// </summary>
        PRIMEMERIDIAN_MADRID,

        /// <summary>
        ///  2°20'14".025 E。
        /// </summary>
        PRIMEMERIDIAN_PARIS,

        /// <summary>
        ///  12°27'08".4 E。
        /// </summary>
        PRIMEMERIDIAN_ROME,

        /// <summary>
        /// 18°03'29".8 E。
        /// </summary>
        PRIMEMERIDIAN_STOCKHOLM,

        /// <summary>
        ///  用户自定义。     
        /// </summary>
        PRIMEMERIDIAN_USER_DEFINED
    }
}
