using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>资源供给中心类。</para>
    /// <para>资源供给中心类在网络分析的资源分配和选址分区功能中使用。</para>
    /// <para>选址分析是指为一个或多个待建的设施选定最佳或最优的地址以使需求方以一种最高效的方式获取服务或者商品。
    /// 资源分配模拟现实世界网络中资源的供需关系模型,资源根据网络阻力值的设置，
    /// 由供应点逐步向需求点(包括弧段或结点)分配,并确保供应点能以最经济有效的方式为需求点提供资源。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class SupplyCenter
#else
    [Serializable]
    public class SupplyCenter : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public SupplyCenter()
        {

        }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="supplyCenter"><see cref="SupplyCenter"/>类型对象。</param>
        public SupplyCenter(SupplyCenter supplyCenter)
        {
            if (supplyCenter == null)
            {
                throw new ArgumentNullException("supplyCenter");
            }
            this.MaxWeight = supplyCenter.MaxWeight;
            this.NodeID = supplyCenter.NodeID;
            //this.ResourceValue = supplyCenter.ResourceValue;
            this.Type = supplyCenter.Type;
        }

        /// <summary>
        /// <para>资源供给中心的最大耗费（阻值）。</para>
        /// <para>中心点最大阻值设置越大，表示中心点所提供的资源可影响范围越大。</para>
        /// <para>最大阻力值是用来限制需求点到中心点的花费。 如果需求点（弧段或结点）到此中心的花费大于最大阻力值，则该需求点被过滤掉。</para>
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
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaxWeight", this.MaxWeight);
            info.AddValue("NodeID", this.NodeID);
            //info.AddValue("ResourceValue", this.ResourceValue);
            info.AddValue("Type", this.Type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SupplyCenter(SerializationInfo info, StreamingContext context)
        {
            this.MaxWeight = info.GetDouble("MaxWeight");
            this.NodeID = info.GetInt32("NodeID");
            //this.ResourceValue = info.GetDouble("ResourceValue");
            this.Type = (SupplyCenterType)info.GetValue("Type", typeof(SupplyCenterType));
        }
        #endregion
#endif
    }
}
