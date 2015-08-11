using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 换乘路线信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferLine
#else
    [Serializable]
    public class TransferLine : ISerializable
#endif
    {
        private int _endStopIndex;
        private string _endStopName;
        private int _lineID;
        private string _lineName;
        private int _startStopIndex;
        private string _startStopName;

        /// <summary>
        /// 初始化TransferLine类的新实例。
        /// </summary>
        public TransferLine()
        {

        }

        /// <summary>
        /// 拷贝构造函数
        /// </summary>
        /// <param name="transferLine">TransferLine对象。</param>
        public TransferLine(TransferLine transferLine)
        {
            if (transferLine == null)
            {
                throw new ArgumentNullException();
            }
            this.EndStopIndex = transferLine.EndStopIndex;
            this.EndStopName = transferLine.EndStopName;
            this.LineID = transferLine.LineID;
            this.LineName = transferLine.LineName;
            this.StartStopIndex = transferLine.StartStopIndex;
            this.StartStopName = transferLine.StartStopName;
        }

        /// <summary>
        /// 下车站点在本公交路线中的索引。
        /// </summary>
        [JsonProperty("endStopIndex")]
        public int EndStopIndex
        {
            get { return _endStopIndex; }
            set { _endStopIndex = value; }
        }

        /// <summary>
        /// 下车站点名称。
        /// </summary>
        [JsonProperty("endStopName")]
        public string EndStopName
        {
            get { return _endStopName; }
            set { _endStopName = value; }
        }

        /// <summary>
        /// 乘车路线ID。
        /// </summary>
        [JsonProperty("lineID")]
        public int LineID
        {
            get { return _lineID; }
            set { _lineID = value; }
        }

        /// <summary>
        /// 乘车路线名称。
        /// </summary>
        [JsonProperty("lineName")]
        public string LineName
        {
            get { return _lineName; }
            set { _lineName = value; }
        }

        /// <summary>
        /// 上车站点在本公交路线中的索引。
        /// </summary>
        [JsonProperty("startStopIndex")]
        public int StartStopIndex
        {
            get { return _startStopIndex; }
            set { _startStopIndex = value; }
        }

        /// <summary>
        /// 上车站点名称。
        /// </summary>
        [JsonProperty("startStopName")]
        public string StartStopName
        {
            get { return _startStopName; }
            set { _startStopName = value; }
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EndStopIndex", EndStopIndex);
            info.AddValue("EndStopName", EndStopName);
            info.AddValue("LineID", LineID);
            info.AddValue("LineName", LineName);
            info.AddValue("StartStopIndex", StartStopIndex);
            info.AddValue("StartStopName", StartStopName);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferLine(SerializationInfo info, StreamingContext context)
        {
            EndStopIndex = info.GetInt32("EndStopIndex");
            EndStopName = info.GetString("EndStopName");
            LineID = info.GetInt32("LineID");
            LineName = info.GetString("LineName");
            StartStopIndex = info.GetInt32("StartStopIndex");
            StartStopName = info.GetString("StartStopName");
        }

        #endregion
#endif
    }
}
