using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 地图投影参数类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class PrjParameter
#else
    [Serializable]
    public sealed class PrjParameter : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public PrjParameter()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="prjParameter">地图投影参数对象。</param>
        /// <exception cref="ArgumentNullException">地图投影参数对象为 null 时抛出异常。</exception>
        public PrjParameter(PrjParameter prjParameter)
        {
            if (prjParameter == null) throw new ArgumentNullException();
            this.Azimuth = prjParameter.Azimuth;
            this.CentralMeridian = prjParameter.CentralMeridian;
            this.CentralParallel = prjParameter.CentralParallel;
            this.FalseEasting = prjParameter.FalseEasting;
            this.FalseNorthing = prjParameter.FalseNorthing;
            this.FirstPointLongitude = prjParameter.FirstPointLongitude;
            this.FirstStandardParallel = prjParameter.FirstStandardParallel;
            this.ScaleFactor = prjParameter.ScaleFactor;
            this.SecondPointLongitude = prjParameter.SecondPointLongitude;
            this.SecondStandardParallel = prjParameter.SecondStandardParallel;
        }
        /// <summary>
        /// 方位角。 
        /// </summary>
        [JsonProperty("azimuth")]
        public double Azimuth { get; set; }

        /// <summary>
        /// 中央经线角度值。 
        /// </summary>
        [JsonProperty("centralMeridian")]
        public double CentralMeridian { get; set; }

        /// <summary>
        ///  坐标原点对应纬度值。 
        /// </summary>
        [JsonProperty("centralParallel")]
        public double CentralParallel { get; set; }

        /// <summary>
        /// 坐标水平偏移量。
        /// </summary>
        [JsonProperty("falseEasting")]
        public double FalseEasting { get; set; }

        /// <summary>
        /// 坐标垂直偏移量。 
        /// </summary>
        [JsonProperty("falseNorthing")]
        public double FalseNorthing { get; set; }

        /// <summary>
        ///第一个点的经度。 
        /// </summary>
        [JsonProperty("firstPointLongitude")]
        public double FirstPointLongitude { get; set; }

        /// <summary>
        ///第一标准纬线的纬度值。  
        /// </summary>
        [JsonProperty("firstStandardParallel")]
        public double FirstStandardParallel { get; set; }

        /// <summary>
        ///投影转换的比例因子。  
        /// </summary>
        [JsonProperty("scaleFactor")]
        public double ScaleFactor { get; set; }

        /// <summary>
        ///第二个点的经度。  
        /// </summary>
        [JsonProperty("secondPointLongitude")]
        public double SecondPointLongitude { get; set; }

        /// <summary>
        ///第二标准纬线的纬度值。  
        /// </summary>
        [JsonProperty("secondStandardParallel")]
        public double SecondStandardParallel { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private PrjParameter(SerializationInfo info, StreamingContext context)
        {
            this.Azimuth = info.GetDouble("Azimuth");
            this.CentralMeridian = info.GetDouble("CentralMeridian");
            this.CentralParallel = info.GetDouble("CentralParallel");
            this.FalseEasting = info.GetDouble("FalseEasting");
            this.FalseNorthing = info.GetDouble("FalseNorthing");
            this.FirstPointLongitude = info.GetDouble("FirstPointLongitude");
            this.FirstStandardParallel = info.GetDouble("FirstStandardParallel");
            this.ScaleFactor = info.GetDouble("ScaleFactor");
            this.SecondPointLongitude = info.GetDouble("SecondPointLongitude");
            this.SecondStandardParallel = info.GetDouble("SecondStandardParallel");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Azimuth", this.Azimuth);
            info.AddValue("CentralMeridian", this.CentralMeridian);
            info.AddValue("CentralParallel", this.CentralParallel);
            info.AddValue("FalseEasting", this.FalseEasting);
            info.AddValue("FalseNorthing", this.FalseNorthing);
            info.AddValue("FirstPointLongitude", this.FirstPointLongitude);
            info.AddValue("FirstStandardParallel", this.FirstStandardParallel);
            info.AddValue("ScaleFactor", this.ScaleFactor);
            info.AddValue("SecondPointLongitude", this.SecondPointLongitude);
            info.AddValue("SecondStandardParallel", this.SecondStandardParallel);
        }
        #endregion
#endif
    }
}
