using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 插值通用参数设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public abstract class InterpolationParameter
#else
    [Serializable]
    public abstract class InterpolationParameter : ISerializable
#endif
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public InterpolationParameter()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="interpolationParameter">插值通用参数设置类。</param>
        /// <exception cref="ArgumentNullException">插值通用参数设置类为 null 时抛出异常。</exception>
        public InterpolationParameter(InterpolationParameter interpolationParameter)
        {
            if (interpolationParameter == null)
            {
                throw new ArgumentNullException("interpolationParameter");
            }
            if (interpolationParameter.Bounds != null)
            {
                this.Bounds = new Rectangle2D(interpolationParameter.Bounds);
            }
            this.ExpectedCount = interpolationParameter.ExpectedCount;
            if (interpolationParameter.FilterQueryParameter != null)
            {
                this.FilterQueryParameter = new QueryParameter(interpolationParameter.FilterQueryParameter);
            }
            this.MaxPointCountForInterpolation = interpolationParameter.MaxPointCountForInterpolation;
            this.MaxPointCountInNode = interpolationParameter.MaxPointCountInNode;
            this.OutputDatasetName = interpolationParameter.OutputDatasetName;
            this.OutputDatasourceName = interpolationParameter.OutputDatasourceName;
            this.PixelFormat = interpolationParameter.PixelFormat;
            this.Resolution = interpolationParameter.Resolution;
            this.SearchMode = interpolationParameter.SearchMode;
            this.SearchRadius = interpolationParameter.SearchRadius;
            this.ZValueFieldName = interpolationParameter.ZValueFieldName;
            this.ZValueScale = interpolationParameter.ZValueScale;
        }

        /// <summary>
        /// 数据集过滤条件。
        /// </summary>
        [JsonProperty("filterQueryParameter")]
        public QueryParameter FilterQueryParameter { get; set; }

        /// <summary>
        /// 存储用于进行插值分析的值的字段名称，插值分析不支持文本类型的字段。
        /// </summary>
        [JsonProperty("zValueFieldName")]
        public string ZValueFieldName { get; set; }

        /// <summary>
        /// 用于进行插值分析值的缩放比率。
        /// </summary>
        [JsonProperty("zValueScale")]
        public double ZValueScale { get; set; }

        /// <summary>
        /// 用于存放结果数据集的数据源。
        /// </summary>
        [JsonProperty("outputDatasourceName")]
        public string OutputDatasourceName { get; set; }

        /// <summary>
        /// 指定结果数据集的名称。
        /// </summary>
        [JsonProperty("outputDatasetName")]
        public string OutputDatasetName { get; set; }

        /// <summary>
        /// 指定结果栅格数据集存储的像素格式，插值分析不支持 BIT64像素格式。
        /// </summary>
        [JsonProperty("pixelFormat")]
        public PixelFormat PixelFormat { get; set; }

        /// <summary>
        /// 插值分析的范围，用于确定运行结果的范围。
        /// </summary>
        [JsonProperty("bounds")]
        public Rectangle2D Bounds { get; set; }

        /// <summary>
        /// 插值运算时使用的分辨率。
        /// </summary>
        [JsonProperty("resolution")]
        public double Resolution { get; set; }

        /// <summary>
        /// 插值运算时，查找参与运算点的方式。
        /// </summary>
        [JsonProperty("searchMode")]
        public SearchMode SearchMode { get; set; }

        /// <summary>
        /// 参与运算点的查找范围。
        /// </summary>
        [JsonProperty("searchRadius")]
        public double SearchRadius { get; set; }

        /// <summary>
        /// 待查找的点数。
        /// </summary>
        [JsonProperty("expectedCount")]
        public int ExpectedCount { get; set; }

        /// <summary>
        /// 块查找时，最多参与插值的点数。
        /// </summary>
        [JsonProperty("maxPointCountForInterpolation")]
        public int MaxPointCountForInterpolation { get; set; }

        /// <summary>
        /// 块查找时，单个块内最多查找点数。
        /// </summary>
        [JsonProperty("maxPointCountInNode")]
        public int MaxPointCountInNode { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FilterQueryParameter", this.FilterQueryParameter);
            info.AddValue("ZValueFieldName", this.ZValueFieldName);
            info.AddValue("ZValueScale", this.ZValueScale);
            info.AddValue("OutputDatasourceName", this.OutputDatasourceName);
            info.AddValue("OutputDatasetName", this.OutputDatasetName);
            info.AddValue("PixelFormat", this.PixelFormat);
            info.AddValue("Bounds", this.Bounds);
            info.AddValue("Resolution", this.Resolution);
            info.AddValue("SearchMode", this.SearchMode);
            info.AddValue("SearchRadius", this.SearchRadius);
            info.AddValue("ExpectedCount", this.ExpectedCount);
            info.AddValue("MaxPointCountForInterpolation", this.MaxPointCountForInterpolation);
            info.AddValue("MaxPointCountInNode", this.MaxPointCountInNode);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected InterpolationParameter(SerializationInfo info, StreamingContext context)
        {
            this.FilterQueryParameter = (QueryParameter)info.GetValue("FilterQueryParameter", typeof(QueryParameter));
            this.ZValueFieldName = info.GetString("ZValueFieldName");
            this.ZValueScale = info.GetDouble("ZValueScale");
            this.OutputDatasourceName = info.GetString("OutputDatasourceName");
            this.OutputDatasetName = info.GetString("OutputDatasetName");
            this.PixelFormat = (PixelFormat)info.GetValue("PixelFormat", typeof(PixelFormat));
            this.Bounds = (Rectangle2D)info.GetValue("Bounds", typeof(Rectangle2D));
            this.Resolution = info.GetDouble("Resolution");
            this.SearchMode = (Utility.SearchMode)info.GetValue("SearchMode", typeof(Utility.SearchMode));
            this.SearchRadius = info.GetDouble("SearchRadius");
            this.ExpectedCount = info.GetInt32("ExpectedCount");
            this.MaxPointCountForInterpolation = info.GetInt32("MaxPointCountForInterpolation");
            this.MaxPointCountInNode = info.GetInt32("MaxPointCountInNode");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 点密度插值的参数设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class InterpolationDensityParameter : InterpolationParameter
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public InterpolationDensityParameter()
            : base()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        public InterpolationDensityParameter(InterpolationDensityParameter param)
            : base(param)
        {
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        private InterpolationDensityParameter(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            
        }
        #endregion
#endif
    }

    /// <summary>
    /// 反距离加权插值的参数设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class InterpolationIDWParameter : InterpolationParameter
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public InterpolationIDWParameter()
            : base()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        public InterpolationIDWParameter(InterpolationIDWParameter param)
            : base(param)
        {
            this.Power = param.Power;
        }

        /// <summary>
        /// 距离权重计算的幂次。
        /// </summary>
        [JsonProperty("power")]
        public int Power { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Power", this.Power);
            base.GetObjectData(info, context);
        }

        private InterpolationIDWParameter(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Power = info.GetInt32("Power");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 普通克吕金插值的参数设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class InterpolationKrigingParameter : InterpolationParameter
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public InterpolationKrigingParameter()
            : base()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        public InterpolationKrigingParameter(InterpolationKrigingParameter param)
            : base(param)
        {
            this.Angle = param.Angle;
            this.Nugget = param.Nugget;
            this.Range = param.Range;
            this.Sill = param.Sill;
            this.Mean = param.Mean;
            this.VariogramMode = param.VariogramMode;
            this.Exponent = param.Exponent;
        }

        /// <summary>
        /// 克吕金算法中旋转角度值。 当InterpolationParameter.searchMode为SearchMode.QUADTREE时该属性不起作用。
        /// </summary>
        [JsonProperty("angle")]
        public double Angle { get; set; }

        /// <summary>
        /// 块金效应值。
        /// </summary>
        [JsonProperty("nugget")]
        public double Nugget { get; set; }

        /// <summary>
        /// 自相关阈值。
        /// </summary>
        [JsonProperty("range")]
        public double Range { get; set; }

        /// <summary>
        /// 基台值。
        /// </summary>
        [JsonProperty("sill")]
        public double Sill { get; set; }

        /// <summary>
        /// 克吕金（Kriging）插值时的半变函数类型。
        /// </summary>
        [JsonProperty("variogramMode")]
        public VariogramMode VariogramMode { get; set; }

        /// <summary>
        /// 用于插值的样点数据中趋势面方程的阶数。此属性只适用于泛克吕金方法。
        /// </summary>
        [JsonProperty("exponent")]
        public Exponent Exponent { get; set; }

        /// <summary>
        /// 插值字段的平均值，即采样点插值字段值总和除以采样点数目。此属性只适用于简单克吕金方法。
        /// </summary>
        [JsonProperty("mean")]
        public double Mean { get; set; }

        /// <summary>
        /// 克吕金插值算法的类型。
        /// </summary>
        [JsonProperty("type")]
        public KrigingAlgorithmType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Angle", this.Angle);
            info.AddValue("Nugget", this.Nugget);
            info.AddValue("Range", this.Range);
            info.AddValue("Sill", this.Sill);
            info.AddValue("VariogramMode", this.VariogramMode);
            info.AddValue("Exponent", this.Exponent);
            info.AddValue("Mean", this.Mean);
            base.GetObjectData(info, context);
        }

        private InterpolationKrigingParameter(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Angle = info.GetDouble("Angle");
            this.Nugget = info.GetDouble("Nugget");
            this.Range = info.GetDouble("Range");
            this.Sill = info.GetDouble("Sill");
            this.VariogramMode = (Utility.VariogramMode)info.GetValue("VariogramMode", typeof(Utility.VariogramMode));
            this.Exponent = (Utility.Exponent)info.GetValue("Exponent", typeof(Utility.Exponent));
            this.Mean = info.GetDouble("Mean");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 样条插值法的参数设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class InterpolationRBFParameter : InterpolationParameter
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public InterpolationRBFParameter()
            : base()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        public InterpolationRBFParameter(InterpolationRBFParameter param)
            : base(param)
        {
            this.Smooth = param.Smooth;
            this.Tension = param.Tension;
        }

        /// <summary>
        /// 光滑系数，值域为 0-1。
        /// </summary>
        [JsonProperty("smooth")]
        public double Smooth { get; set; }

        /// <summary>
        /// 张力系数。
        /// </summary>
        [JsonProperty("tension")]
        public double Tension { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Smooth", this.Smooth);
            info.AddValue("Tension", this.Tension);
            base.GetObjectData(info, context);
        }

        private InterpolationRBFParameter(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Smooth = info.GetDouble("Smooth");
            this.Tension = info.GetDouble("Tension");
        }
        #endregion
#endif
    }

}
