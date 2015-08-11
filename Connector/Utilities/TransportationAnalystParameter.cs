using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 交通网络分析通用参数。
    /// <para>
    /// 该类主要用来提供交通网络分析所需的通用参数。通过本类可以设置障碍边、障碍点、权值字段信息的名称标识、 转向权值字段等信息，还可以对分析结果包含的内容进行一些设置。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class TransportationAnalystParameter
#else
    [Serializable]
    public sealed class TransportationAnalystParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public TransportationAnalystParameter()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="parameter">交通网络分析通用参数对象。</param>
        public TransportationAnalystParameter(TransportationAnalystParameter parameter)
        {
            if (parameter == null) throw new ArgumentException();
            if (parameter.BarrierEdgeIDs != null)
            {
                int length = parameter.BarrierEdgeIDs.Length;
                this.BarrierEdgeIDs = new int[length];
                for (int i = 0; i < length; i++)
                {
                    this.BarrierEdgeIDs[i] = parameter.BarrierEdgeIDs[i];
                }
            }
            if (parameter.BarrierNodeIDs != null)
            {
                int length = parameter.BarrierNodeIDs.Length;
                this.BarrierNodeIDs = new int[length];
                for (int i = 0; i < length; i++)
                {
                    this.BarrierNodeIDs[i] = parameter.BarrierNodeIDs[i];
                }
            }

            if (parameter.BarrierPoints != null)
            {
                int length = parameter.BarrierPoints.Length;
                this.BarrierPoints = new Point2D[length];
                for (int i = 0; i < length; i++)
                {
                    this.BarrierPoints[i] = new Point2D(parameter.BarrierPoints[i]);
                }
            }
            if (parameter.ResultSetting != null)
            {
                this.ResultSetting = new TransportationAnalystResultSetting(parameter.ResultSetting);
            }
            this.TurnWeightField = parameter.TurnWeightField;
            this.WeightFieldName = parameter.WeightFieldName;

        }

        /// <summary>
        /// 障碍弧段 ID 列表。
        /// </summary>
        [JsonProperty("barrierEdgeIDs")]
        public int[] BarrierEdgeIDs { get; set; }

        /// <summary>
        /// 障碍结点 ID 的集合。
        /// </summary>
        [JsonProperty("barrierNodeIDs")]
        public int[] BarrierNodeIDs { get; set; }

        /// <summary>
        /// 障碍坐标数组，以坐标的形式设置障碍。
        /// </summary>
        [JsonProperty("barrierPoints")]
        public Point2D[] BarrierPoints { get; set; }

        /// <summary>
        /// 分析结果应包含内容的设置。
        /// </summary>
        [JsonProperty("resultSetting")]
        public TransportationAnalystResultSetting ResultSetting { get; set; }

        /// <summary>
        /// 转向权值字段的名称。
        /// </summary>
        [JsonProperty("turnWeightField")]
        public string TurnWeightField { get; set; }

        /// <summary>
        /// 权值字段信息的名称，标识了进行网络分析时所使用的权值字段。
        /// </summary>
        [JsonProperty("weightFieldName")]
        public string WeightFieldName { get; set; }

#if !WINDOWS_PHONE
        #region ISerializable 成员
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BarrierEdgeIDs", this.BarrierEdgeIDs);
            info.AddValue("BarrierNodeIDs", this.BarrierNodeIDs);
            info.AddValue("BarrierPoints", this.BarrierPoints);
            info.AddValue("ResultSetting", this.ResultSetting);
            info.AddValue("TurnWeightField", this.TurnWeightField);
            info.AddValue("WeightFieldName", this.WeightFieldName);
        }

        private TransportationAnalystParameter(SerializationInfo info, StreamingContext context)
        {
            this.BarrierEdgeIDs = (int[])info.GetValue("BarrierEdgeIDs", typeof(int[]));
            this.BarrierNodeIDs = (int[])info.GetValue("BarrierNodeIDs", typeof(int[]));
            this.BarrierPoints = (Point2D[])info.GetValue("BarrierPoints", typeof(Point2D[]));
            this.ResultSetting = (TransportationAnalystResultSetting)info.GetValue("ResultSetting",
                typeof(TransportationAnalystResultSetting));
            this.TurnWeightField = info.GetString("TurnWeightField");
            this.WeightFieldName = info.GetString("WeightFieldName");
        }
        #endregion
#endif
    }
}
