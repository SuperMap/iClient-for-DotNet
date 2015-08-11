using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>地球椭球体对象的类型枚举。</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpheroidType
    {
        /// <summary>
        /// Airy 1830。
        /// </summary>
        SPHEROID_AIRY_1830,

        /// <summary>
        /// Airy modified。
        /// </summary>
        SPHEROID_AIRY_MOD,

        /// <summary>
        /// Average Terrestrial System 1977。
        /// </summary>
        SPHEROID_ATS_1977,

        /// <summary>
        /// Australian National。
        /// </summary>
        SPHEROID_AUSTRALIAN,

        /// <summary>
        ///  Bessel 1841。
        /// </summary>
        SPHEROID_BESSEL_1841,

        /// <summary>
        /// Bessel modified。
        /// </summary>
        SPHEROID_BESSEL_MOD,

        /// <summary>
        /// Bessel Namibia。
        /// </summary>
        SPHEROID_BESSEL_NAMIBIA,

        /// <summary>
        /// 中国最新标准投影的椭球体：China 2000。
        /// </summary>
        SPHEROID_CHINA_2000,

        /// <summary>
        /// Clarke 1858。
        /// </summary>
        SPHEROID_CLARKE_1858,

        /// <summary>
        ///  Clarke 1866。
        /// </summary>
        SPHEROID_CLARKE_1866,

        /// <summary>
        /// Clarke 1866 Michigan。
        /// </summary>
        SPHEROID_CLARKE_1866_MICH,

        /// <summary>
        ///  Clarke 1880。
        /// </summary>
        SPHEROID_CLARKE_1880,

        /// <summary>
        /// Clarke 1880 (Arc)。
        /// </summary>
        SPHEROID_CLARKE_1880_ARC,

        /// <summary>
        /// Clarke 1880 (Benoit)。
        /// </summary>
        SPHEROID_CLARKE_1880_BENOIT,

        /// <summary>
        /// Clarke 1880 (IGN)。
        /// </summary>
        SPHEROID_CLARKE_1880_IGN,

        /// <summary>
        /// Clarke 1880 (RGS)。
        /// </summary>
        SPHEROID_CLARKE_1880_RGS,

        /// <summary>
        ///  Clarke 1880 (SGA)。
        /// </summary>
        SPHEROID_CLARKE_1880_SGA,

        /// <summary>
        /// Everest 1830。
        /// </summary>
        SPHEROID_EVEREST_1830,

        /// <summary>
        /// Everest (definition 1967)。
        /// </summary>
        SPHEROID_EVEREST_DEF_1967,

        /// <summary>
        /// Everest (definition 1975)。
        /// </summary>
        SPHEROID_EVEREST_DEF_197,

        /// <summary>
        /// Everest modified。
        /// </summary>
        SPHEROID_EVEREST_MOD,

        /// <summary>
        /// Everest modified 1969。
        /// </summary>
        SPHEROID_EVEREST_MOD_1969,

        /// <summary>
        /// Fischer 1960。
        /// </summary>
        SPHEROID_FISCHER_1960,

        /// <summary>
        /// Fischer 1968。
        /// </summary>
        SPHEROID_FISCHER_1968,

        /// <summary>
        ///  Fischer modified。
        /// </summary>
        SPHEROID_FISCHER_MOD,

        /// <summary>
        /// GEM gravity potential model。
        /// </summary>
        SPHEROID_GEM_10C,

        /// <summary>
        /// GRS 1967 = International 1967。
        /// </summary>
        SPHEROID_GRS_1967,

        /// <summary>
        /// GRS 1980。
        /// </summary>
        SPHEROID_GRS_1980,

        /// <summary>
        /// Helmert 1906。
        /// </summary>
        SPHEROID_HELMERT_1906,

        /// <summary>
        /// Hough 1960。
        /// </summary>
        SPHEROID_HOUGH_1960,

        /// <summary>
        /// Indonesian National。
        /// </summary>
        SPHEROID_INDONESIAN,

        /// <summary>
        ///  International 1924。
        /// </summary>
        SPHEROID_INTERNATIONAL_1924,

        /// <summary>
        ///  International 1967。
        /// </summary>
        SPHEROID_INTERNATIONAL_1967,

        /// <summary>
        ///  International 1975。
        /// </summary>
        SPHEROID_INTERNATIONAL_1975,

        /// <summary>
        ///  Krasovsky 1940。
        /// </summary>
        SPHEROID_KRASOVSKY_1940,

        /// <summary>
        /// NWL_10D。
        /// </summary>
        SPHEROID_NWL_10D,

        /// <summary>
        /// Transit precise ephemeris。
        /// </summary>
        SPHEROID_NWL_9D,

        /// <summary>
        /// OSU 1986 geoidal model。
        /// </summary>
        SPHEROID_OSU_86F,

        /// <summary>
        /// OSU 1991 geoidal model。
        /// </summary>
        SPHEROID_OSU_91A,

        /// <summary>
        /// Plessis 1817。
        /// </summary>
        SPHEROID_PLESSIS_1817,

        /// <summary>
        /// Authalic sphere。
        /// </summary>
        SPHEROID_SPHERE,

        /// <summary>
        /// Authalic sphere (ARC/INFO)。
        /// </summary>
        SPHEROID_SPHERE_AI,

        /// <summary>
        ///  Struve 1860。
        /// </summary>
        SPHEROID_STRUVE_1860,

        /// <summary>
        /// 用户自定义类型。
        /// </summary>
        SPHEROID_USER_DEFINED,

        /// <summary>
        /// Walbeck。
        /// </summary>
        SPHEROID_WALBECK,

        /// <summary>
        /// War Office。
        /// </summary>
        SPHEROID_WAR_OFFICE,

        /// <summary>
        ///  WGS 1966。
        /// </summary>
        SPHEROID_WGS_1966,

        /// <summary>
        /// WGS 1972。
        /// </summary>
        SPHEROID_WGS_1972,

        /// <summary>
        /// WGS 1984。
        /// </summary>
        SPHEROID_WGS_1984
    }
}
