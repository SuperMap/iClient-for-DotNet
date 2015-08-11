using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 公交换乘导引类。
    /// <para>
    /// 公交换乘导引记录了从换乘分析起始站点到终止站点的公交换乘导引方案。公交换乘导引由公交换乘导引子项（TransferGuideItem 类型对象）构成，每一个导引子项可以表示一段换乘或者步行线路。通过本类型可以返回公交换乘导引对象中子项的个数，根据序返回公交换乘导引的子项对象，导引总距离以及总花费等。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class TransferGuide
#else
    [Serializable]
    public class TransferGuide:ISerializable
#endif
    {
        private int _count;
        private TransferGuideItem[] _items;
        private double _totalDistance;
        private double _totalWeight;
        private int _transferCount;

        /// <summary>
        /// 初始化TransferGuide类的新实例。
        /// </summary>
        public TransferGuide()
        {

        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="transferGuides">TransferGuide对象。</param>
        public TransferGuide(TransferGuide transferGuides)
        {
            if (transferGuides == null)
            {
                throw new ArgumentNullException();
            }
            Count = transferGuides.Count;
            TotalDistance = transferGuides.TotalDistance;
            TransferCount = transferGuides.TransferCount;
            if (transferGuides.Items != null && transferGuides.Items.Length > 0)
            {
                Items = new TransferGuideItem[transferGuides.Items.Length];
                for (int i = 0; i < transferGuides.Items.Length; i++)
                {
                    if (transferGuides.Items[i] != null)
                    {
                        Items[i] = new TransferGuideItem(transferGuides.Items[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 返回公交换乘导引对象中子项的个数。 
        /// </summary>
        [JsonProperty("count")]
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        /// <summary>
        /// 根据指定的序号返回公交换乘导引中的子项对象。
        /// </summary>
        [JsonProperty("items")]
        public TransferGuideItem[] Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 返回公交换乘导引的总距离，即当前换乘方案的总距离。
        /// </summary>
        [JsonProperty("totalDistance")]
        public double TotalDistance
        {
            get { return _totalDistance; }
            set { _totalDistance = value; }
        }

        /// <summary>
        /// 返回公交换乘次数，因为中途可能有步行的子项，所以公交换乘次数不能根据换乘导引子项个数 来简单计算。
        /// </summary>
        [JsonProperty("transferCount")]
        public int TransferCount
        {
            get { return _transferCount; }
            set { _transferCount = value; }
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
            info.AddValue("Count",Count);
            info.AddValue("Items",Items);
            info.AddValue("TotalDistance",TotalDistance);
            info.AddValue("TransferCount", TransferCount);
        }

        /// <summary>
        /// 反序列化的构造函数。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        protected TransferGuide(SerializationInfo info, StreamingContext context)
        {
            Count = info.GetInt32("Count");
            Items = (TransferGuideItem[])info.GetValue("Items", typeof(TransferGuideItem[]));
            TotalDistance = info.GetDouble("TotalDistance");
            TransferCount = info.GetInt32("TransferCount");
        }

        #endregion
#endif
    }
}
