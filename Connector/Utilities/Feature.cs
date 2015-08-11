using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 要素类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class Feature
#else
    [Serializable]
    public class Feature : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Feature()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="feature">要素对象。</param>
        /// <exception cref="ArgumentException">要素对象为 Null 时抛出异常。</exception>
        public Feature(Feature feature)
        {
            if (feature == null) throw new ArgumentException();
            if (feature.FieldNames != null)
            {
                int length = feature.FieldNames.Length;
                this.FieldNames = new string[length];
                for (int i = 0; i < length; i++)
                {
                    this.FieldNames[i] = feature.FieldNames[i];
                }
            }
            if (feature.FieldValues != null)
            {
                int length = feature.FieldValues.Length;
                this.FieldValues = new string[length];
                for (int i = 0; i < length; i++)
                {
                    this.FieldValues[i] = feature.FieldValues[i];
                }
            }
            if (feature.Geometry != null)
            {
                this.Geometry = new Geometry(feature.Geometry);
            }
        }

        /// <summary>
        /// 要素ID。
        /// </summary>
        [JsonProperty("ID")]
        public int Id { get; set; }

        /// <summary>
        /// 字段名。
        /// </summary>
        [JsonProperty("fieldNames")]
        public string[] FieldNames { get; set; }

        /// <summary>
        /// 字段值。
        /// </summary>
        [JsonProperty("fieldValues")]
        public string[] FieldValues { get; set; }

        /// <summary>
        /// 几何对象。
        /// </summary>
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected Feature(SerializationInfo info, StreamingContext context)
        {
            this.Id = info.GetInt32("Id");
            this.FieldNames = (string[])info.GetValue("FieldNames", typeof(string[]));
            this.FieldValues = (string[])info.GetValue("FieldValues", typeof(string[]));
            this.Geometry = (Geometry)info.GetValue("Geometry", typeof(Geometry));
        }

        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("FieldNames", this.FieldNames);
            info.AddValue("FieldValues", this.FieldValues);
            info.AddValue("Geometry", this.Geometry);
        }
        #endregion
#endif
    }

    /// <summary>
    /// <para>需求结果。</para>
    /// <para>该类用于描述选址分析结果中需求点的需求分配满足情况，包括需求结点的 ID、资源供给中心的信息。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class DemandResult : Feature
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public DemandResult()
            : base()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="demandResult">DemandResult 对象实例。</param>
        public DemandResult(DemandResult demandResult)
            : base(demandResult)
        {
            if (demandResult == null)
            {
                throw new ArgumentNullException("demandResult");
            }
            //this.ActualResourceValue = demandResult.ActualResourceValue;
            this.DemandID = demandResult.DemandID;
            //this.IsEdge = demandResult.IsEdge;
            if (demandResult.SupplyCenter != null)
            {
                this.SupplyCenter = new SupplyCenter(demandResult.SupplyCenter);
            }
        }

        ///// <summary>
        /////  选址分区分析时，表示需求结果到资源供给中心的最短路径值。
        ///// </summary>
        //[JsonProperty("actualResourceValue")]
        //public double ActualResourceValue { get; set; }

        /// <summary>
        ///<para>需求结果对应的结点的ID。</para>
        /////isEdge字段已经删去，相关缺陷ISJ-2869
        /////<para>当 isEdge 方法为 true 时，该方法返回的是弧段的 ID，当 isEdge 方法为 false 时，该方法返回的是结点的 ID。</para>
        /// </summary>
        [JsonProperty("demandID")]
        public int DemandID { get; set; }

        ///// <summary>
        ///// <para>判断需求结果对应的要素是弧段还是结点。</para>
        ///// <para>true 表明需求结果对应的要素是弧段， false 表明需求结果对应的要素是结点。</para>
        ///// </summary>
        //[JsonProperty("isEdge")]
        //public bool IsEdge { get; set; }

        /// <summary>
        /// 需求结果对应的资源供给中心。
        /// </summary>
        [JsonProperty("supplyCenter")]
        public SupplyCenter SupplyCenter { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("ActualResourceValue", this.ActualResourceValue);
            info.AddValue("DemandID", this.DemandID);
            //info.AddValue("IsEdge", this.IsEdge);
            info.AddValue("SupplyCenter", this.SupplyCenter);
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected DemandResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //this.ActualResourceValue = info.GetDouble("ActualResourceValue");
            this.DemandID = info.GetInt32("DemandID");
            //this.IsEdge = info.GetBoolean("IsEdge");
            this.SupplyCenter = (SupplyCenter)info.GetValue("SupplyCenter", typeof(SupplyCenter));
        }
        #endregion
#endif
    }

    /// <summary>
    /// <para>资源供给中心点结果类。</para>
    /// <para>用于在选址分析中描述每一个资源中心的情况：中心的类型、ID、最大耗费、服务的需求数、资源耗费量等。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class SupplyResult : Feature
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public SupplyResult()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="supplyResult">SupplyResult 对象实例。</param>
        public SupplyResult(SupplyResult supplyResult)
            : base(supplyResult)
        {
            if (supplyResult == null)
            {
                throw new ArgumentNullException("supplyResult");
            }
            //this.ActualResourceValue = supplyResult.ActualResourceValue;
            this.AverageWeight = supplyResult.AverageWeight;
            this.DemandCount = supplyResult.DemandCount;
            this.MaxWeight = supplyResult.MaxWeight;
            this.NodeID = supplyResult.NodeID;
            //this.ResourceValue = supplyResult.ResourceValue;
            this.TotalWeights = supplyResult.TotalWeights;
            this.Type = supplyResult.Type;
        }

        ///// <summary>
        ///// 资源供给中心实际提供的资源量。
        ///// </summary>
        //[JsonProperty("actualResourceValue")]
        //public double ActualResourceValue { get; set; }

        /// <summary>
        /// 从本资源供给中心到每个需求点的平均耗费（阻值）。
        /// </summary>
        [JsonProperty("averageWeight")]
        public double AverageWeight { get; set; }

        /// <summary>
        /// 所服务的需求点（弧段）的数量。
        /// </summary>
        [JsonProperty("demandCount")]
        public int DemandCount { get; set; }

        /// <summary>
        /// 各个需求对象到资源供给中心的最大耗费（阻值）。如果需求对象（如弧段或结点）到此中心的花费大于此值，则该对象被过滤掉。
        /// </summary>
        [JsonProperty("maxWeight")]
        public double MaxWeight { get; set; }

        /// <summary>
        /// 资源供给中心点的结点 ID。
        /// </summary>
        [JsonProperty("nodeID")]
        public int NodeID { get; set; }

        ///// <summary>
        ///// 资源供给中心的资源量。
        ///// </summary>
        //[JsonProperty("resourceValue")]
        //public double ResourceValue { get; set; }

        /// <summary>
        /// 从本资源供给中心到所有需求点的总耗费（阻值）。
        /// </summary>
        [JsonProperty("totalWeights")]
        public double TotalWeights { get; set; }

        /// <summary>
        /// <para>资源供给中心点的类型。</para>
        /// <para>资源供给中心点的类型包括非中心，固定中心和可选中心。固定中心用于资源分配分析； 固定中心和可选中心用于选址分析；非中心在两种网络分析时都不予考虑。</para>
        /// </summary>
        [JsonProperty("type")]
        public SupplyCenterType Type { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("ActualResourceValue", this.ActualResourceValue);
            info.AddValue("AverageWeight", this.AverageWeight);
            info.AddValue("DemandCount", this.DemandCount);
            info.AddValue("MaxWeight", this.MaxWeight);
            info.AddValue("NodeID", this.NodeID);
            //info.AddValue("ResourceValue", this.ResourceValue);
            info.AddValue("TotalWeights", this.TotalWeights);
            info.AddValue("Type", this.Type);
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SupplyResult(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //this.ActualResourceValue = info.GetDouble("ActualResourceValue");
            this.AverageWeight = info.GetDouble("AverageWeight");
            this.DemandCount = info.GetInt32("DemandCount");
            this.MaxWeight = info.GetDouble("MaxWeight");
            this.NodeID = info.GetInt32("NodeID");
            //this.ResourceValue = info.GetDouble("ResourceValue");
            this.TotalWeights = info.GetDouble("TotalWeights");
            this.Type = (SupplyCenterType)info.GetValue("Type", typeof(SupplyCenterType));
        }
        #endregion
#endif
    }
}
