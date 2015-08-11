using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 定义栅格与影像数据存储的像素格式枚举。
    /// </summary>
    /// <remarks>
    /// <para>光栅数据结构实际上就是像元的阵列，像元（或像素）是光栅数据的最基本信息存储单位，本枚举类包含了表示一个像元（或像素）的字节长度。</para>
    /// <para>在 SuperMap 中有两种类型的光栅数据：栅格数据集和影像数据集（参见 <see cref="DatasetGridInfo"/>和<see cref="DatasetImageInfo"/>）。 栅格数据集多用来进行栅格分析，因而其像元值为地物的属性值，如高程，降水量等；而影像数据集一般用来进行显示或作为底图，因而其像元值为颜色值或颜色的索引值。</para>
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PixelFormat
    {
        /// <summary>
        /// 每个像元用16个比特，即2个字节表示。 
        /// </summary>
        BIT16,

        /// <summary>
        /// 每个像元用32个比特，即4个字节表示。 
        /// </summary>       
        BIT32,

        /// <summary>
        /// 每个像元用64个比特，即8个字节表示。 
        /// </summary>
        BIT64,

        /// <summary>
        /// 每个像元用8个字节来表示。 
        /// </summary>
        DOUBLE,

        /// <summary>
        /// 每个像元用4个字节来表示。 
        /// </summary>
        SINGLE,

        /// <summary>
        /// 每个像元用1个比特表示。 
        /// </summary>
        UBIT1,

        /// <summary>
        /// 每个像元用24个比特，即3个字节来表示。 
        /// </summary>
        UBIT24,

        /// <summary>
        /// 每个像元用32个比特，即4个字节来表示。 
        /// </summary>
        UBIT32,

        /// <summary>
        /// 每个像元用4个比特表示。 
        /// </summary>
        UBIT4,

        /// <summary>
        /// 每个像元用8个比特，即1个字节表示。 
        /// </summary>
        UBIT8
    }
}
