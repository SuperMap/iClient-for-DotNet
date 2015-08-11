using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 公交换乘导引子项类
    /// <para>
    /// 交通换乘导引记录了从换乘分析起始站点到终止站点需要换乘或者步行的线路，其中每一换乘或步行线路就是一个交通换乘导引子项。利用该类可以返回交通换乘导引对象的子项信息，诸如交通换乘导引子项的起始站点信息、终止站点信息、公交线路信息等。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferGuideItem
#else
    [Serializable]
    public class TransferGuideItem : ISerializable
#endif
    {
        private double _distance;
        private int _endIndex;
        private Point2D _endPosition;
        private string _endStopName;
        private string _lineName;
        private bool _isWalking;
        private int _passStopCount;
        private Geometry _route;
        private int _startIndex;
        private Point2D _startPosition;
        private string _startStopName;

        /// <summary>
        /// 初始化TransferGuideItem类的新实例。
        /// </summary>
        public TransferGuideItem()
        {

        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="transferGuideItem">TransferGuideItem对象。</param>
        public TransferGuideItem(TransferGuideItem transferGuideItem)
        {
            if (transferGuideItem == null)
            {
                throw new ArgumentNullException();
            }
            this.Distance = transferGuideItem.Distance;
            this.EndIndex = transferGuideItem.EndIndex;
            if (transferGuideItem.EndPosition != null)
            {
                this.EndPosition = new Point2D(transferGuideItem.EndPosition);
            }
            this.EndStopName = transferGuideItem.EndStopName;
            this.IsWalking = transferGuideItem.IsWalking;
            this.LineName = transferGuideItem.LineName;
            this.PassStopCount = transferGuideItem.PassStopCount;
            if (transferGuideItem.Route != null)
            {
                this.Route = new Geometry(transferGuideItem.Route);
            }
            this.StartIndex = transferGuideItem.StartIndex;
            if (transferGuideItem.StartPosition != null)
            {
                this.StartPosition = new Point2D(transferGuideItem.StartPosition);
            }
            this.StartStopName = transferGuideItem.StartStopName;
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘或者步行线路的距离。
        /// </summary>
        [JsonProperty("distance")]
        public double Distance
        {
            get { return _distance; }
            private set { _distance = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘线路的终止站点在其完整的公交线路中处在第几个站点位置。
        /// </summary>
        [JsonProperty("endIndex")]
        public int EndIndex
        {
            get { return _endIndex; }
            private set { _endIndex = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘或者步行线路的终止站点位置坐标。
        /// </summary>
        [JsonProperty("endPosition")]
        public Point2D EndPosition
        {
            get { return _endPosition; }
            private set { _endPosition = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘线路的终止站点的名称。
        /// </summary>
        [JsonProperty("endStopName")]
        public string EndStopName
        {
            get { return _endStopName; }
            set { _endStopName = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示是步行线路还是乘车线路。
        /// </summary>
        [JsonProperty("isWalking")]
        public bool IsWalking
        {
            get { return _isWalking; }
            private set { _isWalking = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘线路名称。
        /// </summary>
        [JsonProperty("lineName")]
        public string LineName
        {
            get { return _lineName; }
            set { _lineName = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘线路所经过的站点个数。
        /// </summary>
        [JsonProperty("passStopCount")]
        public int PassStopCount
        {
            get { return _passStopCount; }
            private set { _passStopCount = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘或者步行的线路的线对象。
        /// </summary>
        [JsonProperty("route")]
        public Geometry Route
        {
            get { return _route; }
            set { _route = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘线路的起始站点在其完整的公交线路中处在第几个站点位置。
        /// </summary>
        [JsonProperty("startIndex")]
        public int StartIndex
        {
            get { return _startIndex; }
            private set { _startIndex = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘或者步行线路的起始站点的位置坐标。
        /// </summary>
        [JsonProperty("startPosition")]
        public Point2D StartPosition
        {
            get { return _startPosition; }
            set { _startPosition = value; }
        }

        /// <summary>
        /// 返回该 TransferGuideItem 对象所表示的一段换乘线路的起始站点的名称。
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
            info.AddValue("Distance", Distance);
            info.AddValue("EndIndex", EndIndex);
            info.AddValue("EndPosition", EndPosition);
            info.AddValue("EndStopName", EndStopName);
            info.AddValue("IsWalking", IsWalking);
            info.AddValue("LineName", LineName);
            info.AddValue("PassStopCount", PassStopCount);
            info.AddValue("Route", Route);
            info.AddValue("StartIndex", StartIndex);
            info.AddValue("StartPosition", StartPosition);
            info.AddValue("StartStopName", StartStopName);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferGuideItem(SerializationInfo info, StreamingContext context)
        {
            Distance = info.GetDouble("Distance");
            EndIndex = info.GetInt32("EndIndex");
            EndPosition = (Point2D)info.GetValue("EndPosition", typeof(Point2D));
            EndStopName = info.GetString("EndStopName");
            IsWalking = info.GetBoolean("IsWalking");
            LineName = info.GetString("LineName");
            PassStopCount = info.GetInt32("PassStopCount");
            Route = (Geometry)info.GetValue("Route", typeof(Geometry));
            StartIndex = info.GetInt32("StartIndex");
            StartPosition = (Point2D)info.GetValue("StartPosition", typeof(Point2D));
            StartStopName = info.GetString("StartStopName");
        }

        #endregion
#endif
    }
}
