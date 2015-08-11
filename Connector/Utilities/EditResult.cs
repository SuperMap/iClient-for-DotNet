using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 编辑结果类。
    /// <para>
    /// 编辑操作返回的结果对象，包含操作成功是否的标识，以及被编辑的地物 ID、地图受影响的范围和操作之后的地图描述。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class EditResult
#else
    [Serializable]
    public sealed class EditResult : ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public EditResult()
        { }

        ///// <summary>
        ///// 地图受影响的范围，即被编辑过的地图数据所对应的范围。
        ///// </summary>
        //[JsonProperty("bounds")]
        //public Rectangle2D Bounds
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 所有数据被更新的实体的 ID 数组。
        /// </summary>
        [JsonProperty("ids")]
        public int[] Ids { get; set; }

        /// <summary>
        /// 获取编辑过程中产生的相关信息。
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 操作是否成功。
        /// </summary>
        [JsonProperty("succeed")]
        public bool Succeed { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private EditResult(SerializationInfo info, StreamingContext context)
        {
            //this.Bounds = (Rectangle2D)info.GetValue("Bounds", typeof(Rectangle2D));
            this.Ids = (int[])info.GetValue("Ids", typeof(int[]));
            this.Message = info.GetString("Message");
            this.Succeed = info.GetBoolean("Succeed");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("Bounds",this.Bounds);
            info.AddValue("Ids",this.Ids);
            info.AddValue("Message",this.Message);
            info.AddValue("Succeed",this.Succeed);
        }
        #endregion
#endif
    }
}
