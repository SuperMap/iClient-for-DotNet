using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>投影方式的类型枚举。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectionType
    {
        /// <summary>
        /// 非投影。
        /// </summary>
        PRJ_NONPROJECTION,

        /// <summary>
        /// Plate Carree。
        /// </summary>
        PRJ_PLATE_CARREE,

        /// <summary>
        /// Equidistant Cylindrical。
        /// </summary>
        PRJ_EQUIDISTANT_CYLINDRICAL,

        /// <summary>
        /// Miller Cylindrical。
        /// </summary>
        PRJ_MILLER_CYLINDRICAL,

        /// <summary>
        /// 墨卡托投影，又叫正轴等角圆柱投影。
        /// </summary>
        PRJ_MERCATOR,

        /// <summary>
        /// 高斯-克吕格（Gauss-Kruger）投影。
        /// </summary>
        PRJ_GAUSS_KRUGER,

        /// <summary>
        /// UTM 投影，全称为“通用横轴墨卡托投影”。
        /// </summary>
        PRJ_TRANSVERSE_MERCATOR,

        /// <summary>
        /// Albers 投影，采用双标准纬线的等积割圆锥进行投影。
        /// </summary>
        PRJ_ALBERS,

        /// <summary>
        /// 正弦曲线投影。
        /// </summary>
        PRJ_SINUSOIDAL,

        /// <summary>
        /// 摩尔魏特投影。
        /// </summary>
        PRJ_MOLLWEIDE,
        
        /// <summary>
        /// Eckert VI。
        /// </summary>
        PRJ_ECKERT_VI,

        /// <summary>
        /// Eckert V。
        /// </summary>
        PRJ_ECKERT_V,

        /// <summary>
        /// Eckert IV。
        /// </summary>
        PRJ_ECKERT_IV,

        /// <summary>
        ///  Eckert III。
        /// </summary>
        PRJ_ECKERT_III,

        /// <summary>
        /// Eckert II。
        /// </summary>
        PRJ_ECKERT_II,

        /// <summary>
        /// Eckert I。
        /// </summary>
        PRJ_ECKERT_I,

        /// <summary>
        /// Gall Stereographic。
        /// </summary>
        PRJ_GALL_STEREOGRAPHIC,

        /// <summary>
        /// Behrmann。
        /// </summary>
        PRJ_BEHRMANN,


        /// <summary>
        /// Winkel I。
        /// </summary>
        PRJ_WINKEL_I,

        /// <summary>
        /// Winkel II。
        /// </summary>
        PRJ_WINKEL_II,

        /// <summary>
        /// Lambert Conformal Conic。
        /// </summary>
        PRJ_LAMBERT_CONFORMAL_CONIC,

        /// <summary>
        /// 多圆锥投影。
        /// </summary>
        PRJ_POLYCONIC,

        /// <summary>
        /// Quartic Authalic。
        /// </summary>
        PRJ_QUARTIC_AUTHALIC,

        /// <summary>
        /// Loximuthal。
        /// </summary>
        PRJ_LOXIMUTHAL,
        
        /// <summary>
        /// Bonne。
        /// </summary>
        PRJ_BONNE,

        /// <summary>
        /// Hotine。
        /// </summary>
        PRJ_HOTINE,

        /// <summary>
        /// Stereographic。
        /// </summary>
        PRJ_STEREOGRAPHIC,

        /// <summary>
        /// 等距圆锥投影。
        /// </summary>
        PRJ_EQUIDISTANT_CONIC,

        /// <summary>
        /// 卡西尼投影。
        /// </summary>
        PRJ_CASSINI,
        
        /// <summary>
        /// Van_der_Grinten_I。
        /// </summary>
        PRJ_VAN_DER_GRINTEN_I,

        /// <summary>
        /// Robinson。
        /// </summary>
        PRJ_ROBINSON,

        /// <summary>
        /// Two-Point Equidistant。
        /// </summary>
        PRJ_TWO_POINT_EQUIDISTANT,

        /// <summary>
        /// Equidistant Azimuthal。
        /// </summary>
        PRJ_EQUIDISTANT_AZIMUTHAL,

        /// <summary>
        ///  Lambert Azimuthal Equal Area。
        /// </summary>
        PRJ_LAMBERT_AZIMUTHAL_EQUAL_AREA,

        /// <summary>
        /// 正轴方位投影。
        /// </summary>
        PRJ_CONFORMAL_AZIMUTHAL,
        
        /// <summary>
        /// Ortho_graphic。
        /// </summary>
        PRJ_ORTHO_GRAPHIC,

        /// <summary>
        /// Gnomonic。
        /// </summary>
        PRJ_GNOMONIC,

        /// <summary>
        /// 中国全图方位投影。
        /// </summary>
        PRJ_CHINA_AZIMUTHAL,

        /// <summary>
        /// 桑逊投影--正弦曲线等积伪圆柱投影。
        /// </summary>
        PRJ_SANSON,

        /// <summary>
        /// EqualArea Cylindrical。
        /// </summary>
        PRJ_EQUALAREA_CYLINDRICAL,

        /// <summary>
        /// Hotine Azimuth Natorigin。
        /// </summary>
        PRJ_HOTINE_AZIMUTH_NATORIGIN,
        
        /// <summary>
        ///  SPHERE MERCATOR投影。
        /// </summary>
        PRJ_SPHERE_MERCATOR
    }
}
