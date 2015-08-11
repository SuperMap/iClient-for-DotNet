using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 公交站点类。
    /// <para>
    /// 该类用于描述公交站点的信息，包括坐标、SmID、ID、名称以及别名。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferStopInfo
#else
    [Serializable]
    public class TransferStopInfo : ISerializable
#endif
    {
        private string _alias;
        private int _id;
        private string _name;
        private Point2D _position;
        private long _stopId;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TransferStopInfo()
        {

        }

        /// <summary>
        /// 拷贝构造函数
        /// </summary>
        /// <param name="transferStopInfo"></param>
        public TransferStopInfo(TransferStopInfo transferStopInfo)
        {
            if (transferStopInfo == null)
            {
                throw new ArgumentNullException();
            }
            this.Alias = transferStopInfo.Alias;
            this.Id = transferStopInfo.Id;
            this.Name = transferStopInfo.Name;
            if (transferStopInfo.Position != null)
            {
                this.Position = new Point2D(transferStopInfo.Position);
            }
            this.StopId = transferStopInfo.StopId;
        }

        /// <summary>
        /// 公交站点别名。
        /// </summary>
        [JsonProperty("alias")]
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        /// <summary>
        /// 公交站点ID。
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 公交站点名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 公交站点坐标。
        /// </summary>
        [JsonProperty("position")]
        public Point2D Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// 公交站点ID，对应服务提供者配置中的stopIDField。
        /// </summary>
        [JsonProperty("stopID")]
        public long StopId
        {
            get { return _stopId; }
            set { _stopId = value; }
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
            info.AddValue("Alias", Alias);
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Position", Position);
            info.AddValue("StopId", StopId);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferStopInfo(SerializationInfo info, StreamingContext context)
        {
            this.Alias = info.GetString("Alias");
            this.Id = info.GetInt32("Id");
            this.Name = info.GetString("Name");
            this.Position = (Point2D)info.GetValue("Position", typeof(Point2D));
            this.StopId = info.GetInt64("StopId");
        }
        #endregion
#endif
    }
}
