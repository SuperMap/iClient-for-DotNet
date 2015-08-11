using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 叠加操作枚举类型。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OverlayOperationType
    {
        /// <summary>
        /// 裁剪。
        /// <para>
        /// 操作对象裁剪被操作对象。
        /// </para>
        /// <list type="bullet">
        /// <item>被操作几何对象只有落在操作几何对象内的那部分才会被输出为结果几何对象。</item>
        /// <item>Clip 与 Intersect 在空间处理上是一致的，不同在于对结果几何对象属性的处理，Clip 分析只是用来做裁剪，
        /// 结果几何对象只保留被操作几何对象的非系统字段，
        /// 而 Intersect 求交分析的结果则可以根据字段设置情况来保留两个几何对象的字段。</item>
        /// <item>该操作适合的几何对象类型： 操作几何对象：面； 被操作几何对象：点、线、面。</item>
        /// </list>
        /// </summary>
        CLIP,

        /// <summary>
        /// 擦除。
        /// <para>在被操作对象上擦除掉与操作对象相重合的部分。</para>
        /// <list type="bullet">
        /// <item>如果对象全部被擦除了，则返回 Null。</item>
        /// <item>操作几何对象定义了擦除区域，凡是落在操作几何对象区域内的被操作几何对象都将被去除，而落在区域外的特征要素都将被输出为结果几何对象，与 Clip 运算相反。</item>
        /// <item>该操作适合的几何对象类型： 操作几何对象：面； 被操作几何对象：点、线、面。</item>
        /// </list>
        /// </summary>
        ERASE,

        /// <summary>
        /// 同一。
        /// <para>对被操作对象进行同一操作，即操作执行后，被操作几何对象包含来自操作几何对象的几何形状。</para>
        /// <list type="bullet">
        /// <item>同一运算就是操作几何对象与被操作几何对象先求交，然后求交结果再与被操作几何对象求并的运算。</item>
        /// <item>如果被操作几何对象为点类型，则结果几何对象为被操作几何对象。</item>
        /// <item>如果被操作几何对象为线类型，则结果几何对象为被操作几何对象，但是操作几何对象相交的部分将被打断。</item>
        /// <item>如果被操作几何对象为面类型，则结果几何对象保留以被操作几何对象为控制边界之内的所有多边形，并且把与操作几何对象相交的地方分割成多个对象。</item>
        /// <item>该操作适合的几何对象类型：操作几何对象：面；被操作几何对象：点、线、面。</item>
        /// </list>
        /// </summary>
        IDENTITY,
        
        /// <summary>
        /// 相交。
        /// <para>对两个几何对象求交，返回两个几何对象的交集。</para>
        /// <list type="bullet">
        /// <item>求交运算与裁剪运算得到的结果几何对象的空间几何信息相同的，但是裁剪运算不对属性表做任何处理，而求交运算可以让用户选择需要保留的属性字段。</item>
        /// <item>该操作适合的几何对象类型： 操作几何对象：面； 被操作几何对象：点、线、面。</item>
        /// </list>
        /// </summary>
        INTERSECT,
        //       /// <item>进行求交运算的两个几何对象必须是同类型的，目前版本只支持面类型的求交。</item>

        /// <summary>
        /// 合并。
        /// <para>对两个对象进行合并操作，进行合并后，两个面对象在相交处被多边形分割。</para>
        /// <list type="bullet">
        /// <item>进行求并运算的两个几何对象必须是同类型的，目前版本只支持面类型的合并。</item>
        /// <item>该操作适合的几何对象类型： 操作几何对象：面； 被操作几何对象：面。</item>
        /// </list>
        /// </summary>
        UNION,
        
        /// <summary>
        /// 更新。
        /// <para>更新运算是对两个面数据进行的操作，即使用操作数据中的内容去更新被操作数据中相应位置的内容。</para>
        /// </summary>
        UPDATE,
        
        /// <summary>
        /// 对称差。
        /// <para>对两个对象进行对称差操作，即对于每一个被操作几何对象，去掉其与操作几何对象相交的部分，而保留剩下的部分。</para>
        /// <list type="bullet">
        /// <item>对称差运算的结果几何对象的属性表包含两个输入几何对象的非系统属性字段。</item>
        /// <item>该操作适合的几何对象类型：操作几何对象：面；被操作几何对象：面。</item>
        /// </list>
        /// </summary>
        XOR
    }
}
