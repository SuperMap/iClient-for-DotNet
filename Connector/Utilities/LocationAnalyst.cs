using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>选址分区分析参数类。</para>
    /// <para>为选址分区分析提供必要的参数信息。
    /// 包含期望用于最终设置选择的资源供给中心数量、 资源供给中心集合、转向权值字段的名称、权值信息字段的名称、是否从资源供给中心开始分配资源等。
    ///</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class LocationAnalystParameter
#else
    [Serializable]
    public class LocationAnalystParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public LocationAnalystParameter()
        { }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="locationAnalystParameter">LocationAnalystParameter 对象实例。</param>
        public LocationAnalystParameter(LocationAnalystParameter locationAnalystParameter)
        {
            if (locationAnalystParameter == null)
            {
                throw new ArgumentNullException("locationAnalystParameter");
            }
            this.ExpectedSupplyCenterCount = locationAnalystParameter.ExpectedSupplyCenterCount;
            this.IsFromCenter = locationAnalystParameter.IsFromCenter;
            //this.NodeDemandField = locationAnalystParameter.NodeDemandField;
            this.ReturnEdgeFeatures = locationAnalystParameter.ReturnEdgeFeatures;
            this.ReturnEdgeGeometry = locationAnalystParameter.ReturnEdgeGeometry;
            this.ReturnNodeFeatures = locationAnalystParameter.ReturnNodeFeatures;
            if (locationAnalystParameter.SupplyCenters != null)
            {
                this.SupplyCenters = new List<SupplyCenter>();
                for (int i = 0; i < locationAnalystParameter.SupplyCenters.Count; i++)
                {
                    if (locationAnalystParameter.SupplyCenters[i] != null)
                    {
                        this.SupplyCenters.Add(new SupplyCenter(locationAnalystParameter.SupplyCenters[i]));
                    }
                    else
                    {
                        this.SupplyCenters.Add(null);
                    }
                }
            }
            this.TurnWeightField = locationAnalystParameter.TurnWeightField;
            this.WeightName = locationAnalystParameter.WeightName;
        }

        /// <summary>
        /// <para>期望用于最终设施选址的资源供给中心数量。</para>
        /// <para>值为 0 时表明最终设施选址的资源供给中心数量默认为覆盖分析区域内的所需最少的供给中心数。</para>
        /// </summary>
        [JsonProperty("expectedSupplyCenterCount")]
        public int ExpectedSupplyCenterCount { get; set; }

        /// <summary>
        /// <para>判断是否从资源供给中心开始分配资源。 </para>
        /// <para>true 表示从资源供给中心开始分配，false 表示不从资源供给中心开始分配。</para>
        /// <para>由于网路数据中的弧段具有正反阻力，即弧段的正向阻力值与其反向阻力值可能不同，因此，在进行分析时，
        /// 从资源供给中心开始分配资源到需求点与从需求点向资源供给中心分配这两种分配形式下，所得的分析结果会不同。</para>
        /// </summary>
        /// <remarks>
        /// 下面例举两个实际的应用场景，帮助进一步理解两种形式的差异，假设网络数据集中弧段的正反阻力值不同。
        /// <list type="bullet">
        ///     <item>从资源供给中心开始分配资源到需求点： 如果你选址的对象是一些仓储中心，而需求点是各大超市，在实际的资源分配中，
        ///     是将仓储中心的货物运输到其服务的超市，这种形式就是由资源供给中心向需求点分配，即分析时要将 isFromCenter 设置为 true，即从资源供给中心开始分配。 </item>
        ///     <item>不从资源供给中心开始分配资源： 如果你选址的对象是像邮局或者银行或者学校一类的服务机构，而需求点是居民点，在实际的资源分配中，是居民点中的居民会主动去其服务机构办理业务，这种形式就不是从资源供给中心向外分配资源了，即分析时要将 isFromCenter 置为 false，即不从资源供给中心开始分配。 </item>
        /// </list>
        /// </remarks>
        [JsonProperty("isFromCenter")]
        public bool IsFromCenter { get; set; }

        //相关缺陷ISJ-2869，组件删除了与需求量相关的字段
        ///// <summary>
        /////<para>表示结点资源需求量的字段名称。 </para>
        /////<para>该字段是网络数据集中，网络结点作为需求地时，用于表示所需资源量的字段名称。</para>
        ///// </summary>
        //[JsonProperty("nodeDemandField")]
        //public string NodeDemandField { get; set; }

        private bool _returnEdgeFeatures = true;
        /// <summary>
        /// 是否返回分析结果弧段的属性信息。默认为 true。
        /// </summary>
        [JsonProperty("returnEdgeFeatures")]
        public bool ReturnEdgeFeatures
        {
            get { return _returnEdgeFeatures; }
            set { _returnEdgeFeatures = value; }
        }

        /// <summary>
        /// 是否返回分析结果弧段对象。默认为 false。
        /// </summary>
        [JsonProperty("returnEdgeGeometry")]
        public bool ReturnEdgeGeometry { get; set; }

        private bool _returnNodeFeatures = true;
        /// <summary>
        ///是否返回分析结果结点的属性信息。 默认为 true。
        /// </summary>
        [JsonProperty("returnNodeFeatures")]
        public bool ReturnNodeFeatures
        {
            get { return _returnNodeFeatures; }
            set { _returnNodeFeatures = value; }
        }

        /// <summary>
        /// <para>资源供给中心集合。</para>
        /// <para>资源供给中心集合包含了一系列资源供给中心的信息。</para>
        /// </summary>
        [JsonProperty("supplyCenters")]
        public List<SupplyCenter> SupplyCenters { get; set; }

        ///<summary>
        ///转向权值字段的名称。
        /// </summary>
        [JsonProperty("turnWeightField")]
        public string TurnWeightField { get; set; }

        /// <summary>
        ///<para>表示权值信息的字段名称。</para>
        ///<para>选址分析时所用到的权值包括正向权值和反向权值。</para>
        /// </summary>
        [JsonProperty("weightName")]
        public string WeightName { get; set; }

#if !WINDOWS_PHONE
        #region  序列化/反序列化
        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ExpectedSupplyCenterCount", this.ExpectedSupplyCenterCount);
            info.AddValue("IsFromCenter", this.IsFromCenter);
            //info.AddValue("NodeDemandField", this.NodeDemandField);
            info.AddValue("ReturnEdgeFeatures", this.ReturnEdgeFeatures);
            info.AddValue("ReturnEdgeGeometry", this.ReturnEdgeGeometry);
            info.AddValue("ReturnNodeFeatures", this.ReturnNodeFeatures);
            info.AddValue("SupplyCenters", this.SupplyCenters);
            info.AddValue("TurnWeightField", this.TurnWeightField);
            info.AddValue("WeightName", this.WeightName);
        }

        private LocationAnalystParameter(SerializationInfo info, StreamingContext context)
        {
            this.ExpectedSupplyCenterCount = info.GetInt32("ExpectedSupplyCenterCount");
            this.IsFromCenter = info.GetBoolean("IsFromCenter");
            //this.NodeDemandField = info.GetString("NodeDemandField");
            this.ReturnEdgeFeatures = info.GetBoolean("ReturnEdgeFeatures");
            this.ReturnEdgeGeometry = info.GetBoolean("ReturnEdgeGeometry");
            this.ReturnNodeFeatures = info.GetBoolean("ReturnNodeFeatures");
            this.SupplyCenters = info.GetValue("SupplyCenters", typeof(List<SupplyCenter>)) as List<SupplyCenter>;
            this.TurnWeightField = info.GetString("TurnWeightField");
            this.WeightName = info.GetString("WeightName");
        }
        #endregion
#endif
    }

    /// <summary>
    /// 选址分区分析的结果。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class LocationAnalystResult
#else
    [Serializable]
    public class LocationAnalystResult : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public LocationAnalystResult()
        {

        }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="locationAnalystResult">LocationAnalystResult 对象实例。</param>
        public LocationAnalystResult(LocationAnalystResult locationAnalystResult)
        {
            if (locationAnalystResult == null)
                throw new ArgumentNullException("locationAnalystResult");
            if (locationAnalystResult.DemandResults != null)
            {
                this.DemandResults = new List<DemandResult>();
                for (int i = 0; i < locationAnalystResult.DemandResults.Count; i++)
                {
                    if (locationAnalystResult.DemandResults[i] != null)
                    {
                        this.DemandResults.Add(new DemandResult(locationAnalystResult.DemandResults[i]));
                    }
                    else
                    {
                        this.DemandResults.Add(null);
                    }
                }
            }
            if (locationAnalystResult.SupplyResults != null)
            {
                this.SupplyResults = new List<SupplyResult>();
                for (int i = 0; i < locationAnalystResult.SupplyResults.Count; i++)
                {
                    if (locationAnalystResult.SupplyResults[i] != null)
                    {
                        this.SupplyResults.Add(new SupplyResult(locationAnalystResult.SupplyResults[i]));
                    }
                    else
                    {
                        this.SupplyResults.Add(null);
                    }
                }
            }
        }

        /// <summary>
        /// 需求结果对象数组。
        /// </summary>
        [JsonProperty("demandResults")]
        public List<DemandResult> DemandResults { get; set; }

        /// <summary>
        /// 资源供给中心结果数组。
        /// </summary>
        [JsonProperty("supplyResults")]
        public List<SupplyResult> SupplyResults { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 使用将目标对象序列化所需的数据填充 SerializationInfo。
        /// </summary>
        /// <param name="info">要填充数据的 SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DemandResults", this.DemandResults);
            info.AddValue("SupplyResults", this.SupplyResults);
        }

        private LocationAnalystResult(SerializationInfo info, StreamingContext context)
        {
            this.SupplyResults = (List<SupplyResult>)info.GetValue("SupplyResults", typeof(List<SupplyResult>));
            this.DemandResults = (List<DemandResult>)info.GetValue("DemandResults", typeof(List<DemandResult>));
        }
        #endregion
#endif
    }
}
