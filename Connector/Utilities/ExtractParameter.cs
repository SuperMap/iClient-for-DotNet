using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>等值线/面的提取参数设置类。</para>
    /// <para>通过该类可以设置提取等值线/面的一些参数，包括基准值、等值距、光滑度、光滑方法等。</para>
    /// </summary>
    /// <remarks>
    /// <para>注意：如果用户既设置了基准值和等值距，又设置了期望的Z值，则分析的结果为 两者的并集。比如对于高程范围为220 -1350的栅格数据集，
    /// 设置基准值为1000， 等值距为100，同时设置期望的Z值数组为{850, 950, 1130}，则最终提取的为 {850, 950, 1000, 1100, 1130, 1200, 1300}。</para>
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class ExtractParameter
#else
    [Serializable]
    public class ExtractParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ExtractParameter()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="extractParameter">等值线/面的提取参数对象。</param>
        /// <exception cref="ArgumentNullException">等值线/面的提取参数为 null 时抛出异常。</exception>
        public ExtractParameter(ExtractParameter extractParameter)
        {
            if (extractParameter == null) throw new ArgumentNullException();
            if (extractParameter.ClipRegion != null)
            {
                this.ClipRegion = new Geometry(extractParameter.ClipRegion);
            }
            this.DatumValue = extractParameter.DatumValue;
            this.Interval = extractParameter.Interval;
            this.ResampleTolerance = extractParameter.ResampleTolerance;
            this.Smoothness = extractParameter.Smoothness;
            if (extractParameter.ExpectedZValues != null)
            {
                int length = extractParameter.ExpectedZValues.Length;
                this.ExpectedZValues = new double[length];
                for (int i = 0; i < length; i++)
                {
                    this.ExpectedZValues[i] = extractParameter.ExpectedZValues[i];
                }
            }
        }

        /// <summary>
        /// 裁剪面对象，如果不需要对操作结果进行裁剪，可以使用null值取代该参数。
        /// </summary>
        [JsonProperty("clipRegion")]
        public Geometry ClipRegion { get; set; }

        /// <summary>
        /// 等值线的基准值。
        /// </summary>
        /// <remarks>
        /// <para>基准值是作为一个生成等值线的初始起算值，并不一定是最小等值线的值。 例如，高程范围为 220 -1550 的 DEM 栅格数据，如果设基准值为0， 等值距为50，则提取等值线时，以基准值0为起点，等值距50为间隔提取等值线， 因为给定高程的最小值是220，所以，在给定范围内提取等值线的最小高程是250。 提取等值线的结果是：最小等值线值为250，最大等值线值为1550。 也就是说，如果设置的提取值有些在范围内有些不再范围内，则提取在范围内的。</para>
        /// <para>另外，如果设置的提取值都不在范围内，如本例，如果设置基准值为1600， 则数据集的高程范围内不存在可以提取的等值线，则系统会抛出异常。</para>
        /// </remarks>
        [JsonProperty("datumValue")]
        public double DatumValue { get; set; }

        /// <summary>
        /// <para>等值距。</para>
        /// </summary>
        /// <remarks>
        /// <para>等值距是两条等值线之间的间隔值。若等值距设置为0，则认为不使用基准值加 等值距的方式进行提取。</para>
        /// </remarks>
        [JsonProperty("interval")]
        public double Interval { get; set; }

        /// <summary>
        /// <para>期望分析结果的 Z 值集合。</para>
        /// </summary>
        /// <remarks>
        /// <para>当对点数据集提取等值面时，该字段暂不被支持，设置该字段可能导致错误的结果。</para>
        /// <para>Z 值集合存储一系列数值，该数值为待提取等值线的值。 即，仅高程值在Z值集合中的等值线会被提取。</para>
        /// </remarks>
        [JsonProperty("expectedZValues")]
        public double[] ExpectedZValues { get; set; }

        /// <summary>
        /// <para>重采样容限，一般取值为 0～1 倍的栅格分辨率。</para>
        /// </summary>
        /// <remarks>
        /// <para>容限值越大，采样结果数据越简化。</para>
        /// <para>当分析结果出现交叉时，可通过调整重采样容限为较小的值来处理。</para>
        /// </remarks>
        [JsonProperty("resampleTolerance")]
        public double ResampleTolerance { get; set; }

        /// <summary>
        /// <para>等值线或等值面的边界线的光滑度。</para>
        /// </summary>
        /// <remarks>
        /// <para>以为0-5为例，光滑度为0表示不进行光滑操作，值越大表示光滑度越高。 随着光滑度的增加，提取的等值线越光滑.当然光滑度越大， 计算所需的时间和占用的内存也就越大。而且，当等值距较小时， 光滑度太高会出现等值线相交的问题。</para>
        /// </remarks>
        [JsonProperty("smoothness")]
        public int Smoothness { get; set; }

        /// <summary>
        /// <para>设置光滑处理所使用的方法。</para>
        /// </summary>
        [JsonProperty("smoothMethod")]
        public SmoothMethod SmoothMethod { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private ExtractParameter(SerializationInfo info, StreamingContext context)
        {
            this.ClipRegion = (Geometry)info.GetValue("ClipRegion", typeof(Geometry));
            this.DatumValue = info.GetDouble("DatumValue");
            this.Interval = info.GetDouble("Interval");
            this.ResampleTolerance = info.GetDouble("ResampleTolerance");
            this.Smoothness = info.GetInt32("Smoothness");
            this.ExpectedZValues = (double[])info.GetValue("ExpectedZValues", typeof(double[]));
            this.SmoothMethod = (SmoothMethod)info.GetValue("SmoothMethod", typeof(SmoothMethod));
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClipRegion", this.ClipRegion);
            info.AddValue("DatumValue", this.DatumValue);
            info.AddValue("Interval", this.Interval);
            info.AddValue("ResampleTolerance", this.ResampleTolerance);
            info.AddValue("Smoothness", this.Smoothness);
            info.AddValue("ExpectedZValues", this.ExpectedZValues);
            info.AddValue("SmoothMethod", this.SmoothMethod);
        }
        #endregion
#endif
    }
}
