using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>行驶导引子项类。</para>
    /// <para>
    /// 行驶导引记录了如何一步步从起点行驶到终点，其中每一步就是一个行驶导引子项，
    /// 包括行驶过程中经过的点和弧段， 这些点可以是分析时选取的站点，也可以是分析
    /// 结果途经的网络结点；弧段可以是网络边，也可能是一条网络边的一部分 （如果分
    /// 析的站点不在网络结点上）。 利用该类可以对行驶导引对象的子项进行一些设置， 
    /// 诸如返回子项的 ID、名称、序号、权值等，可以判断子项是点还是弧段，还可以返
    /// 回行驶方向、转弯方向等等。
    /// </para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class PathGuideItem
#else
    [Serializable]
    public sealed class PathGuideItem : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public PathGuideItem()
        { }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="pathGuideItem"></param>
        public PathGuideItem(PathGuideItem pathGuideItem)
        {
            if (pathGuideItem == null) throw new ArgumentException();
            if (pathGuideItem.Bounds != null)
            {
                this.Bounds = new Rectangle2D(pathGuideItem.Bounds);
            }
            this.Description = pathGuideItem.Description;
            this.DirectionType = pathGuideItem.DirectionType;
            this.Distance = pathGuideItem.Distance;
            if (pathGuideItem.Geometry != null)
            {
                this.Geometry = pathGuideItem.Geometry;
            }
            this.Id = pathGuideItem.Id;
            this.Index = pathGuideItem.Index;
            this.IsEdge = pathGuideItem.IsEdge;
            this.IsStop = pathGuideItem.IsStop;
            this.Length = pathGuideItem.Length;
            this.Name = pathGuideItem.Name;
            this.SideType = pathGuideItem.SideType;
            this.TurnAngle = pathGuideItem.TurnAngle;
            this.TurnType = pathGuideItem.TurnType;
            this.Weight = pathGuideItem.Weight;
        }


        /// <summary>
        /// 行驶导引的范围，对弧段而言，为弧段的外接矩形；对点而言，为点本身。
        /// </summary>
        [JsonProperty("bounds")]
        public Rectangle2D Bounds { get; set; }

        /// <summary>
        /// 行驶引导描述。
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 行驶的方向。
        /// </summary>
        [JsonProperty("directionType")]
        public DirectionType DirectionType { get; set; }

        /// <summary>
        /// 站点到弧段的距离。
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// 行驶引导项所对应的地物对象。
        /// </summary>
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        /// <summary>
        /// 行驶导引对象子项的 ID。
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 行驶导引对象子项序号。
        /// </summary>
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        /// 判断本行驶导引子项是否是弧段。
        /// </summary>
        [JsonProperty("isEdge")]
        public bool IsEdge { get; set; }

        /// <summary>
        /// 判断本行驶导引子项是否是站点，即用户输入的用于做路径分析的点， 站点可能与网络结点重合，也可能不在网络上。
        /// </summary>
        [JsonProperty("isStop")]
        public bool IsStop { get; set; }

        /// <summary>
        /// 弧段的长度（行驶导引对象子项为弧段时）。
        /// </summary>
        [JsonProperty("length")]
        public double Length { get; set; }

        /// <summary>
        /// 行驶导引对象子项的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 行驶位置，是在路的左侧、右侧还是在路上。
        /// </summary>
        [JsonProperty("sideType")]
        public SideType SideType { get; set; }

        /// <summary>
        /// 转弯的角度。
        /// </summary>
        [JsonProperty("turnAngle")]
        public double TurnAngle { get; set; }

        /// <summary>
        /// 转弯的方向。
        /// </summary>
        [JsonProperty("turnType")]
        public TurnType TurnType { get; set; }

        /// <summary>
        /// 行驶导引对象子项的权值，即行使导引子项的花费。
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

#if !WINDOWS_PHONE
        #region ISerializable 成员
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bounds", this.Bounds);
            info.AddValue("Description", this.Description);
            info.AddValue("DirectionType", this.DirectionType);
            info.AddValue("Distance", this.Distance);
            info.AddValue("Geometry", this.Geometry);
            info.AddValue("Id", this.Id);
            info.AddValue("Index", this.Index);
            info.AddValue("IsEdge", this.IsEdge);
            info.AddValue("IsStop", this.IsStop);
            info.AddValue("Length", this.Length);
            info.AddValue("Name", this.Name);
            info.AddValue("SideType", this.SideType);
            info.AddValue("TurnAngle", this.TurnAngle);
            info.AddValue("TurnType", this.TurnType);
            info.AddValue("Weight", this.Weight);
        }
        private PathGuideItem(SerializationInfo info, StreamingContext context)
        {
            this.Bounds = (Rectangle2D)info.GetValue("Bounds", typeof(Rectangle2D));
            this.Description = info.GetString("Description");
            this.DirectionType = (DirectionType)info.GetValue("DirectionType", typeof(DirectionType));
            this.Distance = info.GetDouble("Distance");
            this.Geometry = (Geometry)info.GetValue("Geometry", typeof(Geometry));
            this.Id = info.GetInt32("Id");
            this.Index = info.GetInt32("Index");
            this.IsEdge = info.GetBoolean("IsEdge");
            this.IsStop = info.GetBoolean("IsStop");
            this.Length = info.GetDouble("Length");
            this.Name = info.GetString("Name");
            this.SideType = (SideType)info.GetValue("SideType", typeof(SideType));
            this.TurnAngle = info.GetDouble("TurnAngle");
            this.TurnType = (TurnType)info.GetValue("TurnType", typeof(TurnType));
            this.Weight = info.GetDouble("Weight");
        }
        #endregion
#endif
    }
}
