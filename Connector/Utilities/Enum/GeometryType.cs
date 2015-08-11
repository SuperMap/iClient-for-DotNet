using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>几何对象类型枚举。</para>
    /// <para>定义一系列几何对象类型。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GeometryType
    {   
        /// <summary>
        /// 圆弧。
        /// </summary>
        ARC,

        /// <summary>
        /// 二次B样条曲线。
        /// </summary>
        BSPLINE,

        /// <summary>
        /// 二维Cardinal样条曲线。
        /// </summary>
        CARDINAL,

        /// <summary>
        /// 弓形。
        /// </summary>
        CHORD,

        /// <summary>
        /// 圆。
        /// </summary>
        CIRCLE,

        /// <summary>
        /// 二维曲线。
        /// </summary>
        CURVE,

        /// <summary>
        /// 椭圆。
        /// </summary>
        ELLIPSE,

        /// <summary>
        /// 椭圆弧。
        /// </summary>
        ELLIPTICARC,

        /// <summary>
        /// 线几何对象类型。
        /// </summary>
        LINE,

        /// <summary>
        /// 路由对象，是一组具有X，Y坐标与线性度量值的点组成的线性地物对象。
        /// </summary>
        LINEM,

        /// <summary>
        /// 扇面。
        /// </summary>
        PIE,

        /// <summary>
        /// 点几何对象类型。
        /// </summary>
        POINT,

        /// <summary>
        /// 矩形。
        /// </summary>
        RECTANGLE,

        /// <summary>
        /// 面几何对象类型。
        /// </summary>
        REGION,

        /// <summary>
        /// 圆角矩形。
        /// </summary>
        ROUNDRECTANGLE,

        /// <summary>
        /// 文本几何对象类型。
        /// </summary>
        TEXT,

        /// <summary>
        /// 未定义。
        /// </summary>
        UNKNOWN

    }
}
